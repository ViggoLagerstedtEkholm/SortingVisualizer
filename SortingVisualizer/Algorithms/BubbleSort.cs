using SortingVisualizer.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class BubbleSort : ISortAlgorithms
    {
        /// <summary>
        /// BUBBLE-SORT
        /// https://sv.wikipedia.org/wiki/Bubbelsortering
        /// </summary>
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "BubbleSort";
        private int currentlyMoving;
        private int sleepTime;
        SortingStarter sortingStarter;
        public BubbleSort(int[] array, int sleepTime, SortingStarter sortingStarter)
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
            for (int i = 0; i < array.Length; i++)
            {

                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                        currentlyMoving = array[j];
                        iterations++;
                        Thread.Sleep(sleepTime);
                    }
                }
            }
            Done();
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
            sortingStarter.Shuffle();
            sortingStarter.StartQueue();
            SleepThread.Abort();
        }
    }
}
