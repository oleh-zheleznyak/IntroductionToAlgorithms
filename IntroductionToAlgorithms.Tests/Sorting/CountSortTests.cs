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
    public class CountSortTests : SortTests
    {
        protected override ISort<byte> CreateSortAlgorithm()
        {
            return new CountSort();
        }
    }
}