using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackendClient.Code.Util
{
    /// <summary>
    /// 异步网络实现方案一：维护一个阻塞队列和一个守护线程,缺点：守护线程死循环，长期占用系统资源
    /// </summary>
    public class MessageQueue
    {

        private static bool startFlag = false;

        private static  BlockingCollection<Msg> queue = new BlockingCollection<Msg>();

        private static Thread thread = new Thread(new ThreadStart(exec));

        private static void exec()
        {
            while (true)
            {
                Msg msg = queue.Take();
                if(msg != null)
                {
                    // do network operation
                    Thread.Sleep(1500);
                    SendOrPostCallback action = msg.Act;
                    msg.Sc.Send(action, "helloworld!!!!!!!!!!!");
                }
            }
        }

        public static void poll(Msg msg)
        {
            if (!startFlag)
            {
                thread.Start();
                startFlag = true;
            }
            queue.Add(msg);
        }

        public void test()
        {
            poll(new Msg(new SynchronizationContext(), new Dictionary<string, object>() {
                { "username","liz" },
                { "password","123456" }
            }, (res) => {
                Console.WriteLine(res);
            })) ;
        }
    }

    public class Msg
    {
        public SynchronizationContext Sc;
        public Dictionary<string, object> Data;
        public SendOrPostCallback Act;

        public Msg(SynchronizationContext sc,Dictionary<string,object> data, SendOrPostCallback act)
        {
            this.Sc = sc;
            this.Data = data;
            this.Act = act;
        }
    }
}
