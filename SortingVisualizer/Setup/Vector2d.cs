using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Setup
{
    public class Vector2d
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Vector2d()
        {
            setZero();
        }

        public Vector2d(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        private void setZero()
        {
            this.X = 0;
            this.Y = 0;
        }
    }
}
