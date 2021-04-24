using SortingVisualizer.Algorithms;
using SortingVisualizer.Draw.Windows;
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
using WindowsFormsApp2.Algorithms;
using WindowsFormsApp2.Draw;

namespace SortingVisualizer.Draw
{
    public class Window : Form
    {
        public Size SCREENDIMENSIONS { get; set; }
        public int[] Array { get; set; }
        public int ArrayLength => Array.Length;
        public int[] Colors { get; set; }
        public int SHUFFLE_SPEED { get; set; }
        public bool ShowInfo { get; set; }

        private readonly int AMOUNT_OF_PILLARS;

        private readonly double BAR_HEIGHT_PERCENT = 1080.0 / 1920.0;

        private readonly string FORM_TITLE;

        private readonly ManualResetEvent _manualResetEvent = new ManualResetEvent(true);

        private SortingHandler _sortingHandler;

        public Window(string title, int amountOfBars, Size DIMENSIONS, int SHUFFLE_SPEED)
        {
            InitializeComponent();

            SCREENDIMENSIONS = DIMENSIONS;
            Width = DIMENSIONS.Width;
            Height = DIMENSIONS.Height;
            AMOUNT_OF_PILLARS = amountOfBars;
            FORM_TITLE = title;
            ShowInfo = true;
            this.SHUFFLE_SPEED = SHUFFLE_SPEED;

            CreateArrays();
            PopulateLists();

            DoubleBuffered = true;
            Text = FORM_TITLE;
            Size = DIMENSIONS;

            Paint += Renderer;
        }

        #region SHUFFLE
        public void ShuffleAfterSorted()
        {
            for(int i = 0; i < Array.Length; i++)
            {
                SwapSingle(i, i, SHUFFLE_SPEED);
            }
        }

        public void RunWhenFinallySorted()
        {
            for (int i = 0; i < Array.Length; i++)
            {
                Colors[i] = 100;
                SwapSingle(Array[i], i, SHUFFLE_SPEED);
            }
        }

        public void ShuffleWhenStarted()
        {
            Random random = new Random();

            for(int i = 0; i < Array.Length; i++)
            {
                int index = random.Next(Array.Length - 1);
                Swap(i, index, SHUFFLE_SPEED);
                Colors[i] = 0;
            }
        }
        #endregion

        #region RESET/POPULATE
        private void CreateArrays()
        {
            Array = new int[AMOUNT_OF_PILLARS];
            Colors = new int[AMOUNT_OF_PILLARS];
        }

        private void PopulateLists()
        {
            Array = GenerateArray(AMOUNT_OF_PILLARS, Array);
            Colors = GenerateArray(AMOUNT_OF_PILLARS, Colors);
        }

        private static int[] GenerateArray(int amountOfPillars, int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < amountOfPillars; i++)
            {
                array[i] = random.Next(array.Length - 1);
            }
            return array;
        }

        public void ResetColor()
        {
            for (int i = 0; i < Colors.Length; i++)
            {
                Colors[i] = 0;
            }
        }
        #endregion

        #region SWAP
        //All algorithms should use this method for swapping indices.
        public void Swap(int indexA, int indexB, int sleepTime)
        {
            int temp = Array[indexA];
            Array[indexA] = Array[indexB];
            Array[indexB] = temp;

            Colors[indexA] = 100;
            Colors[indexB] = 100;

            Sleep(sleepTime);
        }
        public int SwapSingle(int index, int value, int sleepTime)
        {
            int temp = index;
            index = Array[value];
            Array[value] = temp;

            Colors[value] = 100;

            Sleep(sleepTime);

            return index;
        }
        public void SwapSingleElement(int index, int value, int sleepTime)
        {
            Array[index] = value;
            Colors[index] = 100;

            Sleep(sleepTime);
        }

        #endregion

        #region VISUALIZE
        private void Sleep(int sleepTime)
        {
            //Try to sleep, otherwise pause the current thread.
            try
            {
                Thread.Sleep(sleepTime);
            }
            catch(ThreadInterruptedException)
            {
                Thread.CurrentThread.Interrupt();
            }

            _manualResetEvent.WaitOne();
        }
        #endregion

        #region RENDER
        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            if (ShowInfo)
            {
                if(_sortingHandler.GetCurrentSortingItem() != null)
                {
                    g.DrawString("Elapsed time: " + _sortingHandler.GetCurrentSortingItem().ElapsedTime + " ms", new Font("Arial", 12, FontStyle.Italic), new SolidBrush(Color.White), 20, 20);
                }
            }

            float BAR_WIDTH = SCREENDIMENSIONS.Width / (float)AMOUNT_OF_PILLARS;

            for (int i = 0; i < AMOUNT_OF_PILLARS; i++)
            {
                float currentVal = GetIndex(i);
                double percentOfMax = currentVal / GetMax();
                double heightPercentOfPanel = percentOfMax * BAR_HEIGHT_PERCENT;

                float height = (float)(heightPercentOfPanel * (float)SCREENDIMENSIONS.Height);
                float xCoord = i + (BAR_WIDTH - 1) * i;
                float yCoord = SCREENDIMENSIONS.Height - height;

                int colorValue = Colors[i] * 2;

                Brush brush;
                if (!(colorValue > 255) && !(colorValue < 0))
                {
                    if (colorValue > 190)
                    {
                        brush = new SolidBrush(Color.FromArgb(255 - colorValue, 255, 255 - colorValue));
                    }
                    else
                    {
                        brush = new SolidBrush(Color.FromArgb(255, 255 - colorValue, 255 - colorValue));
                    }
                    g.FillRectangle(brush, new RectangleF(xCoord, yCoord, BAR_WIDTH, height));

                    if (Colors[i] > 0)
                    {
                        Colors[i] -= 1;
                    }
                }
            }
            Invalidate();
        }
        #endregion

        public int GetMax()
        {
            int max = Array[0];

            for (int i = 0; i < Array.Length; i++)
            {
                if (Array[i] > max)
                {
                    max = Array[i];
                }
            }

            if (max == Array[0])
            {
                return int.MinValue;
            }
            return max;
        }


        #region GETTERS/SETTERS

        public void Toggle_FULLSCREEN()
        {
            if (!WindowState.Equals(FormWindowState.Maximized))
            {
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public void SetSortingHandler(SortingHandler sortingHandler)
        {
            _sortingHandler = sortingHandler;
        }

        public void SetPause()
        {
            _manualResetEvent.Reset();
        }
        public void SetResume()
        {
            _manualResetEvent.Set();
        }

        public int GetIndex(int index)
        {
            return Array[index];
        }

        #endregion
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Window
            // 
            this.ClientSize = new System.Drawing.Size(1252, 562);
            this.Name = "Window";
            this.ResumeLayout(false);
        }
    }
}