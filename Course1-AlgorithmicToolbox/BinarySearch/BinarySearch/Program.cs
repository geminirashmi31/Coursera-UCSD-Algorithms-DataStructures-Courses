using System;

namespace BinarySearch
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] inputStr = Console.ReadLine().Split(' ');
            int itemCount = Convert.ToInt32(inputStr[0]);
            int[] nums = new int[itemCount];

            for (int i = 1; i < inputStr.Length; i++)
            {
                nums[i -1] = Convert.ToInt32(inputStr[i]);
            }

            string[] keyStr = Console.ReadLine().Split(' ');
            int keyCount = Convert.ToInt32(keyStr[0]);
            int[] keys = new int[keyCount];

            for (int j = 1; j < keyStr.Length; j++)
            {
                keys[j -1] = Convert.ToInt32(keyStr[j]);
            }

            for (int z = 0; z < keyCount; z++)
            {
                int bs = BinarySearch(keys[z], 0, nums.Length -1, nums);
                Console.Write(bs + " ");
            }
              
        }

         public static int BinarySearch(int x, int l, int r, int[] input)
          {
            if (l > r){
                return -1;
            }

            if(input[l] == x)
            {
                return l;
            }

            int m = (l + r) / 2;

            if(input[m] == x)
            {
                return m;
            }

            else if(x < input[m])
            {
                return BinarySearch(x, l, m -1, input);
            }

            else
            {
                return BinarySearch(x, m + 1, r, input);
            }
        }

    }
}
