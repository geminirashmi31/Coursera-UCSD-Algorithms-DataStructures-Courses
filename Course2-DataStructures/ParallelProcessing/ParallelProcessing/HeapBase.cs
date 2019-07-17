using System;
using System.Collections.Generic;
namespace ParallelProcessing
{
    public abstract class HeapBase
    {
        private int Capacity { get; set; }
        internal int Size { get; set; }
        internal JobInfo[] Arr { get; set; }

         public HeapBase()
        {
            Capacity = 100;
            Size = 0;
            Arr = new JobInfo[Capacity];
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

        public JobInfo LeftChild(int index)
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

        public JobInfo RightChild(int index)
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

        public JobInfo Parent(int index)
        {
            return Arr[GetParentIndex(index)];
        }

        public void Swap(int index1, int index2)
        {
            JobInfo temp = Arr[index1];
            Arr[index1] = Arr[index2];
            Arr[index2] = temp;
        }

        public JobInfo peek()
        {
            if (Size == 0)
                throw new InvalidOperationException("Heap is empty");

            return Arr[0];
        }

        public JobInfo Pop()
        {
            if (Size == 0)
                throw new InvalidOperationException("Heap is empty");

            JobInfo item = Arr[0];
            Arr[0] = Arr[Size - 1];
            Size--;
            HeapifyDown();
            return item;
        }

        public void Add(JobInfo item)
        {
            EnlargeIfNeeded();
            Arr[Size] = item;
            Size++;
            HeapifyUp();
        }

        internal abstract void HeapifyUp();
        internal abstract void HeapifyDown();
    }
 }
