using SortingVisualizer.Draw;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    class CocktailSort : Algorithm
    {
        /// <summary>
        /// COCKTAIL-SORT
        /// Help with implementation - https://www.geeksforgeeks.org/cocktail-sort/
        /// </summary>
        public CocktailSort(int sleepTime, SortingWindow window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            bool swapped = true;
            int start = 0;
            int end = Window.ArrayLength;

            while (swapped == true)
            {
                swapped = false;

                for (int i = start; i < end - 1; ++i)
                {
                    if (Window.GetIndex(i) > Window.GetIndex(i + 1))
                    {
                        Window.Swap(i, i + 1, SleepTime);
                        Swaps++;
                        swapped = true;
                    }
                }

                if (swapped == false)
                {
                    break;
                }
                swapped = false;

                end -= 1;

                for (int i = end - 1; i >= start; i--)
                {
                    if (Window.GetIndex(i) > Window.GetIndex(i + 1))
                    {
                        Window.Swap(i, i + 1, SleepTime);
                        Swaps++;
                        swapped = true;
                    }
                }
                start += 1;
            }
        }
    }
}
