using System;

namespace MaxPairwiseProduct
{
    class MaxPairwiseProduct
    {
        public static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int[] num = new int[size];

            string[] numArr = Console.ReadLine().Split(' ');


            for (int k = 0; k < numArr.Length; k++)
            {
                num[k] = Convert.ToInt32(numArr[k]);
            }

            int proResult = getMaxPairwiseProduct(num);
            Console.WriteLine(proResult);

        }

        public static int getMaxPairwiseProduct(int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] * arr[j] > result)
                    {
                        result = arr[i] * arr[j];
                    }
                }
            }
            return result;
        }
    }
}

