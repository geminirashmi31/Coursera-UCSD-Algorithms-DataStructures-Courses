using System;

namespace MaxPairwiseProduct
{
    class MaxPairwiseProduct
    {
        public static void Main(string[] args)
        {
            long size = Convert.ToInt32(Console.ReadLine());
            long [] num = new long [size];

            string[] numArr = Console.ReadLine().Split(' ');


            for (long k = 0; k < numArr.Length; k++)
            {
                num[k] = Convert.ToInt64(numArr[k]);
            }

            long proResult = getMaxPairwiseProduct(num);
            Console.WriteLine(proResult);

        }

        public static long getMaxPairwiseProduct(long[] arr)
        {
			int max_index1 = -1;
            for (int i = 0; i < arr.Length; i++)
				if ((max_index1 == -1) || (arr[i] > arr[max_index1]))
					max_index1 = i;

			int max_index2 = -1;
            for (int j = 0; j < arr.Length; ++j)
				if ((j != max_index1) && ((max_index2 == -1) || (arr[j] > arr[max_index2])))
					max_index2 = j;

			return ((long)(arr[max_index1])) *arr[max_index2];
        }
    }
}

