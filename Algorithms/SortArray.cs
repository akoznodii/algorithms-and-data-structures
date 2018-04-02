using System;
using System.Collections.Generic;

namespace Algorithms
{
    public static class SortArray
    {
        public static void InsertionSort(IList<int> a)
        {
            if (a == null) throw new System.ArgumentNullException(nameof(a));

            for (var i = 1; i < a.Count; i++)
            {
                var j = i - 1;

                var temp = a[i];

                while (j >= 0 && a[j] > temp)
                {
                    a[j + 1] = a[j];
                    j--;
                }

                a[j + 1] = temp;
            }
        }

        public static void SelectionSort(IList<int> a)
        {
            if (a == null) throw new System.ArgumentNullException(nameof(a));

            for (var i = 0; i < a.Count; i++)
            {
                var min = i;

                for (var j = i + 1; j < a.Count; j++)
                {
                    if (a[min] > a[j])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    var temp = a[min];
                    a[min] = a[i];
                    a[i] = temp;
                }
            }
        }

        public static void BubbleSort(IList<int> a)
        {
            if (a == null) throw new System.ArgumentNullException(nameof(a));

            var swapped = false;

            do
            {
                swapped = false;

                for (var i = 0; i < a.Count - 1; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        var temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                        swapped = true;
                    }
                }
            }
            while (swapped);
        }

        public static void OptimizedBubbleSort(IList<int> a)
        {
            if (a == null) throw new System.ArgumentNullException(nameof(a));

            var swapped = true;

            for (var i = 0; i < a.Count - 1 && swapped; i++)
            {
                swapped = false;

                for (var j = a.Count - 1; j > i; j--)
                {
                    if (a[j - 1] > a[j])
                    {
                        var temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;
                        swapped = true;
                    }
                }
            }
        }

        public static void MergeSort(IList<int> a)
        {
            MergeSort(a, 0, a.Count - 1);
        }

        private static void MergeSort(IList<int> a, int p, int r)
        {
            if (p < r)
            {
                var q = Math.Abs(p + r) / 2;

                MergeSort(a, p, q);
                MergeSort(a, q + 1, r);
                OptimizedMerge(a, p, q, r);
            }
        }

        private static void OptimizedMerge(IList<int> a, int p, int q, int r)
        {
            var left = new int[q - p + 1];
            var right = new int[r - q];

            var i = 0; var j = 0;

            for (i = 0; i < left.Length; i++)
            {
                left[i] = a[p + i];
            }

            for (j = 0; j < right.Length; j++)
            {
                right[j] = a[q + j + 1];
            }

            i = 0; j = 0;

            for (var k = p; k <= r; k++)
            {
                if ((i < left.Length && j < right.Length && left[i] <= right[j]))
                {
                    a[k] = left[i];
                    i++;
                }
                else if (j < right.Length)
                {
                    a[k] = right[j];
                    j++;
                }
                else if (i < left.Length)
                {
                    a[k] = left[i];
                    i++;
                }
            }
        }
    }
}
