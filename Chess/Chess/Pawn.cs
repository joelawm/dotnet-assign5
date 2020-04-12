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
        public Pawn(int side, Point coord) : base(side, coord) { }
    }
}