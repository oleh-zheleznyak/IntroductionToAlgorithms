using Microsoft.VisualStudio.TestTools.UnitTesting;

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