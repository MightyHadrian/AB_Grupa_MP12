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
using Logika;

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logic BallList = new Logic(760, 270);
        public MainWindow()
        {
            InitializeComponent();
            BallCanvasControl.ItemsSource = BallList.Objects;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            BallList.Objects.Clear();
            int ballcount = Convert.ToInt32(BallCountInput.Text);
            for(;ballcount>0; ballcount--)
            {
                BallList.addBall();
            }
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Stop!!");
        }
    }
}
