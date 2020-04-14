using System;
using System.Drawing;

namespace Chess
{
    class Rook:Piece
    {
        public Rook(Side side, Point coord) : base(side, coord)
        {
            type = Type.Rook;
        }
        public override Point move(Point step)
        {
            Point stepCounter = new Point(step.X - Coordinate.X, step.Y - Coordinate.Y);
            if(Math.Abs(stepCounter.X) == Math.Abs(stepCounter.Y))
            {
                Coordinate = step;
            }
            return Coordinate;
        }
    }
}
