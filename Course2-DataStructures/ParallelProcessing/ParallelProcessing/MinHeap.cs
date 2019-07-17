using System;
namespace ParallelProcessing
{
    public class MinHeap : HeapBase
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
                if (HasRightChild(index) && (RightChild(index).PriorityTime < LeftChild(index).PriorityTime
                                             || (RightChild(index).PriorityTime == LeftChild(index).PriorityTime
                                                 && RightChild(index).ThreadId < LeftChild(index).ThreadId)))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (Arr[smallerChildIndex].PriorityTime < Arr[index].PriorityTime
                    || (Arr[smallerChildIndex].PriorityTime == Arr[index].PriorityTime && Arr[smallerChildIndex].ThreadId < Arr[index].ThreadId))
                    Swap(index, smallerChildIndex);
                else
                    break;
                index = smallerChildIndex;
            }
        }

        internal override void HeapifyUp()
        {
            int index = Size - 1;

            while (HasParent(index) && (Parent(index).PriorityTime > Arr[index].PriorityTime
                                        || (Parent(index).PriorityTime == Arr[index].PriorityTime
                                            && Parent(index).ThreadId > Arr[index].ThreadId)))
            {
                Swap(index, GetParentIndex(index));
                index = GetParentIndex(index);
            }
        }
    }
}
