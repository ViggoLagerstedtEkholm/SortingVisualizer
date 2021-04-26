using SortingVisualizer.Draw;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class ShellSort : Algorithm
    {
        /// <summary>
        /// SHELL-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/shellsort/
        /// </summary>
        public ShellSort(int sleepTime, SortingWindow window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            int n = Window.ArrayLength;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = Window.Array[i];

                    int j;
                    for (j = i; j >= gap && Window.Array[j - gap] > temp; j -= gap)
                    {
                        //sortingStarter.Array[j] = sortingStarter.Array[j - gap];
                        Window.SwapSingleElement(j, Window.Array[j - gap], SleepTime);
                        Swaps++;
                    }

                    Window.SwapSingleElement(j, temp, SleepTime);
                    Swaps++;
                    //sortingStarter.swapSingle(sortingStarter.getArray()[j], temp, sleepTime);
                }
            }
        }
    }
}
