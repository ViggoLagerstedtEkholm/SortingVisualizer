using SortingVisualizer.Draw;

namespace WindowsFormsApp2.Algorithms
{
    public class InsertionSort : Algorithm
    {
        /// <summary>
        /// INSERTION-SORT
        /// https://en.wikipedia.org/wiki/Insertion_sort
        /// </summary>
        public InsertionSort(int sleepTime, SortingWindow window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            for (int i = 1; i < Window.ArrayLength; i++)
            {
                int key = Window.GetIndex(i);
                int j = i - 1;

                while (j >= 0 && Window.GetIndex(j) > key)
                {
                    Window.Swap(j, j + 1, SleepTime);
                    Swaps++;
                    j -= 1;
                }
                Window.SwapSingleElement(j + 1, key, SleepTime);
            }
        }
    }
}
