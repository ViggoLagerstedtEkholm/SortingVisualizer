using SortingVisualizer.Draw;
using WindowsFormsApp2.Algorithms;

namespace SortingVisualizer.Algorithms
{
    public class GnomeSort : Algorithm
    {
        /// <summary>
        /// GNOME-SORT
        /// https://en.wikipedia.org/wiki/Gnome_sort
        /// </summary>

        public GnomeSort(int sleepTime, SortingWindow window, string name) : base(sleepTime, window, name)
        { }

        public override void Sort()
        {
            int index = 0;
            int n = Window.ArrayLength;
            while (index < n)
            {
                if (index == 0)
                    index++;
                if (Window.GetIndex(index) >= Window.GetIndex(index - 1))
                    index++;
                else
                {
                    Window.Swap(index, index - 1, SleepTime);
                    Swaps++;
                    index--;
                }
            }
        }
    }
}
