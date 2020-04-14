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
        public Knight(Side side, Point coord) : base(side, coord)
        {
            type = Type.Knight;
        }
    }
}
