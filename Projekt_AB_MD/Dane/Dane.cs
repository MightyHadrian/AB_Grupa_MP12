namespace Dane
{
    
    public class Data {
        private int ID;
        private int X;
        private int Y;
        private double Speed;
        public Data(int ID, int X, int Y, double Speed) { 
            this.ID = ID;
            this.X = X;
            this.Y = Y; 
            this.Speed = Speed;
        }

        public void setX(int X) 
        {
            this.X = X;
        }
        public void setY(int Y) 
        {
            this.Y = Y;
        }
        public void setSpeed(double Speed) 
        {
            this.Speed = Speed;
        }
        public int getX()
        {
            return X;
        }
        public int getY()
        {
            return Y;
        }
        public double getSpeed()
        {
            return Speed;
        }

    }
    
}