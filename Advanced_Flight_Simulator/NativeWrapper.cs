using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    /*
    static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToLoad);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procedureName);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);
    }
    class NativeWrapper

    {

        NativeWrapper(string filename)

        {

            m_strFileName = filename;

        }

        Load()

        {

            m_hModule = LoadLibrary(m_strFileName);

        }

        Free()

        {

            FreeLibrary(m_hModule);

            m_pfnSomeMethod = null;

        }

        int SomeMethod()

        {

            if (m_pfnSomeMethod == null)

            {

                //pseudocode; you get the idea

                m_pfnSomeMethod = (SomeMethodDelegate)GetProcAddress(m_hModule, "SomeMethod");

            }

            return m_pfnSomeMethod();

        }

    }*/
}
