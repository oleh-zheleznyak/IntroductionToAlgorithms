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
    public class BinarySearchTreeTests
    {
        [TestMethod]
        public void GetEnumeratorTest()
        {
            var sut = new BinarySearchTree<int>();
            sut.Add(2);
            sut.Add(1);
            sut.Add(3);

            var expected = new int[] { 1, 2, 3 };
            var actual = sut.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}