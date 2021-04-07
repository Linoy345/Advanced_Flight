﻿using System;
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
using Microsoft.Win32;


namespace Advanced_Flight_Simulator
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class DisplayWindow : Window
    {
        FlightViewModel vm;
        public DisplayWindow()
        {
            InitializeComponent(); //call it from mainWindow.
            int port = 5400;
            string ip = "127.0.0.1";
            vm = new FlightViewModel(new MyFlightModel(new Model_Flight_Client(ip, port)));

            DataContext = vm;
        }



        private void Joistic_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Disconnect(object sender, RoutedEventArgs e)
        {
            vm.VM_Disconnect();
        }



        private void Button_Click_Connect(object sender, RoutedEventArgs e)
        {
            vm.VM_Start();
        }

        private void Controls_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click_OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {   //(csv_path, xml_path);
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName);
                //vm.VM_init("reg_flight.csv", "playback_small.xml");
            }
        }


    }
}
