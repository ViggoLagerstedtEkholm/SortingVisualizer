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
        private string name = "MergeSort";
        private int sleepTime;
        private Window sortingStarter;
        public MergeSort(int sleepTime, Window sortingStarter)
        {
            this.sleepTime = sleepTime;
            this.sortingStarter = sortingStarter;
        }
        public void Sort()
        {
            Sort(0, sortingStarter.getLength() - 1);
        }
        void Sort(int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                Sort(left, middle);
                Sort(middle + 1, right);
                Merge(left, middle, right);
            }
        }
        public void Merge(int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(sortingStarter.getArray(), left, leftArray, 0, middle - left + 1);
            Array.Copy(sortingStarter.getArray(), middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    sortingStarter.getArray()[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    sortingStarter.getArray()[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    sortingStarter.getArray()[k] = leftArray[i];
                    i++;
                }
                else
                {
                    sortingStarter.getArray()[k] = rightArray[j];
                    j++;

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
    }
}
