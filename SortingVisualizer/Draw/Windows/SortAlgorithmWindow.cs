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

        private int[] array;
        private int[] colors;

        private bool showInfo;

        private readonly int AMOUNT_OF_PILLARS;
        private int SHUFFLE_SPEED;
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
            showInfo = true;
            this.SHUFFLE_SPEED = SHUFFLE_SPEED;

            CreateArrays(amountOfBars);
            PopulateLists();

            DoubleBuffered = true;
            Text = FORM_TITLE;
            Size = DIMENSIONS;

            Paint += Renderer;
        }

        #region SHUFFLE
        public void ShuffleAfterSorted()
        {
            for(int i = 0; i < array.Length; i++)
            {
                SwapSingle(i, i, SHUFFLE_SPEED);
            }
        }

        public void RunWhenFinallySorted()
        {
            for (int i = 0; i < array.Length; i++)
            {
                colors[i] = 100;
                SwapSingle(array[i], i, SHUFFLE_SPEED);
            }
        }

        public void ShuffleWhenStarted()
        {
            Random random = new Random();

            for(int i = 0; i < array.Length; i++)
            {
                int index = random.Next(array.Length - 1);
                Swap(i, index, SHUFFLE_SPEED);
                colors[i] = 0;
            }
        }
        #endregion

        #region RESET/POPULATE
        private void CreateArrays(int amountOfBars)
        {
            array = new int[amountOfBars];
            colors = new int[amountOfBars];
        }

        private void PopulateLists()
        {
            array = GenerateArray(AMOUNT_OF_PILLARS, array);
            colors = GenerateArray(AMOUNT_OF_PILLARS, colors);
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
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = 0;
            }
        }
        #endregion

        #region SWAP
        //All algorithms should use this method for swapping indices.
        public void Swap(int indexA, int indexB, int sleepTime)
        {
            int temp = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = temp;

            colors[indexA] = 100;
            colors[indexB] = 100;

            Sleep(sleepTime);
        }
        public int SwapSingle(int index, int value, int sleepTime)
        {
            int temp = index;
            index = array[value];
            array[value] = temp;

            colors[value] = 100;

            Sleep(sleepTime);

            return index;
        }
        public void SwapSingleElement(int index, int value, int sleepTime)
        {
            array[index] = value;
            colors[index] = 100;

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

            if (showInfo)
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

                int colorValue = colors[i] * 2;

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

                    if (colors[i] > 0)
                    {
                        colors[i] -= 1;
                    }
                }
            }
            Invalidate();
        }
        #endregion

        #region GETTERS/SETTERS
        public int GetMax()
        {
            int max = array[0];
            for(int i = 0; i < array.Length; i++)
            {
                if(array[i] > max)
                {
                    max = array[i];
                }
            }

            if(max == array[0])
            {
                return int.MinValue;
            }

            return max;
        }

        public void Toggle_FULLSCREEN()
        {
            if (!WindowState.Equals(FormWindowState.Maximized))
            {
                SetFullscreen();
            }
            else
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }

        public void RemoveFrame()
        {
            FormBorderStyle = FormBorderStyle.None;
        }

        public void Toggle_Info()
        {
            if (showInfo)
            {
                showInfo = false;
            }
            else
            {
                showInfo = true;
            }
            Console.WriteLine(showInfo);
        }

        public void SetShuffleSpeed(int sleep)
        {
            SHUFFLE_SPEED = sleep;
        }
        public int GetShuffleSpeed()
        {
            return SHUFFLE_SPEED;
        }
        public void SetFullscreen()
        {
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }

        public void SetSortingHandler(SortingHandler sortingHandler)
        {
            _sortingHandler = sortingHandler;
        }

        public SortingHandler GetSortingHandler()
        {
            return _sortingHandler;
        }

        public Handler GetCurrentAlgorithm()
        {
            return _sortingHandler.GetCurrentSortingItem();
        }

        public void SetPause()
        {
            _manualResetEvent.Reset();
        }
        public void SetResume()
        {
            _manualResetEvent.Set();
        }

        public int[] GetArray()
        {
            return array;
        }
        public int GetLength()
        {
            return array.Length;
        }
        public int GetIndex(int index)
        {
            return array[index];
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