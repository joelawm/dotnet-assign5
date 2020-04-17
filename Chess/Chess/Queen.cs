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
        public Queen(Player player) : base(player, Type.Queen)
        {
            //Queen can move in any direction any number of spaces in open direction :: diagnol first 56 pairs up and down last 56 pairs.
            base.Rank = new int[] {1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7, -1, -2, -3, -4, -5, -6, -7, 1, 2, 3, 4, 5, 6, 7,
                                    0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6, -7};
            base.File = new int[] {1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7, 1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7,
                                    1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6, -7, 0, 0, 0, 0, 0, 0, 0};
            base.numberofdirections = 8;
        }
    }
}
