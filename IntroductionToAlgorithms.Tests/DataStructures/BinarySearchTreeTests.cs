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
        private BinarySearchTree<int, string> _sut;
        private IEnumerable<BinarySearchTree<int, string>.Node> _testData;

        private IEnumerable<BinarySearchTree<int, string>.Node> Transform(IDictionary<int, string> input)
        {
            return input.Select(x => new BinarySearchTree<int, string>.Node(x.Key, x.Value));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new BinarySearchTree<int, string>();
            _testData = Transform(new Dictionary<int, string>() { { 4, "four" }, { 2, "two" }, { 6, "six" }, { 3, "three" }, { 1, "one" }, { 5, "five" }, { 7, "seven" } });
        }

        [TestMethod]
        public void GetEnumeratorTest()
        {
            Scenario(new int[] { 1, 2, 3, 4, 5, 6, 7 }, x => x as IEnumerable<BinarySearchTree<int, string>.Node>);
        }

        private void Scenario(IEnumerable<int> expected, Func<BinarySearchTree<int, string>, IEnumerable<BinarySearchTree<int, string>.Node>> iterator)
        {
            _sut.Add(_testData);
            var actual = iterator(_sut).Select(x => x.Key);

            CollectionAssert.AreEqual(expected.ToArray(), actual.ToArray());
        }

        [TestMethod]
        public void InOrderTraversalTest()
        {
            Scenario(new int[] { 1, 2, 3, 4, 5, 6, 7 }, x => x.InOrderTraversal());
        }

        [TestMethod]
        public void PreOrderTraversalTest()
        {
            Scenario(new int[] { 4, 2, 1, 3, 6, 5, 7 }, x => x.PreOrderTraversal());
        }

        [TestMethod]
        public void PostOrderTraversalTest()
        {
            Scenario(new int[] { 1, 3, 2, 5, 7, 6, 4 }, x => x.PostOrderTraversal());
        }

        [TestMethod]
        public void BreadthFirstTraversalTest()
        {
            Scenario(new int[] { 4, 2, 6, 1, 3, 5, 7 }, x => x.BreadthFirstTraversal());
        }
    }
}