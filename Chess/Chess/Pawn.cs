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
        bool firstStep = true;
        public Pawn(Side side, Point coord) : base(side, coord)
        {
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
    }
}