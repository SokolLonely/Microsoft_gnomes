using System;

namespace _22_Гномы
{
    internal class Program
    {
        static void output_line(int line, int len)
        {
            int mask = 1;
            for (int i = 0; i < len; i++)
            {
                if ((line & mask) > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(1);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(0);
                }
                mask <<= 1;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

        }
        static int is_Even(ref int line, ref int len)
        {

            int mask = 1;
            int answer = 0;
            for (int i = 0; i < len; i++)
            {
                if ((mask & line) > 0)
                {
                    answer++;
                }
                mask <<= 1;
            }

            return answer % 2;
        }
        static int firstAnswer(ref int line, ref int len, out int count)
        {
            line >>= 1;
            int answer = is_Even(ref line, ref len);
            //Console.WriteLine(answer);
            string colour = (answer == 0) ? "Зелёный" : "Красный";
            int coin = (answer % 2 == (line & 1)) ? 1 : 0;
            count = coin;
            Console.WriteLine($"1-й гном ответил {colour} и получил монеты ({coin}). Всего монет - {coin}");

            // output_line(line, len);
            return answer % 2;
        }

        static void writeAnswer(ref int even, ref int allCoins, ref int line, ref int len, int i)
        {
            line >>= 1;
            int result = is_Even(ref line, ref len);
            allCoins++;
            if (even == result)
            {
                Console.WriteLine($"{i}-й гном ответил Зелёный и получил монеты (1). Всего монет - {allCoins}");
            }
            else
            {
                Console.WriteLine($"{i}-й гном ответил Красный и получил монеты (1). Всего монет - {allCoins}");
                even = result;
            }
            //output_line(line, len);

        }
        static void Main(string[] args)
        {
            int numb;
            while (true)
            {
                Console.WriteLine("Введите число гномов");
                numb = Convert.ToInt32(Console.ReadLine());
                if (numb == 16 || numb == 32)
                { break; }
                else
                { Console.WriteLine("Число гномов должно быть равно 16 или 32"); }
            }

            Console.WriteLine("Введите число представляющее гномов");
            int line = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("1234567890123456");
            output_line(line, numb);
            int coins;
            int even = firstAnswer(ref line, ref numb, out coins);
            for (int i = 2; i <= numb; i++)
            {
                writeAnswer(ref even, ref coins, ref line, ref numb, i);

            }
            //Console.WriteLine(is_Even(ref line, ref numb));
            Console.ReadLine();
        }
    }
}
