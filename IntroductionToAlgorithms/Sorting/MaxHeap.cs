using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Sorting
{
    public class MaxHeap<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> _comparer = Comparer<T>.Default;

        // TODO: if this is readonly, the heap cannot grow
        private readonly T[] _array;

        public MaxHeap(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            // TODO:mutating original array, consider passing a copy in ctor
            _array = array;

            BuildMaxHeap();
        }

        private void BuildMaxHeap()
        {
            for (int i = _array.Length / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        private void Heapify(int index)
        {
            // restore the heap property of subtree rooted at index
            int maxIndex = index;

            maxIndex = CheckMaxIndex(LeftChildIndex(index), maxIndex);
            maxIndex = CheckMaxIndex(RightChildIndex(index), maxIndex);

            if (maxIndex != index)
            {
                _array.Swap(maxIndex, index);
                Heapify(maxIndex);
            }
        }

        private int CheckMaxIndex(int index, int maxIndex)
        {
            if (index < _array.Length && _comparer.Compare(_array[index], _array[maxIndex]) > 0)
            {
                maxIndex = index;
            }

            return maxIndex;
        }

        private int ParentIndex(int childIndex)
        {
            return childIndex >> 1;
        }

        private int LeftChildIndex(int parentIndex)
        {
            return (parentIndex << 1) + 1;
        }

        private int RightChildIndex(int parentIndex)
        {
            return (parentIndex << 1) + 2;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _array.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
