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
        private readonly Type type;
        public Pawn(int side, Point coord) : base(side, coord)
        {
            type = Type.Pawn;
        }

        public Type Type => type;
    }
}