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
        private readonly Vector2D SCREENDIMENSIONS;
        private int[] array;
        private int[] colors;
        private readonly int AMOUNT_OF_PILLARS;
        private readonly int MIN_PILLAR_HEIGHT;
        private readonly int MAX_PILLAR_HEIGHT;
        private readonly string FORM_TITLE;
        private int sleepTime = 0;
        private string Name = "";
        private int iterations;
        private ManualResetEvent _manualResetEvent = new ManualResetEvent(true);
        private generationType generateArrayType;

        public Window(string title, int amountOfBars, int min, int max, Vector2D dimensions, generationType generateArrayType)
        {
            this.AMOUNT_OF_PILLARS = amountOfBars;
            this.MIN_PILLAR_HEIGHT = min;
            this.MAX_PILLAR_HEIGHT = max;
            this.FORM_TITLE = title;
            this.SCREENDIMENSIONS = dimensions;
            this.generateArrayType = generateArrayType;

            createData(amountOfBars);
            populateLists();

            this.DoubleBuffered = true;
            this.Text = FORM_TITLE;
            this.Size = new Size((int)SCREENDIMENSIONS.X, (int)SCREENDIMENSIONS.Y);
            
            this.Paint += Renderer;
        }    

        public void SET_FULLSCREEN()
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
                swapSingle(random.Next(MIN_PILLAR_HEIGHT, MAX_PILLAR_HEIGHT), i, 5);
            }
        }
        public void ShuffleWhenStarted()
        {
            switch (generateArrayType)
            {
                case generationType.REGULAR:
                    this.array = GenerateData.GenerateSineArray(AMOUNT_OF_PILLARS, array);
                    break;
                case generationType.SINE_WAVE:
                    this.array = GenerateData.GenerateRandomArray(AMOUNT_OF_PILLARS, MIN_PILLAR_HEIGHT, MAX_PILLAR_HEIGHT, array);
                    break;
            }
        }
        private void createData(int amountOfBars)
        {
            array = new int[amountOfBars];
            colors = new int[amountOfBars];
        }

        private void populateLists()
        {
            this.array = GenerateData.GenerateArray(AMOUNT_OF_PILLARS, array);
            this.colors = GenerateData.GenerateArray(AMOUNT_OF_PILLARS, colors);
        }

        //All algorithms should use this method for swapping indices.
        public void swap(int indexA, int indexB, int sleepTime)
        {
            int temp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = temp;

            colors[indexA] = 100;
            colors[indexB] = 100;

            Sleep(sleepTime);
        }
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
        public void ResetColor()
        {
            for (int i = 0; i < this.colors.Length; i++)
            {
                this.colors[i] = 0;
            }
        }
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
        private void RenderBars(Graphics g)
        {
            g.TranslateTransform(0, SCREENDIMENSIONS.Y);
            g.ScaleTransform(1, -1);

            int BAR_WIDTH = SCREENDIMENSIONS.X / array.Length;

            for (int i = 0; i < AMOUNT_OF_PILLARS; i++)
            {
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
        public int getIterations()
        {
            return iterations;
        }
		
		public void setIterations()
		{
			this.iterations = 0;
		}
    }
}