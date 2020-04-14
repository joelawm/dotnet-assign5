using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public enum Type { King, Queen, Knight, Bishop, Rook, Pawn, Null };
    public enum Side { black, White, Null};
    class Piece
    {
        protected Side side;
        private Point coordinate;
        protected Type type;

        public Piece()
        {
            
        }

        public Point Coordinate
        {
            get => coordinate;
            set { coordinate = value; }
        }
        public Side Side => side;

        public Type Type => type;

        public virtual bool move(Point step)
        {
            return false;
        }
    }
}
