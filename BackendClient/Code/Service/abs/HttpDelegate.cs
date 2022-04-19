using BackendClient.Code.Log;
using BackendClient.Code.Service.attr;
using BackendClient.Code.Support.Enum;
using BackendClient.Code.Support.Exec;
using BackendClient.Code.Support.sema;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *                                                 *
 *                                                                                 *
 * Author $zho.li$                                                                 *
 *                                                                                 *
 * Time 2022/2/16 21:44:27                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Service.abs
{
    public class HttpDelegate
    {
        private static HttpDelegate instance = new HttpDelegate();
        private HttpDelegate() { }

        public static HttpDelegate getInstance() {
            return instance;
        }
        /**
         * 处理 http 请求通用入口
         * @contentParam            http content 信息
         * @reqAttr                 每个请求方法上的 attributes，@see BackendClient.Code.Service.attr.ReqAttr
         * @action                  回调函数
         */
        public void DoRequest<T>(
            Dictionary<string, string> contentParam,
            ReqAttr reqAttr,
            SendOrPostCallback action
            )
        {
            if(reqAttr == null)
            {
                return;
            }
            MsgIdEnums msgId = reqAttr.MsgId;
            ReqEnums reqMode= reqAttr.ReqMode;
            string urlPath = reqAttr.UrlPath;
            string serverIp = config.Config.ServerIp;

            string url = buildUrl(serverIp, urlPath);

            ThreadMgr.DoHttpReq<T>(contentParam, reqMode, url);

            // 用于线程间同步
            var sc = SynchronizationContext.Current;

            ThreadPool.SetMaxThreads(1, 1);
            ThreadPool.QueueUserWorkItem((object obj)=> {
                SemaphoreLicense.getInstance().Acquire();
                T res = SemaphoreLicense.getInstance().getData<T>();
                sc.Send(action, res);
                SemaphoreLicense.getInstance().ClearData();
                SemaphoreLicense.getInstance().Release();
            });
        }

        private string buildUrl(string host,string urlPath)
        {
            string url = host + urlPath;
            if (url.StartsWith("http://"))
                return url;
            else
                return "http://" + url;
        }
    }
}
