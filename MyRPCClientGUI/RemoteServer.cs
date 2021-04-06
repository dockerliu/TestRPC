using RRQMRPC.MyTestRPC;
using RRQMSocket.RPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRPCClientGUI
{
    public class RemoteServer
    {
        static RemoteServer()
        {
            client = new RPCClient();
            client.Connect(new RRQMSocket.ConnectSetting { TargetIP = "127.0.0.1", TargetPort = 7789 });
            client.SerializeConverter = new XmlSerializeConverter();
            loginServer = new LoginServer(client);
        }
        static LoginServer loginServer;
        static RPCClient client;

        /// <summary>
        /// 检测是否在线
        /// </summary>
        private void CheckOnline()
        {
            if (!client.Online)
            {
                client.Dispose();
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        client = new RPCClient();
                        client.Connect(new RRQMSocket.ConnectSetting { TargetIP = "127.0.0.1", TargetPort = 7789 });
                        client.SerializeConverter = new XmlSerializeConverter();
                        loginServer = new LoginServer(client);
                        return;

                    }
                    catch (Exception)
                    {

                    }
                    throw new Exception("重试连接次数超过限制！");
                }
            }

        }
        public static bool Login(string acc, string pass)
        {
            
            return loginServer.Login(acc, pass);
        }
    }
}
