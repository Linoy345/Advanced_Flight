using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line
{
    /*
    * Hold line with two arguments represents ax + b 
    */
    public class Line
    {
        public float a;
        public float b;
        /*
        * Constructor - initialize line with default values. 
        */
        public Line()
        {
            a = 0;
            b = 0;
        }
        /*
        * Constructor - initialize line with given a and b.
        */
        public Line(float a, float b)
        {
            this.a = a;
            this.b = b;
        }
        /*
        * Return the result of the point with given argument.
        */
        public float f(float x)
        {
            return a * x + b;
        }

    };
}
