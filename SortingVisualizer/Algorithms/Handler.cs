using SortingVisualizer.Algorithms;
using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Algorithms
{
    public abstract class Handler : ISortAlgorithms
    {
        public string name { get; set; }
        public int sleepTime { get; set; }
        public Window window { get; set; }
        public Handler(int sleepTime, Window window, string name)
        {
            this.window = window;
            this.sleepTime = sleepTime;
            this.name = name;
        }

        public abstract void Sort();

        public abstract string getName();

        public abstract int GetSleepTime();

        public abstract void setSleep(int sleepTime);
    }
}
