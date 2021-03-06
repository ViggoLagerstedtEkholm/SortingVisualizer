﻿using SortingVisualizer.Draw;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    class CombSort : Algorithm
    {
        /// <summary>
        /// COMB-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/comb-sort/
        /// </summary>
        public CombSort(int sleepTime, SortingWindow window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            int n = Window.ArrayLength;

            // initialize gap 
            int gap = n;

            // Initialize swapped as true to  
            // make sure that loop runs 
            bool swapped = true;

            // Keep running while gap is more than  
            // 1 and last iteration caused a swap 
            while (gap != 1 || swapped == true)
            {
                // Find next gap 
                gap = GetNextGap(gap);

                // Initialize swapped as false so that we can 
                // check if swap happened or not 
                swapped = false;

                // Compare all elements with current gap 
                for (int i = 0; i < n - gap; i++)
                {
                    if (Window.GetIndex(i) > Window.GetIndex(i + gap))
                    {
                        // Swap arr[i] and arr[i+gap] 
                        Window.Swap(i, i + 1, SleepTime);
                        Swaps++;
                        // Set swapped 
                        swapped = true;
                    }
                }
            }
        }
        static int GetNextGap(int gap)
        {
            // Shrink gap by Shrink factor 
            gap = (gap * 10) / 13;
            if (gap < 1)
                return 1;
            return gap;
        }
    }
}
