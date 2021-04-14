Welcome to our FlightGear Application!


    We built a WPF application- a GUI interface which will show us information and playback tools according to the plane in FlightGear   
    simulator.
    Our program is based on the MVVM (Model, View and View Model) design pattern. 
    Acorrding to MVVM rules, we created 3 main folders for the Model, View and View Model. The Modle responsible on the logic of our           program, the View is responsible to display our program and the ViewModel create the connection between the model and the view.
    Moreover, our program can represent and detect deviation in the flight by using dll. The dll is on our program from the previous           semester. we show this information by graph, therefore you need to install "oxyplot". 
    The main Classes in our program is the MyFlightModel that in the Model folder, which has all the logic and run the program. The             FlightViewModel in the ViewModle folder and the displayWindow in the View folder which show the main information in our project.
    For more information on the classes and functions, see the documentation in the code.
    
Operating Instructions

    1.	Run the flightGear application, choose an ip and port.
    2.	Start FlightGear simulator. Put in the setting the next line:
        --generic=socket,in,10,IP,PORT,tcp,playback_small--fdm=null
        Instead of IP and PORT put the values that you choose.
        We recommend:
        --generic=socket,in,10,127.0.0.1,5400,tcp,playback_small--fdm=null
    3.	Open a csv file that represent a flight and run it.
    4.	Enjoy.
