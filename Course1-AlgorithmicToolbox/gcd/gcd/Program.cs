using System;

namespace gcd
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] numStr = Console.ReadLine().Split(' ');
            int[] nums = new int[numStr.Length];

            for (int i = 0; i < numStr.Length; i++){
                nums[i] = Convert.ToInt32(numStr[i]);
            }

            int num1 = nums[0];
            int num2 = nums[1];

            int result = Gcd(num1, num2);
            Console.WriteLine(result);
        }

        public static int Gcd(int a, int b)
        {
            int res;
            if(b == 0)
            {
                return a;
            }

            int rem = a % b;
            if(rem > b)
            {
                res = Gcd(rem, b);
            }

            else
            {
                res = Gcd(b, rem);
            }

            return res;

        }
    }
}
