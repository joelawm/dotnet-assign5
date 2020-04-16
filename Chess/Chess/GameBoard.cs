using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class GameBoard
    {
        private Location[,] board;
        private int maxX = 8;
        private int maxY = 8;

        public GameBoard()
        {
            //Init board
            board = new Location[maxX, maxY];
            for (int y = 0; y < maxX; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    board[x, y] = new Location((Rank)x, (File)y);
                }
            }
        }

        public Location[,] GetSquares()
        {
            return board;
        }

        public void Add(Piece piece, Location location)
        {

            if (board[(int)location.Rank, (int)location.File].Piece == null)
                board[(int)location.Rank, (int)location.File].Piece = piece;
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
    }
}
