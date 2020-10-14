using SortingVisualizer.Algorithms;
using SortingVisualizer.Draw.Windows;
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
    public class Window : Form
    {
        private Vector2D ScreenDimensions;
        private int[] array;
        private int[] colors;
        private int amountOfBars;
        private int min;
        private int max;
        private string title;
        private int sleepTime = 0;
        private ISortAlgorithms currentAlgorithm;
        private string Name = "";
        private int iterations;
        private ManualResetEvent _manualResetEvent = new ManualResetEvent(true);
        private RadioButton generateArrayType;

        public Window(string title, int amountOfBars, int min, int max, Vector2D dimensions, RadioButton generateArrayType)
        {
            InitializeComponent();

            this.amountOfBars = amountOfBars;
            this.min = min;
            this.max = max;
            this.title = title;
            this.ScreenDimensions = dimensions;
            this.generateArrayType = generateArrayType;

            createData(amountOfBars);
            populateLists();

            this.DoubleBuffered = true;
            this.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            
            this.Paint += Renderer;
        }    

        private void SET_FULLSCREEN()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Cursor.Hide();
        }
        public void ShuffleAfterSorted()
        {
            Random random = new Random();
            for(int i = 0; i < array.Length; i++)
            {
                swapSingle(random.Next(min, max), i, 5);
            }
        }

        public void ShuffleWhenStarted()
        {
            if (generateArrayType.Name == "sineWave")
            {
                this.array = GenerateData.GenerateSineArray(amountOfBars, array);
            }
            else
            {
                this.array = GenerateData.GenerateRandomArray(amountOfBars, min, max, array);

            }
        }
        private void createData(int amountOfBars)
        {
            array = new int[amountOfBars];
            colors = new int[amountOfBars];
        }

        private void populateLists()
        {
            this.array = GenerateData.GenerateArray(amountOfBars, array);
            this.colors = GenerateData.GenerateArray(amountOfBars, colors);
        }

        //All algorithms should use this method for swapping indices.
        public void swap(int indexA, int indexB, int sleepTime)
        {
            int temp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = temp;

            colors[indexA] = 100;
            colors[indexB] = 100;

            //Make thread sleep so we can see the updated changes.
            Sleep(sleepTime);
        }
        //sortingStarter.swapSingle(sortingStarter.getArray()[k], rightArray[j], sleepTime);
        public int swapSingle(int index, int value, int sleepTime)
        {
            int temp = index;
            index = array[value];
            array[value] = temp;

            colors[value] = 100;

            Sleep(sleepTime);

            return index;
        }

        public void swapSingleElement(int index, int value, int sleepTime)
        {
            array[index] = value;

            colors[index] = 100;

            Sleep(sleepTime);
        }

        private void Sleep(int sleepTime)
        {
            //Repaint screen.
            this.Invalidate();

            //Try to sleep, otherwise pause the current thread.
            try
            {
                Thread.Sleep(sleepTime);
            }
            catch(ThreadInterruptedException e)
            {
                Thread.CurrentThread.Interrupt();
            }

            this.iterations++;
            this.setSleepTime(sleepTime);

            //If the thread is paused we will stop here until it's resumed.
            _manualResetEvent.WaitOne();
        }

        public void runWhenFinallySorted()
        {
            for(int i = 0; i < array.Length; i++)
            {
                colors[i] = 100;
                swapSingle(array[i], i, 10);
            }
        }

        /// <summary>
        /// Set every color in colors array to 0.
        /// </summary>
        public void ResetColor()
        {
            for (int i = 0; i < this.colors.Length; i++)
            {
                this.colors[i] = 0;
            }
        }


        /// <summary>
        /// Render the screen.
        /// </summary>
        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            //Draw information about the algorithm.
            g.DrawString("Iterations: " + iterations, new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 50);
            g.DrawString("Algorithm: " + Name, new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 100);
            g.DrawString("Sleep time: " + sleepTime + " ms", new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 150);

            //Draw the bars.
            RenderBars(g);

            this.Invalidate();
        }

        /// <summary>
        /// Render the bars.
        /// </summary>
        private void RenderBars(Graphics g)
        {
            g.TranslateTransform(0, ScreenDimensions.Y);
            g.ScaleTransform(1, -1);

            int BAR_WIDTH = ScreenDimensions.X / array.Length;

            //Draw all the pillars relative to the screen coordinates.
            for (int i = 0; i < amountOfBars; i++)
            {

                //g.DrawRectangle(Pens.White, new Rectangle((i * ScreenDimensions.X / dataSet.Length), 0, 
                //                                          (ScreenDimensions.X / dataSet.Length), dataSet[i]));
                int x = i + (BAR_WIDTH) * i;
                int y = 0;
                int width = BAR_WIDTH;
                int height = getIndex(i);

                int colorValue = colors[i] * 2;

                Brush brush;

                if(colorValue > 190)
                {
                    brush = new SolidBrush(Color.FromArgb(255 - colorValue, 255, 255 - colorValue));
                }
                else
                {
                    brush = new SolidBrush(Color.FromArgb(255, 255 - colorValue, 255 - colorValue));
                }

                g.FillRectangle(brush, new Rectangle(x, y, width, height));

                if (colors[i] > 0)
                {
                    colors[i] -= 1;
                }
            }
            this.Invalidate();
            
        }

        //Move this to the window code.
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(1209, 495);
            this.Name = "Window";
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Getters and setters.
        /// </summary>
        /// 

        public void setPause()
        {
            _manualResetEvent.Reset();
        }

        public void setResume()
        {
            _manualResetEvent.Set();
        }
        public void setSleepTime(int sleepTime)
        {
            this.sleepTime = sleepTime;
        }
        public void setCurrentAlgorithm(ISortAlgorithms algorithm)
        {
            this.currentAlgorithm = algorithm;
        }
		
		public void setAlgorithmName(string name)
		{
			this.Name = name;
		}

        public int[] getArray()
        {
            return array;
        }

        public void setIndex(int index,int value)
        {
            this.array[index] = value;
        }

        public int getLength()
        {
            return array.Length;
        }
        public int getIndex(int index)
        {
            return array[index];
        }
        public int getColor(int index)
        {
            return colors[index];
        }
		
		public void setIterations()
		{
			this.iterations = 0;
		}

    }
}