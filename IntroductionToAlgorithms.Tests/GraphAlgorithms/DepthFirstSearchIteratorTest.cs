using IntroductionToAlgorithms.GraphAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Tests.GraphAlgorithms
{
    [TestClass]
    public class DepthFirstSearchIteratorTest
    {
        [TestMethod]
        public void DepthFirstSearchIteratorTest_ShouldYieldElements_InCorrectOrder()
        {
            var builder = new DirectedGraphBuilder<int>();

            builder.AddEdge(0, 1);
            builder.AddEdge(0, 2);
            builder.AddEdge(1, 3);
            builder.AddEdge(2, 4);

            var graph = builder.AsDirectedGraph();

            var sequence = new DepthFirstSearchIterator<int>(graph, 0);

            var expected = new[] { 0, 2, 4, 1, 3 };
            var actual = sequence.ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
