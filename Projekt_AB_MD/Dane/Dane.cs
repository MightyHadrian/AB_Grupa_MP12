namespace Dane
{
    public abstract class Data 
    {
        // Klasa abstrakcyjna umożliwiająca stworzenie własnych funkcji zajmujących się daną strukturą
        public abstract int objectID { get; }
        public abstract int objectX { get; set; }
        public abstract int objectY { get; set; }
        public abstract double objectVelocity { get; set; }
        public abstract double objectMass { get; }
        
    }
    public class Ball : Data
    {
        private readonly int ID = 0;
        public int X;
        public int Y;
        public double Velocity;
        private readonly double Mass = 0.0;

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
            set { X = value; }
        }

        public override int objectY
        {
            get { return Y; }
            set { Y = value; }
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

    }

}