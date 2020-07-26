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
        private int sleepTime;
        private Queue<ISortAlgorithms> queue;

        private readonly int amountOfPillars = 600;
        private readonly int minValue = 30;
        private readonly int maxValue = 900;
        public SortingStarter(string Title) 
        {
            this.Title = Title;
            Window = new Window();
            Window.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            queue = new Queue<ISortAlgorithms>();
            sleepTime = 5;

            EnqueueItems();
            StartQueue();

            Cursor.Hide();
            Window.FormBorderStyle = FormBorderStyle.None;
            Window.WindowState = FormWindowState.Maximized;
            Window.Text = Title;
            Window.Paint += Renderer;

            //Create a thread.
            LoopThread = new Thread(SortingLoop);
            LoopThread.Start();

            Application.Run(Window);
        }

        /// <summary>
        /// Uses GenerateArray to return a int[]
        /// </summary>
        /// <returns></returns>
        public int[] Shuffle()
        {
            //this.dataSet = GenerateArray(amountOfPillars, minValue, maxValue);
            return GenerateArray(amountOfPillars, minValue, maxValue);
        }

        /// <summary>
        /// Remove the first item in the queue.
        /// </summary>
        public void DequeueItem()
        {
            if(queue.Count != 0)
            {
                Console.WriteLine(queue.Peek().getName());
                queue.Dequeue();
            }
        }

        /// <summary>
        /// Fill the queue with the different algorithms.
        /// </summary>
        private void EnqueueItems()
        {
            queue.Enqueue(new BubbleSort(Shuffle(), 1, this));
            queue.Enqueue(new SelectionSort(Shuffle(), sleepTime, this));
            queue.Enqueue(new HeapSort(Shuffle(), sleepTime, this));
            queue.Enqueue(new MergeSort(Shuffle(), sleepTime, this));
            queue.Enqueue(new QuickSort(Shuffle(), 100, this));
            queue.Enqueue(new InsertionSort(Shuffle(), 1, this));
            queue.Enqueue(new CocktailSort(Shuffle(), 1, this));
            queue.Enqueue(new ShellSort(Shuffle(), sleepTime, this));
            queue.Enqueue(new CombSort(Shuffle(), 10, this));
            queue.Enqueue(new CycleSort(Shuffle(), sleepTime, this));
            queue.Enqueue(new PigeonholeSort(Shuffle(), 10, this));
            queue.Enqueue(new StoogeSort(Shuffle(), 1, this));
        }

        /// <summary>
        /// Start the queue, this will start the sorting.
        /// </summary>
        public void StartQueue()
        {
            if (queue.Count != 0)
            {
                OnLoad(queue.Peek(), Window);
            }
        }

        /// <summary>
        /// Exit the application.
        /// </summary>
        public void ExitApplication()
        {
            OnExit(LoopThread);
        }
        /// <summary>
        /// Returns an array of integers where none of the integers are recurring.
        /// </summary>
        /// <param name="values"> The amount of pillars we will need to get a number for.</param>
        /// <param name="min"> The smallest number possible to generate. </param>
        /// <param name="max"> The highest numver possible to generate.</param>
        /// <returns></returns>
        private int[] GenerateArray(int values, int min, int max)
        {
            int[] array = new int[values];

            Random random = new Random();

            int number;
            for (int i = 0; i < values; i++)
            {
                do
                {
                    number = random.Next(min, max);
                } while (array.Contains(number));
                array[i] = number;
            }
            return array;
        }

        /// <summary>
        /// Draw window if the thread is alive.
        /// </summary>
        void SortingLoop()
        {
            
            while (LoopThread.IsAlive)
            {
                try
                {
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    Thread.Sleep(sleepTime);
                }
                catch
                { }
            }
        }

        /// <summary>
        /// Render the screen.
        /// </summary>
        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            //This draws the pillars in the right transformation, if we don't use this they will be draw upside down.
            g.TranslateTransform(0, ScreenDimensions.Y);
            g.ScaleTransform(1, -1);

            if(queue.Count != 0)
            {
                //Draw all the pillars relative to the screen coordinates.
                for (int i = 0; i < amountOfPillars; i++)
                {
                    g.DrawRectangle(Pens.White, new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));
                }

                //Get the currently selected pillar that the algorithm is moving.
                int movingValue = queue.Peek().getCurrentMoving();

                for (int i = 0; i < amountOfPillars; i++)
                {
                    //If the pillar matches the moving value draw that pillar red to highlight the sorting.
                    if (queue.Peek().getValue(i) == movingValue)
                    {
                        g.FillRectangle(new SolidBrush(Color.Red), new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));
                    }
                }

                //Reset the transformation so we can draw the text normally.
                g.ResetTransform();

                //Draw the strings with iterations and algorithm name.
                g.DrawString("Iterations: " + queue.Peek().getIterations(), new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 50);
                g.DrawString("Algorithm: " + queue.Peek().getName(), new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 100);
            }
        }

        public abstract void OnLoad(ISortAlgorithms sortAlgorithms, Window Window);
        public abstract void OnExit(Thread thread);
    }
}
