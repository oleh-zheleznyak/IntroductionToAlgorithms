using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using IntroductionToAlgorithms.Tests.GraphAlgorithms;

namespace IntroductionToAlgorithms.GraphAlgorithms.Tests
{
    [TestClass]
    public class TopologicalSortTests
    {
        [TestMethod]
        public void SortTest()
        {
            var graph = TestHelper.CreateSampleGraph();

            var sut = new TopologicalSort<int>();

            var iterator = new DepthFirstSearchIterator<int>(graph, 0);

            var actual = sut.Sort(iterator);

            var sortedVertices = actual.Select(x => x.Vertice).ToList();

            var expected = new int[] { 0, 1, 3, 2, 4 };

            CollectionAssert.AreEqual(expected, sortedVertices);
        }
    }
}