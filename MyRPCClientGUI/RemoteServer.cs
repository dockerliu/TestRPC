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
            /* 单线程方法
            client = new RPCClient();
            client.Connect(new RRQMSocket.ConnectSetting { TargetIP = "127.0.0.1", TargetPort = 7789 });
            client.SerializeConverter = new XmlSerializeConverter();
            loginServer = new LoginServer(client);
            */

            client = new MultipleRPCClient(10,null);
            client.Connect(new RRQMSocket.ConnectSetting { TargetIP = "127.0.0.1", TargetPort = 7789 });
            client.SerializeConverter = new XmlSerializeConverter();
            loginServer = new LoginServer(client);

        }
        /// <summary>
        /// 实例化登陆方法
        /// </summary>
        static LoginServer loginServer;

        //  static RPCClient client;

        /// <summary>
        /// 多线程池
        /// </summary>
        static MultipleRPCClient client;

        

        /// <summary>
        /// 检测是否在线
        /// </summary>
        private static void CheckOnline()
        {
            /*
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
                } */
            client.ConnectionPool.OnClientError += ConnectionPool_OnClientError;//注册事件

            }

        /// <summary>
        /// 错误事件操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ConnectionPool_OnClientError(object sender, RRQMSocket.MesEventArgs e)
        {
          
            //client.ConnectionPool.Replenish();//补充成员
        }
 

        /// <summary>
        /// 检测是否已登陆
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static bool Login(string acc, string pass)
        {
        CheckOnline();
            //return loginServer.Login(new RequestLogin { Account=acc,Password=pass}).Status;

            ResutlLogin resutl;
            loginServer.Login(new RequestLogin() { Account=acc,Password=pass,},out resutl);
            return resutl.Status;
        }
    }
}
