using Dane;
using System.Numerics;

namespace Logika
{
    public class Logic
    {
        List<Data>? Balls;
        // Funkcja zwraca 0 jak liczba nie jest podzielna przez 2, zwraca 1 jak liczba jest podzielna
        private int genRandomInt()
        {
            Random random = new Random(); 
            return random.Next(150, 300);
        }
        private double genRandomDouble()
        {
            Random random = new Random();
            return random.NextDouble() * 10.0;
        }
        public void addBall()
        {
            Balls.Add(new Data(Balls.Count + 1, genRandomInt(), genRandomInt(), genRandomDouble()));
        }

        public void delBall(int index)
        {
            if(Balls != null)
                Balls.Remove(Balls.ElementAt(index));
        }
        public void resetBalls()
        {
            if (Balls != null)
            {
                int totalAmount = Balls.Count;
                Balls.Clear();
                for (int i = 0; i < totalAmount; i++)
                    addBall();
            }
        }
    }
}