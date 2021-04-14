using System.Windows.Controls;
using System.Windows.Input;

namespace Advanced_Flight_Simulator
{
    /***
    * the class Controls responsible on the view of the playback in the appliction.
    ***/
    public partial class Controls : UserControl
    {
        //FlightViewModel vmm;
        public Controls()
        {
            InitializeComponent();
        }
        /***
         * the function back_MouseLeftButtonUp represent the pressing on the back button in the playback.
         * the program will return 10 sec back.
         ***/
        private void back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            slider.Value -= 10;
        }
        /***
         * the function next_MouseLeftButtonUp represent the pressing on the next button in the playback.
         * the program will junp 10 sec on.
         ***/
        private void next_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            slider.Value += 10;
        }
        /***
         * the function stop_MouseLeftButtonUp represent the pressing on the stop button in the playback.
         * the program will stop.
         ***/
        private void stop_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            slider.Value = 0;
            pauseRadioButton.IsChecked = true;
        }
    }
}
