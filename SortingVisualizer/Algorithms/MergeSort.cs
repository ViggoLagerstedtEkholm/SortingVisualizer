using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class MergeSort : Handler
    {
        /// <summary>
        /// MERGE-SORT
        /// Help with implementation - http://csharpexamples.com/c-merge-sort-algorithm-implementation/
        /// </summary>
        public MergeSort(int sleepTime, Window window, string name) : base(sleepTime, window, name)
        { }
        public override void Sort()
        { 
            Sort(0, window.getLength() - 1);
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

            Array.Copy(window.getArray(), left, leftArray, 0, middle - left + 1);
            Array.Copy(window.getArray(), middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    window.swapSingle(rightArray[j], k, sleepTime);
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    window.swapSingle(leftArray[i], k, sleepTime);
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    window.swapSingle(leftArray[i], k, sleepTime);
                    i++;
                }
                else
                {
                    window.swapSingle(rightArray[j], k, sleepTime);
                    j++;
                }
            }
        }
        public override string getName()
        {
            return name;
        }

        public override int GetSleepTime()
        {
            return sleepTime;
        }

        public override void setSleep(int sleepTime)
        {
            this.sleepTime = sleepTime;
        }
    }
}
