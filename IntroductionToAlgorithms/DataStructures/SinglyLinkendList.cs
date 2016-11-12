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

        public Node Tail { get; private set; }

        public void AddLast(T value)
        {
            var newTail = new Node(value, null);

            if (count == 0)
            {
                Head = Tail = newTail;
            }
            else
            {
                Tail.Next = newTail;
                Tail = newTail;
            }

            count++;
        }

        public void AddFirst(T value)
        {
            Head = new Node(value, Head);

            if (count==0)
            {
                Tail = Head;
            }

            count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0) throw new InvalidOperationException("linked list is empty");

            var result = Head;
            Head = Head.Next;

            if (count == 1)
            {
                Tail = Head; // null
            }

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
