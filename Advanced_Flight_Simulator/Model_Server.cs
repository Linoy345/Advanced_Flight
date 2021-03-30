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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Advanced_Flight_Simulator 
{
    public static class INFO{
        public static string fileName = "reg_flight.csv";
        public static int speed = 100;
    }
    public class Model_Server : Server
    {
        private bool stop;
        private int frequency;
        
        public bool Stop { get => stop; set => stop = value; }
        public int Frequency { get => frequency; set => frequency = value; }

        public Model_Server() :base()
        {
            Stop = false;
            Frequency = INFO.speed;
        }
        override public void send()
        {
            if (is_connected())
            {
                try
                {
                    using (var reader = new StreamReader(INFO.fileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            line += "\r\n";
                            byte[] messageSent = Encoding.ASCII.GetBytes(line);
                            stream.Write(Encoding.ASCII.GetBytes(line), 0, messageSent.Length);
                            Thread.Sleep(Frequency);
                        }
                    }
                }
                catch (FileNotFoundException not_found) {
                     Console.WriteLine(not_found.ToString());
                }
            }
        }
        public void disconnect()
        {
            stop = true;
            end_Connection();
        }

    }
}
