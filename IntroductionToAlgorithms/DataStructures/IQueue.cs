using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.DataStructures
{
    public interface IQueue<T>
    {
        void Enqueue(T t);
        T Dequeue();
    }
}
