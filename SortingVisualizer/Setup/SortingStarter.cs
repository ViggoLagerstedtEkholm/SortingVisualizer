using SortingVisualizer.Algorithms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer.Setup
{
    public abstract class SortingStarter
    {
        private Vector2d ScreenDimensions = new Vector2d(1920, 1080);
        private readonly Thread LoopThread = null;
        private Window Window;
        private string Title;
        private int[] dataSet;
        private Input input;
        private int sleepTime;
        private Queue<ISortAlgorithms> queue;

        private readonly int amountOfPillars = 100;
        private readonly int minValue = 20;
        private readonly int maxValue = 900;
        public SortingStarter(string Title) 
        {
            this.Title = Title;
            Window = new Window();
            Window.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            input = new Input(Window, this);
            queue = new Queue<ISortAlgorithms>();
            sleepTime = 20;

            EnqueueItems();
            StartQueue();

            Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Window.Text = Title;
            Window.Paint += Renderer;

            LoopThread = new Thread(SortingLoop);
            LoopThread.Start();

            Application.Run(Window);
        }

        public int[] Shuffle()
        {
            //this.dataSet = GenerateArray(amountOfPillars, minValue, maxValue);
            return GenerateArray(amountOfPillars, minValue, maxValue);
        }

        public void DequeueItem()
        {
            Console.WriteLine(queue.Peek().getName());
            queue.Dequeue();
        }

        private void EnqueueItems()
        {
            queue.Enqueue(new BubbleSort(Shuffle(), 10, this));
            queue.Enqueue(new SelectionSort(Shuffle(), 100, this));
            queue.Enqueue(new HeapSort(Shuffle(), 100, this));
            queue.Enqueue(new MergeSort(Shuffle(), 100, this));
            queue.Enqueue(new QuickSort(Shuffle(), 100, this));
        }

        public void StartQueue()
        {
            if (queue.Count != 0)
            {
                OnLoad(queue.Peek());
            }
            else
            {
                ExitApplication();
            }
        }

        public void ExitApplication()
        {
            OnExit(LoopThread);
        }

        private int[] GenerateArray(int values, int min, int max)
        {
            int[] array = new int[values];

            Random random = new Random();

            for(int i = 0; i < values; i++)
            {
                array[i] = random.Next(min, max);
            }

            return array;
        }

        void SortingLoop()
        {
            while (LoopThread.IsAlive)
            {
                try
                {
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    Thread.Sleep(10);
                }
                catch
                { }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            g.TranslateTransform(0, ScreenDimensions.Y);
            g.ScaleTransform(1, -1);

            if (queue.Count != 0)
            {
                queue.Peek();

                for (int i = 0; i < amountOfPillars; i++)
                {
                    //ScreenDimensions.X
                    g.DrawRectangle(Pens.White, new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));
                }


                int movingValue = queue.Peek().getCurrentMoving();

                for (int i = 0; i < amountOfPillars; i++)
                {
                    if (queue.Peek().getValue(i) == movingValue)
                    {
                        g.FillRectangle(new SolidBrush(Color.Red), new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));
                    }
                }

                g.ResetTransform();

                g.DrawString("Iterations: " + queue.Peek().getIterations(), new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 50);
                g.DrawString("Algorithm: " + queue.Peek().getName(), new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 100);
            }
            else
            {
                ExitApplication();
            }
        }

        public abstract void OnLoad(ISortAlgorithms sortAlgorithms);
        public abstract void OnExit(Thread thread);

        //private int[] testArray;
        //private int test(int index)
        //{
        //    return testArray[index];
        //}
    }
}
