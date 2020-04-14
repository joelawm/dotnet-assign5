﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Bishop:Piece
    {
        public Bishop(Side side, Point coord)
        {
            this.side = side;
            Coordinate = coord;
            type = Type.Bishop;
        }
        public override bool move(Point step)
        {
            Point stepCounter = new Point(step.X - Coordinate.X, step.Y - Coordinate.Y);
            if (Math.Abs(stepCounter.X) == Math.Abs(stepCounter.Y))
            {
                Coordinate = step;
                return true;
            }
            return false;
        }
    }
}
