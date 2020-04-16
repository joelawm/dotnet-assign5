using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Bishop:Piece
    {
        public Bishop(Player player, Location location) : base(player, Type.Bishop, location)
        {
            //Queen can move in any direction any number of spaces in open direction
            base.Ranks = new int[] { 1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7, -1, -2, -3, -4, -5, -6 - 7, 1, 2, 3, 4, 5, 6, 7 };
            base.Files = new int[] { 1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7, 1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7};
        }

        public override bool IsValidMove(GameBoard board, Location to)
        {
            return base.IsValidMove(board, to);
        }
        /*
        public Bishop(Side side, Point coord)
        {
            this.side = side;
            Coordinate = coord;
            type = Type.Bishop;
        }
        public override bool move(Point step)
        {
            Point stepCounter = new Point(step.X - Coordinate.X, step.Y - Coordinate.Y);
            if (Math.Abs(stepCounter.X) == Math.Abs(stepCounter.Y))
            {
                Coordinate = step;
                return true;
            }
            return false;
        }
        */
    }
}
