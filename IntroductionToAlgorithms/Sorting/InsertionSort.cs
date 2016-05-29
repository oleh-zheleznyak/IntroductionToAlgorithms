using System;
using System.Collections.Generic;

namespace IntroductionToAlgorithms.Sorting
{
    public class InsertionSort<T> : ISort<T> where T : IComparable<T>
    {
        private readonly IComparer<T> _comparer = Comparer<T>.Default;

        public void Sort(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                T key = array[i];
                while (j > 0 && _comparer.Compare(key, array[j - 1]) < 0)
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = key;
            }
        }
    }
}
