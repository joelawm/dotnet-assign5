using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public enum PlayerColor { White = 1, Black = 2 }
    public class Player
    {
        PlayerColor color;
        List<Piece> pieceslost;
        List<Piece> pieces;

        int piecessteps = 0;

        TimeSpan timespent = new TimeSpan();
        DateTime start = DateTime.Now;

        public Player(PlayerColor color)
        {
            this.color = color;
            this.pieces = new List<Piece>();
            this.pieceslost = new List<Piece>();
        }
        public List<Piece> Pieces
        {
            get { return pieces; }
        }

        public void AddPiece(Piece piece)
        {
            pieces.Add(piece);
        }

        public List<Piece> PiecesLost
        {
            get { return pieceslost; }
        }

        public void AddSteps(int steps)
        {
            piecessteps += steps;
        }

        public void Start()
        {
            start = DateTime.Now;
        }

        public void Stop()
        {
            DateTime now = DateTime.Now;
            timespent += (now - start);
        }

        public TimeSpan Totaltime()
        {
            return timespent;
        }

        public PlayerColor Color
        {
            get {return color; }
        }
    }
}
