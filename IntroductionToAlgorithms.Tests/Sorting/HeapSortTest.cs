using IntroductionToAlgorithms.Sorting.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
