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
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxX; y++)
                {
                    board[x, y] = new Location((File)x, (Rank)y);
                }
            }
        }

        //find the squares
        public Location[,] GetSquares()
        {
            return board;
        }

        public void Add(Piece piece, Location location)
        {

            if (board[(int)location.File, (int)location.Rank].Piece == null) { 
                board[(int)location.File, (int)location.Rank].Piece = piece;
                piece.CurrentLocation = board[(int)location.File, (int)location.Rank];
            }
            else
                throw new Exception("Cannot add piece here, it is already occupied.");
        }

        public bool Move(Piece piece, Location from, Location to)
        {
            if (piece.IsValidMove(this.Occupation(), from, to))
            {
                //detect the attack
                if(board[(int)to.File, (int)to.Rank].Piece != null &&
                    board[(int)from.File, (int)from.Rank].Piece.Player != board[(int)to.File, (int)to.Rank].Piece.Player)
                {
                    //need to figure out how to do pawn
                    //attack detected and add it to the list of lost pieces
                    board[(int)to.File, (int)to.Rank].Piece.Player.PiecesLost.Add(board[(int)to.File, (int)to.Rank].Piece);
                    piece.CurrentLocation = null;
                    piece.Moved();  //record that the player moved the piece from its initial position
                    piece.Player.Pieces.Remove(piece);//Remove from active pieces
                }                    
                //Move the piece
                board[(int)to.File, (int)to.Rank].Piece = board[(int)from.File, (int)from.Rank].Piece;
                piece.CurrentLocation = to;

                //null out the old piece
                board[(int)from.File, (int)from.Rank].Piece = null;
                return true;
            } else
            {
                return false;
            }
        }

        //basically labeling in binary to make sure the componenets are there
        public int[,] Occupation()
        {
            //create the new table
            int[,] table = new int[8,8];
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxX; y++)
                {
                    if (board[x, y].Piece == null) 
                    {
                        table[x, y] = 0;
                    } else if (board[x, y].Piece.Player.Color == PlayerColor.White)
                    {
                        table[x, y] = 1;
                    }
                    else if (board[x, y].Piece.Player.Color == PlayerColor.Black)
                    {
                        table[x, y] = 2;
                    }
                }
            }

            return table;
        }

        //finds the pieces on the board
        public Piece GetPiece(int x, int y)
        {
            if(board[x,y] == null)
            {
                return null;
            }
            else
            {
                return board[x, y].Piece;
            }
            
        }
    }
}
