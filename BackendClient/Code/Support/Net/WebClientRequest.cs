//using Newtonsoft.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BackendClient.Code.Service.config;

namespace BackendClient.Code
{
    public class WebClientRequest
    {
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// 修改header
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void RefreshRequestHeader(string key, string value)
        {
            client.DefaultRequestHeaders.Add(key, value);
        }

        /// <summary>
        /// 异步 get
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static async Task<string> GetAsync(string url, Dictionary<string, string> headerParam, Dictionary<string, string> contentParam)
        {
            url = CheckUrl(url);
            if (headerParam != null && headerParam.Count > 0)
            {
                foreach (KeyValuePair<string, string> kv in headerParam)
                {
                    HttpRequestHeaders hrh = client.DefaultRequestHeaders;
                    hrh.Add(kv.Key, kv.Value);
                }
            }
            string param = "";
            if (contentParam != null && contentParam.Count > 0)
            {
                param += "&";
                param = param + Util.Util.buildHttpParamStr(headerParam);
            }
            return await client.GetStringAsync(url + param);
        }

        /**
         * 异步 get
         * 
         */
        internal static async Task<string> GetAsync(string url, Dictionary<string, string> param)
        {
            url = CheckUrl(url);

            string token = Config.Get("token");

            if (token != null && token != "")
            {
                HttpRequestHeaders hrh = client.DefaultRequestHeaders;
                // remove oldData
                hrh.Remove("Authorization");
                hrh.Add("Authorization", token);
            }
            url = buildHttpParamStr(url, param);
            return await client.GetStringAsync(url);
        }

        /// <summary>
        /// 异步 postJson
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        internal static async Task<string> PostAsync(string url, string token, Dictionary<string, object> param)
        {
            url = CheckUrl(url);

            //FormUrlEncodedContent content = new FormUrlEncodedContent(param);
            if (token != null && token != "")
            {
                HttpRequestHeaders hrh = client.DefaultRequestHeaders;
                // remove oldData
                hrh.Remove("Authorization");
                hrh.Add("Authorization", token);
            }
            string jsonStr = JsonConvert.SerializeObject(param);

            StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();//用来抛异常的

            return await response.Content.ReadAsStringAsync();
        }

        /**
         * 异步 post json
         * 
         * 
         */
        public static async Task<string> PostJsonAsync(string url, Dictionary<string, string> param)
        {
            url = CheckUrl(url);

            //FormUrlEncodedContent content = new FormUrlEncodedContent(param);

            string jsonStr = JsonConvert.SerializeObject(param);

            StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();//用来抛异常的

            return await response.Content.ReadAsStringAsync();
        }

        /**
         * 同步 post json
         * 
         */
        public static async Task<string> PostJsonAsync1(string url, Dictionary<string, string> param)
        {
            url = CheckUrl(url);

            string jsonStr = JsonConvert.SerializeObject(param);

            StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();//用来抛异常的
            Console.WriteLine(response);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> SendRequestAsync(string adaptiveUri, string xmlRequest)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                StringContent httpConent = new StringContent(xmlRequest, Encoding.UTF8);

                HttpResponseMessage responseMessage = null;
                try
                {
                    responseMessage = await httpClient.PostAsync(adaptiveUri, httpConent);
                }
                catch (Exception ex)
                {
                    if (responseMessage == null)
                    {
                        responseMessage = new HttpResponseMessage();
                    }
                    responseMessage.StatusCode = HttpStatusCode.InternalServerError;
                    responseMessage.ReasonPhrase = string.Format("RestHttpClient.SendRequest failed: {0}", ex);
                }
                return responseMessage;
            }
        }

        /// <summary>
        /// SendAsync 异步发送 delete
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        internal static async Task<string> DeleteAsync(string url, Dictionary<string, string> param)
        {
            url = CheckUrl(url);
            string token = Config.Get("token");
            if (token != null && token != "")
            {
                HttpRequestHeaders hrh = client.DefaultRequestHeaders;
                // remove oldData
                hrh.Remove("Authorization");
                hrh.Add("Authorization", token);
            }
            HttpRequestMessage hrm = new HttpRequestMessage(HttpMethod.Delete, url);

            string jsonStr = JsonConvert.SerializeObject(param);
            HttpContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            hrm.Content = content;

            HttpResponseMessage response = await client.SendAsync(hrm);
            response.EnsureSuccessStatusCode();//用来抛异常的

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 接口未通，待测试
        /// </summary>
        /// <param name="url"></param>
        /// <param name="token"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        internal static async Task<string> PutAsync(string url, Dictionary<string, string> param)
        {
            url = CheckUrl(url);

            string token = Config.Get("token");
            //FormUrlEncodedContent content = new FormUrlEncodedContent(param);
            if (token != null && token != "")
            {
                HttpRequestHeaders hrh = client.DefaultRequestHeaders;
                // remove oldData
                hrh.Remove("Authorization");
                hrh.Add("Authorization", token);
            }
            string jsonStr = JsonConvert.SerializeObject(param);

            StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(url, content);
            response.EnsureSuccessStatusCode();//用来抛异常的

            return await response.Content.ReadAsStringAsync();
        }

        private static string CheckUrl(string url)
        {
            if (url.StartsWith("http://"))
                return url;
            else
                return "http://" + url;
        }

        public static string buildHttpParamStr(string url, Dictionary<string, string> dic)
        {
            //q=vs+C%23+代码补全&qs=n&form=QBRE&sp=-1
            string httpParam = "";
            if (dic == null || dic.Count == 0)
            {
                return url;
            }
            if (url.IndexOf("?") < 0)
            {
                url += "?";
            }
            else
            {
                // www.xx.com?a=b
                url += "&";
            }
            foreach (KeyValuePair<string, string> kv in dic)
            {
                httpParam = httpParam + $"{ kv.Key}={kv.Value}&";
            }
            return url + httpParam.Substring(0, httpParam.Length - 1);
        }
    }
}
