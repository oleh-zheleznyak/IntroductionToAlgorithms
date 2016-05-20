using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public class DepthFirstSearchIterator<T> : IEnumerable<T>
         where T : IEquatable<T>
    {
        public DepthFirstSearchIterator(DirectedGraph<T> graph, T source)
        {
            _graph = graph;
            _source = source;
        }

        private readonly DirectedGraph<T> _graph;
        private readonly T _source;

        public IEnumerator<T> GetEnumerator()
        {
            var visited = new HashSet<T>();
            var stack = new Stack<T>();

            stack.Push(_source);

            while (stack.Count > 0)
            {
                var vertice = stack.Pop();

                if (!visited.Contains(vertice))
                {
                    visited.Add(vertice);

                    foreach (var adjacentVertice in _graph.GetAdjacentVertices(vertice))
                    {
                        stack.Push(adjacentVertice);
                    }
                }

                yield return vertice;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
