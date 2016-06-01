using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToAlgorithms.Foundations
{
    public class MaximumSubarrayDivideAndConquer
    {
        public ArraySum FindMaximumSlice(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return new ArraySum();

            return FindMaximumSlice(array, 0, array.Length - 1);
        }

        private ArraySum FindMaximumSlice(int[] array, int start, int end)
        {
            if (start > end) throw new InvalidOperationException();
            if (start == end) return new ArraySum(start, end, array[start]);

            var half = (end + start) / 2;
            var left = FindMaximumSlice(array, start, half);
            var right = FindMaximumSlice(array, half + 1, end);
            var mid = FindMaximumSliceCrossing(array, start, half, end);

            var max = Maximum(left, mid, right);

            return max;
        }

        private ArraySum Maximum(params ArraySum[] element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));

            var max = element[0];
            for (int i = 1; i < element.Length; i++)
            {
                if (element[i].Sum > max.Sum) max = element[i];
            }

            return max;
        }

        private ArraySum FindMaximumSliceCrossing(int[] array, int start, int mid, int end)
        {
            var right = CalculateRightSum(array, mid, end);

            var left = CalculateLeftSum(array, start, mid);

            return new ArraySum(left.Start, right.End, left.Sum + array[mid] + right.Sum);
        }

        private ArraySum CalculateRightSum(int[] array, int mid, int end)
        {
            int rightSum = 0;
            long maxRightSum = 0;
            int rightIndex = mid;
            for (int i = mid + 1; i <= end; i++)
            {
                rightSum += array[i];
                if (rightSum > maxRightSum)
                {
                    rightIndex = i;
                    maxRightSum = rightSum;
                }
            }

            return new ArraySum(mid + 1, rightIndex, maxRightSum);
        }

        private ArraySum CalculateLeftSum(int[] array, int start, int mid)
        {
            int leftSum = 0;
            long maxLeftSum = 0;
            int leftIndex = mid;

            for (int i = mid - 1; i >= start; i--)
            {
                leftSum += array[i];
                if (leftSum > maxLeftSum)
                {
                    leftIndex = i;
                    maxLeftSum = leftSum;
                }
            }

            return new ArraySum(leftIndex, mid - 1, maxLeftSum);
        }
    }
}