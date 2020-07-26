using SortingVisualizer.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class CycleSort : ISortAlgorithms
    {
        /// <summary>
        /// CYCLE-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/cycle-sort/
        /// </summary>
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "CycleSort";
        private int currentlyMoving;
        private int sleepTime;
        private SortingStarter sortingStarter;
        public CycleSort(int[] array, int sleepTime, SortingStarter sortingStarter)
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
            int writes = 0;
            int n = array.Length;
            // traverse array elements and  
            // put it to on the right place 
            for (int cycle_start = 0; cycle_start <= n - 2; cycle_start++)
            {
                // initialize item as starting point 
                int item = array[cycle_start];

                // Find position where we put the item.  
                // We basically count all smaller elements  
                // on right side of item. 
                int pos = cycle_start;
                for (int i = cycle_start + 1; i < n; i++)
                    if (array[i] < item)
                        pos++;

                // If item is already in correct position 
                if (pos == cycle_start)
                    continue;

                // ignore all duplicate elements 
                while (item == array[pos])
                    pos += 1;

                // put the item to it's right position 
                if (pos != cycle_start)
                {
                    int temp = item;
                    item = array[pos];
                    array[pos] = temp;
                    writes++;
                    currentlyMoving = array[pos];
                    iterations++;
                    Thread.Sleep(sleepTime);
                }

                // Rotate rest of the cycle 
                while (pos != cycle_start)
                {
                    pos = cycle_start;

                    // Find position where we put the element 
                    for (int i = cycle_start + 1; i < n; i++)
                        if (array[i] < item)
                            pos += 1;

                    // ignore all duplicate elements 
                    while (item == array[pos])
                        pos += 1;

                    // put the item to it's right position 
                    if (item != array[pos])
                    {
                        int temp = item;
                        item = array[pos];
                        array[pos] = temp;
                        writes++;
                        iterations++;
                        currentlyMoving = array[pos];
                        Thread.Sleep(sleepTime);
                    }
                }
            }
            Done();
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
