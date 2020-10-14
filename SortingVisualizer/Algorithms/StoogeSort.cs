using SortingVisualizer.Draw;
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
        private string name = "Stooge Sort";
        private int sleepTime;
        private Window sortingStarter;
        public StoogeSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }

        public void Sort()
        {
            Sort(sortingStarter.getArray(), 0, sortingStarter.getLength() - 1);
        }

        public void Sort(int[] arr, int l, int h)
        {
            if (l >= h)
                return;

            // If first element is smaller 
            // than last, swap them 
            if (arr[l] > arr[h])
            {
                sortingStarter.swap(l, h, sleepTime);
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
