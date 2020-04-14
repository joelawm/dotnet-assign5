using System;
using System.Drawing;

namespace Chess
{
    class Rook:Piece
    {
        public Rook(Side side, Point coord)
        {

            this.side = side;
            Coordinate = coord;
            type = Type.Rook;
        }
        public override bool move(Point step)
        {
            Point stepCounter = new Point(step.X - Coordinate.X, step.Y - Coordinate.Y);
            if (stepCounter.X == 0 || stepCounter.Y == 0)
            {
                Coordinate = step;
                return true;
            }
            return false;
        }
    }
}
