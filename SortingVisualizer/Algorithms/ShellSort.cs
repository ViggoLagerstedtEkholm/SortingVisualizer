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
    public class ShellSort : Handler
    {
        /// <summary>
        /// SHELL-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/shellsort/
        /// </summary>
        public ShellSort(int sleepTime, Window window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            int n = window.getLength();

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = window.getArray()[i];

                    int j;
                    for (j = i; j >= gap && window.getArray()[j - gap] > temp; j -= gap)
                    {
                        //sortingStarter.getArray()[j] = sortingStarter.getArray()[j - gap];
                        window.swapSingleElement(j, window.getArray()[j - gap], sleepTime);
                    }

                    window.swapSingleElement(j, temp, sleepTime);
                    //sortingStarter.swapSingle(sortingStarter.getArray()[j], temp, sleepTime);
                }
            }
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
