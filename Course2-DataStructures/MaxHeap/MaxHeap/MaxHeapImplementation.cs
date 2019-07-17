using System;

namespace MaxHeap
{
    public abstract class HeapImplementation
    {
        private int Capacity { get; set; }
        internal int Size { get; set; }
        internal int[] Arr { get; set; }

        public HeapImplementation()
        {
            Capacity = 100;
            Size = 0;
            Arr = new int[Capacity];
        }

        public void EnlargeIfNeeded()
        {
            if (Size == Capacity)
            {
                Capacity = 2 * Capacity;
                Array.Copy(Arr, Arr, Capacity);
            }
        }

        public int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        public bool HasLeftChild(int parentIndex)
        {
            return GetLeftChildIndex(parentIndex) < Size;
        }

        public int LeftChild(int index)
        {
            return Arr[GetLeftChildIndex(index)];
        }

        public int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        public bool HasRightChild(int parentIndex)
        {
            return GetRightChildIndex(parentIndex) < Size;
        }

        public int RightChild(int index)
        {
            return Arr[GetRightChildIndex(index)];
        }

        public int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        public bool HasParent(int childIndex)
        {
            return GetParentIndex(childIndex) >= 0;
        }

        public int Parent(int index)
        {
            return Arr[GetParentIndex(index)];
        }

        public void Swap(int index1, int index2)
        {
            int temp = Arr[index1];
            Arr[index1] = Arr[index2];
            Arr[index2] = temp;
        }

        public int peek()
        {
            if (Size == 0)
                throw new InvalidOperationException("Heap is empty");

            return Arr[0];
        }

        public int Pop()
        {
            if (Size == 0)
                throw new InvalidOperationException("Heap is empty");

            int item = Arr[0];
            Arr[0] = Arr[Size - 1];
            Size--;
            HeapifyDown();
            return item;
        }

        public void Add(int item)
        {
            EnlargeIfNeeded();
            Arr[Size] = item;
            Size++;
            HeapifyUp();
        }

        internal abstract void HeapifyUp();
        internal abstract void HeapifyDown();
    }

    public class MaxHeapDerived : HeapImplementation
    {

        public MaxHeapDerived() : base()
         {
            
          }
       
        internal override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int LargerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index) > LeftChild(index))
                {
                    LargerChildIndex = GetRightChildIndex(index);
                }

                if (Arr[LargerChildIndex] > Arr[index])
                    Swap(index, LargerChildIndex);
                else
                    break;
                index = LargerChildIndex;
            }
        }

        internal override void HeapifyUp()
        {
            int index = Size - 1;

            while (HasParent(index) && Parent(index) < Arr[index])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }

        public int ExtractMax()
        {
            int result = Arr[0];
            Arr[0] = Arr[Size - 1];
            Size = Size - 1;
            HeapifyDown();
            return result;
        }
    }


    public class MinHeap : HeapImplementation
    {
        public MinHeap() : base()
        {
        }
       
        internal override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (Arr[smallerChildIndex] < Arr[index])
                    Swap(index, smallerChildIndex);
                else
                    break;
                index = smallerChildIndex;
            }
        }

        internal override void HeapifyUp()
        {
            int index = Size - 1;

            while (HasParent(index) && Parent(index) > Arr[index])
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }
    }
}
