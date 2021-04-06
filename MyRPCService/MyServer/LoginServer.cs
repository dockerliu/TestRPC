using RRQMSocket.RPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPCService.MyServer
{
    public class LoginServer:ServerProvider
    {
        [RRQMRPCMethod]
        public bool Login(string account, string password)
        {
            if (account=="123" &&password=="abc")
            {
                return true;
            }
            return false;
        }
    }
}
