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
 * Time 2022/2/17 10:16:52                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Support.Enum
{
    public enum ReqEnums
    {
        DO_GET,
        DO_POST,
        DO_PUT,
        DO_DELETE
    }

    public enum MsgIdEnums
    {
        REQ_LOGIN,
        GET_USERINFO
    }
}
