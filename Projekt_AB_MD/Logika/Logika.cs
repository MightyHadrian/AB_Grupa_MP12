using Dane;

namespace Logika
{
    public class Logic
    {
        // Funkcja zwraca 0 jak liczba nie jest podzielna przez 2, zwraca 1 jak liczba jest podzielna
        public static int Calculate(int number)
        {
            if (number % 2 != 0)
                return 0;
            else
                return 1;
        }
    }
}