using IntroductionToAlgorithms.GraphAlgorithms;
using IntroductionToAlgorithms.Visuals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;

namespace IntroductionToAlgorithms.Tests.GraphAlgorithms
{
    [TestClass]
    public class BreadthFirstSearchIteratorTest
    {
        [TestMethod]
        public void BreadthFirstSearch_ShouldYieldElements_InCorrectOrder()
        {
            DirectedGraph<int> graph = TestHelper.CreateSampleGraph();
            var dgml = Visualize(graph);

            var sequence = new BreadthFirstSearchIterator<int>(graph, 0);

            var expected = new BfsVertice<int>[] { new BfsVertice<int>(0, 0, 0), new BfsVertice<int>(1, 0, 1), new BfsVertice<int>(2, 0, 1), new BfsVertice<int>(3, 1, 2), new BfsVertice<int>(4, 2, 2) };
            var actual = sequence.ToList();

            CollectionAssert.AreEqual(expected, actual);
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
