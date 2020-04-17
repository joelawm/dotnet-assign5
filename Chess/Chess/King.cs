using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public class King : Piece
    {

        public King(Player player) : base(player, Type.King) {
            //King can move one space in any open direction
            base.File = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            base.Rank = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
            base.numberofdirections = 8;
        }
    }
}
