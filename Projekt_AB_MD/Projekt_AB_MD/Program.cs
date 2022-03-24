namespace TestProgram {

    public class Modulo
    {
        // Funkcja zwraca 0 jak liczba nie jest podzielna przez 2, zwraca 1 jak liczba jest podzielna
        public int Calculate(int number)
        {
            if (number % 2 != 0)
                return 0;
            else
                return 1;
        }
    }

    public class Test {
        public static void Main()
        {
            int number;
            Console.WriteLine("Podaj dowolną wartość aby sprawdzić jej podzielność przez 2: ");
            number = Console.Read();
            Modulo m = new Modulo();
            if (m.Calculate(number) == 0)
                Console.WriteLine("Podana liczba nie jest podzielna!");
            else
                Console.WriteLine("Podana liczba jest podzielna.");
        }
    }
}