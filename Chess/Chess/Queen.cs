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
        public Queen(Player player, Location location) : base(player, Type.Queen, location)
        {
            //Queen can move in any direction any number of spaces in open direction :: diagnol first 28 pairs up and down last 28 pairs.
            base.Ranks = new int[] {1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7, -1, -2, -3, -4, -5, -6 -7, 1, 2, 3, 4, 5, 6, 7,
                                    0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6, -7};
            base.Files = new int[] {1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7, 1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7,
                                    1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6 , -7, 0, 0, 0, 0, 0, 0, 0};
        }

        public override bool IsValidMove(GameBoard board, Location to)
        {
            return base.IsValidMove(board, to);
        }


        //public Queen(Side side, Point coord)
        //{

        //    this.side = side;
        //    Coordinate = coord;
        //    type = Type.Queen;
        //}
        //public override bool move (Point step)
        //{
        //    Point stepCounter = new Point(step.X - Coordinate.X, step.Y - Coordinate.Y);
        //    if (Math.Abs(stepCounter.X) == Math.Abs(stepCounter.Y))
        //    {
        //        Coordinate = step;
        //        return true;
        //    }
        //    else if (stepCounter.X == 0 || stepCounter.Y == 0)
        //    {
        //        Coordinate = step; 
        //        return true;

        //    }
        //    return false;
        //}
    }
}
