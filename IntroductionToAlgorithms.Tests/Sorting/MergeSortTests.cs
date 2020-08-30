using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToAlgorithms.Sorting.Tests
{
    [TestClass]
    public class MergeSortTests : SortTests
    {
        protected override ISort<byte> CreateSortAlgorithm()
        {
            return new MergeSort<byte>();
        }
    }
}