using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.DataStructures
{
    public interface IHashTable<TKey, TValue>
        where TKey : IEquatable<TKey>
    {
        TValue Search(TKey key);
        void Insert(TKey key, TValue value);
        bool Delete(TKey key);
    }
}
