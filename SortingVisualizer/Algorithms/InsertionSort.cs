using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class InsertionSort : ISortAlgorithms
    {
        /// <summary>
        /// INSERTION-SORT
        /// https://en.wikipedia.org/wiki/Insertion_sort
        /// </summary>
        private string name = "Insertion Sort";
        private int sleepTime;
        private Window sortingStarter;
        public InsertionSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            for (int i = 1; i < sortingStarter.getLength(); i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (sortingStarter.getIndex(j) < sortingStarter.getIndex(j - 1))
                    {
                        sortingStarter.swap(j - 1, j, sleepTime);
                    }
                    else
                    {
                        break;
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

        public void setSleep(int sleepTime)
        {
            this.sleepTime = sleepTime;
        }
    }
}
