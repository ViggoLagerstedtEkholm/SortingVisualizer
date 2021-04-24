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
    public class StoogeSort : Handler
    {
        /// <summary>
        /// STOOGE-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/stooge-sort/
        /// </summary>
        public StoogeSort(int sleepTime, Window window) : base(sleepTime, window)
        { }
        public override void Sort()
        {
            sw.Start();

            Sort(Window.Array, 0, Window.ArrayLength - 1);

            sw.Stop();
            ExecutionTime = sw.ElapsedMilliseconds;
        }

        public void Sort(int[] arr, int l, int h)
        {
            if (l >= h)
                return;

            // If first element is smaller 
            // than last, swap them 
            if (arr[l] > arr[h])
            {
                Window.Swap(l, h, SleepTime);
                Swaps++;
            }

            // If there are more than 2  
            // elements in the array 
            if (h - l + 1 > 2)
            {
                int t = (h - l + 1) / 3;

                // Recursively sort first  
                // 2/3 elements 
                Sort(arr, l, h - t);

                // Recursively sort last 
                // 2/3 elements 
                Sort(arr, l + t, h);

                // Recursively sort first  
                // 2/3 elements again to  
                // confirm 
                Sort(arr, l, h - t);
            }
        }
    }
}
