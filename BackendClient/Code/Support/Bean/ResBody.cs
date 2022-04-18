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
 * Time 2022/2/17 10:21:30                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Support.Bean
{
    // eg:"{\"code\":0,\"message\":\"success\",\"data\":{\"nickname\":\"hahaha\",\"avatar\":null,\"permissions\":[\"DASH_BOARD\"]}}"
    public class ResBody
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }

        public override string ToString()
        {
            return "code: " + Code + ", message: " + Message + ", data: " + Data.ToString();
        }
    }
}
