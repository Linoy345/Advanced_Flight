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
    /// Interaction logic for controls.xaml
    /// </summary>
    public partial class Controls : UserControl
    {
        //FlightViewModel vmm;
        public Controls()
        {
            InitializeComponent();
            //vm = new FlightBoardViewModel();
            //DataContext = vm;
        }


        private void back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            slider.Value -= 10;
        }

        private void next_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            slider.Value += 10;
        }

        private void stop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            slider.Value = 0;
            pauseRadioButton.IsChecked = true;

        }

        
    }
}
