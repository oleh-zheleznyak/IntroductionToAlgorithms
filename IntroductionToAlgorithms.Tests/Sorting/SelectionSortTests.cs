using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToAlgorithms.Sorting.Tests
{
    [TestClass]
    public class SelectionSortTests : SortTests
    {
        protected override ISort<byte> CreateSortAlgorithm()
        {
            return new SelectionSort<byte>();
        }
    }
}