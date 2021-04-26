using SortingVisualizer.Draw;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class StoogeSort : Algorithm
    {
        /// <summary>
        /// STOOGE-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/stooge-sort/
        /// </summary>
        public StoogeSort(int sleepTime, SortingWindow window, string name) : base(sleepTime, window, name)
        { }
        public override void Sort()
        {
            Sort(Window.Array, 0, Window.ArrayLength - 1);
        }

        public void Sort(int[] arr, int l, int h)
        {
            if (l >= h)
                return;

            // If first element is smaller 
            // than last, swap them 
            if (arr[l] > arr[h])
            {
                Window.Swap(l, h, SleepTime);
                Swaps++;
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
    }
}
