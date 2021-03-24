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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender1, RoutedEventArgs e)
        {

            try
            {
                string server = "127.0.0.1";
                Socket soc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                System.Net.IPAddress ipAdd = System.Net.IPAddress.Parse(server);
                System.Net.IPEndPoint remoteEP = new IPEndPoint(ipAdd, 5400);
                soc.Connect(remoteEP);

                try
                {

                 

                    // We print EndPoint information 
                    // that we are connected
                    Console.WriteLine("Socket connected to");

                    string fileName = "reg_flight.csv";
                    using (var reader = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Creation of messagge that
                            // we will send to Server
                            line += "\r\n";
                            byte[] messageSent = Encoding.ASCII.GetBytes(line);
                            int byteSent = soc.Send(messageSent);
                            Console.WriteLine(line);
                            Thread.Sleep(100);
                        }
                    }



                    // Data buffer
                    byte[] messageReceived = new byte[1024];

                    // We receive the messagge using 
                    // the method Receive(). This 
                    // method returns number of bytes
                    // received, that we'll use to 
                    // convert them to string
                    int byteRecv = soc.Receive(messageReceived);
                    Console.WriteLine("Message from Server -> {0}",
                          Encoding.ASCII.GetString(messageReceived,
                                                     0, byteRecv));

                    // Close Socket using 
                    // the method Close()
                    soc.Shutdown(SocketShutdown.Both);
                    soc.Close();
                }

                // Manage of Socket's Exceptions
                catch (ArgumentNullException ane)
                {

                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }

                catch (SocketException se)
                {

                    Console.WriteLine("SocketException : {0}", se.ToString());
                }

                catch (Exception e2)
                {
                    Console.WriteLine("Unexpected exception : {0}", e2.ToString());
                }
            }

            catch (Exception e1)
            {

                Console.WriteLine(e1.ToString());
            }
        }

    }
}
