using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
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
    public partial class DisplayWindow : Window
    {
        private FlightViewModel vm;
        private GraphViewModel graph_vm;
        public DisplayWindow(string ip, string port)
        {
            Model_Flight_Client client = new Model_Flight_Client(ip, Int32.Parse(port));
            initDisplay(client);
        }
        public DisplayWindow()
        {
            InitializeComponent(); //call it from mainWindow.
            initDisplay(new Model_Flight_Client());
        }
        private void initDisplay(Model_Flight_Client client)
        {
            IFlightModel model = new MyFlightModel(client);
            InitializeComponent(); //call it from mainWindow.
                                   //int port = 5400;
                                   //string ip = "127.0.0.1";
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show("Please open the FlightGear application", "Remainder - FlightGear", MessageBoxButton.OK, icon);

            vm = new FlightViewModel(model);
            graph_vm = new GraphViewModel(model);
            this.controls.DataContext = vm;
            this.indices.DataContext = vm;
            this.joystick.DataContext = vm;
            this.graph.DataContext = graph_vm;
        }

        private void Button_Click_Disconnect(object sender, RoutedEventArgs e)
        {
            vm.VM_Disconnect();
            this.Close();
        }
        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            try
            {
                vm.VM_init();
                vm.VM_Start();
            }
            catch (Exception)
            {
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBox.Show("File is not Valid", "Remainder - FlightGear", MessageBoxButton.OK, icon);
            }
        }

        private void Button_Click_OpenFile(object sender, RoutedEventArgs e)
        {
            vm.VM_openFile();
        }
    }
}
