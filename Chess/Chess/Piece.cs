using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public enum Type { King, Queen, Knight, Bishop, Rook, Pawn };
    public enum Player { black, White};

    // https://en.wikipedia.org/wiki/Chess
    public enum Ranks { one, two, three, four, five, six, seven, eight };  //AKA X, Column
    public enum Files { a, b, c, d, e, f, g, h }; // AKA Y, Row

    public class Piece
    {
        private Player player;
        protected Location location;

        protected int[] Ranks;
        protected int[] Files;

        //        private Point coordinate;
        private Type type;

        public Piece(Player player, Type type, Location location)
        {
            this.player = player;
            this.type = type;
            this.location = location;
        }

        public Location CurrentLocation
        {
            get { return this.location; }
        }

        public virtual bool IsValidMove(GameBoard board, Location to)
        {
            int count = 0;
            int p = (int)to.Files;
            int q = (int)to.Ranks;
            int n = 8;
            int m = 8;

            // Check if each possible 
            // move is valid or not 
            for (int i = 0; i < 8; i++)
            {
                // Position of knight 
                // after move 
                int x = p + Ranks[i];
                int y = q + Files[i];

                // count valid moves 
                if (x >= 0 && y >= 0 &&
                    x < n && y < m) // &&
                    //mat[x, y] == 0) //Doesn't have a piece on it
                    count++;
            }

            // Return number  
            // of possible moves 
            //return count;
            return false;
        }

        //public Point Coordinate
        //{
        //    get => coordinate;
        //    set { coordinate = value; }
        //}
        //public Side Side => side;

        //public Type Type => type;

        //public virtual bool move(Point step)
        //{
        //    return false;
        //}
    }
}
