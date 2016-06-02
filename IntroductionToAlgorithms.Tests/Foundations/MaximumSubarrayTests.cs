using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroductionToAlgorithms.Foundations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Foundations.Tests
{
    [TestClass]
    public abstract class MaximumSubarrayTests
    {
        [TestMethod]
        public void FindMaximumSlice_ShouldReturnSingleElement_ForOneElementArray()
        {
            AssertMaxSliceForArrayIs(new int[] { 42 }, new ArraySum(0, 0, 42));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldReturnSum_GivenArrayOfTwoPositiveElements()
        {
            AssertMaxSliceForArrayIs(new int[] { 1, 2 }, new ArraySum(0, 1, 3));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldReturnMax_GivenArrayOfTwoElementsWithDifferentSign()
        {
            AssertMaxSliceForArrayIs(new int[] { -1, 2 }, new ArraySum(1, 1, 2));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldReturnSum_GivenNegativeElementInTheMiddle()
        {
            AssertMaxSliceForArrayIs(new int[] { 2, -1, 2 }, new ArraySum(0, 2, 3));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldIgnorePart_GivenNegativeSequenceOnOneSide()
        {
            AssertMaxSliceForArrayIs(new int[] { -2, -1, 1, 2 }, new ArraySum(2, 3, 3));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldReturnMaxElement_GivenNegativeSequence()
        {
            AssertMaxSliceForArrayIs(new int[] { -1, -2, -3, -4 }, new ArraySum(0, 0, -1));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldReturnSumOverAllArray_GivenPeriodicalFunction()
        {
            var count = 10;
            var minusOne = Enumerable.Repeat(-1, count);
            var two = Enumerable.Repeat(2, count);
            var zip = Enumerable.Zip(two, minusOne, (x, y) => new int[] { x, y }).SelectMany(x => x).ToArray();

            // NOTE: last "one" is excluded from the sequence
            AssertMaxSliceForArrayIs(zip, new ArraySum(0, zip.Length - 2, 2 * count - count + 1));
        }

        private void AssertMaxSliceForArrayIs(int[] input, ArraySum expected)
        {
            var sut = CreateSut();
            var actual = sut.FindMaximumSlice(input);
            Assert.AreEqual(expected, actual);
        }

        protected abstract IMaximumSubarray CreateSut();
        
    }
}