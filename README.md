# FlightSimulatorApp
1. The Application allows the user to simulate a given csv file of flight data via FlightGear simulator and display important data at any given time.
    Note that the app works on csv files that fit the playback_small.xml definitions (the first line should not include heading titles), and at a given frequency of 10 frames per     second.
2. The Application is built according to the MVVM principles(Model-ViewModel-View) and written in C# and Xaml languages.
3. The Application is written in a .NET5 environment.
4. In order to run the Application it is required to:
4.1.  download the FlightGear Simulator from https://www.flightgear.org/
4.2.  copy the playback_small.xml file into data\Protocol (under the simulator's location directory)
4.3.  open the FG simulator and in the settings menu input the following lines: 
          --generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
          --fdm=null
4.4   once clicking fly, run the app(recommended through Visual Studio)
~Anything else is self explanatory
