using SortingVisualizer.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class StoogeSort : ISortAlgorithms
    {
        /// <summary>
        /// STOOGE-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/stooge-sort/
        /// </summary>
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "StoogeSort";
        private int currentlyMoving;
        private int sleepTime;
        private SortingStarter sortingStarter;
        public StoogeSort(int[] array, int sleepTime, SortingStarter sortingStarter)
        {
            this.array = array;
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }
        public void StartThread()
        {
            SleepThread = new Thread(temp);
            SleepThread.Start();
        }

        private void temp()
        {
            Sort(array, 0, array.Length - 1);
        }

        public void Sort(int[] arr, int l, int h)
        {
            if (l >= h)
                return;

            // If first element is smaller 
            // than last, swap them 
            if (arr[l] > arr[h])
            {
                int t = arr[l];
                arr[l] = arr[h];
                arr[h] = t;
                iterations++;
                currentlyMoving = arr[h];
                Thread.Sleep(sleepTime);
            }

            // If there are more than 2  
            // elements in the array 
            if (h - l + 1 > 2)
            {
                int t = (h - l + 1) / 3;

                // Recursively sort first  
                // 2/3 elements 
                Sort(arr, l, h - t);

                // Recursively sort last 
                // 2/3 elements 
                Sort(arr, l + t, h);

                // Recursively sort first  
                // 2/3 elements again to  
                // confirm 
                Sort(arr, l, h - t);
            }
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
            sortingStarter.StartQueue();
            SleepThread.Abort();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }
    }
}
