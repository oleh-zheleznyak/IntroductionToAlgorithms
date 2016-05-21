using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroductionToAlgorithms.Visuals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Visuals.Tests
{
    [TestClass]
    public class GraphTypeConverterTests
    {
        [TestMethod]
        public void CanConvertFromTest()
        {
            var sut = new GraphTypeConverter();

            var actual = sut.CanConvertFrom(typeof(GraphAlgorithms.DirectedGraph<int>));

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CanConvertToTest()
        {
            var sut = new GraphTypeConverter();

            var actual = sut.CanConvertTo(typeof(DirectedGraph));

            Assert.IsTrue(actual);
        }
    }
}