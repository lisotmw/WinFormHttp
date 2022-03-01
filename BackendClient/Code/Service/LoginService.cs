using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendClient.Code.Service.attr;
using BackendClient.Code.Service.abs;
using BackendClient.Code.Support.Enum;
using System.Reflection;
using System.Threading;

namespace BackendClient.Code
{
    public class LoginService
    {
        //{"code":0,"message":"success","data":{"token":"Bearer e86585728b914771b793f1fb05e49676","ref":"ae213e3e-baa6-4379-928a-5f3692e0ffd6"}}
        [ReqAttr(UrlPath = "/user/login", ReqMode = ReqEnums.DO_POST, MsgId = MsgIdEnums.REQ_LOGIN)]
        public async Task<string> RequsetLoginAsync(string serverAddress, string userName, string password)
        {
            serverAddress = buildUrl(serverAddress, "/user/login");
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", userName);
            dic.Add("password", password);

            // TODO liz
            //string response = await WebClientRequest.PostAsync(serverAddress, dic);

            string response = await WebClientRequest.PostJsonAsync1(serverAddress, dic);
            return response;
        }


        [ReqAttr(UrlPath = "/user/login", ReqMode = ReqEnums.DO_POST, MsgId = MsgIdEnums.REQ_LOGIN)]
        public void RequestLoginDelegate<T>(string userName, string password, SendOrPostCallback action)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("username", userName);
            dic.Add("password", password);
            var attr = typeof(LoginService).GetMethod("RequestLoginDelegate").GetCustomAttribute<ReqAttr>();
            // 网络请求唯一接口
            HttpDelegate.getInstance().DoRequest<T>(dic, attr, action);
        }

        private string buildUrl(string serverAddress, string path)
        {
            serverAddress = serverAddress + path;
            return serverAddress;
        }
    }
}
