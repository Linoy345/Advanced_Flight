using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    /*
    * This class represents GraphViewModel as viewmodel.
    */
    public class GraphViewModel : FlightViewModel
    {
        /*
        * Constructor - initialize GraphViewModel by given model.
        */
        public GraphViewModel(IFlightModel model) : base(model) { }
        /*
        * Getter for property VM_AttributesNames.
        */
        public List<string> VM_AttributesNames
        {
            get { return model.AttributesNames; }

        }
        /*
        * Getter and Setter for property VM_GraphAttribute.
        */
        public string VM_GraphAttribute
        {
            get { return model.GraphAttribute; }
            set
            {
                model.GraphAttribute = value;
            }
        }
        /*
        * Getter and Setter for property VM_CorrelatedAttribute.
        */
        public string VM_CorrelatedAttribute
        {
            get { return model.Correlated_Attribute; }
            set
            {
                model.Correlated_Attribute = value;
            }
        }

        /*
        * Getter for property VM_MainGraph.
        */
        public List<DataPoint> VM_MainGraph
        {
            get
            {
                return model.MainGraph;
            }
        }
        /*
        * Getter for property VM_LinePoints.
        */
        public List<DataPoint> VM_LinePoints
        {
            get
            {
                return model.LinePoints;
            }
        }
        /*
        * Getter for property VM_CorrelatedGraph.
        */
        public List<DataPoint> VM_CorrelatedGraph
        {
            get
            {
                return model.CorrelatedGraph;
            }
        }
        /*
        * Getter for property VM_AttributesGraph.
        */
        public List<DataPoint> VM_AttributesGraph
        {
            get
            {
                return model.AttributesGraph;
            }
        }
        /*
        * Getter for property VM_LatestPoints.
        */
        public List<DataPoint> VM_LatestPoints
        {
            get
            {
                return model.LatestPoints;
            }
        }
        /*
        * Getter for property VM_Anomaly.
        */
        public string VM_Anomaly
        {
            get { return model.CurrentAnomaly; }
            set
            {
                model.CurrentAnomaly = value;
            }
        }
        /*
        * Getter for property VM_AnomaliesList.
        */
        public List<string> VM_AnomaliesList
        {
            get
            {
                return model.AnomaliesList;
            }
        }
        /*
        * Getter for property VM_AnomaliesPoints.
        */
        public List<DataPoint> VM_AnomaliesPoints
        {
            get
            {
                return model.AnomaliesPoints;
            }
        }
        /*
        * Getter for property VM_AnomaliesLine.
        */
        public List<DataPoint> VM_AnomaliesLine
        {
            get
            {
                return model.AnomaliesLine;
            }
        }
        /*
        * Getter for property VM_AnomalyPoint.
        */
        public List<DataPoint> VM_AnomalyPoint
        {
            get
            {
                return model.AnomalyPoint;
            }
        }
        /*
        * Return the most correlated feature using model.
        */
        public string VM_getMostCorraltedFeature() //go over the dictionaray, every pair is the "me" and ny corrlated featuer
        {
            return model.getMostCorraltedFeature();
        }
        /*
        * Return the linear reg using model.
        */
        public Line.Line VM_getLinearReg() //graph for yair
        {
            return this.model.getLinearReg();
        }


    }
}
