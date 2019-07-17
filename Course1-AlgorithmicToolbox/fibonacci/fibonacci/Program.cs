using System;

namespace fibonacci
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine());
            int fibonacci = Fibonacci(number);
            Console.WriteLine(fibonacci);
        }


        static int Fibonacci(int num)
        {
            int f0 = 0;
            int f1 = 1;
            int result = 0;
            if(num > 1)
            {
				for (int i = 2; i <= num; i++)
				{
                    result = (f0 + f1) % 10;
                    f0 = f1;
                    f1 = result;

				}
            }
            else if(num == 0)
            {
                result = f0;
            }
            else if(num == 1)
            {
                result = f1;
            }

            return result;
        }
    }
}
