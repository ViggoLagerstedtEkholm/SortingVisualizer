using SortingVisualizer.Draw;
using System.ComponentModel;
using System.Diagnostics;

namespace WindowsFormsApp2.Algorithms
{
    public abstract class Algorithm : INotifyPropertyChanged
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
        public SortingWindow Window { get; set; }

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
        public double ExecutionTime { get; set; }

        public double ElapsedTime
        {
            get { return sw.Elapsed.TotalSeconds; }
        }

        public Stopwatch sw = new Stopwatch();

        public Algorithm(int sleepTime, SortingWindow window, string name)
        {
            Window = window;
            SleepTime = sleepTime;
            Name = name;
        }
        public void Start()
        {
            sw.Start();
        }
        public void Stop()
        {
            sw.Stop();
            ExecutionTime = sw.Elapsed.TotalMilliseconds;
        }
        public abstract void Sort();
    }
}
