using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroductionToAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.DataStructures.Tests
{
    [TestClass]
    public class SinglyLinkendListTests
    {
        private SinglyLinkendList<int> sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new SinglyLinkendList<int>();
        }

        [TestMethod]
        public void AddLast_SetsHeadAndTail_GivenEmptyList()
        {
            var value = 1;
            sut.AddLast(value);

            AssertSingleElement(value);
        }

        private void AssertSingleElement(int value)
        {
            Assert.AreEqual(value, sut.Head.Value);
            Assert.AreEqual(value, sut.Tail.Value);
            Assert.AreEqual(1, sut.Count);
        }

        [TestMethod]
        public void AddFirst_SetsHeadAndTail_GivenEmptyList()
        {
            var value = 1;
            sut.AddFirst(value);

            AssertSingleElement(value);
        }

        [TestMethod]
        public void RemoveFirst_ShouldYieldEmptyList_GivenOneElement()
        {
            // arrange
            var value = 1;
            sut.AddFirst(value);

            // act
            var removed = sut.RemoveFirst();

            // assert
            Assert.AreEqual(value, removed);
            Assert.AreEqual(0, sut.Count);
            Assert.IsNull(sut.Head);
            Assert.IsNull(sut.Tail);
        }
    }
}