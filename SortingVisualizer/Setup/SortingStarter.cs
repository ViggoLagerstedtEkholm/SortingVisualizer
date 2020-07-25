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
        private BubbleSort bubbleSort;
        private SelectionSort selectionSort;
        public SortingStarter(string Title) 
        {
            this.Title = Title;
            Window = new Window();

            Window.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);

            this.dataSet = GenerateArray(200);
            //bubbleSort = new BubbleSort(dataSet);
            selectionSort = new SelectionSort(dataSet);

            Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Window.Text = Title;
            Window.Paint += Renderer;

            LoopThread = new Thread(SortingLoop);
            LoopThread.Start();

            Application.Run(Window);
        }

        private int[] GenerateArray(int values)
        {
            int[] array = new int[values];

            Random random = new Random();

            for(int i = 0; i < values; i++)
            {
                array[i] = random.Next(0, 800);
            }

            return array;
        }

        void SortingLoop()
        {
            OnLoad(selectionSort);

            while (LoopThread.IsAlive)
            {
                try
                {
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
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
            }
            g.ResetTransform();
            g.DrawString("ITERATIONS: " + selectionSort.iterations.ToString(), new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 50);
        }

        public abstract void OnLoad(SelectionSort selectionSort);
        public abstract void OnUpdate();
    }
}
