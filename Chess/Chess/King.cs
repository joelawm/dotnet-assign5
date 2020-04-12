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
        private readonly Type type;
        public King(int side, Point coord) : base(side, coord)
        {
            type = Type.King;
        }

        public Type Type => type;
    }
}
