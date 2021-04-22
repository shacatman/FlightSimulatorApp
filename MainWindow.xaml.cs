using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel vm;
        Thread t;
        public MainWindow(ViewModel vm)
        {
            InitializeComponent();
            this.vm = vm ?? throw new ArgumentNullException(nameof(vm));
            string[] comboarr = new[] { "0.5", "1", "1.5", "2" };
            cbox.ItemsSource = comboarr;
            
            this.DataContext = vm;
        }




        private void PlayButton_Click(object sender, RoutedEventArgs e)//start/stop time
        {
            if (!vm.VM_Stop)//stop the time-makes button red
            {
                Button b = sender as Button;
                b.Background = Brushes.Red;
                vm.VM_Stop=true;
            }
            else//start the time-makes button green
            {
                //play button
                Button b = sender as Button;
                b.Background = Brushes.LawnGreen;
                //open thread
                vm.VM_Stop=false;
                t= new Thread(new ThreadStart(vm.play));
                t.Start();
            }
        }

        private void cbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double citem =  Convert.ToDouble(cbox.SelectedValue);
            vm.VM_FrameRate = citem;
        }
    }
}
