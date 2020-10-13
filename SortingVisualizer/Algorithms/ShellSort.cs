using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class ShellSort : ISortAlgorithms
    {
        /// <summary>
        /// SHELL-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/shellsort/
        /// </summary>
        private string name = "ShellSort";
        private int sleepTime;
        private Window sortingStarter;

        public ShellSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            int n = sortingStarter.getLength();

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = sortingStarter.getArray()[i];

                    int j;
                    for (j = i; j >= gap && sortingStarter.getArray()[j - gap] > temp; j -= gap)
                    {
                        //sortingStarter.getArray()[j] = sortingStarter.getArray()[j - gap];
                        sortingStarter.swapSingleElement(j, sortingStarter.getArray()[j - gap], sleepTime);
                    }

                    sortingStarter.swapSingleElement(j, temp, sleepTime);
                    //sortingStarter.swapSingle(sortingStarter.getArray()[j], temp, sleepTime);
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
