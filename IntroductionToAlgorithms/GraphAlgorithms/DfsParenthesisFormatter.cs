using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public class DfsParenthesisFormatter<T>
        where T : IEquatable<T>
    {
        private class DfsParenthesisVertice<T>
            where T : IEquatable<T>
        {
            public T Vertice { get; set; }
            public int Timestamp { get; set; }
            public bool IsWhite { get; set; }

            public override string ToString()
            {
                var str = Vertice.ToString();
                if (IsWhite)
                    return "(" + str;
                else
                    return str + ")";
            }
        }

        public string ToString(DepthFirstSearchIterator<T> iterator)
        {
            var list = iterator.ToList();

            var traversed = list.Select(CreateWhite).Union(list.Select(CreateBlack)).OrderBy(x => x.Timestamp).ToList();

            var result = string.Join(" ", traversed);

            return result;
        }

        private DfsParenthesisVertice<T> CreateWhite(DfsVertice<T> vertice)
        {
            return new DfsParenthesisVertice<T>()
            {
                IsWhite = true,
                Timestamp = vertice.DiscoveredTimestamp,
                Vertice = vertice.Vertice
            };
        }

        private DfsParenthesisVertice<T> CreateBlack(DfsVertice<T> vertice)
        {
            return new DfsParenthesisVertice<T>()
            {
                IsWhite = false,
                Timestamp = vertice.TraversedTimestamp,
                Vertice = vertice.Vertice
            };
        }
    }
}
