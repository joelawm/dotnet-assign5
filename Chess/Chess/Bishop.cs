using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Bishop:Piece
    {
        private readonly Type type;
        public Bishop(int side, Point coord) : base(side, coord) 
        {
            type = Type.Bishop;
        }

        public Type Type => type;
    }
}
