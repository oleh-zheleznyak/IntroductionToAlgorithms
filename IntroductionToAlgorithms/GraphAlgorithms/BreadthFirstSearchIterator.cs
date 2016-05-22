using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public class BreadthFirstSearchIterator<T> : IEnumerable<BfsVertice<T>>
         where T : IEquatable<T>
    {
        public BreadthFirstSearchIterator(DirectedGraph<T> graph, T source)
        {
            _graph = graph;
            _source = source;
        }

        private readonly DirectedGraph<T> _graph;
        private readonly T _source;

        public IEnumerator<BfsVertice<T>> GetEnumerator()
        {
            var visited = new HashSet<T>();
            var queue = new Queue<BfsVertice<T>>();

            // NOTE: questionable usage of default(T) - it is not meaningful for non-reference types, especially for integers
            queue.Enqueue(new BfsVertice<T>(_source, default(T), 0));

            while (queue.Count > 0)
            {
                var bfsVertice = queue.Dequeue();

                if (!visited.Contains(bfsVertice.Vertice))
                {
                    visited.Add(bfsVertice.Vertice);

                    foreach (var adjacentVertice in _graph.GetAdjacentVertices(bfsVertice.Vertice))
                    {
                        queue.Enqueue(new BfsVertice<T>(adjacentVertice, bfsVertice.Vertice, bfsVertice.Distance+1));
                    }
                }

                yield return bfsVertice;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
