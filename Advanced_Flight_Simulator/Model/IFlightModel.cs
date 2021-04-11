using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    public interface IFlightModel : INotifyPropertyChanged
    {
        // connection to the flight
        void connect(string ip, int port);
        void disconnect();
        void start();
        
        string openFile();
        // sensors properties

        //Linoy
        bool ShouldStop { set; get; }
        bool FinishedStart {set; get;}
        int FrameId { set; get; }
        double Rudder { set; get; }
        double Throttle { set; get; }
        double Aileron { set; get; }
        double Elevator { set; get; }
        double X { set; get; }
        double Y { set; get; }

        void init();

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
        string getValue(int frame, string attributeName);
        int RowCount { get; }
        List<string> AttributesNames { get; }
        string GraphAttribute { set; get; }
        List<DataPoint> GraphPoints { get; }
        string FilePath { get; set; }

        // activate actuators
        void stopFrame();
        void continueFrame();
        void changeFrame(int frameNum);
        string getMostCorraltedFeature();

    }
}
