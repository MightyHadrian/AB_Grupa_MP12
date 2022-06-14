using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public abstract class BallApi {
        public static BallApi Create(int ID, double X, double Y, double Mass, double VelocityX, double VelocityY)
        {
            return new Ball(ID, X, Y, Mass, VelocityX, VelocityY);
        }

        public abstract void objectMove();
        public abstract int objectID { get; }
        public abstract double objectX { get; set; }
        public abstract double objectY { get; set; }
        public abstract double objectVelocityX { get; set; }
        public abstract double objectVelocityY { get; set; }
        public abstract double objectMass { get; }

        public abstract event PropertyChangedEventHandler? PropertyChanged;
        internal class Ball : BallApi, INotifyPropertyChanged
        {
            private readonly int ID = 0;
            public double X;
            public double Y;
            public double VelocityX;
            public double VelocityY;
            private readonly double Mass = 0.0;
            public override event PropertyChangedEventHandler? PropertyChanged;

            public Ball(int ID, double X, double Y, double Mass, double VelocityX, double VelocityY)
            {
                this.ID = ID;
                this.X = X;
                this.Y = Y;
                this.Mass = Mass;
                this.VelocityX = VelocityX;
                this.VelocityY = VelocityY;
            }

            public override void objectMove()
            {
                X += VelocityX;
                Y += VelocityY;
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

            public override double objectVelocityX
            {
                get => VelocityX;
                set 
                { 
                    VelocityX = value; 
                }
            }

            public override double objectVelocityY
            {
                get => VelocityY;
                set
                {
                    VelocityY = value;
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
