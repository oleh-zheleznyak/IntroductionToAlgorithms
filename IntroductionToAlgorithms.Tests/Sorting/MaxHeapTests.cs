using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroductionToAlgorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Sorting.Tests
{
    [TestClass]
    public class MaxHeapTests
    {
        [TestMethod]
        public void MaxHeap_ShouldHeapifyCorrectly_GivenUnorderedArrayOf3()
        {
            AssertEquality(new int[] { 0, 1, 2 }, new int[] { 2, 1, 0 });
        }

        [TestMethod]
        public void MaxHeap_ShouldChangeNothing_GivenOrderedArrayOf3()
        {
            AssertEquality(new int[] { 2, 1, 0 }, new int[] { 2, 1, 0 });
        }

        [TestMethod]
        public void MaxHeap_ShouldChangeNothing_GivenAValidHeapOf3()
        {
            AssertEquality(new int[] { 2, 0, 1 }, new int[] { 2, 0, 1 });
        }

        [TestMethod]
        public void MaxHeap_ShouldHeapifyCorrectly_GivenUnorderedArrayOf7()
        {
            AssertEquality(new int[] { 0, 1, 2, 3, 4, 5, 6 }, new int[] { 6, 4, 5, 3, 1, 0, 2 });
        }

        [TestMethod]
        public void MaxHeap_ShouldChangeNothing_GivenOrderedArrayOf7()
        {
            AssertEquality(new int[] { 6, 5, 4, 3, 2, 1, 0 }, new int[] { 6, 5, 4, 3, 2, 1, 0 });
        }

        [TestMethod]
        public void MaxHeap_ShouldChangeNothing_GivenAValidHeapOf7()
        {
            AssertEquality(new int[] { 6, 4, 5, 1, 3, 2, 0 }, new int[] { 6, 4, 5, 1, 3, 2, 0 });
        }

        [TestMethod]
        public void MaxHeap_Peek_ShouldRetrunMaxValue()
        {
            var input = new int[] { 5, 0, 7, 2 };
            var sut = new MaxHeap<int>(input);
            var actual = sut.Peek();
            var expected = input.Max();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MaxHeap_Pop_ShouldRetrunMaxValueAndDiscardElement()
        {
            var input = new int[] { 5, 0, 7, 2 };

            var sut = new MaxHeap<int>(input);
            var expected = input.Max();
            var actual = sut.Pop();

            Assert.AreEqual(expected, actual);
            CollectionAssert.AreEqual(new int[] { 5, 2, 0 }, sut.ToArray());
        }

        private static void AssertEquality(int[] input, int[] expected)
        {
            var sut = new MaxHeap<int>(input);

            var actual = sut.ToArray();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PushTest()
        {
            var input = new int[] { 2, 1 };

            var sut = new MaxHeap<int>(input);
            var newItem = 3;
            sut.Push(newItem);

            Assert.AreEqual(newItem, sut.Peek());
            CollectionAssert.AreEqual(new int[] { 3, 1, 2 }, sut.ToArray());
        }
    }
}