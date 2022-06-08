using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    internal class Ball : Data
    {
        private readonly int ID = 0;
        public int X;
        public int Y;
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

        public override int objectID
        {
            get { return ID; }
        }

        public override int objectX
        {
            get { return X; }
            set
            {
                X = value;
                OnPropertyChanged();
            }
        }

        public override int objectY
        {
            get { return Y; }
            set
            {
                Y = value;
                OnPropertyChanged();
            }
        }

        public override double objectVelocity
        {
            get { return Velocity; }
            set { Velocity = value; }
        }

        public override double objectMass
        {
            get { return Mass; }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }

}
