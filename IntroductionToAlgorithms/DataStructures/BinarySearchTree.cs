using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.DataStructures
{
    public class BinarySearchTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public Node Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Value { get; }
        }

        private IComparer<T> _comparer = Comparer<T>.Default;

        public Node Head { get; private set; }

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new Node(value);
                return;
            }

            Node parent = null, current = Head;
            int comparison = 0;

            while (current != null)
            {
                parent = current;
                comparison = _comparer.Compare(value, current.Value);
                current = comparison < 0 ? current.Left : current.Right;
            }

            var newNode = new Node(value);

            newNode.Parent = parent;
            if (comparison < 0) parent.Left = newNode;
            else parent.Right = newNode;
        }

        public IEnumerable<Node> InOrderTraversal()
        {
            return InOrderTraversal(Head);
        }

        private IEnumerable<Node> InOrderTraversal(Node node)
        {
            if (node == null) return Enumerable.Empty<Node>();
            else return
                InOrderTraversal(node.Left)
                .Union(Enumerable.Repeat(node, 1))
                .Union(InOrderTraversal(node.Right));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal().Select(x=>x.Value).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
