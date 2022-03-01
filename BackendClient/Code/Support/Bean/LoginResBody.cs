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
 * Time 2022/2/17 10:21:30                                                         *
 *                                                                                 *
 * Describe $根据后端返回数据格式，定义不同数据体$                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Support.Bean
{
    // 返回数据：{"code":0,"message":"success","data":{"token":"Bearer e86585728b914771b793f1fb05e49676","ref0":"ae213e3e-baa6-4379-928a-5f3692e0ffd6"}}
    public class LoginResBody
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public LoginResData Data { get; set; }

        public class LoginResData
        {
            public string token { get; set; }

            public string ref0 { get; set; }
        }

        public override string ToString()
        {
            return "code: " + Code + ", message: " + Message + ", data: " + Data.ToString();
        }
    }
}
