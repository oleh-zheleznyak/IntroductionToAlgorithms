using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public class BreadthFirstSearchIterator<T> : IEnumerable<T>
         where T : IEquatable<T>
    {
        public BreadthFirstSearchIterator(DirectedGraph<T> graph, T source)
        {
            _graph = graph;
            _source = source;
        }

        private readonly DirectedGraph<T> _graph;
        private readonly T _source;

        public IEnumerator<T> GetEnumerator()
        {
            var visited = new HashSet<T>();
            var queue = new Queue<T>();

            queue.Enqueue(_source);

            while (queue.Count > 0)
            {
                var vertice = queue.Dequeue();

                if (!visited.Contains(vertice))
                {
                    visited.Add(vertice);

                    foreach (var adjacentVertice in _graph.GetAdjacentVertices(vertice))
                    {
                        queue.Enqueue(adjacentVertice);
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
