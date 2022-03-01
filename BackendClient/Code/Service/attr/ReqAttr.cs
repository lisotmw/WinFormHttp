using BackendClient.Code.Support.Enum;
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
 * Time 2022/2/16 13:17:59                                                                     *
 *                                                                                 *
 * Describe $Used to do something$                                                 *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
namespace BackendClient.Code.Service.attr
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ReqAttr : Attribute
    {
        public string UrlPath{set;get;}
        public ReqEnums ReqMode{ set; get; }
        public MsgIdEnums MsgId { set; get; }
    }
}
