using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Piece
    {
        private readonly int side;
        private Point coordinate;

        public Piece(int side, Point coord)
        {
            this.side = side;
            coordinate = coord;
        }

        public Point Coordinate
        {
            get => coordinate;
            set { coordinate = value; }
        }
        public int Side => side;
    }
}
