using Dane;
using System.Collections.ObjectModel;

namespace Logika
{
    public abstract class LogicApi
    {
        public static LogicApi CreateLogic(int limitX, int limitY)
        {
            return new BallLogic(DataApi.Create(), limitX, limitY);
        }

        public abstract void Start();
        public abstract void Stop();
        public abstract void addObject();
        public abstract void delObject(int index);
        public abstract void resetObjects();
        public abstract void calcCollision(BallApi ballOne, BallApi ballTwo);
        public abstract bool ballCollision(double X, double Y);
        public abstract ObservableCollection<BallApi> getList();

        // Dodanie nowego obiektu, prędkość i masa losowo generowane, identyfikatorem jest ilość aktualnych kulek plus jeden
        internal class BallLogic : LogicApi
        {
            private DataApi Objects;
            private readonly int limitX;
            private readonly int limitY;

            public BallLogic(DataApi? data, int limitX, int limitY)
            {
                Objects = data ?? DataApi.Create();
                this.limitX = limitX;
                this.limitY = limitY;
            }

            public override void Start()
            {
                Objects.Start();
            }

            public override void Stop()
            {
                Objects.Stop();
            }

            public override void addObject()
            {
                try
                {
                    Objects.addBall(Objects.getBalls().Count + 1, genRandomInt(10, limitX), genRandomInt(5, limitY), genRandomDouble(), genRandomDouble(), genRandomDouble());
                }
                catch (Exception)
                {
                    throw new InvalidDataException("Error: addBall");
                }
            }

            // Usunięcie danego obiektu
            public override void delObject(int index)
            {
                try
                {
                    Objects.getBalls().RemoveAt(index);
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: delBall, index: " + index);
                }
            }

            // Wygenerowanie na nowo stworzonych obiektów
            public override void resetObjects()
            {
                try
                {
                    int i = Objects.getBalls().Count();
                    Objects = DataApi.Create();
                    for (; i > 0; i--)
                        Objects.addBall(i, genRandomInt(10, limitX), genRandomInt(5, limitY), genRandomDouble(), genRandomDouble(), genRandomDouble());
                }
                catch (Exception)
                {
                    throw new InvalidOperationException("Error: resetBalls");
                }
            }

            // Losowanie wartości całkowitej z danego przedziału
            private static int genRandomInt(int x, int y)
            {
                Random random = new();
                return random.Next(x, y);
            }

            // Losowanie wartości zmiennoprzecinkowej z przedziału [0, 1]
            private static double genRandomDouble()
            {
                Random random = new();
                return random.NextDouble() - 0.4;
            }

            // Obliczenie prędkości oraz energii po zderzeniu (zderzenie sprężyste, zasada zachowania pędu)
            public override void calcCollision(BallApi ballOne, BallApi ballTwo)
            {
                try
                {
                    double massOne = ballOne.objectMass, massTwo = ballTwo.objectMass;
                    double speedOneX = ballOne.objectVelocityX, speedTwoX = ballTwo.objectVelocityX;
                    double speedOneY = ballOne.objectVelocityY, speedTwoY = ballTwo.objectVelocityY;
                    double newSpeedOneX = (speedOneX * (massOne - massTwo) + 2 * massTwo * speedTwoX) / (massOne + massTwo);
                    double newSpeedOneY = (speedOneY * (massOne - massTwo) + 2 * massTwo * speedTwoY) / (massOne + massTwo);
                    double newSpeedTwoX = (speedTwoX * (massTwo - massOne) + 2 * massOne * speedOneX) / (massOne + massTwo);
                    double newSpeedTwoY = (speedTwoY * (massTwo - massOne) + 2 * massOne * speedOneY) / (massOne + massTwo);
                    ballOne.objectX = newSpeedOneX;
                    ballOne.objectY = newSpeedOneY;
                    ballTwo.objectX = newSpeedOneX;
                    ballTwo.objectY = newSpeedOneY;
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: calcCollision, ballOneID: " + ballOne.objectID + ", ballTwoID:" + ballTwo.objectID);
                }
            }

            public override bool ballCollision(double X, double Y)
            {
                foreach (BallApi ball in Objects.getBalls())
                {
                    double distance = Math.Sqrt((X - ball.objectX) * (X - ball.objectX) + (Y - ball.objectY) * (Y - ball.objectY));
                    if (distance <= 20)
                        return false;
                }
                return true;
            }

            // Settery dla danych obiektów
            public void setObjectX(BallApi ball, int value)
            {
                try
                {
                    ball.objectX = value;
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setObjectX, ballID: " + ball.objectID);
                }
            }
            public void setObjectY(BallApi ball, int value)
            {
                try
                {
                    ball.objectY = value;
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: setObjectY, ballID: " + ball.objectID);
                }
            }

            // Gettery dla danych obiektów
            public int getObjectID(BallApi ball)
            {
                try
                {
                    return ball.objectID;
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: getObjectID, ballID: " + ball.objectID);
                }
            }

            public double getObjectX(BallApi ball)
            {
                try
                {
                    return ball.objectX;
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: getObjectX, ballID: " + ball.objectID);
                }
            }
            public double getObjectY(BallApi ball)
            {
                try
                {
                    return ball.objectY;
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: getObjectY, ballID: " + ball.objectID);
                }
            }
            public double getObjectVelocityX(BallApi ball)
            {
                try
                {
                    return ball.objectVelocityX;
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: getObjectY, ballID: " + ball.objectID);
                }
            }
            public double getObjectVelocityY(BallApi ball)
            {
                try
                {
                    return ball.objectVelocityY;
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: getObjectY, ballID: " + ball.objectID);
                }
            }
            public double getObjectMass(BallApi ball)
            {
                try
                {
                    return ball.objectMass;
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: getObjectY, ballID: " + ball.objectID);
                }
            }

            public override ObservableCollection<BallApi> getList()
            {
                return Objects.getBalls();
            }

            // Sprawdza czy lista obiektów jest pusta (na potrzeby testów)
            public bool listEmpty()
            {
                if (Objects.getBalls().Count == 0)
                    return true;
                else
                    return false;
            }

        }

    }

}