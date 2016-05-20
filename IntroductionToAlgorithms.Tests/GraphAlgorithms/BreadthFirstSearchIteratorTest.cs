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
    public class BreadthFirstSearchIteratorTest
    {
        [TestMethod]
        public void BreadthFirstSearch_ShouldYieldElements_InCorrectOrder()
        {
            var builder = new DirectedGraphBuilder<int>();

            builder.AddEdge(0, 1);
            builder.AddEdge(0, 2);
            builder.AddEdge(1, 3);
            builder.AddEdge(2, 4);

            var graph = builder.AsDirectedGraph();

            var sequence = new BreadthFirstSearchIterator<int>(graph, 0);

            var expected = graph.Vertices.OrderBy(x => x).ToList();
            var actual = sequence.ToList();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
