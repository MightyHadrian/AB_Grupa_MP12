using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Dane
{
    public abstract class DataApi
    {
        // Klasa abstrakcyjna umożliwiająca stworzenie własnych funkcji zajmujących się daną strukturą
        public static DataApi Create()
        {
            return new Data();
        }
        public abstract void addBall(int ID, double X, double Y, double Mass, double VelocityX, double VelocityY);
        public abstract void Start();
        public abstract void Stop();
        public abstract ObservableCollection<BallApi> getBalls();

        internal class Data : DataApi
        {
            private readonly ObservableCollection<BallApi> Balls;
            private List<Thread> Threads = new();
            private static readonly object locker = new();
            private static readonly object barrier = new();
            private bool Moving = false;

            public Data()
            {
                Balls = new();
            }

            public override void addBall(int ID, double X, double Y, double Mass, double VelocityX, double VelocityY)
            {
                BallApi newBall = BallApi.Create(ID, X, Y, Mass, VelocityX, VelocityY);
                Balls.Add(newBall);

                Thread t = new Thread(() =>
                {
                    while (Moving)
                    {
                        //critical section
                        /*lock (locker)
                        {
                            Monitor.Enter(barrier);
                            newBall.objectMove();
                            Monitor.Exit(barrier);
                        }*/
                            newBall.objectMove();
                        Console.WriteLine("Movement: " + ID.ToString());
                            Thread.Sleep(1);
                    }
                });
                t.Name = ID.ToString();
                Threads.Add(t);
            }

            public override void Start()
            {
                foreach (Thread thread in Threads)
                    thread.Abort();

                Moving = true;
                foreach (Thread thread in Threads)
                    thread.Start();
            }

            public override void Stop()
            {
                Moving = false;
                foreach (Thread thread in Threads)
                    thread.Suspend();
            }

            public override ObservableCollection<BallApi> getBalls()
            {
                return Balls;
            }

        }

    }
    
}