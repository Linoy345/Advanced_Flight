using System.Windows.Controls;
using System.Windows.Input;

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
