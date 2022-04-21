using Dane;

namespace Logika
{
    public class Logic : Data
    {
        private List<Ball>? Balls;
        private static int genRandomInt(int x, int y)
        {
            Random random = new Random(); 
            return random.Next(x, y);
        }
        private static double genRandomDouble()
        {
            Random random = new Random();
            return random.NextDouble() * 10.0;
        }
        private static double calcKinEnergy(double x, double e)
        {
            return 0.5 * x * e;
        }

        public override void addBall()
        {
            try
            {
                double Speed = genRandomDouble();
                double Mass = genRandomDouble();
                Balls.Add(new Ball(Balls.Count + 1, genRandomInt(150, 300), genRandomInt(150, 300), Mass, Speed, calcKinEnergy(Mass, Speed)));
            }
            catch (Exception)
            {
                throw new InvalidDataException("Error: addBall");
            }
        }

        public override void delBall(int index)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.RemoveAt(index);
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: delBall, index: " + index);
                }
            }
        }

        public override void resetBalls()
        {
            if (Balls != null)
            {
                try
                {
                    int totalAmount = Balls.Count;
                    Balls.Clear();
                    for (int i = 0; i < totalAmount; i++)
                        addBall();
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Error: resetBalls");
                }
            }
        }

        public override void setBallX(int index, int value)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.ElementAt(index).setX(value);
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallX, index: " + index + ", value: " + value);
                }
            }
        }

        public override void setBallY(int index, int value)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.ElementAt(index).setY(value);
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallY, index: " + index + ", value: " + value);
                }
            }
        }

        public override void setBallVelocity(int index, double value)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.ElementAt(index).setVelocity(value);
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallVelocity, index: " + index + ", value: " + value);
                }
            }
        }
        public override void setBallKinEnergy(int index, double value)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.ElementAt(index).setKinEnergy(value);
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallKinEnergy, index: " + index + ", value: " + value);
                }
            }
        }
        public override int getBallID(int index)
        {
            if (Balls != null)
            {
                try
                {
                    return Balls.ElementAt(index).getID();
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallX, index: " + index);
                }
            }
            return -1;
        }

        public override int getBallX(int index)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.ElementAt(index).getX();
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallX, index: " + index);
                }
            }
            return -1;
        }

        public override int getBallY(int index)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.ElementAt(index).getY();
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallX, index: " + index);
                }
            }
            return -1;
        }

        public override double getBallVelocity(int index)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.ElementAt(index).getVelocity();
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallX, index: " + index);
                }
            }
            return 0;
        }

        public override double getBallMass(int index)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.ElementAt(index).getMass();
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallX, index: " + index);
                }
            }
            return -1;
        }

        public override double getBallKinEnergy(int index)
        {
            if (Balls != null)
            {
                try
                {
                    Balls.ElementAt(index).getKinEnergy();
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setBallX, index: " + index);
                }
            }
            return -1;
        }

    }
}