namespace Advanced_Flight_Simulator {
    interface Model_IClient
    {
        void connect(string ip, int port);
        /*
        * If connection has been established- Send to Server the given Line.
        */
        void write(string line);
        /*
        * Read one line or 512 bytes.
        */
        string read();
        void disconnect();
    }
}
