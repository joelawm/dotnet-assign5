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
        public Pawn(Player player, Location location) : base(player, Type.Pawn, location)
        {
            //Queen can move in any direction any number of spaces in open direction
            base.Ranks = new int[] { };
            base.Files = new int[] { };
        }

        public override bool IsValidMove(GameBoard board, Location to)
        {
            return base.IsValidMove(board, to);
        }

        /*
        bool firstStep = true;
        public Pawn(Side side, Point coord)
        {

            this.side = side;
            Coordinate = coord;
            type = Type.Pawn;
        }
        public override bool move(Point step)
        {
            if (firstStep && step.X - Coordinate.X == 0)
            {
                switch (Side)
                {
                    case Side.black:
                        {
                            if (step.Y - Coordinate.Y == 2 * 105 || step.Y - Coordinate.Y == 105)
                            {
                                Coordinate = step;
                                firstStep = false;
                                return true;
                            }
                        }break;
                    case Side.White:
                        {
                            if (step.Y - Coordinate.Y == -2 * 105 || step.Y - Coordinate.Y == -105)
                            {
                                Coordinate = step;
                                firstStep = false;
                                return true;
                            }
                        }break;
                    default:
                        break;
                }
            }
            else if (step.X - Coordinate.X == 0)
            {
                switch (Side)
                {
                    case Side.black:
                        {
                            if (step.Y - Coordinate.Y == 105)
                            {
                                Coordinate = step;
                                return true;
                            }
                        }
                        break;
                    case Side.White:
                        {
                            if (step.Y - Coordinate.Y == -105)
                            {
                                Coordinate = step;
                                return true;
                            }
                        }break;
                    default:
                        break;
                }
            }
            return false;
        }
        */
    }
}