using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroductionToAlgorithms.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Sorting.Tests
{
    [TestClass]
    public class InsertionSortTests : SortTests
    {
        protected override ISort<int> CreateSortAlgorithm()
        {
            return new InsertionSort<int>();
        }
    }
}