using Dane;

namespace Logika
{
    public class Logic
    {
        public List<Data> Objects = new();

        // Dodanie nowego obiektu, prędkość i masa losowo generowane, identyfikatorem jest ilość aktualnych kulek plus jeden
        public void addBall()
        {
            try
            {
                double Speed = genRandomDouble();
                double Mass = genRandomDouble();
                Objects.Add(new Ball(Objects.Count + 1, genRandomInt(100, 700), genRandomInt(100, 700), Mass, Speed));
            }
            catch (Exception)
            {
                throw new InvalidDataException("Error: addBall");
            }
        }

        // Usunięcie danego obiektu
        public void delBall(int index)
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
        public void resetBalls()
        {
            if (Objects != null)
            {
                try
                {
                    int totalAmount = Objects.Count;
                    Objects.Clear();
                    for (int i = 0; i < totalAmount; i++)
                        addBall();
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

        // Losowanie wartości zmiennoprzecinkowej z przedziału [0, 1] * 10
        private static double genRandomDouble()
        {
            Random random = new();
            return random.NextDouble() * 10.0 + 0.1;
        }

        // Obliczanie energii kinetycznej obiektu
        public double calcKinEnergy(double x, double e)
        {
            return 0.5 * x * e;
        }

        // Obliczenie prędkości oraz energii po zderzeniu (zderzenie sprężyste, zasada zachowania pędu)
        public void calcCollision(int indexOne, int indexTwo)
        {
            try
            {
                double massOne = Objects.ElementAt(indexOne).objectMass, massTwo = Objects.ElementAt(indexTwo).objectMass;
                double speedOne = Objects.ElementAt(indexOne).objectVelocity, speedTwo = Objects.ElementAt(indexTwo).objectVelocity;
                double newSpeedOne = (speedOne * (massOne - massTwo) + 2 * massTwo * speedTwo) / (massOne + massTwo);
                double newSpeedTwo = (speedTwo * (massTwo - massOne) + 2 * massOne * speedOne) / (massOne + massTwo);
                Objects.ElementAt(indexOne).objectVelocity = newSpeedOne;
                Objects.ElementAt(indexTwo).objectVelocity = newSpeedTwo;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: calcCollision, indexOne: " + indexOne + ", indexTwo:" + indexTwo);
            }
        }

        // Settery dla danych obiektów
        public void setObjectX(int index, int value)
        {
            try
            {
                Objects.ElementAt(index).objectX = value;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: setObjectX, index: " + index);
            }
        }
        public void setObjectY(int index, int value)
        {
            try
            {
                Objects.ElementAt(index).objectY = value;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: setObjectY, index: " + index);
            }
        }

        // Gettery dla danych obiektów
        public int getObjectID(int index)
        {
            try
            {
                return Objects.ElementAt(index).objectID;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectID, index: " + index);
            }
        }

        public int getObjectX(int index)
        {
            try
            {
                return Objects.ElementAt(index).objectX;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectX, index: " + index);
            }
        }
        public int getObjectY(int index)
        {
            try
            {
                return Objects.ElementAt(index).objectY;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectY, index: " + index);
            }
        }
        public double getObjectVelocity(int index)
        {
            try
            {
                return Objects.ElementAt(index).objectVelocity;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectY, index: " + index);
            }
        }

        public double getObjectMass(int index)
        {
            try
            {
                return Objects.ElementAt(index).objectMass;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("Error: getObjectY, index: " + index);
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