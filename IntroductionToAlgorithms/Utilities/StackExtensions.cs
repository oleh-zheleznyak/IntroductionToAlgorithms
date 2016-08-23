using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Utilities
{
    public static class StackExtensions
    {
        public static void PushIfNotNull<T>(this Stack<T> stack, T node)
            where T : class
        {
            if (node != null) stack.Push(node);
        }
    }
}
