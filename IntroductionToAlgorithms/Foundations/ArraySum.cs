using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Foundations
{
    public struct ArraySum
    {
        public ArraySum (int start, int end, long sum)
        {
            Start = start;
            End = end;
            Sum = sum;
        }

        public int Start { get; }
        public int End { get; }
        public long Sum { get; }

        public override string ToString()
        {
            return string.Format("[{0}..{1}]:{2}", Start,End,Sum);
        }
    }
}
