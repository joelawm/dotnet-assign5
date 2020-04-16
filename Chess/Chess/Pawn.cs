using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(Player player) : base(player, Type.Pawn)
        {
            //Queen can move in any direction any number of spaces in open direction
            base.Ranks = new int[] {0};
            base.Files = new int[] {1}; // do plus one on first move
        }

        public override bool IsValidMove(GameBoard board, Location to)
        {
            return base.IsValidMove(board, to);
        }
    }
}