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
    public class CycleSort : Handler
    {
        /// <summary>
        /// CYCLE-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/cycle-sort/
        /// </summary>
        public CycleSort(int sleepTime, Window window) : base(sleepTime, window)
        { }

        public override void Sort()
        {
            sw.Start();

            int writes = 0;
            int n = Window.ArrayLength;
            // traverse array elements and  
            // put it to on the right place 
            for (int cycle_start = 0; cycle_start <= n - 2; cycle_start++)
            {
                // initialize item as starting point 
                int item = Window.Array[cycle_start];

                // Find position where we put the item.  
                // We basically count all smaller elements  
                // on right side of item. 
                int pos = cycle_start;
                for (int i = cycle_start + 1; i < n; i++)
                    if (Window.Array[i] < item)
                        pos++;

                // If item is already in correct position 
                if (pos == cycle_start)
                    continue;

                // ignore all duplicate elements 
                while (item == Window.Array[pos])
                    pos += 1;

                // put the item to it's right position 
                if (pos != cycle_start)
                {
                    //int temp = item;
                    //item = array[pos];
                    //array[pos] = temp

                    item = Window.SwapSingle(item, pos, SleepTime);
                    Swaps++;
                    writes++;
                }

                // Rotate rest of the cycle 
                while (pos != cycle_start)
                {
                    pos = cycle_start;

                    // Find position where we put the element 
                    for (int i = cycle_start + 1; i < n; i++)
                        if (Window.Array[i] < item)
                            pos += 1;

                    // ignore all duplicate elements 
                    while (item == Window.Array[pos])
                        pos += 1;

                    // put the item to it's right position 
                    if (item != Window.Array[pos])
                    {
                        item = Window.SwapSingle(item, pos, SleepTime);
                        Swaps++;
                        writes++;
                    }
                }
            }
            sw.Stop();
            ExecutionTime = sw.ElapsedMilliseconds;
        }
    }
}
