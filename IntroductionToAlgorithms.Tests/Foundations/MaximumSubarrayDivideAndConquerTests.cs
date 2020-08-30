using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntroductionToAlgorithms.Foundations.Tests
{
    [TestClass]
    public class MaximumSubarrayDivideAndConquerTests : MaximumSubarrayTests
    {
        protected override IMaximumSubarray CreateSut()
        {
            return new MaximumSubarrayDivideAndConquer();
        }
    }
}