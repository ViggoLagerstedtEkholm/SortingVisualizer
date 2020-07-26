using SortingVisualizer.Setup;
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
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "CombSort";
        private int currentlyMoving;
        private int sleepTime;
        private SortingStarter sortingStarter;
        public CombSort(int[] array, int sleepTime, SortingStarter sortingStarter)
        {
            this.array = array;
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }
        public void StartThread()
        {
            SleepThread = new Thread(Sort);
            SleepThread.Start();
        }

        public void Sort()
        {
            int n = array.Length;

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
                    if (array[i] > array[i + gap])
                    {
                        // Swap arr[i] and arr[i+gap] 
                        int temp = array[i];
                        array[i] = array[i + gap];
                        array[i + gap] = temp;
                        iterations++;
                        currentlyMoving = array[i + gap];
                        Thread.Sleep(sleepTime);
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
        public int getCurrentMoving()
        {
            return currentlyMoving;
        }

        public int getIterations()
        {
            return iterations;
        }

        public string getName()
        {
            return name;
        }

        public int getValue(int index)
        {
            return array[index];
        }

        public void Done()
        {
            sortingStarter.DequeueItem();
            sortingStarter.StartQueue();
            SleepThread.Abort();
        }
    }
}
