using SortingVisualizer.Algorithms;
using System;
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
        private ISortAlgorithms sortAlgorithm;
        private Input input;
        private int sleepTime;
        private int atIndex;

        private readonly int amountOfPillars = 100;
        private readonly int minValue = 20;
        private readonly int maxValue = 900;
        public SortingStarter(string Title) 
        {
            this.Title = Title;
            Window = new Window();
            Window.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            input = new Input(Window, this);
            sleepTime = 10;

            startData();

            Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Window.Text = Title;
            Window.Paint += Renderer;

            LoopThread = new Thread(SortingLoop);
            LoopThread.Start();

            Application.Run(Window);
        }

        public void startData()
        {
            this.dataSet = GenerateArray(amountOfPillars, minValue, maxValue);

            switch (atIndex)
            {
                case 0:
                    SelectAlgorithm(AlgorithmType.BubbleSort);
                    break;
                case 1:
                    SelectAlgorithm(AlgorithmType.SelectionSort);
                    break;
                case 2:
                    SelectAlgorithm(AlgorithmType.GnomeSort);
                    break;
                case 3:
                    SelectAlgorithm(AlgorithmType.HeapSort);
                    break;
                case 4:
                    SelectAlgorithm(AlgorithmType.MergeSort);
                    break;
                case 5:
                    SelectAlgorithm(AlgorithmType.QuickSort);
                    break;
                default:
                   // Application.Exit();
                    break;
            }

            OnLoad(sortAlgorithm, atIndex);

            Console.WriteLine("INDEX: " + atIndex);
            atIndex++;
        }

        private void SelectAlgorithm(AlgorithmType algorithm)
        {
            if(algorithm == AlgorithmType.BubbleSort)
            {
                sleepTime = 10;
                sortAlgorithm = new BubbleSort(dataSet, sleepTime, this);
            }
            else if(algorithm == AlgorithmType.SelectionSort)
            {
                sleepTime = 10;
                sortAlgorithm = new SelectionSort(dataSet, sleepTime, this);
            }
            else if (algorithm == AlgorithmType.GnomeSort)
            {
                sleepTime = 10;
                sortAlgorithm = new GnomeSort(dataSet, sleepTime, this);
            }
            else if (algorithm == AlgorithmType.HeapSort)
            {
                sleepTime = 10;
                sortAlgorithm = new HeapSort(dataSet, sleepTime, this);
            }
            else if (algorithm == AlgorithmType.MergeSort)
            {
                sleepTime = 200;
                sortAlgorithm = new MergeSort(dataSet, sleepTime, this);
            }
            else if (algorithm == AlgorithmType.QuickSort)
            {
                sleepTime = 200;
                sortAlgorithm = new QuickSort(dataSet, sleepTime, this);
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

     
            for (int i = 0; i < dataSet.Length; i++)
            {
                //ScreenDimensions.X
                g.DrawRectangle(Pens.White, new Rectangle((i * ScreenDimensions.X / dataSet.Length), 0, (ScreenDimensions.X / dataSet.Length), dataSet[i]));
                g.FillRectangle(new SolidBrush(Color.White), new Rectangle((i * ScreenDimensions.X / dataSet.Length), 0, (ScreenDimensions.X / dataSet.Length), dataSet[i]));
            }


            int movingValue = sortAlgorithm.getCurrentMoving();

            for (int i = 0; i < dataSet.Length; i++)
            {
                if (dataSet[i] == movingValue)
                {
                    g.FillRectangle(new SolidBrush(Color.Red), new Rectangle((i * ScreenDimensions.X / dataSet.Length), 0, (ScreenDimensions.X / dataSet.Length), dataSet[i]));
                }
            }

            g.ResetTransform();

            g.DrawString("Iterations: " + sortAlgorithm.getIterations(), new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 50);
            g.DrawString("Algorithm: " + sortAlgorithm.getName(), new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 100); 
        }

        public abstract void OnLoad(ISortAlgorithms sortAlgorithms, int index);
        public abstract void OnExit(Thread thread);
    }
}
