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
        public void SortTest()
        {
            var input = new int[] { 3, 5, 2, 1, 4 };
            var expected = input.OrderBy(x => x).ToArray();

            var sut = CreateSortAlgorithm();

            sut.Sort(input);

            CollectionAssert.AreEqual(expected, input);
        }

        protected abstract ISort<int> CreateSortAlgorithm();
    }
}