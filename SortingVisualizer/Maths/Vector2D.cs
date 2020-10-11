using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualizer.Maths
{
    public class Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }
        /// <summary>
        /// Create a Vector2D at (0,0) with the help of setZero()
        /// </summary>
        public Vector2D()
        {
            setZero();
        }

        /// <summary>
        /// Creates a Vector2D using the parameter values.
        /// </summary>
        /// <param name="X">X INT VALUE</param>
        /// <param name="Y">Y INT VALUE</param>
        public Vector2D(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Sets this.X and this.Y to 0;
        /// </summary>
        private void setZero()
        {
            this.X = 0;
            this.Y = 0;
        }
    }
}