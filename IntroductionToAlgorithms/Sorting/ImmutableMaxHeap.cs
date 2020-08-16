﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToAlgorithms.Sorting
{
    /// <summary>
    /// NOTE: this is just a dojo, an excersise, this class is not very useful by itself
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ImmutableMaxHeap<T> : IEnumerable<T>, IReadOnlyCollection<T>
        where T : IComparable<T>
    {
        private readonly T[] _storage;
        private int _heapSize; // NOTE: poor modelling of heapsize - disassociated with sotrage
        private IComparer<T> _comparer = Comparer<T>.Default;  // TODO: consider accepting comparer as parameter

        public int Count => _heapSize; // this will change when heap is mutated

        public ImmutableMaxHeap(T[] storage)
        {
            if (storage is null) throw new ArgumentNullException(nameof(storage));
            if (storage.Length == 0) throw new ArgumentException("Cannot construct max heap on empty array", nameof(storage));

            _storage = BuildMaxHeap(storage);
        }

        public T PeekMax() => _storage[0];

        private T[] BuildMaxHeap(T[] storage)
        {
            var newStorage = storage.ToArray();
            _heapSize = newStorage.Length;

            if (newStorage.Length == 1) return newStorage;

            var upperBound = newStorage.Length / 2 - 1;
            for (int i = upperBound; i >= 0; i--)
                MaxHeapify(newStorage, i);

            return newStorage;
        }

        private void MaxHeapify(T[] storage, int index)
        {
            var l = Left(index);
            var r = Right(index);
            var largest = index;

            if (l < _heapSize && _comparer.Compare(storage[l], storage[index]) > 0)
                largest = l;
            if (r < _heapSize && _comparer.Compare(storage[r], storage[largest]) > 0)
                largest = r;
            if (largest != index)
            {
                Swap(storage, largest, index);
                MaxHeapify(storage, largest);
            }
        }

        private void Swap(T[] storage, int i, int j)
        {
            var temp = storage[i];
            storage[i] = storage[j];
            storage[j] = temp;
        }

        private int Right(int index) => 2 * index + 2; // TODO: replace with shift

        private int Left(int index) => 2 * index + 1; // TODO: consider compiler aggressive inlining

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_storage).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}