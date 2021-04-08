using System;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace Advanced_Flight_Simulator
{
    public class Model_Flight_Client : IClient
    {
        protected TcpClient client;
        protected NetworkStream stream;
        public Model_Flight_Client()
        {
            client = new TcpClient();
        }
        public Model_Flight_Client(string ip, int port)
        {
            client = new TcpClient();
            client.Connect(ip, port);
            stream = client.GetStream();
        }
        private bool is_connected()
        {
            if(client == null) { return false; }
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
        public void write(string line)
        {
            if (is_connected())
            {
                try
                {
                    byte[] message = Encoding.ASCII.GetBytes(line);
                    stream.Write(message, 0, message.Length);
                }
                catch (FileNotFoundException not_found)
                {
                    Console.WriteLine(not_found.ToString());
                }
            }
        }
        public string read() // Todo: need testing.
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
        public void disconnect()
        {
            client.Close();
        }
    }
}