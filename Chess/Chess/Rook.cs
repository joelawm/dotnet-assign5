using System;
using System.Drawing;

namespace Chess
{
    class Rook:Piece
    {
        public Rook(Player player, Location location) : base(player, Type.Rook, location)
        {
            //Queen can move in any direction any number of spaces in open direction
            base.Ranks = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6, -7};
            base.Files = new int[] { 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6, -7, 0, 0, 0, 0, 0, 0, 0};
        }

        public override bool IsValidMove(GameBoard board, Location to)
        {
            return base.IsValidMove(board, to);
        }


        /*
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
        */
    }
}
