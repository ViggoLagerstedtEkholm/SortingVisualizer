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
    public class ShellSort : Handler
    {
        /// <summary>
        /// SHELL-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/shellsort/
        /// </summary>
        public ShellSort(int sleepTime, Window window) : base(sleepTime, window)
        { }

        public override void Sort()
        {
            sw.Start();

            int n = Window.GetLength();

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = Window.GetArray()[i];

                    int j;
                    for (j = i; j >= gap && Window.GetArray()[j - gap] > temp; j -= gap)
                    {
                        //sortingStarter.getArray()[j] = sortingStarter.getArray()[j - gap];
                        Window.SwapSingleElement(j, Window.GetArray()[j - gap], SleepTime);
                        Swaps++;
                    }

                    Window.SwapSingleElement(j, temp, SleepTime);
                    Swaps++;
                    //sortingStarter.swapSingle(sortingStarter.getArray()[j], temp, sleepTime);
                }
            }

            sw.Stop();
            ExecutionTime = sw.ElapsedMilliseconds;
        }
    }
}
