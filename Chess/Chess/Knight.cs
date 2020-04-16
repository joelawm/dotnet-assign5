using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Knight:Piece
    {
        public Knight(Player player, Location location) : base(player, Type.Knight, location)
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
        public Knight(Side side, Point coord)
        {

            this.side = side;
            Coordinate = coord;
            type = Type.Knight;
        }

        public override bool move(Point step)
        {
            Point stepCounter = new Point(step.X - Coordinate.X, step.Y - Coordinate.Y);
            switch (stepCounter.X)
            {
                case -2 * 105:
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
                case -1 * 105:
                    {
                        switch (stepCounter.Y)
                        {
                            case 2 * 105: Coordinate = step; return true;
                            case -2 * 105: Coordinate = step; return true;
                            default:
                                break;
                        }
                    }
                    break;
                case 1 * 105:
                    {
                        switch (stepCounter.Y)
                        {
                            case 2 * 105: Coordinate = step; return true;
                            case -2 * 105: Coordinate = step; return true;
                            default:
                                break;
                        }
                    }
                    break;
                case 2 * 105:
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
                default:
                    break;
            }
            return false;
        }
        */
    }
}
