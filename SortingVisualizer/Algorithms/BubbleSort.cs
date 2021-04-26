using SortingVisualizer.Draw;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class BubbleSort : Algorithm
    {
        /// <summary>
        /// BUBBLE-SORT
        /// https://sv.wikipedia.org/wiki/Bubbelsortering
        /// </summary>

        public BubbleSort(int sleepTime, SortingWindow window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            for (int i = 0; i < Window.ArrayLength; i++)
            {
                for (int j = 0; j < Window.ArrayLength - 1; j++)
                {
                    if (Window.GetIndex(j) > Window.GetIndex(j + 1))
                    {
                        Window.Swap(j, j + 1, SleepTime);
                        Swaps++;
                    }
                }
            }
        }
    }
}
