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
        public override Point move(Point step)
        {
            if (firstStep)
            {
                switch (Side)
                {
                    case Side.black:
                        {
                            if (step.Y - Coordinate.Y == 2 || step.Y - Coordinate.Y == 1)
                            {
                                Coordinate = step;
                                firstStep = false;
                            }
                        }break;
                    case Side.White:
                        {
                            if (step.Y - Coordinate.Y == -2 || step.Y - Coordinate.Y == -1)
                            {
                                Coordinate = step;
                                firstStep = false;
                            }
                        }break;
                    default:
                        break;
                }
            }
            else
            {
                switch (Side)
                {
                    case Side.black:
                        {
                            if (step.Y - Coordinate.Y == 1)
                            {
                                Coordinate = step;
                            }
                        }
                        break;
                    case Side.White:
                        {
                            if (step.Y - Coordinate.Y == -1)
                            {
                                Coordinate = step;
                            }
                        }break;
                    default:
                        break;
                }
            }
            return Coordinate;
        }
    }
}