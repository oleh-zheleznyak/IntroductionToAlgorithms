using System;
using System.Collections.Generic;

namespace IntroductionToAlgorithms.Sorting
{
    public class BubbleSort<T> : ISort<T> where T : IComparable<T>
    {
        private readonly IComparer<T> _comparer = Comparer<T>.Default;

        public void Sort(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    if (_comparer.Compare(array[j], array[j - 1]) < 0)
                    {
                        array.Swap(j, j - 1);
                    }
                }
            }
        }
    }
}