using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class FindMaximumSubarray
    {
        /// <summary>
        /// Algorithm's time complexity is O(n^2)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static (int low, int high, int sum) BrutalForce(IList<int> a)
        {
            if (a == null) throw new System.ArgumentNullException(nameof(a));

            var low = 0;
            var high = 0;
            var maxSum = int.MinValue;

            for (var i = 0; i < a.Count; i++)
            {
                var sum = 0;

                for (var j = i; j < a.Count; j++)
                {
                    sum += a[j];

                    if (sum > maxSum)
                    {
                        low = i;
                        high = j;
                        maxSum = sum;
                    }
                }
            }

            return (low, high, maxSum);
        }

        /// <summary>
        /// Alorigthm's time complexity is O(n*log(n))
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static (int low, int high, int sum) Recursion(IList<int> a)
        {
            if (a == null) throw new System.ArgumentNullException(nameof(a));

            return FindMaxSubarray(a, 0, a.Count - 1);
        }

        private static (int low, int high, int sum) FindMaxSubarray(IList<int> a, int low, int high)
        {
            if (high == low)
            {
                return (low, high, a[low]);
            }
            else
            {
                var mid = Math.Abs(low + high) / 2;

                var left = FindMaxSubarray(a, low, mid);
                var right = FindMaxSubarray(a, mid + 1, high);
                var cross = FindMaxCrossingSubarray(a, low, mid, high);

                if (left.sum >= right.sum && left.sum >= cross.sum)
                {
                    return left;
                }

                if (right.sum >= left.sum && right.sum >= cross.sum)
                {
                    return right;
                }

                return cross;
            }
        }

        private static (int low, int high, int sum) FindMaxCrossingSubarray(IList<int> a, int low, int mid, int high)
        {
            var maxLeft = low;
            var maxRight = high - 1;
            var leftSum = int.MinValue;
            var rightSum = int.MinValue;
            var sum = 0;

            for (var i = mid; i >= low; i--)
            {
                sum += a[i];

                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            sum = 0;

            for (var i = mid + 1; i <= high; i++)
            {
                sum += a[i];

                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = i;
                }
            }

            return (maxLeft, maxRight, leftSum + rightSum);
        }
    }
}
