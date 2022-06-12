using System;
using System.Windows;
using System.Windows.Threading;
using Logika;

namespace Prezentacja
{
    /// <summary>
    /// Model interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LogicApi BallList = LogicApi.CreateLogic(760, 450);
        private readonly Action execute;
        public MainWindow()
        {
            InitializeComponent();
            BallCanvasControl.ItemsSource = BallList.getList();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            BallList.getList().Clear();
            for(int ballCount = Convert.ToInt32(BallCountInput.Text); ballCount > 0; ballCount--)
                BallList.addObject();

            Dispatcher.Run();
            //this.Activate();
            //this.execute();
            Console.ReadLine();
            BallList.Start();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            BallList.resetObjects();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
