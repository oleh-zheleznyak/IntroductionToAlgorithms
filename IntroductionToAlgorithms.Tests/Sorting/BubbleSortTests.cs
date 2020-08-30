using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToAlgorithms.Sorting.Tests
{
    [TestClass]
    public class BubbleSortTests : SortTests
    {
        protected override ISort<byte> CreateSortAlgorithm()
        {
            return new BubbleSort<byte>();
        }
    }
}