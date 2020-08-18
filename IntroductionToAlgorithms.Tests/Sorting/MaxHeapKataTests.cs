using IntroductionToAlgorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace IntroductionToAlgorithms.Tests.Sorting
{
    [TestClass]
    public class MaxHeapKataTests
    {
        [TestMethod]
        public void UnsortedInputBalancedMinimal()
        {
            AssertScenario(new[] { 1, 2, 3 }, new[] { 3, 2, 1 }, 3);
        }

        [TestMethod]
        public void TrivialHeap()
        {
            AssertScenario(new[] { 1 }, new[] { 1 }, 1);
        }

        [TestMethod]
        public void UnsortedInputUnbalanced()
        {
            AssertScenario(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 }, 5);
        }

        [TestMethod]
        public void HeapSortExample_Figure6_3()
        {
            AssertScenario(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 }, new[] { 16, 14, 10, 8, 7, 9, 3, 2, 4, 1 }, 16);
        }

        public void BuildMaxHeap_ShouldThrow_GivenNullInput()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new MaxHeapKata<int>(null));
        }

        public void BuildMaxHeap_ShouldThrow_GivenEmptyInput()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new MaxHeapKata<int>(Array.Empty<int>()));
        }

        [TestMethod]
        public void Peek_ReturnsMax_AndDoesNotRemoveElement()
        {
            var input = new int[] { 42, 1, 2 };
            var maxHeap = new MaxHeapKata<int>(input);

            Assert.AreEqual(42, maxHeap.Peek());
            CollectionAssert.AreEquivalent(input, maxHeap.ToArray());
        }

        [TestMethod]
        public void Pop_ReturnsMaxAndRemovesTheElement()
        {
            var maxHeap = MaxHeap(42, 1, 2);

            Assert.AreEqual(42, maxHeap.Pop());
            CollectionAssert.AreEquivalent(new int[] { 1, 2 }, maxHeap.ToArray());
        }

        [TestMethod]
        public void Peek_Throws_WhenHeapIsEmpty() =>
            AssertThrowsWhenEmpty(x => x.Peek());

        [TestMethod]
        public void Pop_Throws_WhenHeapIsEmpty() =>
            AssertThrowsWhenEmpty(x => x.Pop());

        private void AssertThrowsWhenEmpty(Action<MaxHeapKata<int>> action)
        {
            var maxHeap = EmptyHeap();
            Assert.ThrowsException<InvalidOperationException>(() => action(maxHeap));
        }

        private void AssertScenario(int[] input, int[] expected, int max)
        {
            var maxHeap = new MaxHeapKata<int>(input);

            Assert.AreEqual(max, maxHeap.Peek());
            CollectionAssert.AreEquivalent(expected, maxHeap.ToArray());
        }

        private MaxHeapKata<int> MaxHeap(params int[] values) => new MaxHeapKata<int>(values);

        private MaxHeapKata<int> EmptyHeap()
        {
            var maxHeap = MaxHeap(42);
            maxHeap.Pop();
            return maxHeap;
        }
    }
}
