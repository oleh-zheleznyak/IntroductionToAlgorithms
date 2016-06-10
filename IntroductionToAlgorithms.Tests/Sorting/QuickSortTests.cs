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
    public class QuickSortTests : SortTests
    {
        protected override ISort<int> CreateSortAlgorithm()
        {
            return new QuickSort<int>();
        }
    }
}
