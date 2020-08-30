using IntroductionToAlgorithms.Sorting.Tests;
using IntroductionToAlgorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToAlgorithms.Tests.Sorting
{
    [TestClass]
    public class QuickSortTests : SortTests
    {
        protected override ISort<byte> CreateSortAlgorithm()
        {
            return new QuickSort<byte>();
        }
    }
}
