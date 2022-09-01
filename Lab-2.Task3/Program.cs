namespace Lab_2.Task3
{
    internal class Program
    {
        public static uint a_main = 0b011110100100000000000000;
        public static uint b_main = 0b010000010000000000000000;
        public static uint a_exponenta = 0b10000101;
        public static uint b_exponenta = 0b10000010;
        public static uint a_znack = 0;
        public static uint b_znack = 0;
        public static uint fin_znack = 0;

        static void Main(string[] args)
        {

            Console.Write("a = ");
            float a = float.Parse(Console.ReadLine());
            uint A = (uint)BitConverter.SingleToInt32Bits(a);

            Console.Write("b = ");
            float b = float.Parse(Console.ReadLine());
            uint B = (uint)BitConverter.SingleToInt32Bits(b);
            Console.WriteLine();
            a_znack = A >> 31;
            b_znack = B >> 31;

            a_exponenta = (A >> 23) & 0xFF;
            b_exponenta = (B >> 23) & 0xFF;
            a_main = A & 0x007FFFFF;
            b_main = B & 0x007FFFFF;


            fin_znack = a_znack ^ b_znack;
            Console.WriteLine("Результуючий біт знаку= " + Convert.ToString(fin_znack, 2)); // 1 - мінус; 0 - плюс
            uint exp = a_exponenta + b_exponenta - 0x7F;
            Console.WriteLine("Основна експонента результату: (" + Convert.ToString(a_exponenta, 2) + " ) + ( " + Convert.ToString(b_exponenta, 2) + " ) = ( " + Convert.ToString(exp, 2) + " )");
            a_main |= 0x00800000; // побітове або
            b_main |= 0x00800000;
            ulong zFrac = (ulong)a_main * (ulong)b_main;

            uint zFrac0 = (uint)(zFrac >> 24);


            Console.WriteLine("Основна мантиса: (" + Convert.ToString(a_main, 2) + " ) * ( " + Convert.ToString(b_main, 2) + " )  = ( " + Convert.ToString((long)zFrac, 2) + " )");
            Console.WriteLine("Нормалізований результат");
            if (zFrac0 >> 22 == 0b1)
            {
                Console.WriteLine("Результуюча мантиса 1, тому Мантиса зсувається вліво на одиницю");
                zFrac0 &= 0x3FFFFF;

                zFrac0 <<= 1;
            }
            else
            {
                Console.WriteLine("Результуюча мантиса  0, тому додаємо до експоненти 1");
                zFrac0 &= 0x3FFFFF;
                exp++;
            }
            Console.WriteLine("\n");
            Console.WriteLine("Результат");
            Console.WriteLine("Знак: " + Convert.ToString(fin_znack, 2));
            Console.WriteLine("Експонента: " + Convert.ToString(exp, 2));
            Console.WriteLine("Мантиса: " + Convert.ToString(zFrac0, 2));
            uint final = zFrac0 + (exp << 23) + (fin_znack << 31);
            float c = BitConverter.Int32BitsToSingle((int)final);
            Console.WriteLine("Кінцевий десятковий результат " + c);

        }

    }
}