using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Sorting
{
    public class QuickSort<T> : ISort<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> _comparer = Comparer<T>.Default;

        public void Sort(T[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(T[] array, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                var index = Partition(array, startIndex, endIndex);
                Sort(array, startIndex, index - 1);
                Sort(array, index + 1, endIndex);
            }

        }

        private int Partition(T[] array, int startIndex, int endIndex)
        {
            var pivotValue = array[endIndex];
            var sortedIndex = startIndex - 1;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (_comparer.Compare(pivotValue,array[i])>=0)
                {
                    sortedIndex++;
                    array.Swap(sortedIndex, i);
                }
            }

            array.Swap(++sortedIndex, endIndex);

            return sortedIndex;
        }
    }
}