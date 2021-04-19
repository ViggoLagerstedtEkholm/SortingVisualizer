using SortingVisualizer.Algorithms;
using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Algorithms
{
    public abstract class Handler
    {
        public string Name { get; set; }
        public int SleepTime { get; set; }
        public Window Window { get; set; }
        public int Swaps { get; set; }
        public long ExecutionTime { get; set; }
        public long ElapsedTime => sw.ElapsedMilliseconds;

        public Stopwatch sw = new Stopwatch();

        public Handler(int sleepTime, Window window, string name)
        {
            Window = window;
            SleepTime = sleepTime;
            Name = name;
        }

        public abstract void Sort();
    }
}
