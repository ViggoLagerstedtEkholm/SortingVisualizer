using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    class CombSort : ISortAlgorithms
    {
        /// <summary>
        /// COMB-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/comb-sort/
        /// </summary>
        private string name = "Comb Sort";
        private int sleepTime;
        private Window sortingStarter;
        public CombSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            int n = sortingStarter.getLength();

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
                    if (sortingStarter.getIndex(i) > sortingStarter.getIndex(i + gap))
                    {
                        // Swap arr[i] and arr[i+gap] 
                        sortingStarter.swap(i, i + 1, sleepTime);
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

        public string getName()
        {
            return name;
        }

        public int GetSleepTime()
        {
            return sleepTime;
        }

        public void setSleep(int sleepTime)
        {
            this.sleepTime = sleepTime;
        }
    }
}
