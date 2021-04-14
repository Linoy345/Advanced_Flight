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
    /***
     * the class DisplayWindow inherit from the class Window.
     * in this window will shown the the window after the main window. all the display of our application 
     * will be here. the class contain members of FlightViewModel and GraphViewModel.
     ***/
    public partial class DisplayWindow : Window
    {
        private FlightViewModel vm;
        private GraphViewModel graph_vm;
        private IFlightModel model;

        /***
         * constractor of DisplayWindow that get ip and port to start connection.
         ***/
        public DisplayWindow(string ip, string port)
        {
            Model_Flight_Client client = new Model_Flight_Client(ip, Int32.Parse(port));
            initDisplay(client);
        }
        /***
         * empty constractor of DisplayWindow.
         ***/
        public DisplayWindow()
        {
            InitializeComponent(); //call it from mainWindow.
            initDisplay(new Model_Flight_Client());
        }
        /***
         * the function initDisplay initiiliaze the DisplayWindow.
         ***/
        private void initDisplay(Model_Flight_Client client)
        {
            model = new MyFlightModel(client);
            InitializeComponent(); //call it from mainWindow.
                                   //int port = 5400;
                                   //string ip = "127.0.0.1";
            
            vm = new FlightViewModel(model);
            graph_vm = new GraphViewModel(model);
            this.controls.DataContext = vm;
            this.indices.DataContext = vm;
            this.joystick.DataContext = vm;
            this.graph.DataContext = graph_vm;
        }
        /***
         * the function Button_Click_Disconnect represent the pressing on the disconnect button and stop the run.
         ***/
        private void Button_Click_Disconnect(object sender, RoutedEventArgs e)
        {
            vm.VM_Disconnect();
            this.Close();
        }
        /***
         * the function Button_Click_Start represent the pressing on the Start button and start the run.
         ***/
        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            vm.VM_Start();
            openDllDlgo.IsEnabled = true;
        }
        /***
         * the function Button_Click_OpenFile represent the pressing on the open button.
         * the user will need to choose the file that he want to load and open.
         ***/
        private void Button_Click_OpenFile(object sender, RoutedEventArgs e)
        {
            try
            {
                vm.VM_openFile();
                vm.VM_init();
            }
            catch (Exception)
            {
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show("File is not Valid", "Remainder - FlightGear", MessageBoxButton.OK, icon);
            }
        }
        private void Graph_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_OpenDllAlgo(object sender, RoutedEventArgs e)
        {
            vm.VM_openDllAlgo();
        }
    }
}
