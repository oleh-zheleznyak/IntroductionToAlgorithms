using IntroductionToAlgorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace IntroductionToAlgorithms.Tests.Sorting
{
    [TestClass]
    public class ImmutableMaxHeapTests
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
            Assert.ThrowsException<ArgumentNullException>(() => new ImmutableMaxHeap<int>(null));
        }

        public void BuildMaxHeap_ShouldThrow_GivenEmptyInput()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ImmutableMaxHeap<int>(Array.Empty<int>()));
        }

        private void AssertScenario(int[] input, int[] expected, int max)
        {
            var maxHeap = new ImmutableMaxHeap<int>(input);

            Assert.AreEqual(max, maxHeap.PeekMax());
            CollectionAssert.AreEquivalent(expected, maxHeap.ToArray());
        }
    }
}
