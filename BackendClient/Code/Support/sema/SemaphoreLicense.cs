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
 * Time 2022/2/28 16:55:49                                                                     *
 *                                                                                 *
 * Describe 信号量通知许可证                                                *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Support.sema
{
    public class SemaphoreLicense
    {
        private object data;
        private SemaphoreLicense() { }
        private static SemaphoreLicense instance = new SemaphoreLicense();

        public static SemaphoreLicense getInstance()
        {
            return instance;
        }

        private Semaphore semaphore = new Semaphore(1, 1);

        public void Acquire()
        {
            semaphore.WaitOne();
        }

        public void Release()
        {
            semaphore.Release();
        }

        public void setData<T>(T _data)
        {
            this.data = _data;
        }

        public T getData<T>()
        {
            return (T)data;
        }

        public void ClearData()
        {
            data = null;
        }
    }
}
