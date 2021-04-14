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
    /*
    * This class represents model.
    */
    public class MyFlightModel : IFlightModel
    {
        private Flight_Info info;
        private IClient client;
        private CorrelatedDll correlatedDll;
        private LoadDll algodDll;

        volatile private bool dllPluged;
        volatile private bool showCorrelationGraphs;
        volatile private bool shouldStop;
        volatile private int frameId;
        volatile private int rowCount;
        volatile private bool finishedStart; // Prevent from oppening multiple thread in start.
        volatile private string filePath;
        volatile private string filePathDllAlgo;

        volatile private List<string> attributeNames;
        volatile private List<DataPoint> linePoints;
        volatile private List<DataPoint> mainGraph;
        volatile private List<DataPoint> correlated_Graph;
        volatile private List<DataPoint> attributesGraph;
        volatile private List<DataPoint> latestPoints;
        volatile private List<DataPoint> anomaliesPoints;
        volatile private List<string> anomaliesList;
        volatile private List<DataPoint> anomaliesLine;
        private List<DataPoint> anomalyPoint;




        volatile private string currentAnomaly;



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
        /*
        * Constructor - initialize model with given client.
        */
        public MyFlightModel(IClient client)
        {
            RowCount = 0;
            FrameId = 0;
            DllPluged = false;
            Frequency = 1;
            info = new Flight_Info();
            this.client = client;
            AttributesNames = new List<string>();
            MainGraph = new List<DataPoint>();
            LinePoints = new List<DataPoint>();
            LatestPoints = new List<DataPoint>();
            CorrelatedGraph = new List<DataPoint>();
            AnomaliesPoints = new List<DataPoint>();
            AnomaliesLine = new List<DataPoint>();

            AnomaliesList = new List<string>();
            FinishedStart = true;
            ShouldStop = false;
            showCorrelationGraphs = false;
            x = 0;
            y = 0;
        }
        /*
        * Getter and Setter for property ShouldStop.
        */

        /*
         * Getter for property Flight_Info.
         */
        public Flight_Info FlightInfo
        {
            get { return info; }
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
        /*
        * Getter and Setter for property FinishedStart.
        */
        public bool FinishedStart
        {
            get { return finishedStart; }
            set
            {
                finishedStart = value;
                NotifyPropertyChanged("FinishedStart");
            }
        }
        /*
        * Getter and Setter for property Direction.
        */
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
        /*
        * Getter and Setter for property Yaw.
        */
        public double Yaw
        {
            get { return yaw; }
            set
            {
                yaw = value;
                NotifyPropertyChanged("Yaw");
            }
        }
        /*
        * Getter and Setter for property Roll.
        */
        public double Roll
        {
            get { return roll; }

            set
            {
                roll = value;
                NotifyPropertyChanged("Roll");
            }

        }
        /*
        * Getter and Setter for property Pitch.
        */
        public double Pitch
        {
            get { return pitch; }
            set
            {
                pitch = value;
                NotifyPropertyChanged("Pitch");
            }
        }
        /*
        * Getter and Setter for property Altitude.
        */
        public double Altitude
        {
            get { return altitude; }
            set
            {
                altitude = value;
                NotifyPropertyChanged("Altitude");
            }
        }
        /*
        * Getter and Setter for property Speed.
        */
        public double Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                NotifyPropertyChanged("Speed");
            }
        }
        /*
        * Updating the Indices properties.
        */
        public void RefreshIndices()
        {
            Speed = Convert.ToDouble(info.get_value(FrameId, "airspeed-kt"));
            Altitude = Convert.ToDouble(info.get_value(FrameId, "altitude-ft"));
            Pitch = Convert.ToDouble(info.get_value(FrameId, "pitch-deg"));
            Roll = Convert.ToDouble(info.get_value(FrameId, "roll-deg"));
            Yaw = Convert.ToDouble(info.get_value(FrameId, "side-slip-deg"));
            Direction = Convert.ToDouble(info.get_value(FrameId, "heading-deg"));
        }
        /*
        * Getter and Setter for property FrameId.
        */
        public int FrameId
        {
            get
            {
                return frameId;
            }
            set
            {
                if (value >= 0 && value <= RowCount)
                {
                    frameId = value;
                }
                NotifyPropertyChanged("FrameId");
            }
        }
        /*
        * Getter and Setter for property Aileron.
        */
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
        /*
        * Getter and Setter for property Elevator.
        */
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
        /*
        * Getter and Setter for property X.
        */
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
        /*
        * Getter and Setter for property Y.
        */
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
        /*
        * Getter and Setter for property Rudder.
        */
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
        /*
        * Getter and Setter for property Throttle.
        */
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
        /*
        * Updating the Joistick properties.
        */
        public void updateJoistick()
        {
            Rudder = Convert.ToDouble(info.get_value(FrameId, "rudder"));
            Throttle = Convert.ToDouble(info.get_value(FrameId, "throttle"));
            Aileron = Convert.ToDouble(info.get_value(FrameId, "aileron"));
            Elevator = Convert.ToDouble(info.get_value(FrameId, "elevator"));
            X = (Aileron * 90);
            Y = (Elevator * 90);
        }
        /*
        * Getter and Setter for property Frequency.
        */
        public double Frequency
        {
            get { return frequency; }
            set
            {
                frequency = 100 / value;
                NotifyPropertyChanged("Frequency");
            }
        }
        /*
        * Getter for property Frequency.
        */
        public int RowCount
        {
            get { return rowCount; }
            set
            {
                rowCount = value;
                NotifyPropertyChanged("RowCount");
            }
        }

        /*
        * Changing frame by changing FrameId to given id.
        */
        public void changeFrame(int id)
        {
            FrameId = id;
        }
        /*
        * Notify that property changed.
        */
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        /*
        * stopping the frame.
        */
        public void stopFrame()
        {
            ShouldStop = true;
        }
        public bool DllPluged
        {
            get
            {
                return dllPluged;
            }
            set
            {
                dllPluged = value;
                NotifyPropertyChanged("DllPluged");
            }
        }
        /*
        * continuing the frame.
        */
        public void continueFrame()
        {
            ShouldStop = false;
        }
        /*
        * Connect the client with given ip and port.
        */
        public void connect(string ip, int port)
        {
            client.connect(ip, port);
        }
        /*
        * Disconnect the client.
        */
        public void disconnect()
        {
            client.disconnect();
            stopFrame();
            FrameId = 0;
        }
        /*
        * Sending 1 frame to server by sending him row.
        */
        public void sendFrame()
        {
            if (!ShouldStop && FrameId < RowCount)
            {
                client.write(info.get_row_string(FrameId));
                FrameId++;
            }
        }
        /*
        * Return the the size of attributes.
        */
        public int attributeCount()
        {
            return info.attribute_count();
        }
        /*
        * Initialize the flight.
        */
        public void init()
        {
            if (FilePath != string.Empty)
            {
                info.init_Flight_Info(FilePath);
                AttributesNames = info.get_attribute_names();
                RowCount = info.row_count();
                //correlatedDll = new CorrelatedDll(FilePath);
                //NotifyPropertyChanged(string.Empty);
                //NotifyPropertyChanged("AttributesNames");
                //NotifyPropertyChanged("RowCount");

            }

        }
        /*
        * Updating the line of the graph.
        */
        private void updateLineGraph()
        {
            LinePoints = generateLinePoints();
            AttributesGraph = generateGraphAttributes();
        }
        /*
        * Return the latest points.
        */
        private List<DataPoint> generateLatestsPoints()
        {
            float x, y;
            int frame = 0;
            List<DataPoint> pointsList = new List<DataPoint>();
            if (FrameId > 150)
            {
                frame = frameId - 150;
            }
            for (; frame < FrameId; frame++)
            {
                x = float.Parse(info.get_value(frame, GraphAttribute));
                y = float.Parse(info.get_value(frame, CorrelatedAttribute));
                pointsList.Add(new DataPoint(x, y));
            }
            return pointsList;
        }

        /*
        * Return the graph attributes.
        */
        private List<DataPoint> generateGraphAttributes()
        {
            double x, y;
            List<DataPoint> pointsList = new List<DataPoint>();
            for (int row = 0; row < RowCount; row++)
            {
                x = Double.Parse(info.get_value(row, GraphAttribute));
                y = Double.Parse(info.get_value(row, CorrelatedAttribute));
                pointsList.Add(new DataPoint(x, y));
            }
            return pointsList;
        }

        /*
         * Return Anomalies Reg Line
         */
        private List<DataPoint> generateAnomaliesLine()
        {
            float maxX = float.MinValue, minX = float.MaxValue;
            List<DataPoint> pointsList = new List<DataPoint>();
            Line.Line line = getLinearReg();
            foreach (DataPoint point in anomaliesPoints)
            {
                if (point.X < minX)
                {
                    minX = (float)point.X;
                }
                if (point.X > maxX)
                {
                    maxX = (float)point.X;
                }
            }
            if (minX != float.MaxValue && maxX != float.MinValue)
            {
                pointsList.Add(new DataPoint(minX, line.f(minX)));
                pointsList.Add(new DataPoint(maxX, line.f(maxX)));
            }
            return pointsList;
        }

        /*
        * Return the line points.
        */
        private List<DataPoint> generateLinePoints()
        {
            float maxX = 0, minX = float.MaxValue;
            float currentValue;
            List<DataPoint> pointsList = new List<DataPoint>();
            Line.Line line = getLinearReg();
            foreach (var value in info.get_attribute(GraphAttribute))
            {
                currentValue = float.Parse(value);
                if (currentValue < minX)
                {
                    minX = currentValue;
                }
                if (currentValue > maxX)
                {
                    maxX = currentValue;
                }
            }
            pointsList.Add(new DataPoint(minX, line.f(minX)));
            pointsList.Add(new DataPoint(maxX, line.f(maxX)));
            return pointsList;
        }


        /*
        * Updating the graph.
        */
        private void updateGraphs()
        {
            MainGraph = getGraphPoint(GraphAttribute);
            CorrelatedGraph = getGraphPoint(correlated_Attribute);
        }
        /*
        * Strating the app.
        */
        public void start()
        {
            if (FinishedStart)
            {
                new Task(delegate ()
                {
                    FinishedStart = false;
                    while (FrameId < RowCount)
                    {
                        sendFrame();
                        // the same for the other sensors properties
                        Thread.Sleep((int)Frequency);// read the data in 4Hz
                    }
                    FinishedStart = true;
                }).Start();
                new Task(delegate ()
                {
                    while (FrameId < RowCount)
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
        /*
        * Return graph points.
        */
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
        /*
        * Getter and Setter for property MainGraph.
        */
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
        /*
        * Getter and Setter for property CorrelatedGraph.
        */
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
        /*
        * Getter and Setter for property AttributesGraph.
        */
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
        /*
        * Getter and Setter for property AttributesNames.
        */
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
        /*
        * Getter and Setter for property GraphAttribute.
        */
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
                    CorrelatedAttribute = getMostCorraltedFeature();
                    updateGraphs();
                    updateLineGraph();
                    if (DllPluged)
                    {
                        AnomalyPoint = new List<DataPoint>();
                        updateAnomalies();
                    }
                }).Start();
            }
        }
        /*
        * Getter and Setter for property CurrentAnomaly.
        */
        public string CurrentAnomaly
        {
            get
            {
                return currentAnomaly;
            }
            set
            {
                currentAnomaly = value;
                if (!string.IsNullOrEmpty(currentAnomaly))
                {
                    double x, y;
                    FrameId = int.Parse(value);
                    x = Double.Parse(info.get_value(int.Parse(CurrentAnomaly), GraphAttribute));
                    y = Double.Parse(info.get_value(int.Parse(CurrentAnomaly), CorrelatedAttribute));
                    List<DataPoint> newPoint = new List<DataPoint>();
                    newPoint.Add(new DataPoint(x, y));
                    AnomalyPoint = newPoint;
                }
                NotifyPropertyChanged("CurrentAnomaly");
            }
        }
        /*
        * Getter and Setter for property CurrentAnomaly.
        */
        public List<string> AnomaliesList
        {
            get
            {
                return anomaliesList;
            }
            set
            {
                anomaliesList = value;
                NotifyPropertyChanged("AnomaliesList");
            }
        }

        public List<DataPoint> AnomaliesPoints
        {
            get
            {
                return anomaliesPoints;
            }
            set
            {
                anomaliesPoints = value;
                NotifyPropertyChanged("AnomaliesPoints");
            }
        }
        public List<DataPoint> AnomalyPoint
        {
            get
            {
                return anomalyPoint;
            }
            set
            {
                anomalyPoint = value;
                NotifyPropertyChanged("AnomalyPoint");
            }
        }

        public List<DataPoint> AnomaliesLine
        {
            get
            {
                return anomaliesLine;
            }
            set
            {
                anomaliesLine = value;
                NotifyPropertyChanged("AnomaliesLine");
            }
        }
        private List<DataPoint> getAnomaliesPoints()
        {
            double x, y;
            int row;
            List<DataPoint> listAnomalies = new List<DataPoint>();
            foreach (var anomaly in AnomaliesList)
            {
                row = int.Parse(anomaly);
                x = Double.Parse(getValue(row, GraphAttribute));
                y = Double.Parse(getValue(row, CorrelatedAttribute));
                listAnomalies.Add(new DataPoint(x, y));
            }
            return listAnomalies;
        }
        private void updateAnomalies()
        {
            if (!String.IsNullOrEmpty(CorrelatedAttribute))
            {
                AnomaliesList = getAnomalyReportByAttribute(GraphAttribute);
                AnomaliesPoints = getAnomaliesPoints();
                AnomaliesLine = generateAnomaliesLine();
                
            }
        }
        /*
        * Getter and Setter for property Correlated_Attribute.
        */
        public string CorrelatedAttribute
        {
            get
            {
                return correlated_Attribute;
            }
            set
            {
                correlated_Attribute = value;
                showCorrelationGraphs = true;
                NotifyPropertyChanged("CorrelatedAttribute");
            }
        }
        /*
        * Return the value of the attribute in a row by given attribute name and a row.
        */
        public string getValue(int row, string attribueName)
        {
            return info.get_value(row, attribueName);
        }
        /*
        * Opening a file and return the file path as string.
        */

        public string openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV file (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == true)
            {   //(csv_path, xml_path);
                FilePath = openFileDialog.FileName;
                correlatedDll = new CorrelatedDll("reg_flight.csv");//load a regular flight and learn from it
            }
            else
            {
                FilePath = String.Empty;
            }
            return FilePath;
        }
        /*
        * Getter and Setter for property FilePath.
        */
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
        /*
        * Getter and Setter for property LinePoints.
        */

        public string openDllAlgo()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Dll file (*.dll) | *.dll";

            if (openFileDialog.ShowDialog() == true)
            {
                FilePathDllAlgo = openFileDialog.FileName;
                algodDll = new LoadDll(FilePathDllAlgo, FilePath, FlightInfo);
                DllPluged = true;
            }
            else
            {
                FilePathDllAlgo = String.Empty;
            }
            return FilePathDllAlgo;
        }
        public string FilePathDllAlgo
        {
            get
            {
                return filePathDllAlgo;
            }
            set
            {
                filePathDllAlgo = value;
                NotifyPropertyChanged("FilePathDllAlgo");
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
        /*
        * Getter and Setter for property LatestPoints.
        */
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
        /*
        * Return the most correlated feature to GraphAttribute.
        */
        public string getMostCorraltedFeature() //graph for yair
        {
            int index = info.getIndex(GraphAttribute);
            string correlatedIndex = this.correlatedDll.getPearsonFeature(index);
            return info.getAttributeFromIndex(Int32.Parse(correlatedIndex));
        }
        /*
        * Return the line reg for Graph Attribute.
        */
        public Line.Line getLinearReg() //graph for yair
        {
            return this.correlatedDll.getLine(info.getIndex(GraphAttribute));
        }

        /*
        * Return the List<string> with number of line
        */
        public List<string> getAnomalyReportByAttribute(string attribute)
        {
            return this.algodDll.getAnomalyReportByAttribute(attribute);
        }
    }
}
