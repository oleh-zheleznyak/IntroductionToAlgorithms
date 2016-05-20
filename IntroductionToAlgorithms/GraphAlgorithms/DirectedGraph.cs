using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public class DirectedGraph<T>
        where T : IEquatable<T>
    {
        internal DirectedGraph(Dictionary<T, HashSet<T>> adjacencyList)
        {
            _adjacencyList = adjacencyList;
        }

        public IEnumerable<T> Vertices { get { return _adjacencyList.Keys; } }

        // TODO: refactor to get rid of tuple, introduce pair class instead
        public IEnumerable<Tuple<T, T>> Edges { get { return _adjacencyList.SelectMany(x => x.Value.Select(y => Tuple.Create<T, T>(x.Key, y))); } }

        public ISet<T> GetAdjacentVertices(T source)
        {
            return _adjacencyList[source];
        }

        private readonly Dictionary<T, HashSet<T>> _adjacencyList;

        public IEnumerable<T> BreadthFirstSearch(T source)
        {
            return new BreadthFirstSearchIterator<T>(this, source);
        }
    }
}
