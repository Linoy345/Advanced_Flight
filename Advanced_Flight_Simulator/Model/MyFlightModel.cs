using Microsoft.Win32;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    public class MyFlightModel : IFlightModel
    {
        private Flight_Info info;
        private IClient client;
        private CorrelatedDll correlatedDll;


        volatile private bool shouldStop;
        volatile private int frameId;
        volatile private bool finishedStart; // Prevent from oppening multiple thread in start.
        volatile private string filePath;

        volatile private List<string> attributeNames;
        volatile private List<DataPoint> graphPoints;
        volatile private string graphAttribute;

        private double throttle;
        private double rudder;
        private double aileron;
        private double elevator;
        private double x;
        private double y;

        private double frequency;
        private double yaw;
        private double roll;
        private double pitch;
        private double direction;
        private double altitude;
        private double speed;

        public event PropertyChangedEventHandler PropertyChanged;

        public MyFlightModel(IClient client)
        {
            FrameId = 0;
            Frequency = 1;
            info = new Flight_Info();
            this.client = client;
            attributeNames = new List<string>();
            graphPoints = new List<DataPoint>();
            FinishedStart = true;
            ShouldStop = false;
            x = 0;
            y = 0;
        }

        public bool ShouldStop
        {
            get { return shouldStop; }
            set
            {
                shouldStop = value;
                NotifyPropertyChanged("ShouldStop");
            }
        }
        public bool FinishedStart
        {
            get { return finishedStart; }
            set
            {
                finishedStart = value;
                NotifyPropertyChanged("FinishedStart");
            }
        }
        public double Direction
        {
            get {
                return direction; }
            set
            {
                direction = value;
                NotifyPropertyChanged("Direction");
            }
        }

        public double Yaw
        {
            get { return yaw; }
            set
            {
                yaw = value;
                NotifyPropertyChanged("Yaw");
            }
        }
        public double Roll
        {
            get { return roll; }
          
            set 
            {
                roll = value;
                NotifyPropertyChanged("Roll");
            }

        }
        public double Pitch
        {
            get { return pitch; }
            set
            {
                pitch = value;
                NotifyPropertyChanged("Pitch");
            }
        }
        public double Altitude
        {
            get { return altitude; }
            set
            {
                altitude = value;
                NotifyPropertyChanged("Altitude");
            }
        }
        public double Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                NotifyPropertyChanged("Speed");
            }
        }
        public void RefreshIndices()
        {
            Speed = Convert.ToDouble(info.get_value(FrameId, "airspeed-kt"));
            Altitude = Convert.ToDouble(info.get_value(FrameId, "altitude-ft"));
            Pitch = Convert.ToDouble(info.get_value(FrameId, "pitch-deg"));
            Roll = Convert.ToDouble(info.get_value(FrameId, "roll-deg"));
            Yaw = Convert.ToDouble(info.get_value(FrameId, "side-slip-deg"));
            Direction = Convert.ToDouble(info.get_value(FrameId, "heading-deg"));
        }
        public int FrameId
        {
            get {
                return frameId; }
            set
            {
                frameId = value;
                NotifyPropertyChanged("FrameId");
            }
        }

        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                NotifyPropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                NotifyPropertyChanged("Y");
            }
        }
        
        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                if (value >= -1 && value <= 1)
                {
                    rudder = value;
                    NotifyPropertyChanged("Rudder");
                }
            }
        }
        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                if(value >= 0 && value <= 1)
                {
                    throttle = value;
                    NotifyPropertyChanged("Throttle");
                }
                
            }
        }

        public void updateJoistick()
        {
            Rudder = Convert.ToDouble(info.get_value(FrameId, "rudder"));
            Throttle = Convert.ToDouble(info.get_value(FrameId, "throttle"));
            Aileron = Convert.ToDouble(info.get_value(FrameId, "aileron"));
            Elevator = Convert.ToDouble(info.get_value(FrameId, "elevator"));
            X = (Aileron * 90);
            Y = (Elevator * 90);
        }
        public double Frequency
        {
            get { return frequency; }
            set
            {
                frequency = 100 / value;
                NotifyPropertyChanged("Frequency");
            }
        }

        public int RowCount
        {
            get { return info.row_count(); }
        }


        public void changeFrame(int id)
        {
            FrameId = id;
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }


        public void stopFrame()
        {
            ShouldStop = true;
        }

        public void continueFrame()
        {
            ShouldStop = false;
        }

        public void connect(string ip, int port)
        {
            client.connect(ip, port);
        }

        public void disconnect()
        {
            client.disconnect();
            stopFrame();
            FrameId = 0;
        }
        
        public void sendFrame()
        {
            if (!ShouldStop)
            {
                client.write(info.get_row_string(FrameId));
                RefreshIndices();
                updateJoistick();
                FrameId++;
            }
        }

        public int attributeCount()
        {
            return info.attribute_count();
        }
        public void init()
        {
            if (FilePath != string.Empty)
            {
                info.init_Flight_Info(FilePath);
                AttributesNames = info.get_attribute_names();
                correlatedDll = new CorrelatedDll(FilePath);
                NotifyPropertyChanged(string.Empty);
                NotifyPropertyChanged("AttributesNames");
                NotifyPropertyChanged("RowCount");

            }

        }
            
        public void start()
        {
            if (FinishedStart)
            {
                new Thread(delegate ()
                {
                    FinishedStart = false;
                    while (frameId < info.row_count())
                    { 
                        GraphPoints = UpdateGraphPoint();
                        sendFrame();
                        //for check
                        /*string s = getMostCorraltedFeature();
                        Console.WriteLine("pearon - {0}", s);

                        Line.Line l = getLinearReg();
                        Console.WriteLine("a - {0}", l.a);
                        Console.WriteLine("b - {0}", l.b);
                        */
                        // the same for the other sensors properties
                        Thread.Sleep((int)Frequency);// read the data in 4Hz
                    }
                    FinishedStart = true;
                }).Start();
            }
        }

        //Yair addition:
        private List<DataPoint> UpdateGraphPoint()
        {
            List<DataPoint> currentList = new List<DataPoint>();
            for (int frame = 0; frame < frameId; frame++)
            {
                currentList.Add(new DataPoint(frame, Double.Parse(info.get_value(frame, graphAttribute))));
            }
            return currentList;
        }
        public List<DataPoint> GraphPoints
        {
            get
            {
                return graphPoints;
            }
            set
            {
                graphPoints = value;
                NotifyPropertyChanged("GraphPoints");
            }
        }
        public List<string> AttributesNames
        {
            get
            {
                return attributeNames;
            }
            set
            {
                attributeNames = value;
            }
        }
        public string GraphAttribute
        {
            get
            {
                return graphAttribute;
            }
            set
            {
                graphAttribute = value;
                NotifyPropertyChanged("GraphAttribute");
            }
        }

        public string getValue(int row, string attribueName)
        {
            return info.get_value(row, attribueName);
        }
        public string openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {   //(csv_path, xml_path);
                FilePath = openFileDialog.FileName;
            }
            else
            {
                FilePath = String.Empty;
            }
            return FilePath;
        }
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {   
                this.filePath = value;
                NotifyPropertyChanged("FilePath");
            }
        }

        //CALL FIRST TO getMostCorraltedFeature AND THEN TO getLinearReg
        public string getMostCorraltedFeature() //graph for yair
        {
            //what to do with index -1?
            return this.correlatedDll.getPearsonFeature(info.getIndex(GraphAttribute));
            //yair will use : info.getAttributeFromIndex(index);
        }

        public Line.Line getLinearReg() //graph for yair
        {
            return this.correlatedDll.getLine(info.getIndex(GraphAttribute));
        }
    }
}
