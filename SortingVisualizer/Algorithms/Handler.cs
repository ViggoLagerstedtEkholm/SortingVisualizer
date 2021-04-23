using SortingVisualizer.Algorithms;
using SortingVisualizer.Draw;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Algorithms
{
    public abstract class Handler : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Name { get; set; }

        private int sleepTime;

        public int SleepTime
        {
            get { return sleepTime; }
            set
            {
                if (value != sleepTime)
                {
                    sleepTime = value;
                    OnPropertyChanged(nameof(SleepTime));
                }
            }
        }
        public Window Window { get; set; }

        public int swaps;

        public int Swaps
        {
            get { return swaps; }
            set
            {
                if (value != swaps)
                {

                    swaps = value;
                    OnPropertyChanged(nameof(Swaps));
                }
            }
        }
        public long ExecutionTime { get; set; }

        private long elapsedTime;

        public long ElapsedTime
        {
            get { return sw.ElapsedMilliseconds; }
            set
            {
                if (value != elapsedTime)
                {
                    elapsedTime = sw.ElapsedMilliseconds;
                    OnPropertyChanged(nameof(ElapsedTime));
                }
            }
        }

        public Stopwatch sw = new Stopwatch();

        public Handler(int sleepTime, Window window)
        {
            Window = window;
            SleepTime = sleepTime;
        }

        public abstract void Sort();
    }
}
