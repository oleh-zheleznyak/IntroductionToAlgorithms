using Microsoft.VisualStudio.TestTools.UnitTesting;
using IntroductionToAlgorithms.Foundations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Foundations.Tests
{
    [TestClass]
    public class MaximumSubarrayLinearTests : MaximumSubarrayTests
    {
        protected override IMaximumSubarray CreateSut()
        {
            return new MaximumSubarrayLinear();
        }
    }
}