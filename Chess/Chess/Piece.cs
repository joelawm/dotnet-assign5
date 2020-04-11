using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Piece
    {
        private readonly int side;

        public Piece(int side)
        {
            this.side = side;
        }

        public int Side => side;
    }
}
