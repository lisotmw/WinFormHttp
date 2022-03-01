using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *                                                 *
 *                                                                                 *
 * Author $zho.li$                                                                 *
 *                                                                                 *
 * Time 2022/2/15 20:54:07                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Util
{
    class Util
    {
       public static string buildHttpParamStr(Dictionary<string, string> dic)
        {
            //q=vs+C%23+代码补全&qs=n&form=QBRE&sp=-1
            string httpParam = "";
            if(dic == null || dic.Count == 0)
            {
                return httpParam;
            }
            foreach(KeyValuePair<string, string> kv in dic)
            {
                httpParam = httpParam + kv.Key + "=" + kv.Value + "&";
            }
            return httpParam.Substring(0, httpParam.Length - 1);
        }
    }
}
