namespace Dane
{
    
    public abstract class Data 
    {
        
        public abstract void addBall();
        public abstract void delBall(int index);
        public abstract void resetBalls();
        public abstract void setBallX(int index, int value);
        public abstract void setBallY(int index, int value);
        public abstract void setBallVelocity(int index, double value);
        public abstract void setBallKinEnergy(int index, double value);
        public abstract int getBallID(int index);
        public abstract int getBallX(int index);
        public abstract int getBallY(int index);
        public abstract double getBallVelocity(int index);
        public abstract double getBallMass(int index);
        public abstract double getBallKinEnergy(int index);

        public class Ball
        {
            private readonly int ID;
            private int X;
            private int Y;
            private double Velocity;
            private readonly double Mass;
            private double kinEnergy;

            public Ball(int ID, int X, int Y, double Mass, double Velocity, double kinEnergy)
            {
                this.ID = ID;
                this.X = X;
                this.Y = Y;
                this.Mass = Mass;
                this.Velocity = Velocity;
                this.kinEnergy = kinEnergy;
            }

            public void setX(int value)
            {
                this.X = value;
            }
            public void setY(int value)
            {
                this.Y = value;
            }
            public void setVelocity(double value)
            {
                this.Velocity = value;
            }
            public void setKinEnergy(double value)
            {
                this.kinEnergy = value;
            }
            public int getID()
            {
                return this.ID;
            }
            public int getX()
            {
                return this.X;
            }
            public int getY()
            {
                return this.Y;
            }
            public double getVelocity()
            {
                return this.Velocity;
            }
            public double getMass()
            {
                return this.Mass;
            }
            public double getKinEnergy()
            {
                return this.kinEnergy;
            }
        }
        
    }
    
}