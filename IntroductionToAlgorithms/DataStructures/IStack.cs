using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.DataStructures
{
    public interface IStack<T>
    {
        T Pop();
        void Push(T value);
    }
}
