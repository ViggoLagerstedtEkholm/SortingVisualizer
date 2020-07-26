using SortingVisualizer.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class HeapSort : ISortAlgorithms
    {
        /// <summary>	
        /// HEAP-SORT	
        /// Help with implementation - https://www.geeksforgeeks.org/heap-sort/	
        /// </summary>	
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "HeapSort";
        private int currentlyMoving;
        private int sleepTime;
        private SortingStarter sortingStarter;
        public HeapSort(int[] array, int sleepTime, SortingStarter sortingStarter)
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
            int n = array.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heap(array, n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                heap(array, i, 0);
                currentlyMoving = array[i];
                iterations++;
                Thread.Sleep(sleepTime);
            }
            Done();
        }

        private void heap(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }
            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                heap(array, n, largest);
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
