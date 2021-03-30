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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace Advanced_Flight_Simulator
{
    public abstract class Server
    {
        protected TcpClient client;
        protected NetworkStream stream;
        public Server()
        {
            client = new TcpClient();
        }
        public bool is_connected()
        {
            return client.Connected;
        }
        public void connect(string ip, int port)
        {
            if (!is_connected())
            {
                client.Connect(ip, port);
                stream = client.GetStream();
            }
        }
        public abstract void send();
        public string Read()
        {
            if (is_connected())
            {
                char[] data = new char[512];
                BinaryReader reader = new BinaryReader(stream);
                char currentC = ' ';
                int i;
                for (i = 0; i < data.Length && currentC != '\n'; i++) // Read one char each iteration.
                {
                    currentC = reader.ReadChar();
                    data[i] = currentC;
                }
                return new string(data);
            }
            else
            {
                return string.Empty;
            }
        }
        protected void end_Connection()
        {
            client.Close();
        }

    }
}
