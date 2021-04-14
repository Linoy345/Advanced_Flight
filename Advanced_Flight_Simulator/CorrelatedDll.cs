using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Line;

namespace Advanced_Flight_Simulator
{
    /***
   * the class CorrelatedDll will cover userstory 7+8 in the mission.
   * the class created by using dll and used the code in c++ from previous semester.
   * the class find the corralated features and the linear regres.
   ***/
    public class CorrelatedDll
    {
        IntPtr infoDll;
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

        /***
         * constructor of CorrelatedDll that open the regular file "reg_flight.csv" and learn from it.
         ***/
        public CorrelatedDll(string fileName)
        {
            this.infoDll = Create(fileName);
        }
        /***
         * the function getPearsonFeature return the corralted feature to the index that given.
         * all this created by the dll.
         ***/
        public string getPearsonFeature(int index)
        {
            IntPtr stringCorelate = getCorlatedFeature(this.infoDll, index);  
            string ret = intPtrToString(stringCorelate);
            return ret;
        }
        /***
         * the function getLine return the lne of the linear regress of two correlated features.
         * all this created by the dll.
         ***/
        public Line.Line getLine(int index)
        {
            IntPtr line = getLineReg(this.infoDll, index, Int32.Parse(getPearsonFeature(index)));
            string s = intPtrToString(line);
            var splitLine = s.Split(',');
            Line.Line l = new Line.Line(float.Parse(splitLine[0]), float.Parse(splitLine[1]));
            return l;
        }
        /***
         * the function intPtrToString convert IntPtr to string because we cant move a string with dll.
         ***/
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
