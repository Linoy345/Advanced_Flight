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

        volatile private bool showCorrelationGraphs;
        volatile private bool shouldStop;
        volatile private int frameId;
        volatile private bool finishedStart; // Prevent from oppening multiple thread in start.
        volatile private string filePath;

        volatile private List<string> attributeNames;
        volatile private List<DataPoint> linePoints;
        volatile private List<DataPoint> mainGraph;
        volatile private List<DataPoint> correlated_Graph;
        volatile private List<DataPoint> attributesGraph;
        volatile private List<DataPoint> latestPoints;

        volatile private string graphAttribute;
        volatile private string correlated_Attribute;


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
            AttributesNames = new List<string>();
            MainGraph = new List<DataPoint>();
            LinePoints = new List<DataPoint>();
            LatestPoints = new List<DataPoint>();
            CorrelatedGraph = new List<DataPoint>();
            FinishedStart = true;
            ShouldStop = false;
            showCorrelationGraphs = false;
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
            get
            {
                return direction;
            }
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
            get
            {
                return frameId;
            }
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
                if (value >= 0 && value <= 1)
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
            if (!ShouldStop && FrameId < RowCount)
            {
                client.write(info.get_row_string(FrameId));
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
                //correlatedDll = new CorrelatedDll(FilePath);
                NotifyPropertyChanged(string.Empty);
                NotifyPropertyChanged("AttributesNames");
                NotifyPropertyChanged("RowCount");

            }

        }
        private void updateLineGraph()
        {
            LinePoints = generateLinePoints();
            AttributesGraph = generateGraphAttributes();
        }
        private List<DataPoint> generateLatestsPoints()
        {
            float x, y;
            int frame = 0;
            List<DataPoint> pointsList = new List<DataPoint>();
            if(FrameId > 300)
            {
                frame = frameId - 300;
            }
                for(; frame < FrameId; frame++)
                {
                    x = float.Parse(info.get_value(frame, GraphAttribute));
                    y = float.Parse(info.get_value(frame, Correlated_Attribute));
                    pointsList.Add(new DataPoint(x, y));
                }
            return pointsList;
        }
        private List<DataPoint> generateGraphAttributes()
        {
            double x, y;
            List<DataPoint> pointsList = new List<DataPoint>();
            for (int row = 0; row < RowCount; row++)
            {
                x = Double.Parse(info.get_value(row, GraphAttribute));
                y = Double.Parse(info.get_value(row, Correlated_Attribute));
                pointsList.Add(new DataPoint(x, y));
            }
            return pointsList;
        }
        private List<DataPoint> generateLinePoints()
        {
            float maxX = 0, minX = float.MaxValue;
            List<DataPoint> pointsList = new List<DataPoint>();
            Line.Line line = getLinearReg();
            foreach (var value in info.get_attribute(GraphAttribute))
            {
                if (float.Parse(value) < minX)
                {
                    minX = float.Parse(value);
                }
                if (float.Parse(value) > maxX)
                {
                    maxX = float.Parse(value);
                }
            }
            pointsList.Add(new DataPoint(minX, line.f(minX)));
            pointsList.Add(new DataPoint(maxX, line.f(maxX)));
            return pointsList;
        }
        private void updateGraphs()
        {
            MainGraph = getGraphPoint(GraphAttribute);
            CorrelatedGraph = getGraphPoint(correlated_Attribute);
        }
        public void start()
        {
            if (FinishedStart)
            {
                new Thread(delegate ()
                {
                    FinishedStart = false;
                    while (FrameId < info.row_count())
                    {
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
                new Thread(delegate ()
                {
                    while (FrameId < info.row_count())
                    {
                        NotifyPropertyChanged("MainGraph");
                        NotifyPropertyChanged("CorrelatedGraph");
                        RefreshIndices();
                        updateJoistick();
                        if (showCorrelationGraphs)
                        {
                            LatestPoints = generateLatestsPoints();
                        }
                        // the same for the other sensors properties
                        Thread.Sleep((int)Frequency); // read the data in 4Hz
                    }
                }).Start();
            }
        }

        //Yair addition:
        private List<DataPoint> getGraphPoint(string header)
        {
            string valueString;
            double currentValue;
            List<DataPoint> currentList = new List<DataPoint>();
            if (!String.IsNullOrEmpty(header)) 
            {
                for (int frame = 0; frame < RowCount; frame++)
                {
                    valueString = info.get_value(frame, header);
                    currentValue = Double.Parse(valueString);
                    currentList.Add(new DataPoint(frame, currentValue));
                }
            }
            return currentList;
        }

        public List<DataPoint> MainGraph
        {
            get
            {
                return mainGraph.GetRange(0, FrameId);
            }
            set
            {
                mainGraph = value;
                NotifyPropertyChanged("MainGraph");
            }
        }
        public List<DataPoint> CorrelatedGraph
        {
            get
            {
                return correlated_Graph.GetRange(0, FrameId);
            }
            set
            {
                correlated_Graph = value;
                NotifyPropertyChanged("CorrelatedGraph");
            }
        }
        public List<DataPoint> AttributesGraph
        {
            get
            {
                return attributesGraph;
            }
            set
            {
                attributesGraph = value;
                NotifyPropertyChanged("AttributesGraph");
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
                NotifyPropertyChanged("AttributesNames");
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
                new Task(delegate ()
                {
                    Correlated_Attribute = getMostCorraltedFeature();
                    updateGraphs();
                    updateLineGraph();
                }).Start();
            }
        }

        public string Correlated_Attribute
        {
            get
            {
                return correlated_Attribute;
            }
            set
            {
                correlated_Attribute = value;
                showCorrelationGraphs = true;
                NotifyPropertyChanged("Correlated_Attribute");
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
                correlatedDll = new CorrelatedDll(FilePath);
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
                filePath = value;
                NotifyPropertyChanged("FilePath");
            }
        }

        public List<DataPoint> LinePoints
        {
            get
            {
                return linePoints;
            }
            set
            {
                linePoints = value;
                NotifyPropertyChanged("LinePoints");
            }
        }
        public List<DataPoint> LatestPoints
        {
            get
            {
                return latestPoints;
            }
            set
            {
                latestPoints = value;
                NotifyPropertyChanged("LatestPoints");
            }
        }
        //CALL FIRST TO getMostCorraltedFeature AND THEN TO getLinearReg
        public string getMostCorraltedFeature() //graph for yair
        {
            int index = info.getIndex(GraphAttribute);
            string correlatedIndex = this.correlatedDll.getPearsonFeature(index);
            //what to do with index -1?
            return info.getAttributeFromIndex(Int32.Parse(correlatedIndex));
            //yair will use : info.getAttributeFromIndex(index);
        }

        public Line.Line getLinearReg() //graph for yair
        {
            return this.correlatedDll.getLine(info.getIndex(GraphAttribute));
        }
    }
}
