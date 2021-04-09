using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    public class MangeDll
    {
        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Create(string fileName);

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getCorlatedFeature(IntPtr a, string fileName);


        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreatestringWrapper(string newStr);

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int len(IntPtr str);

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern char getCharByIndex(IntPtr str, int x);

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void set(IntPtr str, string newString);


        public static void runDll()
        {
            Console.WriteLine("Hello World!");
            string fileName = "anomaly_flight.csv";
            IntPtr a = Create(fileName);

            Console.WriteLine("Bye!1");
            IntPtr stringCorelate = getCorlatedFeature(a, "rudder");
            Console.WriteLine(intPtrToString(stringCorelate));
            Console.WriteLine("Bye2!");
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
