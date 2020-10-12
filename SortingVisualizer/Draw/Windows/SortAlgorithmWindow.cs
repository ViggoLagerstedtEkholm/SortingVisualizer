﻿using SortingVisualizer.Algorithms;
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
        private Vector2D ScreenDimensions = new Vector2D(1920, 1080);
        private int[] array;
        private int[] colors;
        private int amountOfBars;
        private int min;
        private int max;
        private string title;
        private ISortAlgorithms currentAlgorithm;
        private string Name = "";
        private int iterations;

        public Window(string title, int amountOfBars, int min, int max)
        {
            InitializeComponent();

            this.amountOfBars = amountOfBars;
            this.min = min;
            this.max = max;
            this.title = title;

            createData(amountOfBars);
            populateLists();

            this.DoubleBuffered = true;
            this.Size = new Size((int)ScreenDimensions.X, (int)ScreenDimensions.Y);
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            this.Paint += Renderer;
        }    

        public void Shuffle()
        {
            GenerateRandomArray(amountOfBars, min, max, array);
        }
        private void createData(int amountOfBars)
        {
            array = new int[amountOfBars];
            colors = new int[amountOfBars];
        }

        private void populateLists()
        {
            this.array = GenerateArray(this.amountOfBars);
            this.colors = GenerateArray(this.amountOfBars);
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

        public void swapSingle(int item, int pos, int sleepTime)
        {
            int temp = item;
            item = array[pos];
            array[pos] = temp;

            colors[pos] = 100;

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
        /// Returns an array of integers where none of the integers are recurring.
        /// </summary>
        /// <param name="values"> The amount of pillars we will need to get a number for.</param>
        /// <param name="min"> The smallest number possible to generate. </param>
        /// <param name="max"> The highest numver possible to generate.</param>
        /// <returns></returns>
        private int[] GenerateArray(int values)
        {
            int[] array = new int[values];

            for (int i = 0; i < values; i++)
            {
                this.colors[i] = 0;
                this.array[i] = 0;
            }
            return array;
        }


        /// <summary>
        /// Returns an array of integers where none of the integers are recurring.
        /// </summary>
        /// <param name="values"> The amount of pillars we will need to get a number for.</param>
        /// <param name="min"> The smallest number possible to generate. </param>
        /// <param name="max"> The highest numver possible to generate.</param>
        /// <returns></returns>
        private int[] GenerateRandomArray(int values, int min, int max, int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < values; i++)
            {
                array[i] = random.Next(min, max);
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

            //Draw information about the algorithm.
            g.DrawString("Iterations: " + iterations, new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 50);
            g.DrawString("Algorithm: " + Name, new Font("Arial", 24, FontStyle.Bold), new SolidBrush(Color.White), 100, 100);

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

            //Draw all the pillars relative to the screen coordinates.
            for (int i = 0; i < amountOfBars; i++)
            {
                int x = (i * ScreenDimensions.X / amountOfBars);
                int y = 0;
                int width = (ScreenDimensions.X / amountOfBars);
                int height = getIndex(i);

                int colorValue = colors[i] * 2;

                if(colorValue > 190)
                {
                    Brush brush = new SolidBrush(Color.FromArgb(255 - colorValue, 255, 255 - colorValue));
                    g.FillRectangle(brush, new Rectangle(x, y, width, height));
                    g.DrawRectangle(new Pen(brush,width), new Rectangle(x, y, width, height));
                }
                else
                {
                    Brush brush = new SolidBrush(Color.FromArgb(255, 255 - colorValue, 255 - colorValue));
                    g.FillRectangle(brush, new Rectangle(x, y, width, height));
                    g.DrawRectangle(new Pen(brush, width), new Rectangle(x, y, width, height));
                }
               
                if(colors[i] > 0)
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
            this.ClientSize = new System.Drawing.Size(1209, 411);
            this.Name = "Window";
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Getters and setters.
        /// </summary>
        /// 
        public void setCurrentAlgorithm(ISortAlgorithms algorithm)
        {
            this.currentAlgorithm = algorithm;
        }

        public int[] getArray()
        {
            return array;
        }

        public void setIndex(int index,int value)
        {
            this.array[index] = value;
        }

        public void setAlgorithmName(string value)
        {
            this.Name = value;
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

    }
}