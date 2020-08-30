using System;
using System.Collections;
using System.Collections.Generic;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public class DepthFirstSearchIterator<T> : IEnumerable<DfsVertice<T>>
         where T : IEquatable<T>
    {
        private enum VerticeColor : byte
        {
            White = 0,
            Gray = 1,
            Black = 2
        }

        public DepthFirstSearchIterator(DirectedGraph<T> graph, T source)
        {
            _graph = graph;
            _source = source;
        }

        private readonly DirectedGraph<T> _graph;
        private readonly T _source;

        public IEnumerator<DfsVertice<T>> GetEnumerator()
        {
            var visited = new Dictionary<T, VerticeColor>();
            var stack = new Stack<DfsVertice<T>>();
            var timestamp = 0;

            var source = new DfsVertice<T>(_source, default(T));
            source.DiscoveredTimestamp = timestamp++;

            stack.Push(source);

            while (stack.Count > 0)
            {
                var vertice = stack.Pop();
                var color = VerticeColor.White;

                visited.TryGetValue(vertice.Vertice, out color);

                switch (color)
                {
                    case VerticeColor.White:
                        visited[vertice.Vertice] = VerticeColor.Gray;
                        vertice.DiscoveredTimestamp = timestamp++;
                        stack.Push(vertice);

                        foreach (var adjacentVertice in _graph.GetAdjacentVertices(vertice.Vertice))
                        {
                            var adjacentColor = VerticeColor.White;
                            visited.TryGetValue(adjacentVertice, out adjacentColor);

                            if (adjacentColor == VerticeColor.White)
                                stack.Push(new DfsVertice<T>(adjacentVertice, vertice.Vertice));
                        }
                        break;

                    case VerticeColor.Gray:
                        visited[vertice.Vertice] = VerticeColor.Black;
                        stack.Push(vertice);
                        break;

                    case VerticeColor.Black:
                        vertice.TraversedTimestamp = timestamp++;
                        yield return vertice;
                        break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
