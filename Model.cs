using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp
{
    public class Model : ModelInterface
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ICommClient commClient;
        volatile Boolean stop;
        int freq = 10;//assume 10
        int time=0;
        List<List<double>> flightData = new List<List<double>>();
        List<string> csvData = new List<string>();//used for the flightgear
        double frameRate=1;//playback speed

        //properties implementation
        public Boolean Stop
        {
            get { return stop; }
            set
            {
                stop = value;
                NotifyPropertyChanged("Stop");
            }
        }
        public int Time
        {
            get { return time; }
            set { time = value;
                NotifyPropertyChanged("Time");
                NotifyPropertyChanged("TimedData");
                NotifyPropertyChanged("JoystickX");
                NotifyPropertyChanged("JoystickY");
            }
        }
        public List<List<double>> FlightData
        {
            get { return flightData; }
        }
        public List<double> TimedData
        {
            get { return FlightData[Time]; }
        }
        public int TotalTime
        {
            get { return FlightData.Count/ 42 -1; }
        }
        public double FrameRate
        {
            get { return frameRate; }
            set { frameRate = value;
                NotifyPropertyChanged("FrameRate");
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        
        
        public Model(ICommClient commClient)
        {
            this.commClient = commClient;
            stop = true;
        }

        public void connect(string ip, int port)
        {
            commClient.connect(ip, port);
        }

        public void disconnect()
        {
            stop = true;
            commClient.disconnect();
        }

        public void start(string file1)//initialize flight data
        {
            StreamReader reader = new StreamReader(file1);
            string currentline;
            int t = 0;//timing
            while ((currentline = reader.ReadLine()) != null)//save the flightData
            {
                csvData.Add(currentline);
                string[] args = currentline.Split(',');
                foreach(string arg in args)
                {
                    flightData.Add(new List<double>());
                    flightData[t].Add(Convert.ToDouble(arg));
                }
                t++;
            }
            
        }
        public void play()//send information
        {
            while (!stop)
            {
                
                if (this.Time >= this.TotalTime) {break; }
                this.Time++;
                commClient.send(csvData[Time]);//send info to flightgear
                Thread.Sleep((int)(1000 / (freq* FrameRate)));
            }

        }
        public Boolean getStop()
        {
            return this.Stop;
        }
        public void setStop(Boolean b)
        {
            this.Stop = b;
        }
        
    }
}
