using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
