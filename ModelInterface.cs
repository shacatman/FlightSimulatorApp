using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp
{
    public interface ModelInterface : INotifyPropertyChanged
    {
        
        //connection to flightgear
        void connect(string ip, int port);
        void disconnect();
        void start(string file1);
        void play();
        public Boolean getStop();
        public void setStop(Boolean b);
        public int Time { get; set; }
        public Boolean Stop { get; set; }
        public List<List<double>> FlightData{ get; }
        public List<double> TimedData { get; }
        public int TotalTime { get; }
        public double FrameRate { get; set; }
    }
}
