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
        public void InOrderTraversalNonRecursiveTest()
        {
            Scenario(new int[] { 1, 2, 3, 4, 5, 6, 7 }, x => x.InOrderTraversalNonRecursive());
        }

        [TestMethod]
        public void PreOrderTraversalTest()
        {
            Scenario(new int[] { 4, 2, 1, 3, 6, 5, 7 }, x => x.PreOrderTraversal());
        }

        [TestMethod]
        public void PreOrderTraversalNonRecursiveTest()
        {
            Scenario(new int[] { 4, 2, 1, 3, 6, 5, 7 }, x => x.PreOrderTraversalNonRecursive());
        }

        [TestMethod]
        public void PostOrderTraversalTest()
        {
            Scenario(new int[] { 1, 3, 2, 5, 7, 6, 4 }, x => x.PostOrderTraversal());
        }

        [TestMethod]
        public void PostOrderTraversalNonRecursiveTest()
        {
            Scenario(new int[] { 1, 3, 2, 5, 7, 6, 4 }, x => x.PostOrderTraversalNonRecursive());
        }

        [TestMethod]
        public void BreadthFirstTraversalTest()
        {
            Scenario(new int[] { 4, 2, 6, 1, 3, 5, 7 }, x => x.BreadthFirstTraversal());
        }

        [TestMethod]
        public void InOrderTraversalLoadTest()
        {
            var data = GetRandomArray();

            var tree = new BinarySearchTree<int, bool>();
            tree.Add(data.Select(x => new BinarySearchTree<int, bool>.Node(x, false)));

            var actual = tree.InOrderTraversalNonRecursive().Select(x => x.Key).ToArray();
            var expected = data.OrderBy(x => x).ToArray();

            CollectionAssert.AreEquivalent(expected, actual);
        }

        private static int[] GetRandomArray()
        {
            var size = 100000;
            var random = new Random();
            var data = Enumerable.Repeat<int>(0, size).Select(x => random.Next()).ToArray();

            return data;
        }

        [TestMethod]
        public void Minimum_ShouldReturnNull_ForEmptyTree()
        {
            Assert.IsNull(_sut.Minimum());
        }

        [TestMethod]
        public void Minimum_ShouldReturnNodeWithMinimumValue()
        {
            // Act
            _sut.Add(_testData);

            var expected = _testData.OrderBy(x => x.Key).First();
            var actual = _sut.Minimum();

            Assert.AreEqual(expected.Key, actual.Key);
        }

        [TestMethod]
        public void Maximum_ShouldReturnNodeWithMinimumValue()
        {
            // Act
            _sut.Add(_testData);

            var expected = _testData.OrderByDescending(x => x.Key).First();
            var actual = _sut.Maximum();

            Assert.AreEqual(expected.Key, actual.Key);
        }

        [TestMethod]
        public void Maximum_ShouldReturnNull_ForEmptyTree()
        {
            Assert.IsNull(_sut.Maximum());
        }

        [TestMethod]
        public void Successor_ShouldReturnMinimalBiggerValue_GivenNoRightChild()
        {
            _sut.Add(_testData);

            SuccessorScenario(6, 7);
        }

        [TestMethod]
        public void Successor_ShouldReturnMinimalBiggerValue_WhenRightChildExists()
        {
            _sut.Add(_testData);

            SuccessorScenario(4, 5);
        }

        [TestMethod]
        public void Successor_ShouldReturnNextKey_ForAllKeysExceptMax()
        {
            _sut.Add(_testData);

            // take all keys but the maximum
            var keys = _testData.OrderByDescending(x => x.Key).Skip(1).ToList();

            foreach (var key in keys)
            {
                SuccessorScenario(key.Key, key.Key + 1);
            }
        }

        [TestMethod]
        public void Predescessor_ShouldReturnMinimalBiggerValue_GivenNoLeftChild()
        {
            _sut.Add(_testData);

            PredescessorScenario(3, 2);
        }

        [TestMethod]
        public void Predescessor_ShouldReturnMinimalBiggerValue_WhenLeftChildExists()
        {
            _sut.Add(_testData);

            PredescessorScenario(4, 3);
        }

        [TestMethod]
        public void Predescessor_ShouldReturnNextKey_ForAllKeysExceptMax()
        {
            _sut.Add(_testData);

            // take all keys but the minimum
            var keys = _testData.OrderBy(x => x.Key).Skip(1).ToList();

            foreach (var key in keys)
            {
                PredescessorScenario(key.Key, key.Key - 1);
            }
        }

        private void PredescessorScenario(int key, int prevKey)
        {
            PredescessorOrSuccessor(key, prevKey, (tree, node) => tree.Predescessor(node));
        }

        private void SuccessorScenario(int key, int nextKey)
        {
            PredescessorOrSuccessor(key, nextKey, (tree, node) => tree.Successor(node));
        }

        private void PredescessorOrSuccessor(int keyToFind, int expected, Func<BinarySearchTree<int, string>, BinarySearchTree<int, string>.Node, BinarySearchTree<int, string>.Node> nodeFinder)
        {
            var node = _sut.Find(keyToFind);
            var actual = nodeFinder(_sut, node);

            Assert.AreEqual(expected, actual.Key);
        }
    }
}