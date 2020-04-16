using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Knight:Piece
    {
        public Knight(Player player) : base(player, Type.Knight)
        {
            //Queen can move in any direction any number of spaces in open direction
            base.Ranks = new int[] { 1, 2, -2, -1, -2, -1, 1, 2};
            base.Files = new int[] { 2, 1, 1, 2, -1, -2, -2, -1};
        }

        public override bool IsValidMove(GameBoard board, Location to)
        {
            return base.IsValidMove(board, to);
        }
    }
}
