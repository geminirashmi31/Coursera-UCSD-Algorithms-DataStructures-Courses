using System;

namespace lcm
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			string[] numStr = Console.ReadLine().Split(' ');
			long[] nums = new long[numStr.Length];

			for (long i = 0; i < numStr.Length; i++)
			{
                nums[i] = Convert.ToInt64(numStr[i]);
			}

            long num1 = nums[0];
            long num2 = nums[1];

            //int result = Gcd(num1, num2);
            long result = Lcm(num1, num2);
			Console.WriteLine(result);
		}

        public static long Gcd(long a, long b)
		{
            long res;
			if (b == 0)
			{
				return a;
			}

            long rem = a % b;
			if (rem > b)
			{
				res = Gcd(rem, b);
			}
			else
			{
				res = Gcd(b, rem);
			}

			return res;
		}

        public static long Lcm(long a, long b)
        {
            long result = Gcd(a, b);
            long lcm = (a * b) / result;
            return lcm;
        }
	}
}

