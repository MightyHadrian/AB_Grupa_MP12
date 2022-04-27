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

namespace GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Ellipse newBall = new Ellipse();
            newBall.Width = 10;
            newBall.Height = 10;
            newBall.Stroke = new SolidColorBrush(Colors.Black);
            newBall.StrokeThickness = 1;
            Canvas.SetLeft(newBall, 250);
            Canvas.SetTop(newBall, 0);
            BallCanvas.Children.Add(newBall);
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Stop!!");
        }
    }
}
