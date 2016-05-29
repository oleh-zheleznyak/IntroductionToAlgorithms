using System;
using System.Collections.Generic;

namespace IntroductionToAlgorithms.Sorting
{
    public class SelectionSort<T> : ISort<T> where T : IComparable<T>
    {
        private readonly IComparer<T> _comparer = Comparer<T>.Default;

        public void Sort(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = FindMinimumIndex(array, i, array.Length);
                array.Swap(i, minIndex);
            }
        }

        private int FindMinimumIndex(T[] array, int start, int end)
        {
            T min = array[start];
            int minIndex = start;

            for (int i = start + 1; i < end; i++)
            {
                if (_comparer.Compare(array[i], min)<0)
                {
                    min = array[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}