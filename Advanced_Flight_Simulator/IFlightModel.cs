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

        int RowCount { get; }

        // activate actuators
        void stopFrame();
        void continueFrame();
        void changeFrame(int frameNum);
    }
}
