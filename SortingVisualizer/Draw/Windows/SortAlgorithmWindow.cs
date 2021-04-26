using SortingVisualizer.Draw.Windows;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SortingVisualizer.Draw
{
    public class SortingWindow : Form
    {
        public event EventHandler MinimizeScreen;
        public event EventHandler MaximizeScreen;

        private readonly BufferedGraphicsContext cntxt = BufferedGraphicsManager.Current;
        private BufferedGraphics grafx;

        private byte bufferingMode;
        private readonly string[] bufferingModeStrings =
            { "Draw to Form without OptimizedDoubleBufferring control style",
          "Draw to Form using OptimizedDoubleBuffering control style",
          "Draw to HDC for form" };
        public int[] Array { get; set; }
        public int ArrayLength => Array.Length;
        public int[] Colors { get; set; }
        public int SHUFFLE_SPEED { get; set; }
        public bool ShowInfo { get; set; }
        public bool MeasureTime { get; set; }
        public Brush BGColor { get; set; }

        private readonly int AMOUNT_OF_PILLARS;

        private readonly double BAR_HEIGHT_PERCENT = 1080.0 / 1920.0;

        private readonly ManualResetEvent _manualResetEvent = new ManualResetEvent(true);

        private SortingHandler _sortingHandler;
        private int count;

        public bool Fullscreen { get; set; }

        public SortingWindow(int AMOUNT_OF_PILLARS, Size WINDOW_SIZE, int SHUFFLE_SPEED)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            TopLevel = false;
            Size = WINDOW_SIZE;
            this.AMOUNT_OF_PILLARS = AMOUNT_OF_PILLARS;
            this.SHUFFLE_SPEED = SHUFFLE_SPEED;
            BGColor = Brushes.Black;

            ShowInfo = true;
            bufferingMode = 1;

            CreateArrays();
            PopulateLists();
            MouseDown += new MouseEventHandler(MouseDownHandler);
            Resize += new EventHandler(OnResize);
            Closed += new EventHandler(OnClosed);
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            cntxt = BufferedGraphicsManager.Current;
            cntxt.MaximumBuffer = new Size(Width + 1, Height + 1);
            grafx = cntxt.Allocate(this.CreateGraphics(),
                 new Rectangle(0, 0, Width, Height));
        }

        #region SHUFFLE
        public void ShuffleAfterSorted()
        {
            for (int i = 0; i < Array.Length; i++)
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

            for (int i = 0; i < Array.Length; i++)
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
            Invoke(new MethodInvoker(() =>
            {
                if (grafx != null)
                {
                    DrawToBuffer(grafx.Graphics);
                    Refresh();
                }
            }));

            //Try to sleep, otherwise pause the current thread.
            try
            {
                Thread.Sleep(sleepTime);
            }
            catch (ThreadInterruptedException)
            {
                Thread.CurrentThread.Interrupt();
            }
            _manualResetEvent.WaitOne();
        }
        #endregion

        #region Events
        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    if (++bufferingMode > 2)
                        bufferingMode = 0;

                    if (bufferingMode == 1)
                        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                    if (bufferingMode == 2)
                        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
                    PrepareRefresh();
                    break;
                case MouseButtons.Left:
                    Toggle_FULLSCREEN();
                    break;
            }

        }

        private void OnResize(object sender, EventArgs e)
        {
            Console.WriteLine("Resized!");
            // Re-create the graphics buffer for a new window size.
            cntxt.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            if (grafx != null)
            {
                grafx.Dispose();
                grafx = null;
            }
            grafx = cntxt.Allocate(this.CreateGraphics(),
                new Rectangle(0, 0, this.Width, this.Height));


            // Cause the background to be cleared and redraw.
            PrepareRefresh();
        }

        private void PrepareRefresh()
        {
            count = 3;
            DrawToBuffer(grafx.Graphics);
            Refresh();
        }

        private void OnClosed(object sender, EventArgs e)
        {
            grafx.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            grafx.Render(e.Graphics);
        }
        #endregion

        #region Render
        private void DrawToBuffer(Graphics g)
        {
            // Clear the graphics buffer every five updates.
            if (++count > 2)
            {
                count = 0;
                g.FillRectangle(BGColor, 0, 0, Width, Height);
            }

            RenderTexts(g);

            float BAR_WIDTH = Size.Width / (float)AMOUNT_OF_PILLARS;

            for (int i = 0; i < AMOUNT_OF_PILLARS; i++)
            {
                float currentVal = GetIndex(i);
                double percentOfMax = currentVal / GetMax();
                double heightPercentOfPanel = percentOfMax * BAR_HEIGHT_PERCENT;

                float height = (float)(heightPercentOfPanel * (float)Size.Height);
                float xCoord = i + (BAR_WIDTH - 1) * i;
                float yCoord = Size.Height - height;

                int colorValue = Colors[i] * 2;

                Brush brush;
                if (!(colorValue > 255) && !(colorValue < 0))
                {
                    if (colorValue > 245)
                    {
                        brush = new SolidBrush(Color.FromArgb(11, 255 - colorValue, 153));
                    }
                    else
                    {
                        brush = new SolidBrush(Color.FromArgb(255 - colorValue, 121, 232));
                    }
                    g.FillRectangle(brush, new RectangleF(xCoord, yCoord, BAR_WIDTH, height));

                    if (Colors[i] > 0)
                    {
                        Colors[i] -= 1;
                    }
                }
            }
        }

        private void RenderTexts(Graphics g)
        {
            if (!Fullscreen)
            {
                g.DrawString("Click to go full screen.", new Font("Arial", 8), Brushes.White, 10, 10);
            }
            else
            {
                g.DrawString("Buffering Mode: " + bufferingModeStrings[bufferingMode] + " - [Right Click To Change Render Mode]", new Font("Arial", 8), Brushes.White, 10, 10);
            }

            if (ShowInfo)
            {
                if (_sortingHandler.GetCurrentSortingItem() != null)
                {
                    g.DrawString("Real world elapsed time: " + _sortingHandler.GetCurrentSortingItem().ElapsedTime + " seconds", new Font("Arial", 10), Brushes.White, 10, 25);
                }
            }
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

        public void Toggle_FULLSCREEN()
        {
            if (!Fullscreen)
            {
                MaximizeScreen?.Invoke(this, null);
            }
            else
            {
                MinimizeScreen?.Invoke(this, null);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SortingWindow
            // 
            this.ClientSize = new System.Drawing.Size(1252, 0);
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.Name = "SortingWindow";
            this.Text = "Sorting window";
            this.ResumeLayout(false);
        }
    }
}