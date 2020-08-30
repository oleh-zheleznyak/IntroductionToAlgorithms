using System;

namespace IntroductionToAlgorithms.Foundations
{
    public class MaximumSubarrayLinear : IMaximumSubarray
    {
        public ArraySum FindMaximumSlice(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return new ArraySum();

            int start = 0, end = 0;
            long maxSum = array[0], maxSumAtPosition = array[0];

            int sliceStart = 0, sliceEnd = 0;

            for (int i = 1; i < array.Length; i++)
            {
                sliceEnd = i;
                if (maxSumAtPosition > 0)
                {
                    maxSumAtPosition += array[i];
                }
                else
                {
                    maxSumAtPosition = array[i];
                    sliceStart = i;
                }

                if (maxSumAtPosition > maxSum)
                {
                    maxSum = maxSumAtPosition;
                    start = sliceStart;
                    end = sliceEnd;
                }
            }

            return new ArraySum(start, end, maxSum);
        }


    }
}
