using System;
using System.Collections;
using System.Collections.Generic;

namespace IntroductionToAlgorithms.DataStructures
{
    /// <summary>
    /// Queue implementation using two stacks, excersise 10.1-6
    /// </summary>
    /// <remarks>
    /// This implementation is not efficient, provided only to complete the excersise
    /// Array/LinkedList based queue will provide constant enq and deq time, but this implementation
    /// will have both of those operations linear in the worst case (if used in turn)
    /// Use <see cref="Queue{T}"/> instead of this class
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    public class TwoStackQueue<T> : IQueue<T>, IEnumerable<T>
    {
        private readonly Stack<T> forward = new Stack<T>();
        private readonly Stack<T> backward = new Stack<T>();

        public T Dequeue()
        {
            if (Count == 0) throw new InvalidOperationException("Queue is empty");

            Reverse(forward, backward);

            return backward.Pop();
        }

        public int Count
        {
            get
            {
                return Math.Max(forward.Count, backward.Count); // only one of them is not zero
            }
        }

        public void Enqueue(T t)
        {
            Reverse(backward, forward);

            forward.Push(t);
        }

        private void Reverse(Stack<T> from, Stack<T> to)
        {
            if (to.Count > 0 && from.Count > 0) throw new InvalidOperationException();

            while (from.Count > 0)
                to.Push(from.Pop());
        }

        public IEnumerator<T> GetEnumerator()
        {
            Reverse(backward, forward);

            return forward.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
