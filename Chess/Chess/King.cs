using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class King : Piece
    {
        public King(Side side, Point coord) : base(side, coord)
        {
            type = Type.King;
        }
        public override bool move (Point step)
        {
            Point stepCounter = new Point(step.X - Coordinate.X, step.Y - Coordinate.Y);
            switch (stepCounter.X)
            {
                case 0:
                    {
                        switch (stepCounter.Y)
                        {
                            case 1 * 105: Coordinate = step; return true;
                            case -1 * 105: Coordinate = step; return true;
                            default:
                                break;
                        }
                    }
                    break;
                case 1 * 105:
                    {
                        switch (stepCounter.Y)
                        {
                            case 0: Coordinate = step; return true;
                            case 1 * 105: Coordinate = step; return true;
                            case -1 * 105: Coordinate = step; return true;
                            default:
                                break;
                        }
                    }
                    break;
                case -1 * 105:
                    {
                        switch (stepCounter.Y)
                        {
                            case 0: Coordinate = step; return true;
                            case 1 * 105: Coordinate = step; return true;
                            case -1 * 105: Coordinate = step; return true;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
