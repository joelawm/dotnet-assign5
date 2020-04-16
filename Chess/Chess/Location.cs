using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Location
    {
        public File File { get; set; }
        public Rank Rank { get; set; }

        public Location(Rank rank, File file)
        {
            this.File = file;
            this.Rank = rank;
        }

        //Can return null if no piece exists.
        public Piece Piece { get; set; }
    }
}
