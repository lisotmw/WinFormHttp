using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *                                                 *
 *                                                                                 *
 * Author $zho.li$                                                                 *
 *                                                                                 *
 * Time 2022/2/16 11:03:06                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Util
{
    public class HttpUtil
    {

        public static string Get(string Url)
        {
            //System.GC.Collect();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Proxy = null;
            request.KeepAlive = false;
            request.Method = "GET";
            request.ContentType = "application/json; charset=UTF-8";
            request.AutomaticDecompression = DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }

            return retString;
        }

        public static string Post(string Url, string Data, string Referer)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.Referer = Referer;
            byte[] bytes = Encoding.UTF8.GetBytes(Data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = bytes.Length;
            Stream myResponseStream = request.GetRequestStream();
            myResponseStream.Write(bytes, 0, bytes.Length);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();

            myStreamReader.Close();
            myResponseStream.Close();

            if (response != null)
            {
                response.Close();
            }
            if (request != null)
            {
                request.Abort();
            }
            return retString;
        }

        public static string HttpPostJson(string url, string postStr, int timeOut, string charset)
        {
            HttpWebRequest wreq = null;
            HttpWebResponse res = null;
            string strRst = "";

            #region http web request

            Encoding ecd = Encoding.GetEncoding(charset);

            byte[] data = ecd.GetBytes(postStr);
            wreq = (HttpWebRequest)WebRequest.Create(url);
            wreq.Timeout = timeOut * 1000;
            wreq.ReadWriteTimeout = timeOut * 1000;
            wreq.Method = "POST";
            wreq.KeepAlive = false;
            wreq.ContentType = "application/json;charset=utf-8";
            wreq.ServicePoint.Expect100Continue = false; //当服务器恢复正常时，访问已经是200时，这个线程还是返回操作超时

            wreq.ContentLength = data.Length;
            using (Stream putStream = wreq.GetRequestStream())
            {
                putStream.Write(data, 0, data.Length);
            }
            res = wreq.GetResponse() as HttpWebResponse;
            byte[] by = new byte[800];
            using (Stream stream = res.GetResponseStream())
            {
                int size = 1024;
                int read = 0;
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[size];
                    do
                    {
                        read = stream.Read(buffer, 0, size);
                        ms.Write(buffer, 0, read);
                    } while (read > 0);

                    by = ms.ToArray();
                }
            }

            strRst = ecd.GetString(by);

            if (res != null)
                res.Close();
            if (wreq != null)
                wreq.Abort();//主动释放

            #endregion

            return strRst;
        }
    }
}
