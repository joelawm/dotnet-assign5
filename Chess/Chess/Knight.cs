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
        private readonly Type type;
        public Knight(int side, Point coord) : base(side, coord)
        {
            type = Type.Knight;
        }

        public Type Type => type;
    }
}
