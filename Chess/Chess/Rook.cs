using System;
using System.Drawing;

namespace Chess
{
    class Rook:Piece
    {
        public Rook(Player player) : base(player, Type.Rook)
        {
            //Queen can move in any direction any number of spaces in open direction
            base.Rank = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6, -7};
            base.File = new int[] { 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6, -7, 0, 0, 0, 0, 0, 0, 0};
            base.numberofdirections = 4;
        }
    }
}
