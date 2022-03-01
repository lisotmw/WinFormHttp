using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BackendClient.Code.Support.Enum;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BackendClient.Code.Support.Bean;
using BackendClient.Code.Support.sema;



/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *                                                 *
 *                                                                                 *
 * Author $zho.li$                                                                 *
 *                                                                                 *
 * Time 2022/2/16 23:14:08                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Support.Exec
{
    public class ThreadMgr
    {

        public static void DoHttpReq<T>( 
            Dictionary<string, string> contentData,
            ReqEnums reqMode,
            string url)
        {

            CountDownLatch countDown = new CountDownLatch(1);
            Task0<T> task = new Task0<T>(contentData,url,reqMode, countDown);
            // 最大线程数5，异步io线程最大10
            ThreadPool.SetMaxThreads(5, 10);
            ThreadPool.QueueUserWorkItem((object obj)=> {
                task.SendMsg();
            });

            countDown.Await();
        }
    }

    public class Task0<T> {
        public Dictionary<string, string> HeadData { get; }
        public Dictionary<string, string> ContentData { get; }

        public string Url { get; }
        public ReqEnums ReqMod { get; }

        public CountDownLatch CountDown;

        public Task0(Dictionary<string, string> _contentData, string _url, ReqEnums _reqMod, CountDownLatch _countDown)
        {
            this.ContentData = _contentData;
            this.Url = _url;
            this.ReqMod = _reqMod;
            this.CountDown = _countDown;
        }

        public void SendMsg()
        {
            SemaphoreLicense.getInstance().Acquire();
            CountDown.CountDown();
            string res = "";
            switch (ReqMod)
            {
                case ReqEnums.DO_GET:
                    res = WebClientRequest.GetAsync(Url, ContentData).Result;
                    break;
                case ReqEnums.DO_PUT:
                    res = WebClientRequest.PutAsync(Url, ContentData).Result;
                    break;
                case ReqEnums.DO_DELETE:
                    res = WebClientRequest.DeleteAsync(Url, ContentData).Result;
                    break;
                case ReqEnums.DO_POST:
                    res = WebClientRequest.PostJsonAsync(Url, ContentData).Result;
                    break;
                default:
                    break;
            }
            T resBody = JsonConvert.DeserializeObject<T>(res);
            SemaphoreLicense.getInstance().setData<T>(resBody);
            SemaphoreLicense.getInstance().Release();
        }
    
    }

    /// <summary>
    /// 门栓
    /// </summary>
    public class CountDownLatch
    {
        private object lockObj = new Object();
        private int counter;

        public CountDownLatch(int counter)
        {
            this.counter = counter;
        }

        public void Await()
        {
            lock (lockObj)
            {
                while (counter > 0)
                {
                    Monitor.Wait(lockObj);
                }
            }
        }

        public void CountDown()
        {
            lock (lockObj)
            {
                counter--;
                Monitor.PulseAll(lockObj);
            }
        }
    }

    
}
