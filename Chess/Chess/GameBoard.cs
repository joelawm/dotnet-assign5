using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class GameBoard
    {
        private Piece[,] board;
        public GameBoard()
        {
            //Init board
            board = new Piece[8, 8];
        }

        public void Add(Piece piece)
        {
            if (board[(int)piece.CurrentLocation.Files, (int)piece.CurrentLocation.Ranks] == null)
                board[(int)piece.CurrentLocation.Files, (int)piece.CurrentLocation.Ranks] = piece;
            else
                throw new Exception("Cannot add piece here, it is already occupied.");
        }

        public void Move(Piece piece, Location to)
        {
            if (piece.IsValidMove(this, to))
            {
                //Move the piece
            } else
            {
                throw new Exception("This is not a valid move");
            }
        }

        //public void Init()
        //{
        //    Piece p = new King(Player.black, new Location(Row.one, Column.a));
        //}
    }
}
