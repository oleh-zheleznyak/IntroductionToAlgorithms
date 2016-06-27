using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.DataStructures
{
    public class ChainingHashTable<TKey, TValue> : IHashTable<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
        private struct Pair : IEquatable<Pair>
        {
            public Pair(TKey key, TValue value)
            {
                Key = key;
                Value = value;

                _keyComparer = EqualityComparer<TKey>.Default;
            }

            public static Pair FromKey(TKey key)
            {
                return new Pair(key, default(TValue));
            }

            private readonly IEqualityComparer _keyComparer;
            public TKey Key { get; }
            public TValue Value { get; }

            public bool Equals(Pair other)
            {
                return _keyComparer.Equals(Key, other.Key);
            }

            public override bool Equals(object obj)
            {
                if (obj is Pair) return Equals((Pair)obj);
                else return false;
            }

            public override int GetHashCode()
            {
                return _keyComparer.GetHashCode(Key);
            }
        }

        //TODO: replace size by capacity, as reserving the whole storage at once is not efficient
        public ChainingHashTable(int size)
        {
            _size = size; // use HashHelpers.GetPrime instead
            _data = new LinkedList<Pair>[_size]; // do not allocate full storage at once
        }

        private EqualityComparer<TKey> _comparer = EqualityComparer<TKey>.Default;
        private readonly int _size;
        private readonly LinkedList<Pair>[] _data;

        public bool Delete(TKey key)
        {
            var list = GetListByKey(key);
            if (list == null) return false;

            return list.Remove(Pair.FromKey(key));
        }

        public void Insert(TKey key, TValue value)
        {
            var list = GetListByKey(key);

            if (list == null) list = new LinkedList<Pair>();

            list.AddFirst(new Pair(key, value));
        }

        private LinkedList<Pair> GetListByKey(TKey key)
        {
            return _data[GetIndex(key)];
        }

        public TValue Search(TKey key)
        {
            var list = GetListByKey(key);
            if (list == null) throw new KeyNotFoundException();

            var node = list.Find(Pair.FromKey(key));

            return node.Value.Value;
        }

        private int GetIndex(TKey key)
        {
            var index = key.GetHashCode() % _size;

            // remainder of division % can be negative for negative numbers, but with absolute value always less then _size
            if (index < 0) index += _size;

            return index;
        }
    }
}