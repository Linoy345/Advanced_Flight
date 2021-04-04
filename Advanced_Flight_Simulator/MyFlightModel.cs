using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    class MyFlightModel : IFlightModel
    {
        private Flight_Info info;
        private IClient client;

        volatile private bool shouldStop;
        volatile private int frameId;
        volatile private int rowCount;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public MyFlightModel(IClient client)
        {
            FrameId = 0;
            info = new Flight_Info();
            info.init_Flight_Info("reg_flight.csv", "playback_small.xml"); // TODO: INIT in open method
            this.client = client;
            ShouldStop = false;

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

        public int FrameId
        {
            get { return frameId; }
            set
            {
                frameId = value;
                NotifyPropertyChanged("FrameId");
            }
        }

        public int RowCount
        {
            get { return info.row_count(); }
            set
            {
                rowCount = value;
                NotifyPropertyChanged("RowCount");
            }
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
        }
        public void sendFrame()
        {
            if (!ShouldStop)
            {
                client.write(info.get_row_string(FrameId));
                FrameId++;
            }
        }

        public int attributeCount()
        {
            return info.attribute_count();
        }

        public void start()
        {
            new Thread(delegate () {
                while (frameId < info.row_count())
                {
                    sendFrame();
                    // the same for the other sensors properties
                    Thread.Sleep(60);// read the data in 4Hz
                }
            }).Start();
        }
    }
}
