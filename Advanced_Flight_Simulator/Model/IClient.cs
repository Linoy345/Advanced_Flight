using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Flight_Simulator
{
    /*
    * Interface that represents client. 
    */
    public interface IClient
    {
        /*
        * Connect to the server.
        */
        void connect(string ip, int port);
        /*
        * If connection has been established- Send to Server the given Line.
        */
        void write(string line);
        /*
        * Read one line or 512 bytes.
        */
        string read();
        /*
        * Disconnect from the server.
        */
        void disconnect();
    }
}
