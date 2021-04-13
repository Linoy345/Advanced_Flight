  Welcome to our FlightGear Application!
    We built a WPF application - a GUI interface which will show us information and playback tools according to the plane in FlightGear simulator.
    Our program based on the MVVM (Model, View and View Model) design pattern. For more information on the classes and functions, see the documentation in the code.
  Operating Instructions
    1.	Run the flightGear application, choose an ip and port.
    2.	Start FlightGear simulator. Put in the setting the next line:
    --generic=socket,in,10,IP,PORT,tcp,playback_small--fdm=null
    Instead of IP and PORT put the values that you choose.
    Our recommend:
    --generic=socket,in,10,127.0.0.1,5400,tcp,playback_small--fdm=null
    3.	Open a csv file that represent a flight and run it.
    4.	Enjoy.
