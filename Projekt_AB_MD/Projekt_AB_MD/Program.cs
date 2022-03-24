namespace TestProgram {

    public class Modulo
    {
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