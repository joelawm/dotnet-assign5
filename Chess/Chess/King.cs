using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public class King : Piece
    {

        public King(Player player, Location location) : base(player, Type.King, location) {
            //King can move one space in any open direction
            base.Ranks = new int[] { -1, -1, -1, 0, 0, 1, 1, 1 };
            base.Files = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        }


        public override bool IsValidMove(GameBoard board, Location to)
        {
            return base.IsValidMove(board, to);
        }




        //public override bool move (Point step)
        //{
        //    Point stepCounter = new Point(step.X - Coordinate.X, step.Y - Coordinate.Y);
        //    switch (stepCounter.X)
        //    {
        //        case 0:
        //            {
        //                switch (stepCounter.Y)
        //                {
        //                    case 1 * 105: Coordinate = step; return true;
        //                    case -1 * 105: Coordinate = step; return true;
        //                    default:
        //                        break;
        //                }
        //            }
        //            break;
        //        case 1 * 105:
        //            {
        //                switch (stepCounter.Y)
        //                {
        //                    case 0: Coordinate = step; return true;
        //                    case 1 * 105: Coordinate = step; return true;
        //                    case -1 * 105: Coordinate = step; return true;
        //                    default:
        //                        break;
        //                }
        //            }
        //            break;
        //        case -1 * 105:
        //            {
        //                switch (stepCounter.Y)
        //                {
        //                    case 0: Coordinate = step; return true;
        //                    case 1 * 105: Coordinate = step; return true;
        //                    case -1 * 105: Coordinate = step; return true;
        //                    default:
        //                        break;
        //                }
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    return false;
        //}
    }
}
