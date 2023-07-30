using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Point
    {
        private int X { get; set; }
        private int Y { get; set; }

        public Point (int x, int y)
        {
            if (x < 1 || x > 8)
                throw new ArgumentException("x must be between 1 and 8");
            else
                X = x;
            if (y < 1 || y > 8)
                throw new ArgumentException("y must be between 1 and 8");
            else
                Y = y;
        }

        public int GetX
        {
            get { return X; } 
        }

        public int GetY
        {
            get { return Y; }
        }
    }
}
