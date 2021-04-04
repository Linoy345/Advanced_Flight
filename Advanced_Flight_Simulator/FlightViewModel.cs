using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    class FlightViewModel : INotifyPropertyChanged
    {
        private IFlightModel model;

        public event PropertyChangedEventHandler PropertyChanged;
        public FlightViewModel(IFlightModel model)
        {
            this.model = model;
            model.PropertyChanged +=
            delegate (Object sender, PropertyChangedEventArgs e) {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
       
        }


        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        // Properties
        public int VM_FrameId
        {
            get { return model.FrameId; }
            set { model.FrameId = value; }
        }
        public int VM_RowCount
        {
            get { return model.RowCount; } 
        }

        public bool VM_ShouldStop
        {
            get { return model.ShouldStop; }
            set { model.ShouldStop = value; }
        }
        public void VM_Start()
        {
            model.start();
        }

    }
}
