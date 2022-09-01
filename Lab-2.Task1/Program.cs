namespace Lab_2.Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, input the first number: ");
            var firstNumber = Console.ReadLine();
            Console.WriteLine("And now, enter the second: ");
            var secondNumber = Console.ReadLine();
            Multiplication(firstNumber, secondNumber);
            Console.ReadKey();
        }

        public static void Multiplication(string firstNumber, string secondNumber)
        {
            Int64 multiplicand, multiplier, product = 0, startMultiplicand, startMultiplier;
            startMultiplicand = multiplicand = Int32.Parse(firstNumber);
            startMultiplier = multiplier = Int32.Parse(secondNumber);
            for (int i = 0; i < 32; ++i)
            {
                Console.WriteLine("The step № " + (i + 1) + ":\n");

                Console.WriteLine("Multiplicand:\n" + FinishStringWithZeros(Convert.ToString(multiplicand, 2)) +
                    "\nMultiplier:\n" + FinishStringWithZeros(Convert.ToString(multiplier, 2)) + "\n");

                short lsb = (short)(multiplier & 1);

                if (lsb == 1)
                {
                    Console.WriteLine("Add multiplicand and product.\n");
                    product += multiplicand;
                }
                Console.WriteLine("Product:\n" + FinishStringWithZeros(Convert.ToString(product, 2)) + "\n");
                Console.WriteLine("Shift multiplicand left");
                Console.WriteLine("Shift multiplier right");

                multiplicand <<= 1;
                multiplier >>= 1;
            }

            Console.WriteLine("\n" + FinishStringWithZeros(Convert.ToString(startMultiplicand, 2)) +
                "\nx\n" +
                FinishStringWithZeros(Convert.ToString(startMultiplier, 2)) +
                "\n=\n" +
                FinishStringWithZeros(Convert.ToString(product, 2)) + "\n");

            Console.WriteLine(startMultiplicand + " x " + startMultiplier + " = " + product);
        }

        static string FinishStringWithZeros(string val)
        {
            var count = 64 - val.Length;
            var head = "";
            for (int i = 0; i < count; ++i)
                head += "0";
            return head + val;
        }
    }
}