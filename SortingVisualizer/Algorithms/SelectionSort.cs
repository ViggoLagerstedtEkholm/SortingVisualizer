using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class SelectionSort : ISortAlgorithms
    {
        /// <summary>
        /// SELECTION-SORT
        /// https://en.wikipedia.org/wiki/Selection_sort
        /// </summary>
        private string name = "Selection Sort";
        private int sleepTime;
        private Window sortingStarter;
        public SelectionSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            int smallest;
            for (int i = 0; i < sortingStarter.getLength() - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < sortingStarter.getLength(); index++)
                {
                    if (sortingStarter.getArray()[index] < sortingStarter.getArray()[smallest])
                    {
                        smallest = index;
                    }
                }
                Swap(i, smallest);
            }
        }

        public void Swap(int first, int second)
        {
            sortingStarter.swap(first, second, sleepTime);
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
