using SortingVisualizer.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class GnomeSort : ISortAlgorithms
    {
        /// <summary>
        /// GNOME-SORT
        /// https://en.wikipedia.org/wiki/Gnome_sort
        /// </summary>
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "GnomeSort";
        private int currentlyMoving;
        private int sleepTime;
        SortingStarter sortingStarter;
        
        public GnomeSort(int[] array, int sleepTime, SortingStarter sortingStarter)
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
            int index = 0;
            int n = array.Length;
            while (index < n)
            {
                if (index == 0)
                    index++;
                if (array[index] >= array[index - 1])
                    index++;
                else
                {
                    int temp = 0;
                    temp = array[index];
                    array[index] = array[index - 1];
                    array[index - 1] = temp;
                    index--;
                    iterations++;
                    Thread.Sleep(sleepTime);
                    currentlyMoving = array[index];
                }
            }
            Done();
        }


        public int getCurrentMoving()
        {
            return currentlyMoving;
        }

        public int getIterations()
        {
            return iterations;
        }

        public string getName()
        {
            return name;
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
