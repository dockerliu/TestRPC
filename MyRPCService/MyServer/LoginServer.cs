using MyRPCService.ArgsClass;
using RRQMSocket.RPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPCService.MyServer
{
    public class LoginServer : ServerProvider
    {

        /*
        /// <summary>
        /// 禁用方法
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="methodItem"></param>
        protected override void RPCEnter(IRPCParser parser, MethodItem methodItem)
        {
            if (methodItem.Method == "Login")
            {

                throw new RRQMAbandonRPCException("就不让你调用！");
            }
        } 
        */

        [RRQMRPCMethod(async: false)]
        /*
        public bool Login(string account, string password)
        {
            if (account == "123" && password == "abc")
            {
                return true;
            }
            return false;
        }
        */

        public ResutlLogin Login (RequestLogin request)
        {
            ResutlLogin resutl = new ResutlLogin();
            if (request==null)
            {
                return resutl.Message="";
            }
            return;
        }
    }
}
