using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public abstract class Obiekt {
        public static Obiekt newBall(int ID, int X, int Y, double Mass, double Velocity)
        {
            return new Ball(ID, X, Y, Mass, Velocity);
        }

        public abstract void objectMove();
        public abstract int objectID { get; }
        public abstract double objectX { get; set; }
        public abstract double objectY { get; set; }
        public abstract double objectVelocity { get; set; }
        public abstract double objectMass { get; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;
        internal class Ball : Obiekt, INotifyPropertyChanged
        {
            private readonly int ID = 0;
            public double X;
            public double Y;
            public double Velocity;
            private readonly double Mass = 0.0;

            public override event PropertyChangedEventHandler? PropertyChanged;

            public Ball(int ID, int X, int Y, double Mass, double Velocity)
            {
                this.ID = ID;
                this.X = X;
                this.Y = Y;
                this.Mass = Mass;
                this.Velocity = Velocity;
            }
            public override void objectMove()
            {
                X += Velocity;
                Y += Velocity;
            }

            public override int objectID
            {
                get => ID; 
            }

            public override double objectX
            {
                get => X;
                set
                {
                    X = value;
                    OnPropertyChanged();
                }
            }

            public override double objectY
            {
                get => Y;
                set
                {
                    Y = value;
                    OnPropertyChanged();
                }
            }

            public override double objectVelocity
            {
                get => Velocity;
                set 
                { 
                    Velocity = value; 
                }
            }

            public override double objectMass
            {
                get => Mass;
            }

            protected void OnPropertyChanged([CallerMemberName] string name = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

    }

}
