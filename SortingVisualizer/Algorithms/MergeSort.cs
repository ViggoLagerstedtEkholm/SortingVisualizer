using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class MergeSort : Handler
    {
        /// <summary>
        /// MERGE-SORT
        /// Help with implementation - http://csharpexamples.com/c-merge-sort-algorithm-implementation/
        /// </summary>
        public MergeSort(int sleepTime, SortingWindow window) : base(sleepTime, window)
        { }
        public override void Sort()
        {
            Sort(0, Window.ArrayLength - 1);
        }
        void Sort(int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Sort(left, middle);
                Sort(middle + 1, right);
                Merge(left, middle, right);
            }
        }
        public void Merge(int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(Window.Array, left, leftArray, 0, middle - left + 1);
            Array.Copy(Window.Array, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    Window.SwapSingle(rightArray[j], k, SleepTime);
                    Swaps++;
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    Window.SwapSingle(leftArray[i], k, SleepTime);
                    Swaps++;
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    Window.SwapSingle(leftArray[i], k, SleepTime);
                    Swaps++;
                    i++;
                }
                else
                {
                    Window.SwapSingle(rightArray[j], k, SleepTime);
                    Swaps++;
                    j++;
                }
            }
        }
    }
}
