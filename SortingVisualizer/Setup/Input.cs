﻿using SortingVisualizer.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortingVisualizer.Setup
{
    public class Input
    {
        private SortingStarter sortingStarter;
        public Input(Window window, SortingStarter sortingStarter)
        {
            this.sortingStarter = sortingStarter;
            window.KeyDown += Window_KeyDown;
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                sortingStarter.startData();
                //Application.Exit();
                sortingStarter.ExitApplication();
            }
        }
    }
}
