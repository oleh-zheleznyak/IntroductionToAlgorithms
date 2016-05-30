using System;
using System.Collections.Generic;

namespace IntroductionToAlgorithms.Sorting
{
    public class MergeSort<T> : ISort<T> where T : IComparable<T>
    {
        private readonly IComparer<T> _comparer = Comparer<T>.Default;

        public void Sort(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            SortImpl(array);
        }

        private void SortImpl(T[] array)
        {
            if (array.Length > 1)
            {
                var index = CalculateSplitIndex(array);

                var leftArray = new T[index + 1];
                Array.Copy(array, leftArray, index + 1);

                var rightArray = new T[array.Length - index - 1];
                Array.Copy(array, index + 1, rightArray, 0, array.Length - index - 1);

                SortImpl(leftArray);
                SortImpl(rightArray);

                Merge(array, leftArray, rightArray);
            }
        }

        private int CalculateSplitIndex(T[] array)
        {
            return (array.Length - 1) / 2;
        }

        private void Merge(T[] array, T[] leftArray, T[] rightArray)
        {
            int left = 0, right = 0, main = 0;
            while (main < array.Length)
            {
                if (left >= leftArray.Length)
                {
                    array[main] = rightArray[right++];
                }
                else if (right >= rightArray.Length)
                {
                    array[main] = leftArray[left++];
                }
                else
                {
                    int comparison = _comparer.Compare(leftArray[left], rightArray[right]);

                    if (comparison <= 0)
                    {
                        array[main] = leftArray[left++];
                    }
                    else
                    {
                        array[main] = rightArray[right++];
                    }
                }
                main++;
            }
        }
    }
}
