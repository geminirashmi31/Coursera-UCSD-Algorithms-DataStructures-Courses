using System;
using System.Collections.Generic;

namespace KnapsackWithoutRepetitions
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(' ');
            int knapsackCapacity = Convert.ToInt32(inputs[0]);
            int goldBarsCount = Convert.ToInt32(inputs[1]);

			string[] numStr = Console.ReadLine().Split(' ');
            int[] nums = new int[goldBarsCount];

			for (int i = 0; i < numStr.Length; i++)
			{
				nums[i] = Convert.ToInt32(numStr[i]);
			}

            var result = MaximizeGoldValue(knapsackCapacity, nums);
            Console.WriteLine(result);
                
		}

        public static int MaximizeGoldValue(int knapsackWeight, int[] goldBarsWeight)
        {
            // rows: Weights; cols: Items
            int[,] mat = new int[knapsackWeight + 1, goldBarsWeight.Length + 1];

            // Base case: 0 weight- Intiaize 1st row (index 0, i) 
			for (int i = 0; i < goldBarsWeight.Length + 1; i++)
				mat[0, i] = 0;

            // Base case: 0 item - Initialize 1st column (index j, 0)
			for (int j = 0; j < knapsackWeight + 1; j++)
                mat[j, 0] = 0;

            for (int i = 1; i < goldBarsWeight.Length + 1; i++)
            {

                for (int w = 1; w <= knapsackWeight; w++)
                {
                    mat[w, i] = mat[w, i - 1];

                    int wi = goldBarsWeight[i - 1];
                    if(wi <= w)
                    {
                        int val = mat[w - wi, i - 1] + wi;

                        if (mat[w, i] < val)
                            mat[w, i] = val;
                    }
                }
            }

            return mat[knapsackWeight, goldBarsWeight.Length];
		}
    }
}
