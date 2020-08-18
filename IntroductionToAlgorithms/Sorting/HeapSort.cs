using System;

namespace IntroductionToAlgorithms.Sorting
{
    public class HeapSort<T> : ISort<T>
        where T : IComparable<T>
    {
        public void Sort(T[] array)
        {
            // create the heap to heapify the array
            var heap = new MaxHeap<T>(array);

            // use the side effect to put the max values in the tail in sorted order
            for (int i = array.Length - 1; i >= 0; i--)
            {
                T max = heap.Pop();
                array[i] = max;
            }
        }
    }
}
