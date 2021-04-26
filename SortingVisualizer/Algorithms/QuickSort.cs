using SortingVisualizer.Draw;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class QuickSort : Algorithm
    {
        /// <summary>
        /// QUICK-SORT
        /// Help with implementation - http://csharpexamples.com/c-quick-sort-algorithm-implementation/
        /// </summary>
        public QuickSort(int sleepTime, SortingWindow window, string name) : base(sleepTime, window, name)
        { }
        public override void Sort()
        {
            Sort(0, Window.ArrayLength - 1);
        }
        public void Sort(int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(start, end);

                Sort(start, i - 1);
                Sort(i + 1, end);
            }
        }
        private int Partition(int start, int end)
        {
            int p = Window.Array[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (Window.Array[j] <= p)
                {
                    i++;
                    Window.Swap(i, j, SleepTime);
                    Swaps++;
                }
            }
            Window.Swap(i + 1, end, SleepTime);
            Swaps++;

            return i + 1;
        }
    }
}
