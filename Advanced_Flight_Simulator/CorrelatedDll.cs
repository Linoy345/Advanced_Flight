using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Line;

namespace Advanced_Flight_Simulator
{
    public class CorrelatedDll
    {
        IntPtr infoDll;
        //private int feature1;
        //private int feature2;

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Create(string fileName);

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getCorlatedFeature(IntPtr a, int index);


        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreatestringWrapper(string newStr);

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int len(IntPtr str);

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern char getCharByIndex(IntPtr str, int x);

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set(IntPtr str, string newString);


        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getLineReg(IntPtr str, int index1, int index2);


        public CorrelatedDll(string fileName)
        {
            this.infoDll = Create(fileName);
        }
        public string getPearsonFeature(int index)
        {
            IntPtr stringCorelate = getCorlatedFeature(this.infoDll, index);  
            string ret = intPtrToString(stringCorelate);
            //this.feature1 = index;
            //this.feature2 = Int32.Parse(ret);
            return ret;
        }

        public Line.Line getLine(int index)
        {
            IntPtr line = getLineReg(this.infoDll, index, Int32.Parse(getPearsonFeature(index)));

            string s = intPtrToString(line);
            var splitLine = s.Split(',');
            return new Line.Line(float.Parse(splitLine[0]), float.Parse(splitLine[1]));
        }

        public static string intPtrToString(IntPtr intPtr)
        {
            string s = "";
            IntPtr strWr = intPtr;
            int str_len = len(strWr);
            for (int i = 0; i < str_len; i++)
            {
                char c = getCharByIndex(strWr, i);
                s += c.ToString();
            }
            return s;
        }


    }
}
