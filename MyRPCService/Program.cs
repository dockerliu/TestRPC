using RRQMSocket.RPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 服务端
/// </summary>
namespace MyRPCService
{
    class Program
    {
        static void Main(string[] args)
        {
            RPCService service = new RPCService();
            int serviceCount = service.RegistAllService();
            Console.WriteLine($"成功注册{serviceCount}个服务");

            TcpRPCParser parser = new TcpRPCParser();
            parser.Bind(new RRQMSocket.BindSetting { IP = "127.0.0.1", Port = 7789, MultithreadThreadCount = 1 });
            parser.SerializeConverter = new XmlSerializeConverter();
            service.AddRPCParser("TcpParser", parser);
            RPCServerSetting setting = new RPCServerSetting();
            setting.NameSpace = "MyTestRPC";
            setting.ProxySourceCodeVisible = true;
            setting.ProxyToken = "abc123";
            //setting.Version = new Version(1, 0, 0, 0);
            service.OpenRPCServer(setting,new RRQMSocket.Plugin.RPC.RPCCompiler());
            

            Console.WriteLine("服务器启动成功！");

            Console.ReadKey();
        }
    }
}
