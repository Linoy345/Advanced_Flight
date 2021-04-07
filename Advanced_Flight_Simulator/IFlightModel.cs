using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    interface IFlightModel : INotifyPropertyChanged
    {
        // connection to the robot
        void connect(string ip, int port);
        void disconnect();
        void start();
        // sensors properties

        //Linoy
        bool ShouldStop { set; get; }
        int FrameId { set; get; }
        double Rudder { set; get; }
        double Throttle { set; get; }
        double Aileron { set; get; }
        double Elevator { set; get; }
        double X { set; get; }
        double Y { set; get; }

        //Orad
        double Direction { get; set; }
        double Yaw { get; set; }
        double Roll { get; set; }
        double Pitch { get; set; }
        double Altitude { get; set; }
        double Speed { get; set; }

        //Adam
        double Frequency { set; get; }

        //Yair
        int RowCount { get; }


        // activate actuators
        void stopFrame();
        void continueFrame();
        void changeFrame(int frameNum);
    }
}
