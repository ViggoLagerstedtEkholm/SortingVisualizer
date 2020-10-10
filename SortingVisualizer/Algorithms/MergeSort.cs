using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingVisualizer.Algorithms
{
    public class MergeSort : ISortAlgorithms
    {
        /// <summary>
        /// MERGE-SORT
        /// Help with implementation - http://csharpexamples.com/c-merge-sort-algorithm-implementation/
        /// </summary>
        private int[] array;
        private Thread SleepThread = null;
        public int iterations;
        private string name = "MergeSort";
        private int currentlyMoving;
        private int sleepTime;
        private Window sortingStarter;
        public MergeSort(int[] array, int sleepTime, Window sortingStarter)
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
            Sort(0, array.Length - 1);
            Done();
        }
        void Sort(int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Sort(left, middle);
                Sort(middle + 1, right);
                Merge(left, middle, right);
                iterations++;
                Thread.Sleep(sleepTime);
            }
        }
        public void Merge(int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(array, left, leftArray, 0, middle - left + 1);
            Array.Copy(array, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    array[k] = rightArray[j];
                    j++;
                    currentlyMoving = array[k];
                }
                else if (j == rightArray.Length)
                {
                    array[k] = leftArray[i];
                    i++;
                    currentlyMoving = array[k];
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                    currentlyMoving = array[k];
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                    currentlyMoving = array[k];
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

        public void Sort()
        {}
    }
}
