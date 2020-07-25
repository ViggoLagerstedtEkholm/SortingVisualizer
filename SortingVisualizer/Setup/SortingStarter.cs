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
        private List<ISortAlgorithms> sortAlgorithms;
        private Input input;
        private int sleepTime;
        private int atIndex;
        public SortingStarter(string Title) 
        {
            this.Title = Title;
            Window = new Window();
            Window.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            sortAlgorithms = new List<ISortAlgorithms>();
            input = new Input(Window, this);
            sleepTime = 100;

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
            sortAlgorithms.Clear();
            this.dataSet = GenerateArray(100, 10, 900);

            switch (atIndex)
            {
                case 0:
                    selectAlgorithm(AlgorithmType.BubbleSort);
                    break;
                case 1:
                    selectAlgorithm(AlgorithmType.SelectionSort);
                    break;
                default:
                    Application.Exit();
                    break;
            }

            OnLoad(sortAlgorithms, atIndex);

            Console.WriteLine("INDEX: " + atIndex);
            atIndex++;
        }

        private void selectAlgorithm(AlgorithmType algorithm)
        {
            if(algorithm == AlgorithmType.BubbleSort)
            {
                sortAlgorithms.Add(new BubbleSort(dataSet, sleepTime, this));
            }
            else if(algorithm == AlgorithmType.SelectionSort)
            {
                sortAlgorithms.Add(new SelectionSort(dataSet, sleepTime, this));
            }
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
                    Thread.Sleep(100);
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

            foreach (ISortAlgorithms algo in sortAlgorithms)
            {
                int movingValue = algo.getCurrentMoving();

                for (int i = 0; i < dataSet.Length; i++)
                {
                    if (dataSet[i] == movingValue)
                    {
                        g.FillRectangle(new SolidBrush(Color.Red), new Rectangle((i * ScreenDimensions.X / dataSet.Length), 0, (ScreenDimensions.X / dataSet.Length), dataSet[i]));
                    }
                }

                g.ResetTransform();

                g.DrawString("Iterations: " + algo.getIterations(), new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 50);
                g.DrawString("Algorithm: " + algo.getName(), new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 100);
            }
            
        }

        public abstract void OnLoad(List<ISortAlgorithms> sortAlgorithms, int index);
        public abstract void OnExit();
    }
}
