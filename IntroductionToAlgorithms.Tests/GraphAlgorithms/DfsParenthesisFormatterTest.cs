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
    public class DfsParenthesisFormatterTest
    {
        [TestMethod]
        public void DepthFirstSearchIterator_ShouldYield_CorrectParenthesisedString()
        {
            DirectedGraph<int> graph = TestHelper.CreateSampleGraph();

            var sequence = new DepthFirstSearchIterator<int>(graph, 0);
            var formatter = new DfsParenthesisFormatter<int>();

            var expected = "(0 (2 (4 4) 2) (1 (3 3) 1) 0)";
            var actual = formatter.ToString(sequence);

            Assert.AreEqual(expected, actual);
        }
    }
}
