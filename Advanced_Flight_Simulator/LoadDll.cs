using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using System.Runtime.InteropServices;


namespace Advanced_Flight_Simulator
{
    class LoadDll
    {

        static class NativeMethods
        {
            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string dllToLoad);

            [DllImport("kernel32.dll")]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

            [DllImport("kernel32.dll")]
            public static extern bool FreeLibrary(IntPtr hModule);
        }
        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int len(IntPtr str);

        [DllImport("anomalyDetectorDll3.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern char getCharByIndex(IntPtr str, int x);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr Create(string fileName);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr GetAllAnomalyReport(IntPtr dataDll, int index1, int index2);

        private IntPtr ptrDll;

        private IntPtr dataDll;


        private GetAllAnomalyReport getAllAnomalyReport;

        private Dictionary<string, List<string>> anomalyRepor;

        private Flight_Info flight_Info;

        public LoadDll(string dllPath, string fileName, Flight_Info flight_Info)
        {
            ptrDll = NativeMethods.LoadLibrary(@dllPath);
            //oh dear, error handling here
            //if (ptrDll == IntPtr.Zero)

            IntPtr pAddressOfFunctionToCallCreate = NativeMethods.GetProcAddress(ptrDll, "Create");
            IntPtr pAddressOfFunctionToCallGetAllAnomalyReport = NativeMethods.GetProcAddress(ptrDll, "GetAllAnomalyReport");

            Create create = (Create)Marshal.GetDelegateForFunctionPointer(
                                                pAddressOfFunctionToCallCreate, typeof(Create));
            getAllAnomalyReport = (GetAllAnomalyReport)Marshal.GetDelegateForFunctionPointer(
                                    pAddressOfFunctionToCallGetAllAnomalyReport, typeof(GetAllAnomalyReport));

            dataDll = create(fileName);

            this.flight_Info = flight_Info;
            setAnomalyReport();
        }
        private void setAnomalyReport()
        {
            anomalyRepor = new Dictionary<string, List<string>>();

            string strAnomalyReport = intPtrToString(getAllAnomalyReport(dataDll, 1, 2));

            List<string> lineNumbers = null;
            string oldColName = "";
            foreach (string word in strAnomalyReport.Split('\n'))
            {
                //last run
                if (word.Equals(""))
                {
                    anomalyRepor.Add(flight_Info.getAttributeFromIndex(Int32.Parse(oldColName)), lineNumbers);
                    break;
                }
                string[] tokens = word.Split(' ');
                string colName = tokens[1];

                //if true there no new column to add
                if (colName.Equals(oldColName))
                {
                    lineNumbers.Add(tokens[0]);
                }
                else //if false there is new column to add
                {
                    //if this is the first time don't enter
                    if (!oldColName.Equals(""))
                    {
                        anomalyRepor.Add(flight_Info.getAttributeFromIndex(Int32.Parse(oldColName)), lineNumbers);
                    }

                    lineNumbers = new List<string>();
                    lineNumbers.Add(tokens[0]);
                    oldColName = tokens[1];
                }
            }


            foreach (string att in flight_Info.get_attribute_names())
            {
                if (!anomalyRepor.ContainsKey(att))
                {
                    List<string> emptyLineNumbers = new List<string>();
                    anomalyRepor.Add(att, emptyLineNumbers);
                }

            }

        }

        public List<string> getAnomalyReportByAttribute(string att)
        {
            return anomalyRepor[att];
        }

        public void freeDll()
        {
            bool result = NativeMethods.FreeLibrary(ptrDll);
        }

        private static string intPtrToString(IntPtr intPtr)
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
