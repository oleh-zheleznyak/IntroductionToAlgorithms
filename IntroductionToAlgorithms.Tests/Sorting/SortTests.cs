using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace IntroductionToAlgorithms.Sorting.Tests
{
    [TestClass]
    public abstract class SortTests
    {
        [TestMethod]
        public void SortSmallArrayTest()
        {
            Scenario(new byte[] { 3, 5, 2, 1, 4 });
        }

        [TestMethod]
        public void SortSingleElementArrayTest()
        {
            Scenario(new byte[] { 1 });
        }

        [TestMethod]
        public void SortReversedArrayTest()
        {
            Scenario(new byte[] { 5, 4, 3, 2, 1 });
        }

        [TestMethod]
        public void SortSortedArrayTest()
        {
            Scenario(new byte[] { 1, 2, 3, 4, 5 });
        }

        [TestMethod]
        public void SortArrayWithSameElementsTest()
        {
            Scenario(new byte[] { 1, 1, 1, 1, 1, 1, 1 });
        }

        private void Scenario(byte[] input)
        {
            var expected = input.OrderBy(x => x).ToArray();

            var sut = CreateSortAlgorithm();

            sut.Sort(input);

            CollectionAssert.AreEqual(expected, input);
        }

        protected abstract ISort<byte> CreateSortAlgorithm();
    }
}