using IntroductionToAlgorithms.GraphAlgorithms;
using IntroductionToAlgorithms.Visuals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
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
            DirectedGraph<int> graph = CreateSampleGraph();
            var dgml = Visualize(graph);

            var sequence = new BreadthFirstSearchIterator<int>(graph, 0);

            var expected = new BfsVertice<int>[] { new BfsVertice<int>(0, 0, 0), new BfsVertice<int>(1, 0, 1), new BfsVertice<int>(2, 0, 1), new BfsVertice<int>(3, 1, 2), new BfsVertice<int>(4, 2, 2) };
            var actual = sequence.ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        private static DirectedGraph<int> CreateSampleGraph()
        {
            var builder = new DirectedGraphBuilder<int>();

            builder.AddEdge(0, 1);
            builder.AddEdge(0, 2);
            builder.AddEdge(1, 3);
            builder.AddEdge(2, 4);

            var graph = builder.AsDirectedGraph();
            return graph;
        }

        private static FileInfo Visualize<T>(DirectedGraph<T> graph)
            where T : IEquatable<T>
        {
            var converter = new GraphTypeConverter();
            var serializer = new DgmlSerializer();

            var result = serializer.Serialize(converter.Convert<T>(graph));

            return result;
        }
    }
}
