using SortingVisualizer.Setup;
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
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "InsertionSort";
        private int currentlyMoving;
        private int sleepTime;
        private SortingStarter sortingStarter;
        public InsertionSort(int[] array, int sleepTime, SortingStarter sortingStarter)
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
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        int tmp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = tmp;
                        currentlyMoving = array[j];
                        iterations++;
                        Thread.Sleep(sleepTime);
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

        public int getIterations()
        {
            return iterations;
        }

        public int getCurrentMoving()
        {
            return currentlyMoving;
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
