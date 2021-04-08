using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator 
{
   public class GraphViewModel: FlightViewModel
    {

        public GraphViewModel(IFlightModel model) : base(model) {}
        public List<string> VM_AttributesNames
        {
            get { return model.AttributesNames; }

        }
        
        public string VM_Graph_Attribute
        {
            get { return model.GraphAttribute; }
            set
            {
                model.GraphAttribute = value;
            }
        }
        
        public List<DataPoint> VM_GraphPoints
        {
            get
            {
                return model.GraphPoints;
            }
        }

    }
}
