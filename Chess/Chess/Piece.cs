using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    public enum Type { King, Queen, Knight, Bishop, Rook, Pawn };
    public enum Side { black, White};
    class Piece
    {
        private readonly Side side;
        private Point coordinate;
        protected Type type;

        public Piece(Side side, Point coord)
        {
            this.side = side;
            Coordinate = coord;
        }

        public Point Coordinate
        {
            get => coordinate;
            set { coordinate = value; }
        }
        public Side Side => side;

        public Type Type => type;

        public virtual Point move(Point step)
        {
            return Coordinate;
        }
    }
}
