using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    /*
    * This class represents viewmodel.
    */
    public class FlightViewModel : INotifyPropertyChanged
    {
        protected IFlightModel model;

        public event PropertyChangedEventHandler PropertyChanged;
        /*
        * Constructor - initialize viewmodel by given model.
        */
        public FlightViewModel(IFlightModel model)
        {
            this.model = model;
            model.PropertyChanged +=
            delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };

        }
        /*
        * Notify that property changed.
        */
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        // Properties
        /*
        * Getter and Setter for property VM_FrameId.
        */
        public int VM_FrameId
        {
            get { return model.FrameId; }
            set { model.FrameId = value; }
        }
        /*
        * Getter and Setter for property VM_Rudder.
        */
        public double VM_Rudder
        {
            get { return model.Rudder; }
            set { model.Rudder = value; }
        }
        /*
        * Getter and Setter for property VM_Throttle.
        */
        public double VM_Throttle
        {
            get { return model.Throttle; }
            set { model.Throttle = value; }

        }
        /*
        * Getter and Setter for property VM_Aileron.
        */
        public double VM_Aileron
        {
            get { return model.Aileron; }
            set { model.Aileron = value; }

        }
        /*
        * Getter and Setter for property VM_Elevator.
        */
        public double VM_Elevator
        {
            get { return model.Elevator; }
            set { model.Elevator = value; }

        }
        /*
        * Getter and Setter for property VM_X.
        */
        public double VM_X
        {
            get { return model.X; }
            set { model.X = value; }

        }
        /*
        * Getter and Setter for property VM_Y.
        */
        public double VM_Y
        {
            get { return model.Y; }
            set { model.Y = value; }

        }
        /*
        * Getter for property VM_RowCount.
        */
        public int VM_RowCount
        {
            get { return model.RowCount; }
        }
        /*
        * Getter and Setter for property VM_ShouldStop.
        */
        public bool VM_ShouldStop
        {
            get { return model.ShouldStop; }
            set { model.ShouldStop = value; }
        }
        /*
        * Starting using the model.
        */
        public void VM_Start()
        {
            model.start();
        }
        /*
        * Getter and Setter for property VM_Direction.
        */
        public double VM_Direction
        {
            get { return model.Direction; }

            set { model.Direction = value; }
        }
        /*
        * Getter and Setter for property VM_Yaw.
        */
        public double VM_Yaw
        {
            get
            {
                return model.Yaw;
            }

            set { model.Yaw = value; }
        }
        /*
        * Getter and Setter for property VM_Roll.
        */
        public double VM_Roll
        {
            get { return model.Roll; }

            set { model.Roll = value; }
        }
        /*
        * Getter and Setter for property VM_Pitch.
        */
        public double VM_Pitch
        {
            get { return model.Pitch; }

            set { model.Pitch = value; }
        }
        /*
        * Getter and Setter for property VM_Altitude.
        */
        public double VM_Altitude
        {
            get
            {
                return model.Altitude;
            }

            set { model.Altitude = value; }
        }
        /*
        * Getter and Setter for property VM_Speed.
        */
        public double VM_Speed
        {
            get { return model.Speed; }

            set { model.Speed = value; }
        }
        /*
        * Disconnecting using the model.
        */
        public void VM_Disconnect()
        {
            model.disconnect();
        }
        /*
        * Getter and Setter for property VM_Frequency.
        */
        public double VM_Frequency
        {
            get { return model.Frequency; }
            set { model.Frequency = value; }
        }
        /*
        * Init the model.
        */
        public void VM_init()
        {
            model.init();
        }
        /*
        * Openning a file using the model.
        */
        public string VM_openFile()
        {
            return model.openFile();
        }
        public string VM_openDllAlgo()
        {
            return model.openDllAlgo();
        }
    }
}