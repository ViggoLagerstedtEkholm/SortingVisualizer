using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class QuickSort : ISortAlgorithms
    {
        /// <summary>
        /// QUICK-SORT
        /// Help with implementation - http://csharpexamples.com/c-quick-sort-algorithm-implementation/
        /// </summary>
        private string name = "Quick Sort";
        private int sleepTime;
        private Window sortingStarter;
        public QuickSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            Sort(0, sortingStarter.getLength() - 1);
        }
        public void Sort(int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(start, end);

                Sort(start, i - 1);
                Sort(i + 1, end);
            }
        }
        private int Partition(int start, int end)
        {
            int temp;
            int p = sortingStarter.getArray()[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (sortingStarter.getArray()[j] <= p)
                {
                    i++;
                    sortingStarter.swap(i, j, sleepTime);
                }
            }
            sortingStarter.swap(i + 1, end, sleepTime);

            return i + 1;
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
