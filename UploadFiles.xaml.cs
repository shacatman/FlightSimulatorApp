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
using System.Windows.Shapes;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for UploadFiles.xaml
    /// </summary>
    public partial class UploadFiles : Window
    {
        private string file1;
        ViewModel vm;
        public string File1
        {
            get { return file1; }
            set { file1=value; }
        }

        
        public UploadFiles()//constructor
        {
            InitializeComponent();
            vm = new ViewModel(new Model(new CommClient()));
            this.DataContext = vm;
        }

        private void Upload1_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            bool? ishow = dialog.ShowDialog();
            if (ishow == true)
            {
                File1 = dialog.FileName;
                MessageBox.Show(File1);
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)//starts the simulator on a new MainWindow after choosing files
        {
            MainWindow flightsim = new MainWindow(vm);
            vm.start(File1);//send the files to the view model
            flightsim.Show();
            this.Close();
        }
    }
}
