using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Rook:Piece
    {
        private readonly Type type;
        public Rook(int side, Point coord) : base(side, coord)
        {
            type = Type.Rook;
        }

        public Type Type => type;
    }
}
