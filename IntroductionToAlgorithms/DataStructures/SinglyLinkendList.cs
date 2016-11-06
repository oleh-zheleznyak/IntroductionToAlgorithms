using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.DataStructures
{
    public class SinglyLinkendList<T> : IEnumerable<T>, IReadOnlyCollection<T>
    {
        private int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public Node Head { get; private set; }

        public void AddFirst(T value)
        {
            Head = new Node(value, Head);
            count++;
        }

        public T RemoveFirst()
        {
            if (Head == null) throw new InvalidOperationException("linked list is empty");

            var result = Head;
            Head = Head.Next;
            count--;

            return result.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class Node
        {
            public Node(T value, Node next)
            {
                Value = value;
                Next = next;
            }

            public T Value { get; set; }
            public Node Next { get; set; }
        }
    }
}
