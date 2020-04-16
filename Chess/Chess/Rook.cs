using System;
using System.Drawing;

namespace Chess
{
    class Rook:Piece
    {
        public Rook(Player player) : base(player, Type.Rook)
        {
            //Queen can move in any direction any number of spaces in open direction
            base.Ranks = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6, -7};
            base.Files = new int[] { 1, 2, 3, 4, 5, 6, 7, 0, 0, 0, 0, 0, 0, 0, -1, -2, -3, -4, -5, -6, -7, 0, 0, 0, 0, 0, 0, 0};
        }

        public override bool IsValidMove(GameBoard board, Location to)
        {
            return base.IsValidMove(board, to);
        }
    }
}
