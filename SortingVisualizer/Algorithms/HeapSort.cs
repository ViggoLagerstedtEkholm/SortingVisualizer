using SortingVisualizer.Draw;
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

        private string name = "HeapSort";
        private int sleepTime;
        private Window sortingStarter;
        public HeapSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }
        public void Sort()
        {
            int n = sortingStarter.getLength();
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heap(sortingStarter.getArray(), n, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                sortingStarter.swap(0, i, sleepTime);
                heap(sortingStarter.getArray(), i, 0);
            }
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
                sortingStarter.swap(i, largest, sleepTime);
                heap(array, n, largest);
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
