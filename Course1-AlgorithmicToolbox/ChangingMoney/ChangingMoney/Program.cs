using System;

namespace ChangingMoney
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            int[] coins = ChangingMoneyCoins(input);
            int sum = 0;
            for (int i = 0; i < coins.Length; i++)
            {
                sum += coins[i];
            }

            Console.WriteLine(sum);
        }

        public static int[] ChangingMoneyCoins(int value)
        {
            int res1 = value / 10;
            int rem1 = value % 10;
            int res2 = rem1 / 5;
            int rem2 = rem1 % 5;
            int res3 = rem2 / 1;

            int[] array = new int[3];
            array[0] = res1;
            array[1] = res2;
            array[2] = res3;

            return array;
        }
    }
}
