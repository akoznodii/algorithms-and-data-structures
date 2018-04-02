using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Tests
{
    public static class DataProvider
    {
        public static IList<int> GenerateArray(int length, int min, int max)
        {
            var random = new Random();

            return Enumerable.Range(1, length).Select(i => random.Next(min, max)).ToArray();
        }

        public static IList<int> GetTestArray()
        {
            return new[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };
        }

        public static IList<int> GetSortedTestArray()
        {
            return GetTestArray().OrderBy(i => i).ToArray();
        }

        public static (int low, int high, int sum) GetMaximumSubarrayFromTestArray()
        {
            return (low: 7, high: 10, sum: 43);
        }
    }
}
