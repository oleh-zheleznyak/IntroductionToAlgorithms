using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using IntroductionToAlgorithms.Utilities;

namespace IntroductionToAlgorithms.DataStructures
{
    public class BinarySearchTree<TKey, TValue> : IEnumerable<BinarySearchTree<TKey, TValue>.Node>
        where TKey : IComparable<TKey>
    {
        public class Node
        {
            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            internal Node Parent { get; set; }
            internal Node Left { get; set; }
            internal Node Right { get; set; }
            public TKey Key { get; }
            public TValue Value { get; }
        }

        private struct NodeVisit
        {
            public NodeVisit(Node node, bool visited)
            {
                Node = node;
                Visited = visited;
            }
            public Node Node { get; }
            public bool Visited { get; }
        }

        private IComparer<TKey> _comparer = Comparer<TKey>.Default;

        public Node Head { get; private set; }

        public void Add(Node node)
        {
            var newNode = new Node(node.Key, node.Value);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node parent = null, current = Head;
            int comparison = 0;

            while (current != null)
            {
                parent = current;
                comparison = _comparer.Compare(node.Key, current.Key);
                current = comparison < 0 ? current.Left : current.Right;
            }

            newNode.Parent = parent;
            if (comparison < 0) parent.Left = newNode;
            else parent.Right = newNode;
        }

        public void Add(IEnumerable<Node> nodes)
        {
            foreach (var node in nodes)
            {
                Add(node);
            }
        }

        public Node Find(TKey key)
        {
            var current = Head;
            while (current != null)
            {
                var comparison = _comparer.Compare(key, current.Key);
                if (comparison == 0) break;
                else if (comparison < 0) current = current.Left;
                else current = current.Right;
            }
            return current;
        }

        public IEnumerable<Node> BreadthFirstTraversal()
        {
            if (Head == null) yield break;

            var queue = new Queue<Node>();
            queue.Enqueue(Head);
            Action<Node> enqueIfNotNull = n => { if (n != null) queue.Enqueue(n); };

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                enqueIfNotNull(element.Left);
                enqueIfNotNull(element.Right);

                yield return element;
            }
        }

        public IEnumerable<Node> InOrderTraversal()
        {
            return InOrderTraversal(Head);
        }

        public IEnumerable<Node> PreOrderTraversalNonRecursive()
        {
            if (Head == null) yield break;

            var stack = new Stack<Node>();

            stack.PushIfNotNull(Head);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                stack.PushIfNotNull(node.Right);
                stack.PushIfNotNull(node.Left);

                yield return node;
            }
        }

        public IEnumerable<Node> InOrderTraversalNonRecursive()
        {
            if (Head == null) yield break;

            var stack = new Stack<NodeVisit>();

            Action<NodeVisit> pushIfNotNull = x => { if (x.Node != null) stack.Push(x); };

            pushIfNotNull(new NodeVisit(Head, false));

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (node.Visited)
                {
                    yield return node.Node;
                }
                else
                {
                    pushIfNotNull(new NodeVisit(node.Node.Right,false));
                    pushIfNotNull(new NodeVisit(node.Node, true));
                    pushIfNotNull(new NodeVisit(node.Node.Left, false));
                }
            }
        }

        private void PushNonNullNode(Stack<Node> stack, Node node)
        {
            if (node != null) stack.Push(node);
        }

        public IEnumerable<Node> PreOrderTraversal()
        {
            return PreOrderTraversal(Head);
        }

        public IEnumerable<Node> PostOrderTraversal()
        {
            return PostOrderTraversal(Head);
        }

        private IEnumerable<Node> InOrderTraversal(Node node)
        {
            if (node == null) return Enumerable.Empty<Node>();
            else return
                InOrderTraversal(node.Left)
                .Union(Enumerable.Repeat(node, 1))
                .Union(InOrderTraversal(node.Right));
        }

        private IEnumerable<Node> PreOrderTraversal(Node node)
        {
            if (node == null) return Enumerable.Empty<Node>();
            else return
                Enumerable.Repeat(node, 1)
                .Union(PreOrderTraversal(node.Left))
                .Union(PreOrderTraversal(node.Right));
        }

        private IEnumerable<Node> PostOrderTraversal(Node node)
        {
            if (node == null) return Enumerable.Empty<Node>();
            else return
                PostOrderTraversal(node.Left)
                .Union(PostOrderTraversal(node.Right))
                .Union(Enumerable.Repeat(node, 1));
        }

        public IEnumerator<BinarySearchTree<TKey, TValue>.Node> GetEnumerator()
        {
            return InOrderTraversal().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
