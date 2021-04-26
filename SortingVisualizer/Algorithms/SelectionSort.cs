using SortingVisualizer.Draw;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class SelectionSort : Algorithm
    {
        /// <summary>
        /// SELECTION-SORT
        /// https://en.wikipedia.org/wiki/Selection_sort
        /// </summary>
        public SelectionSort(int sleepTime, SortingWindow window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            int smallest;
            for (int i = 0; i < Window.ArrayLength - 1; i++)
            {
                smallest = i;

                for (int index = i + 1; index < Window.ArrayLength; index++)
                {
                    if (Window.Array[index] < Window.Array[smallest])
                    {
                        smallest = index;
                    }
                }
                Swap(i, smallest);
                Swaps++;
            }
        }
        public void Swap(int first, int second)
        {
            Window.Swap(first, second, SleepTime);
        }
    }
}
