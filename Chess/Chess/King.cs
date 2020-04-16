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
            base.Ranks = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            base.Files = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        }

        public override bool IsValidMove(GameBoard board, Location to)
        {
            return base.IsValidMove(board, to);
        }
    }
}
