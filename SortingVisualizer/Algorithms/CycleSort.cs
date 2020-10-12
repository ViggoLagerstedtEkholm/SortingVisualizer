using SortingVisualizer.Draw;
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
        private string name = "CycleSort";
        private int sleepTime;
        private Window sortingStarter;
        public CycleSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            int writes = 0;
            int n = sortingStarter.getLength();
            // traverse array elements and  
            // put it to on the right place 
            for (int cycle_start = 0; cycle_start <= n - 2; cycle_start++)
            {
                // initialize item as starting point 
                int item = sortingStarter.getIndex(cycle_start);

                // Find position where we put the item.  
                // We basically count all smaller elements  
                // on right side of item. 
                int pos = cycle_start;
                for (int i = cycle_start + 1; i < n; i++)
                    if (sortingStarter.getIndex(i) < item)
                        pos++;

                // If item is already in correct position 
                if (pos == cycle_start)
                    continue;

                // ignore all duplicate elements 
                while (item == sortingStarter.getIndex(pos))
                    pos += 1;

                // put the item to it's right position 
                if (pos != cycle_start)
                {
                    sortingStarter.swapSingle(sortingStarter.getIndex(pos), pos, sleepTime);
                    writes++;
                    Thread.Sleep(sleepTime);
                }

                // Rotate rest of the cycle 
                while (pos != cycle_start)
                {
                    pos = cycle_start;

                    // Find position where we put the element 
                    for (int i = cycle_start + 1; i < n; i++)
                        if (sortingStarter.getIndex(i) < item)
                            pos += 1;

                    // ignore all duplicate elements 
                    while (item == sortingStarter.getIndex(pos))
                        pos += 1;

                    // put the item to it's right position 
                    if (item != sortingStarter.getIndex(pos))
                    {
                        sortingStarter.swapSingle(sortingStarter.getIndex(pos), pos, sleepTime);
                        writes++;
                        Thread.Sleep(sleepTime);
                    }
                }
            }
        }

        public string getName()
        {
            return name;
        }

        public int GetSleepTime()
        {
            return sleepTime;
        }
    }
}
