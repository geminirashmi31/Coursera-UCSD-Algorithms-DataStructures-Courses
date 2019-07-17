using System;

namespace MajorityElement
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            string[] numStr = Console.ReadLine().Split(' ');
            int[] nums = new int[size];

            for (int i = 0; i < numStr.Length; i++)
            {
                nums[i] = Convert.ToInt32(numStr[i]);
            }

            MergeSorting(nums, 0, numStr.Length - 1);
            // PrintArray(nums);

            var hasMajority = ContainsMajority(nums);
            var result = hasMajority ? 1 : 0;

            Console.WriteLine(result);
        }

        public static void Merge(int[] arr, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1; // including arr[m]
            int n2 = r - m; // excluding arr[m]

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (i = 0; i < n1; i++)
            {
                L[i] = arr[l + i];
            }

            for (j = 0; j < n2; j++)
            {
                R[j] = arr[m + 1 + j];
            }

            i = 0;
            j = 0;
            k = l;

            while(i < n1 && j < n2)
            {
                if(L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }

                else
                {
                    arr[k] = R[j];
                    j++;
                }

                k++;
            }

            while(i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while(j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        public static void MergeSorting(int[]arr, int l, int r)
        {
            if(l < r)
            {
                int m = (l + r) / 2;
                MergeSorting(arr, l, m);
                MergeSorting(arr, m+1, r);
                Merge(arr, l, m, r);
            }

        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

		
			
       private static bool ContainsMajority(int[] arr){

            int globalMax = 0;
            int majorityCount = arr.Length / 2;

            int currentMax = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == arr[i - 1])
                {
                    currentMax++;
                }
                else
                {
                    currentMax = 1;
                }

				if (currentMax > globalMax)
				{
					globalMax = currentMax;
				}
            }



            return globalMax > majorityCount;
        }
    }
}
