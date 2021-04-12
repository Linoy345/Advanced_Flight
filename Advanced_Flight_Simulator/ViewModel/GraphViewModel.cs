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
        
        public string VM_GraphAttribute
        {
            get { return model.GraphAttribute; }
            set
            {
                model.GraphAttribute = value;
            }
        }
        public string VM_CorrelatedAttribute
        {
            get { return model.Correlated_Attribute; }
            set
            {
                model.Correlated_Attribute = value;
            }
        }
        

        public List<DataPoint> VM_MainGraph
        {
            get
            {
                return model.MainGraph;
            }
        }
        public List<DataPoint> VM_LinePoints
        {
            get
            {
                return model.LinePoints;
            }
        }

        public List<DataPoint> VM_CorrelatedGraph
        {
            get
            {
                return model.CorrelatedGraph;
            }
        }

        public List<DataPoint> VM_AttributesGraph
        {
            get
            {
                return model.AttributesGraph;
            }
        }
        public List<DataPoint> VM_LatestPoints
        {
            get
            {
                return model.LatestPoints;
            }
        }
        public string VM_getMostCorraltedFeature() //go over the dictionaray, every pair is the "me" and ny corrlated featuer
        {
            return model.getMostCorraltedFeature();
        }
        public Line.Line VM_getLinearReg() //graph for yair
        {
            return this.model.getLinearReg();
        }
    }
}
