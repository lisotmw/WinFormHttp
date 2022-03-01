using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *                                                 *
 *                                                                                 *
 * Author $zho.li$                                                                 *
 *                                                                                 *
 * Time 2022/2/15 22:23:53                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Util
{
    public class user
    {
        public string password;//密码hash
        public string account;//账户


        public static async void TaskAsync()
        {


            using (var client = new HttpClient())
            {

                try
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("username", "admin");
                    dic.Add("password", "123456");
                    
                    var str = JsonConvert.SerializeObject(dic);

                    HttpContent content = new StringContent(str);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response = await client.PostAsync("http://192.168.101.135:8990/user/login", content);//改成自己的
                    response.EnsureSuccessStatusCode();//用来抛异常的
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseBody);
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }
        }
        
    }



}
