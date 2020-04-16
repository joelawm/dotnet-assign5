using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Location
    {
        public Files Files { get; set; }
        public Ranks Ranks { get; set; }

        public Location(Ranks ranks, Files files)
        {
            this.Files = files;
            this.Ranks = ranks;
        }
    }
}
