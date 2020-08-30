using IntroductionToAlgorithms.Sorting.Tests;
using IntroductionToAlgorithms.Sorting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToAlgorithms.Tests.Sorting
{
    [TestClass]
    public class HeapSortTest : SortTests
    {
        protected override ISort<byte> CreateSortAlgorithm()
        {
            return new HeapSort<byte>();
        }
    }
}
