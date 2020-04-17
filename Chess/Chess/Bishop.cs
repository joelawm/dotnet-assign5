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
        public Bishop(Player player) : base(player, Type.Bishop)
        {
            //Queen can move in any direction any number of spaces in open direction
            base.Rank = new int[] { 1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7, -1, -2, -3, -4, -5, -6, - 7, 1, 2, 3, 4, 5, 6, 7 };
            base.File = new int[] { 1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7, 1, 2, 3, 4, 5, 6, 7, -1, -2, -3, -4, -5, -6, -7};
            base.numberofdirections = 4;
        }
    }
}
