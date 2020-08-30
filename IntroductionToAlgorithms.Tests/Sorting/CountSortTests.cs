using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToAlgorithms.Sorting.Tests
{
    [TestClass]
    public class CountSortTests : SortTests
    {
        protected override ISort<byte> CreateSortAlgorithm()
        {
            return new CountSort();
        }
    }
}