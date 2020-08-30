using System;
using System.Collections.Generic;
using System.Linq;

namespace IntroductionToAlgorithms.GraphAlgorithms
{
    public class TopologicalSort<T>
        where T : IEquatable<T>
    {
        public IEnumerable<DfsVertice<T>> Sort(DepthFirstSearchIterator<T> dfs)
        {
            return dfs.Reverse();
        }
    }
}
