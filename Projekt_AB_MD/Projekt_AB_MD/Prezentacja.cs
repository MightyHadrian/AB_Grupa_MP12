using Logika;

namespace Prezentacja {

    public class Presentation {
        public static void Main()
        {
            int number;
            Console.WriteLine("Podaj dowolną wartość aby sprawdzić jej podzielność przez 2: ");
            number = Console.Read();

            if (Logic.Calculate(number) == 0)
                Console.WriteLine("Podana liczba nie jest podzielna!");
            else
                Console.WriteLine("Podana liczba jest podzielna.");
        }
    }
}