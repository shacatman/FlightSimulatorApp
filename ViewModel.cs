using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSimulatorApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ModelInterface model;
        public ViewModel(ModelInterface model)
        {
            this.model = model;
            model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e)
                {
                    NotifyPropertyChanged("VM_" + e.PropertyName);
                };
            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public void start(string file1)
        {
            this.model.start(file1);
            this.model.connect("127.0.0.1", 5400);
        }
        public void play()
        {
            this.model.play();
        }
        public Boolean getStop()
        {
            return this.model.getStop();
        }
        public void setStop(Boolean b)
        {
            this.model.setStop(b);
        }
        //properties
        public int VM_Time
        {
            get { return model.Time;}
            set { model.Time=value;}
        }
        public Boolean VM_Stop
        {
            get { return model.Stop; }
            set { model.setStop(value); }
        }
        public List<List<double>> VM_FlightData
        {
            get { return model.FlightData; }
        }
        public List<double> VM_TimedData
        {
            get { return model.TimedData; }
        }
        public int VM_TotalTime
        {
            get { return model.TotalTime; }
        }
        public double VM_FrameRate
        {
            get { return model.FrameRate; }
            set { model.FrameRate = value; }
        }
        public int VM_JoystickX
        {
            get { return (int)(model.TimedData[0] * 50) + 110; }
        }
        public int VM_JoystickY
        {
            get { return -(int)(model.TimedData[1] * 50) + 85; }
        }
    }
}
