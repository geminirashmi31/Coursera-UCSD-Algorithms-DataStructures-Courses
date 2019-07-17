using System;
using System.Collections.Generic;

namespace MaximizingLootValue
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var inputs = Console.ReadLine().Split(' ');
            int itemCount = Convert.ToInt32(inputs[0]);
            int bagCapacity = Convert.ToInt32(inputs[1]);

            List<Item> itemList = new List<Item>();

            for (int i = 0; i < itemCount; i++){
                string[] itemInput = Console.ReadLine().Split(' ');
                double itemValue = Convert.ToDouble(itemInput[0]);
                int itemWeight = Convert.ToInt32(itemInput[1]);

                var item = new Item(itemValue, itemWeight);
                itemList.Add(item);
            }

            var result = MaxLoot(itemList, bagCapacity);
            Console.WriteLine(result);
        }

        public static double MaxLoot(List<Item> itemList, int bagWeight)
        {
            double amount = 0;
            itemList.Sort((x, y) =>
            {
                if (x.ValuePerWeight < y.ValuePerWeight)
                    return 1;
                else if (x.ValuePerWeight > y.ValuePerWeight)
                    return -1;
                else return 0;
            });


            for (int i = 0; i < itemList.Count; i++)
            {
                if (bagWeight <= 0)
                    continue;
                
                if(bagWeight >= itemList[i].Weight)
                {
                    amount += itemList[i].Value;
                    bagWeight -= itemList[i].Weight;
                }
				else if (bagWeight < itemList[i].Weight)
				{
					double part = (double)bagWeight / itemList[i].Weight;
					amount += part * itemList[i].Value;
                    bagWeight = 0;
				}
            }

            return amount;
        }
    }


	public class Item
	{
		public Item(double value, int weight)
		{
			this.Value = value;
			this.Weight = weight;
            this.ValuePerWeight = this.Value / this.Weight;
		}

        public double Value { get; }

		public int Weight { get; }

		public double ValuePerWeight { get; }
	}
}
