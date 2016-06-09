using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Sorting
{
    /// <summary>
    /// This class is actually more than MaxHeap - it is a hybrid of MaxHeap and MaxPriorityQueue
    /// The reason they are combined in one class is that it would be hard to provide an implementation
    /// of MaxPriorityQueue that would be DRY and respect encapsulation of MaxHeap
    /// Heap-Increase-Key is cannot be added without introducing a separate Key abstraction, since key comparison in encapsulated in type T
    /// Heap-Insert is a trivial operation - copying data into a new bigger array (if needed), putting element at the top and calling heapify
    /// </summary>
    public class MaxHeap<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private readonly IComparer<T> _comparer = Comparer<T>.Default;
        private int _heapSize;

        private T[] _array;

        public MaxHeap(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            // TODO:mutating original array, consider passing a copy in ctor
            _array = array;
            _heapSize = array.Length;

            BuildMaxHeap();
        }

        public T Peek()
        {
            ThrowIfEmpty();

            return _array[0];
        }

        private void ThrowIfEmpty()
        {
            if (_heapSize <= 0) throw new InvalidOperationException("Heap is empty");
        }

        public T Pop()
        {
            ThrowIfEmpty();

            T max = _array[0];
            _array[0] = _array[_heapSize - 1];
            _array[_heapSize - 1] = default(T);
            _heapSize--;

            Heapify(0);

            return max;
        }

        public void Push(T value)
        {
            if (_heapSize == _array.Length) GrowArray();

            _array[_heapSize] = value;

            RestoreHeapProperty(_heapSize);

            _heapSize++;
        }

        private void RestoreHeapProperty(int index)
        {
            int parentIndex = 0;
            while ((parentIndex = ParentIndex(index)) >= 0 && _comparer.Compare(_array[index], _array[parentIndex]) > 0)
            {
                _array.Swap(index, parentIndex);
                index = parentIndex;
            }
        }

        private void GrowArray()
        {
            var newArray = new T[_array.Length * 2];
            Array.Copy(_array, newArray, _array.Length);
            _array = newArray;
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
            if (index < _heapSize && _comparer.Compare(_array[index], _array[maxIndex]) > 0)
            {
                maxIndex = index;
            }

            return maxIndex;
        }

        private int ParentIndex(int childIndex)
        {
            return (childIndex - 1) >> 1;
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
            return _array.AsEnumerable().Take(_heapSize).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
