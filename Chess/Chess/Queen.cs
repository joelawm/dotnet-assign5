using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Queen:Piece
    {
        public Queen(Side side, Point coord) : base(side, coord)
        {
            type = Type.Queen;
        }
        public override Point move (Point step)
        {
            Point stepCounter = new Point(step.X - Coordinate.X, step.Y - Coordinate.Y);
            if (Math.Abs(stepCounter.X) == Math.Abs(stepCounter.Y))
                Coordinate = step;
            else if (stepCounter.X == 0 || stepCounter.Y == 0)
                Coordinate = step;
            return Coordinate;
        }
    }
}
