using System;
using System.Collections.Generic;

namespace PrimitiveCalculator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            MinOperations(n);


        }

        private static void MinOperations(int n)
        {
            if(n == 1){
                Console.WriteLine(0);
                Console.WriteLine(1);

                return;
            }
            else if(n <= 3){
				Console.WriteLine(1);

                for (int k = 1; k <= n; k++){
                    Console.Write("{0} ", k);
                }

                return;
			}

            int[] operationCount = new int[n + 1];
            int[] prevIndex = new int[n + 1];

            operationCount[0] = 0;
            operationCount[1] = 0;
            operationCount[2] = 1;
            operationCount[3] = 1;

            prevIndex[1] = 1;
            prevIndex[2] = 1;
            prevIndex[3] = 1;

            for (int i = 4; i <= n; i++)
            {
                // case: +1
                int minCount = operationCount[i - 1];

                    prevIndex[i] = i-1;

				if (i % 2 == 0 && operationCount[i / 2] <= minCount)
				{
					minCount = operationCount[i / 2];
					    prevIndex[i] = i/2;
				}

                if (i % 3 == 0 && operationCount[i / 3] <= minCount)
				{
					minCount = operationCount[i / 3];

					    prevIndex[i] = i/3;
				}

                operationCount[i] = minCount + 1;
            }

            // Show count
            Console.WriteLine(operationCount[n]);

            // Show sequence
            var list = new List<int>();
            int c = n;

            do
            {
                list.Add(c);
                c = prevIndex[c];
            } while (c > 1);
            list.Add(1);

            list.Reverse();

            foreach(var item in list){
                Console.Write("{0} ", item);
            }

        }
    }
}
