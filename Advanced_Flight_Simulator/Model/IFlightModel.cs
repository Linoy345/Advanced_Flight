using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Line;

namespace Advanced_Flight_Simulator
{
    /*
    * Interface that represents model.
    */
    public interface IFlightModel : INotifyPropertyChanged
    {
        // connection to the flight
        void connect(string ip, int port);
        void disconnect();
        void start();

        string openFile();

        string openDllAlgo();
        // sensors properties

        //Linoy
        bool ShouldStop { set; get; }
        bool FinishedStart { set; get; }
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
        string Correlated_Attribute { get; set; }
        List<DataPoint> MainGraph { get; set; }
        List<DataPoint> CorrelatedGraph { get; set; }
        List<DataPoint> LinePoints { get; set; }
        List<DataPoint> AttributesGraph { get; set; }
        List<DataPoint> LatestPoints { get; }

        //List<DataPoint> LatestPoints { get; set; }





        string FilePath { get; set; }
        Flight_Info FlightInfo { get; }

        // activate actuators
        void stopFrame();
        void continueFrame();
        void changeFrame(int frameNum);
        string getMostCorraltedFeature();
        Line.Line getLinearReg();

    }
}
