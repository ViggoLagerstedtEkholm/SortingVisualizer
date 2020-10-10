using SortingVisualizer.Algorithms;
using SortingVisualizer.Maths;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer.Draw
{
    public partial class Window : Form
    {
        private Vector2D ScreenDimensions = new Vector2D(1920, 1080);
        private Queue<ISortAlgorithms> queue;
    

        private string Title;
        private int sleepTime;
        private readonly Thread LoopThread = null;


        //These should be selected using a GUI in the new version.
        private readonly int amountOfPillars = 300;
        private readonly int minValue = 100;
        private readonly int maxValue = 900;

        private List<ISortAlgorithms> selectedAlgorithms = new List<ISortAlgorithms>();
        private List<int> recentlyMoved = new List<int>();
        public Window(String Title)
        {
            InitializeComponent();
            queue = new Queue<ISortAlgorithms>();
            this.DoubleBuffered = true;

            this.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            sleepTime = 5;

            EnqueueItems();
            StartQueue();


            this.Paint += Renderer;
            this.Text = Title;
        }

        /// <summary>
        /// Fill the queue with the different algorithms.
        /// </summary>
        private void EnqueueItems()
        {
            queue.Enqueue(new BubbleSort(Shuffle(), sleepTime, this));
        }


        /// <summary>
        /// Remove the first item in the queue.
        /// </summary>
        public void DequeueItem()
        {
            queue.Dequeue();
        }

        /// <summary>
        /// Start the queue, this will start the sorting.
        /// </summary>
        public void StartQueue()
        {
            if(queue.Count() != 0)
            {
                queue.Peek().StartThread();
            }
            else
            {
                Console.WriteLine("Queue is empty!");
            }
            
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
        /// Render the screen.
        /// </summary>
        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            g.TranslateTransform(0, ScreenDimensions.Y);
            g.ScaleTransform(1, -1);
            //Draw all the pillars relative to the screen coordinates.
            for (int i = 0; i < amountOfPillars; i++)
            {

                g.DrawRectangle(Pens.White, new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));

                //If the pillar matches the moving value draw that pillar red to highlight the sorting.
                int movingValue = queue.Peek().getCurrentMoving();

                if (queue.Peek().getValue(i) == movingValue)
                {
                    g.DrawRectangle(Pens.Red, new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));
                    g.FillRectangle(new SolidBrush(Color.Red), new Rectangle((i * ScreenDimensions.X / amountOfPillars), 0, (ScreenDimensions.X / amountOfPillars), queue.Peek().getValue(i)));
                }

            }
            this.Invalidate();
        }
    }
}
