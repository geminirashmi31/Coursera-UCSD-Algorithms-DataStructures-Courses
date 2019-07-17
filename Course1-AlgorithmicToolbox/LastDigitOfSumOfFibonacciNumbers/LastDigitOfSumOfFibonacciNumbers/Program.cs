using System;
using System.Collections.Generic;

namespace LastDigitOfSumOfFibonacciNumbers
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] numStr = Console.ReadLine().Split(' ');
            int[] nums = new int[numStr.Length];

            for (int i = 0; i < numStr.Length; i++)
            {
                nums[i] = Convert.ToInt32(numStr[i]);
            }
            int num = nums[0];
			int fibonacci = SumFibonacci(num);
			Console.WriteLine(fibonacci);
        }

        public static int SumFibonacci(int n)
        {
			if (n <= 1)
			{
				return n;
			}
			int f0 = 0;
			int f1 = 1;
			int result = 0;

			List<int> list = new List<int>();
			list.Add(f0 % 10);
			list.Add(f1 % 10);


            int sumLastDigit = (f0 + f1) % 10;

			for (int i = 2; i <= n; i++)
			{
				result = (f0 + f1) % 10;
				f0 = f1;
				f1 = result;
				list.Add(result);

                sumLastDigit = (sumLastDigit + result) % 10;


				if (HasRepeatingSequence(list) == true)
				{
					int sequenceLength = list.Count / 2;

                    // step 1: compute sum of repeating sequence
                    int sequenceSum = 0;
                    for (int j = 0; i < sequenceLength; i++){
                        sequenceSum += list[j];
                    }

                    // step 2: find quotient and remainder w.r.t. n (m = 10 for last digit)
                    int quotient = n / 10;
                    int remainder = n % 10;

                    // step 3: compute sum of last digits for n fibonacci numbers
                    int quotientSumLastDigit = (sequenceSum * quotient) % 10;

                    int remainderSumLastDigit = 0;
                    for (int k = 0; k <= remainder; k++){
                        remainderSumLastDigit = (remainderSumLastDigit + list[k]) % 10;
                    }

                    int valueLastDigit = (quotientSumLastDigit + remainderSumLastDigit) % 10;
                    return valueLastDigit;
				}
			}

            return sumLastDigit;
        }

		private static bool HasRepeatingSequence(List<int> list)
		{
			if (list.Count % 2 == 1)
			{
				return false;
			}

			int l = list.Count;
			int d = l / 2;

			for (int i = 0; i < d; i++)
			{
				int j = d + i;
				if (list[i] != list[j])
				{
					return false;
				}
			}

			return true;
		}
    }
}
