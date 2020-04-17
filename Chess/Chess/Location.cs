using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Location
    {
        //variables
        public File File { get; set; }  //X
        public Rank Rank { get; set; }  //Y

        public Location(File file, Rank rank)
        {
            this.File = file;
            this.Rank = rank;
        }

        //Can return null if no piece exists.
        public Piece Piece { get; set; }

        public override string ToString()
        {
            return Enum.GetName(typeof(File), File) + Enum.GetName(typeof(Rank), Rank);
        }
        
    }
}
