using Dane;
using System.Collections.ObjectModel;

namespace Logika
{
    public abstract class LogicApi
    {
        public static LogicApi CreateLogic(DataApi? data, int limitX, int limitY)
        {
            return new BallLogic(data ?? DataApi.Create(), limitX, limitY);
        }

        public abstract void addObject();
        public abstract void delObject(int index);
        public abstract void resetObjects();
        public abstract void calcCollision(BallApi ballOne, BallApi ballTwo);

        // Dodanie nowego obiektu, prędkość i masa losowo generowane, identyfikatorem jest ilość aktualnych kulek plus jeden
        internal class BallLogic : LogicApi
        {
            public ObservableCollection<DataApi> Objects;
            private readonly int limitX;
            private readonly int limitY;

            public BallLogic(DataApi? data, int limitX, int limitY)
            {
                Objects.Add(data ?? DataApi.Create());
                this.limitX = limitX;
                this.limitY = limitY;
            }

            public override void addObject()
            {
                try
                {
                    DataApi data = DataApi.Create();
                    data.addBall(Objects.Count + 1, genRandomInt(10, limitX), genRandomInt(5, limitY), genRandomDouble(), genRandomDouble(), genRandomDouble());
                    Objects.Add(data);
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
                    Objects.RemoveAt(index);
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException("Error: delBall, index: " + index);
                }
            }

            // Wygenerowanie na nowo stworzonych obiektów
            public override void resetObjects()
            {
                if (Objects != null)
                {
                    try
                    {
                        DataApi data;
                        int totalAmount = Objects.Count;
                        Objects.Clear();
                        for (int i = 0; i < totalAmount; i++) {
                            data = DataApi.Create();
                            data.addBall(Objects.Count + 1, genRandomInt(10, limitX), genRandomInt(5, limitY), genRandomDouble(), genRandomDouble(), genRandomDouble());
                            Objects.Add(data);
                        }
                    }
                    catch (Exception)
                    {
                        throw new InvalidOperationException("Error: resetBalls");
                    }
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

            // Sprawdza czy lista obiektów jest pusta (na potrzeby testów)
            public bool getListStatus()
            {
                if (Objects.Count == 0)
                    return true;
                else
                    return false;
            }

        }

    }

}