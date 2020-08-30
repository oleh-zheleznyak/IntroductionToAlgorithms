using System.Collections.Generic;

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
