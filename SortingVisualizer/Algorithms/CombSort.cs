using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    class CombSort : Handler
    {
        /// <summary>
        /// COMB-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/comb-sort/
        /// </summary>
        public CombSort(int sleepTime, Window window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            int n = window.getLength();

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
                gap = getNextGap(gap);

                // Initialize swapped as false so that we can 
                // check if swap happened or not 
                swapped = false;

                // Compare all elements with current gap 
                for (int i = 0; i < n - gap; i++)
                {
                    if (window.getIndex(i) > window.getIndex(i + gap))
                    {
                        // Swap arr[i] and arr[i+gap] 
                        window.swap(i, i + 1, sleepTime);
                        // Set swapped 
                        swapped = true;
                    }
                }
            }
        }
        static int getNextGap(int gap)
        {
            // Shrink gap by Shrink factor 
            gap = (gap * 10) / 13;
            if (gap < 1)
                return 1;
            return gap;
        }

        public override string getName()
        {
            return name;
        }

        public override int GetSleepTime()
        {
            return sleepTime;
        }

        public override void setSleep(int sleepTime)
        {
            this.sleepTime = sleepTime;
        }
    }
}
