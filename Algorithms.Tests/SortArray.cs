using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests
{
    [TestClass]
    public class SortArray
    {
        [TestMethod]
        public void InsertionSortTest()
        {
            SortTest(Algorithms.SortArray.InsertionSort);
        }

        [TestMethod]
        public void BubbleSortTest()
        {
            SortTest(Algorithms.SortArray.BubbleSort);
        }

        [TestMethod]
        public void OptimizedBubbleSortTest()
        {
            SortTest(Algorithms.SortArray.OptimizedBubbleSort);
        }

        [TestMethod]
        public void SelectionSortTest()
        {
            SortTest(Algorithms.SortArray.SelectionSort);
        }

        [TestMethod]
        public void MergeSortTest()
        {
            SortTest(Algorithms.SortArray.MergeSort);
        }

        [DataTestMethod]
        [DataRow(100)]
        [DataRow(1000)]
        [DataRow(10000)]
        [DataRow(100000)]
        public void Compare(int length)
        {
            var a = DataProvider.GenerateArray(length, -100, 100);

            var tasks = new Task<(string name, TimeSpan time)>[] {
                Task.Factory.StartNew(() => Run(a.ToArray(), nameof(Algorithms.SortArray.BubbleSort), Algorithms.SortArray.BubbleSort)),
                Task.Factory.StartNew(() => Run(a.ToArray(), nameof(Algorithms.SortArray.OptimizedBubbleSort), Algorithms.SortArray.OptimizedBubbleSort)),
                Task.Factory.StartNew(() => Run(a.ToArray(), nameof(Algorithms.SortArray.InsertionSort), Algorithms.SortArray.InsertionSort)),
                Task.Factory.StartNew(() => Run(a.ToArray(), nameof(Algorithms.SortArray.MergeSort), Algorithms.SortArray.MergeSort)),
                Task.Factory.StartNew(() => Run(a.ToArray(), nameof(Algorithms.SortArray.SelectionSort), Algorithms.SortArray.SelectionSort)),
            };

            Task.WaitAll(tasks);

            Trace.WriteLine($"Input N: {length};");
            Trace.WriteLine(string.Join($";{Environment.NewLine}", tasks.Select(t => $"{t.Result.name}: {t.Result.time.TotalMilliseconds} ms")));
        }

        private static (string name, TimeSpan time) Run(IList<int> a, string name, Action<IList<int>> algorithm)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            algorithm(a);
            stopwatch.Stop();

            var time = stopwatch.Elapsed;

            return (name: name, time: time);
        }

        private void SortTest(Action<IList<int>> algorithm)
        {
            var a = DataProvider.GetTestArray();

            algorithm(a);

            var expected = DataProvider.GetSortedTestArray();

            for (var i = 0; i < a.Count; i++)
            {
                Assert.AreEqual(expected[i], a[i]);
            }
        }
    }
}
