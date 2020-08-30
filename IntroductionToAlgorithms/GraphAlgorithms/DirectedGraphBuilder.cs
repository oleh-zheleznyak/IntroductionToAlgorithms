using System;
using System.Collections.Generic;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public class DirectedGraphBuilder<T>
        where T : IEquatable<T>
    {
        private readonly Dictionary<T, HashSet<T>> _adjacencyList = new Dictionary<T, HashSet<T>>();

        public void AddEdge(T from, T to)
        {
            AddVertice(from);
            AddVertice(to);

            var adjacent = _adjacencyList[from];

            if (!adjacent.Contains(to))
            {
                adjacent.Add(to);
            }
        }

        public void AddVertice(T vertice)
        {
            if (!_adjacencyList.ContainsKey(vertice))
            {
                _adjacencyList[vertice] = new HashSet<T>();
            }
        }

        public DirectedGraph<T> AsDirectedGraph()
        {
            return new DirectedGraph<T>(_adjacencyList);
        }
    }
}
