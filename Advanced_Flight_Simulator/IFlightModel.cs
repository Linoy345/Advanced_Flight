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

        //int FrameNum { set; get; }

        bool ShouldStop { set; get; }
        int FrameId { set; get; }
        double Direction { get; set; }
        double Yaw { get; set; }
        double Roll { get; set; }
        double Pitch { get; set; }
        double Altitude { get; set; }
        double Speed { get; set;}
        int RowCount { get; set;}

        // activate actuators
        void stopFrame();
        void continueFrame();
        void changeFrame(int frameNum);
    }
}
