using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class FindMaximumSubarray
    {
        [TestMethod]
        public void BrutalForceTest()
        {
            var a = DataProvider.GetTestArray();

            var actual = Algorithms.FindMaximumSubarray.BrutalForce(a);

            var expected = DataProvider.GetMaximumSubarrayFromTestArray();

            Assert.AreEqual(expected.low, actual.low);
            Assert.AreEqual(expected.high, actual.high);
            Assert.AreEqual(expected.sum, actual.sum);
        }


        [TestMethod]
        public void RecursionTest()
        {
            var a = DataProvider.GetTestArray();

            var actual = Algorithms.FindMaximumSubarray.Recursion(a);

            var expected = DataProvider.GetMaximumSubarrayFromTestArray();

            Assert.AreEqual(expected.low, actual.low);
            Assert.AreEqual(expected.high, actual.high);
            Assert.AreEqual(expected.sum, actual.sum);
        }

        [DataTestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        [DataRow(100000)]
        public void Compare(int length)
        {
            var a1 = CreateArray(length);
            var a2 = a1.Select(i => i).ToArray();

            var t1 = Task.Factory.StartNew(() => Compute(a1, Algorithms.FindMaximumSubarray.BrutalForce));
            var t2 = Task.Factory.StartNew(() => Compute(a2, Algorithms.FindMaximumSubarray.Recursion));

            Task.WaitAll(t1, t2);

            Trace.WriteLine($"Results: Brutal Force: {t1.Result.result}; Recursion: {t2.Result.result}");
            Trace.WriteLine($"Input N: {length}; Brutal Force: {t1.Result.time.TotalMilliseconds} ms; Recursion: {t2.Result.time.TotalMilliseconds} ms;");
        }

        private static (TimeSpan time, (int low, int high, int sum) result) Compute(IList<int> a, Func<IList<int>, (int low, int high, int sum)> algorithm)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var result = algorithm(a);
            stopwatch.Stop();

            var time = stopwatch.Elapsed;

            return (time: time, result: result);
        }

        private static IList<int> CreateArray(int length)
        {
            return DataProvider.GenerateArray(length, -20, 20);
        }
    }
}
