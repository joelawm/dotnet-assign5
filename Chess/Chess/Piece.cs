using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public enum Type { King, Queen, Knight, Bishop, Rook, Pawn };

    // https://en.wikipedia.org/wiki/Chess
    public enum File { a, b, c, d, e, f, g, h }; // AKA X, Colunmn
    public enum Rank { eight, seven, six, five, four ,three, two, one};  //AKA Y, Row

    public class Piece
    {
        protected int[] File = new int[8]; //Tracks valid moves
        protected int[] Rank = new int[8]; //Tracks valid moves

        private Player player;
        protected Location currentLocation;
        protected int numberofdirections;

        private Type type;
        private bool hasmoved = false;
        public Location CurrentLocation { get; set; }
        
        public Piece(Player player, Type type)
        {
            this.player = player;
            this.type = type;
            player.AddPiece(this);
        }

        public Player Player { get { return player; } }

        public void Moved()
        {
            hasmoved = true;
        }

        //find if the planned move is valid
        public virtual bool IsValidMove(int[,] table, Location from,  Location to)
        {
            int opponent = 0;
            if (player.Color == PlayerColor.White)
            {
                opponent = (int)PlayerColor.Black;
            } else
            {
                opponent = (int)PlayerColor.White;
            }


            int curX = (int)from.File;
            int curY = (int)from.Rank;
            int maxX = 8;
            int maxY = 8;

            int maxsteps = File.Length / numberofdirections; //how many steps each direction is 7= 56 / 8
            if (this is Pawn) maxsteps = 1;

            int currentstep = 1;
            int currentdirection = 1;
            // Check if each possible 
            // move is valid or not 
            for (int i = 0; i < File.Length; i++)
            {
                // Position of knight 
                // after move
                int offsetX = File[i];
                int offsetY = Rank[i];
                if (player.Color == PlayerColor.White && this is Pawn)
                {
                    offsetX *= -1;
                    offsetY *= -1;
                }
                int x = curX + offsetX;
                int y = curY + offsetY;
                
                // count valid moves 
                if (x >= 0 &&
                    y >= 0 &&
                    x < maxX &&
                    y < maxY)
                {
                    if (table[x, y] == 0 //Doesn't have a piece on it
                        || (table[x, y] == opponent) //Or our opponent is occupying space (attack)
                        )
                    {
                        //Pawn check...
                        if (this is Pawn && hasmoved && i == 1)
                        {
                            //second move is not allowed to move 2 spaces
                        }
                        else if (this is Pawn &&
                            x == (int)to.File
                            && y == (int)to.Rank 
                            && table[x, y] == opponent 
                            && i == 0 )
                        {
                            //Can't attack forward
                        }
                        else if (this is Pawn &&
                            x == (int)to.File
                            && y == (int)to.Rank
                            && table[x, y] == opponent
                            && i == 1)
                        {
                            //Can't attack forward
                        }
                        else if (x == (int)to.File
                            && y == (int)to.Rank)
                        {
                            return true;
                        }
                    }
                    else if (table[x, y] != opponent) //Is this us?
                    {
                        //Offset as nothing past this point will work
                        int totalsteps = currentdirection * maxsteps;
                        i += totalsteps - 1 - i;
                        currentstep = maxsteps - 1;
                    }
                } 
                else
                {
                    //Offset as nothing past this point will work
                    int totalsteps = currentdirection * maxsteps;
                    i += totalsteps - 1 - i;
                    currentstep = maxsteps - 1;
                }

                currentstep++;

                if (currentstep%maxsteps==0)
                {
                    currentdirection++;
                    currentstep = 0;
                }
            }

            // Return number  
            // of possible moves 
            //return count;
            return false;
        }

        //chcek if the king is in check
        public virtual bool IsCheck(int[,] table, Location from, Location to)
        {
            int opponent = 0;
            if (player.Color == PlayerColor.White)
            {
                opponent = (int)PlayerColor.Black;
            }
            else
            {
                opponent = (int)PlayerColor.White;
            }


            int curX = (int)from.File;
            int curY = (int)from.Rank;
            int maxX = 8;
            int maxY = 8;

            int maxsteps = File.Length / numberofdirections; //how many steps each direction is 7= 56 / 8
            if (this is Pawn) maxsteps = 1;

            int currentstep = 1;
            int currentdirection = 1;
            // Check if each possible 
            // move is valid or not 
            for (int i = 0; i < File.Length; i++)
            {
                // Position of knight 
                // after move
                int offsetX = File[i];
                int offsetY = Rank[i];
                if (player.Color == PlayerColor.White && this is Pawn)
                {
                    offsetX *= -1;
                    offsetY *= -1;
                }
                int x = curX + offsetX;
                int y = curY + offsetY;

                // count valid moves 
                if (x >= 0 &&
                    y >= 0 &&
                    x < maxX &&
                    y < maxY)
                {
                    if (table[x, y] == 0 //Doesn't have a piece on it
                        || (table[x, y] == opponent) //Or our opponent is occupying space (attack)
                        )
                    {
                        //Pawn check...
                        if (this is Pawn && hasmoved && i == 1)
                        {
                            //second move is not allowed to move 2 spaces
                        }
                        else if (this is Pawn &&
                            x == (int)to.File
                            && y == (int)to.Rank
                            && table[x, y] == opponent
                            && i == 0)
                        {
                            //Can't attack forward
                        }
                        else if (this is Pawn &&
                            x == (int)to.File
                            && y == (int)to.Rank
                            && table[x, y] == opponent
                            && i == 1)
                        {
                            //Can't attack forward
                        }
                        else if (x == (int)to.File
                            && y == (int)to.Rank)
                        {
                            return true;
                        } 
                        else if (table[x, y] == opponent)
                        {
                            return false;  //Dont go further as there is a piece in the way.
                        }
                        //else
                        //{
                        //    return false;  //Dont go further as there is a piece in the way.
                        //}
                    }
                    else if (table[x, y] != opponent) //Is this us?
                    {
                        //Offset as nothing past this point will work
                        int totalsteps = currentdirection * maxsteps;
                        i += totalsteps - 1 - i;
                        currentstep = maxsteps - 1;
                    }
                }
                else
                {
                    //Offset as nothing past this point will work
                    int totalsteps = currentdirection * maxsteps;
                    i += totalsteps - 1 - i;
                    currentstep = maxsteps - 1;
                }

                currentstep++;

                if (currentstep % maxsteps == 0)
                {
                    currentdirection++;
                    currentstep = 0;
                }
            }

            // Return number  
            // of possible moves 
            //return count;
            return false;
        }

    }
}
