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
    public class MaximumSubarrayDivideAndConquerTests
    {
        MaximumSubarrayDivideAndConquer _sut = new MaximumSubarrayDivideAndConquer();

        [TestMethod]
        public void FindMaximumSlice_ShouldReturnSingleElement_ForOneElementArray()
        {
            AssertMaxSliceForArrayIs(new int[] { 42 }, new ArraySum(0, 0, 42));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldReturnSum_GivenArrayOfTwoPositiveElements()
        {
            AssertMaxSliceForArrayIs(new int[] { 1,2 }, new ArraySum(0, 1, 3));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldReturnMax_GivenArrayOfTwoElementsWithDifferentSign()
        {
            AssertMaxSliceForArrayIs(new int[] { -1, 2 }, new ArraySum(1, 1, 2));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldReturnSum_GivenNegativeElementInTheMiddle()
        {
            AssertMaxSliceForArrayIs(new int[] { 2, -1,  2 }, new ArraySum(0, 2, 3));
        }

        [TestMethod]
        public void FindMaximumSlice_ShouldIgnorePart_GivenNegativeSequenceOnOneSide()
        {
            AssertMaxSliceForArrayIs(new int[] { -2, -1, 1, 2 }, new ArraySum(2, 3, 3));
        }

        private void AssertMaxSliceForArrayIs(int[] input, ArraySum expected)
        {
            var actual = _sut.FindMaximumSlice(input);
            Assert.AreEqual(expected, actual);
        }
    }
}