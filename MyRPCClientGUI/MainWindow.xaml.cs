using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RRQMRPC.MyTestRPC;
using RRQMSocket;
using RRQMSocket.RPC;

namespace MyRPCClientGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* 第一种方法
            RPCClient client = new RPCClient();

            client.Connect(new ConnectSetting { TargetIP="127.0.0.1",TargetPort=7789});
            client.SerializeConverter = new XmlSerializeConverter();

            LoginServer loginServer = new LoginServer(client);

            bool isLogin= loginServer.Login(this.Tb_Account.Text, this.Tb_Password.Text);
            MessageBox.Show(isLogin.ToString());
            */

            //第二种方法
            bool isLogin = RemoteServer.Login(this.Tb_Account.Text, this.Tb_Password.Text);
            MessageBox.Show(isLogin.ToString());

        }

        private static void Login()
        {
            RPCClient client = new RPCClient();
            client.SerializeConverter = new XmlSerializeConverter();
            ConnectSetting confirmSocket = new ConnectSetting();
            confirmSocket.TargetIP = "127.0.0.1";
            confirmSocket.TargetPort = 7789;

            client.Connect(confirmSocket);
            client.InitializedRPC();
            MessageBox.Show("Xml连接成功");
            
        }
    }
}
