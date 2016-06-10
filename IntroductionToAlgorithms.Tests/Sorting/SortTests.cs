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
    public abstract class SortTests
    {
        [TestMethod]
        public void SortSmallArrayTest()
        {
            Scenario(new int[] { 3, 5, 2, 1, 4 });
        }

        [TestMethod]
        public void SortSingleElementArrayTest()
        {
            Scenario(new int[] { 1 });
        }

        [TestMethod]
        public void SortReversedArrayTest()
        {
            Scenario(new int[] { 5, 4, 3, 2, 1 });
        }

        [TestMethod]
        public void SortSortedArrayTest()
        {
            Scenario(new int[] { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void SortArrayWithSameElementsTest()
        {
            Scenario(new int[] { 1, 1, 1, 1, 1, 1, 1 });
        }

        private void Scenario(int[] input)
        {
            var expected = input.OrderBy(x => x).ToArray();

            var sut = CreateSortAlgorithm();

            sut.Sort(input);

            CollectionAssert.AreEqual(expected, input);
        }

        protected abstract ISort<int> CreateSortAlgorithm();
    }
}