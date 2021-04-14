using System;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace Advanced_Flight_Simulator
{
    /*
    * Class that represents a client.
    */
    public class Model_Flight_Client : IClient
    {
        protected TcpClient client;
        protected NetworkStream stream;
        /*
        * Constructor - initialize client.
        */
        public Model_Flight_Client()
        {
            client = new TcpClient();
        }
        /*
        * Constructor - initialize client with given ip and port.
        */
        public Model_Flight_Client(string ip, int port)
        {
            client = new TcpClient();
            client.Connect(ip, port);
            stream = client.GetStream();
        }
        /*
        * Checks if client connected to server.
        */
        private bool is_connected()
        {
            if (client == null || client.Client == null) { return false; }
            return client.Connected;
        }
        /*
        * Connect to the server.
        */
        public void connect(string ip, int port)
        {
            if (!is_connected())
            {
                client.Connect(ip, port);
                stream = client.GetStream();
            }
        }
        /*
        * If connection has been established- Send to Server the given Line.
        */
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
        /*
        * Read one line or 512 bytes.
        */
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
        /*
        * Disconnect from the server.
        */
        public void disconnect()
        {
            if (stream != null)
            {
                stream.Close();
            }
            client.Close();
        }
    }
}