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
using System.Windows.Shapes;

namespace Advanced_Flight_Simulator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ContinueWindow : Window
    {

        //private ViewModelPlayBack viewModelPlayBack;
        //FlightViewModel vm;
        public ContinueWindow()
        {
            InitializeComponent(); //call it from mainWindow.

            //vm = new FlightViewModel(new MyFlightModel(new MyTelnetClient()));
            //DataContext = vm;

            int port = 5400;
            string ip = "127.0.0.1";
            //MyTelnetClient mfc = new MyTelnetClient();
            Flight_Info info = new Flight_Info();
            info.init_Flight_Info("reg_flight.csv", "playback_small.xml");
            //mfc.connect(ip, port);


            ////ViewModelPlayBack vMlPlayBack = new ViewModelPlayBack();
            //while (true)
            //{
            //    if (vMlPlayBack.IsRun)
            //    {
            //        mfc.write(info.get_row_string(fram_id));
            //        Thread.Sleep(10);
            //        fram_id++;
            //    }
            //}
            //this.viewModelPlayBack = viewModelPlayBack;

        }

        private void Joistic_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //internal ViewModelPlayBack ViewModelPlayBack { get => viewModelPlayBack; set => viewModelPlayBack = value; }
    }
}