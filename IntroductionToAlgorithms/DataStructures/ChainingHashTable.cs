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
        //TODO: replace size by capacity, as reserving the whole storage at once is not efficient
        public ChainingHashTable(int size)
        {
            _size = size; // use HashHelpers.GetPrime instead
            _data = new LinkedList<KeyValuePair<TKey, TValue>>[_size]; // do not allocate full storage at once
        }

        private EqualityComparer<TKey> _comparer = EqualityComparer<TKey>.Default;
        private readonly int _size;
        private readonly LinkedList<KeyValuePair<TKey, TValue>>[] _data;

        public void Delete(TKey key)
        {
            var list = GetListByKey(key);
            if (list == null) return; //TODO: consider throwing exception

            // TODO:inefficient, this is achievable in one pass
            var pair = list.FirstOrDefault(x => _comparer.Equals(x.Key, key));
            list.Remove(pair);
        }

        public void Insert(TKey key, TValue value)
        {
            var list = GetListByKey(key);

            if (list == null) list = new LinkedList<KeyValuePair<TKey, TValue>>();

            list.AddFirst(new KeyValuePair<TKey, TValue>(key, value));
        }

        private LinkedList<KeyValuePair<TKey, TValue>> GetListByKey(TKey key)
        {
            var index = GetIndex(key);
            var list = _data[index];

            return list;
        }

        // TODO: rewrite using exceptions? returning default() is a bad option for value types
        public TValue Search(TKey key)
        {
            var list = GetListByKey(key);
            if (list == null) return default(TValue);

            var pair = list.FirstOrDefault(x => _comparer.Equals(x.Key, key));

            return pair.Value;
        }

        private int GetIndex(TKey key)
        {
            return key.GetHashCode() % _size;
        }
    }
}
