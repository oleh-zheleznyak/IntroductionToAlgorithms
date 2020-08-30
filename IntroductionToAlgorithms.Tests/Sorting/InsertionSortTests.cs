using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToAlgorithms.Sorting.Tests
{
    [TestClass]
    public class InsertionSortTests : SortTests
    {
        protected override ISort<byte> CreateSortAlgorithm()
        {
            return new InsertionSort<byte>();
        }
    }
}