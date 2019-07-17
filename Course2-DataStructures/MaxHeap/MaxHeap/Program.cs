using System;

namespace MaxHeap
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*MaxHeaps mh = new MaxHeaps(8);
            mh.Insert(2);
            mh.Insert(6);
            mh.Insert(5);
            mh.Insert(4);
            mh.Insert(1);
            int res =  mh.ExtractMax();
            Console.WriteLine("result {0}", res);*/

            MaxHeapDerived mhp = new MaxHeapDerived();
            mhp.Add(2);
            mhp.Add(6);
            mhp.Add(5);
            mhp.Add(4);
            mhp.Add(1);

            int result = mhp.Pop();
            Console.WriteLine("result {0}", result);

            MinHeap minH = new MinHeap();
            minH.Add(2);
            minH.Add(6);
            minH.Add(5);
            minH.Add(4);
            minH.Add(1);

            int minHeapResult = minH.Pop();
            Console.WriteLine("Minheap result {0}", minHeapResult);

        }
    }
}


   /* public class MaxHeaps
    {
        int[] Array { get; set; }
        int heapSize;
        int capacity;

        public MaxHeaps(int capacity)
        {
            this.heapSize = 0;
            this.Array = new int[capacity];
            this.capacity = capacity;
        }

        private int Parent(int i)
        {
            return (i - 1) / 2;
        }

        private int LeftChild(int i)
        {
            return (2 * i + 1);
        }

        private int RightChild(int i)
        {
            return (2 * i + 2);
        }

        // TODO: Check if swap is effective for array
        private void Swap(int i, int j)
        {
            int temp = Array[i];
            Array[i] = Array[j];
            Array[j] = temp;
        }


        private void Siftdown(int i)
        {
            int index = 0;
            while (LeftChild(i))
            {
                int largerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index) > leftChild(index))
                {
                    largerChildIndex = getRightChildIndex(index);
                }

                if (Nodes[largerChildIndex] > Nodes[index])
                    swap(index, largerChildIndex);
                else
                    break;
                index = largerChildIndex;
            }
            int maxIndex = i;
            int l = LeftChild(i);
            int r = RightChild(i);

            if ((l <= heapSize) && (Array[l] > Array[maxIndex]))
            {
                maxIndex = l;
            }
            else
            {
                maxIndex = i;
            }

            if ((r <= heapSize) && (Array[r] > Array[maxIndex]))
            {
                maxIndex = r;
            }

            if (i != maxIndex)
            {
                Swap(i, maxIndex);
                Siftdown(maxIndex);
            }

            //Console.WriteLine(maxIndex);
        }

        private void Siftup(int i)
        {
            i = heapSize - 1;
            while ((i > 0) && (Array[Parent(i)] < Array[i]))
            {
                Swap(Array[i], Array[Parent(i)]);
                i = Parent(i);
            }

        }

        public int ExtractMax()
        {
            int result = Array[0];
            Array[0] = Array[heapSize -1];
            heapSize = heapSize - 1;
            Siftdown(0);
            return result;
        }

        public void Insert(int p)
        {
            if (heapSize == capacity)
            {
                return;
            }

            heapSize++;
            Array[heapSize - 1] = p;
            Siftup(heapSize);
             
        }

        public void Remove(int i)
        {
            Array[i] = -1;
            Siftup(i);
            ExtractMax();
        }

        private void ChangePriority(int i, int p)
        {
            int oldp;
            oldp = Array[i];
            Array[i] = p;
            if(p > oldp)
            {
                Siftup(i);
            }
            else
            {
                Siftdown(i);
            }
        }*/
    


