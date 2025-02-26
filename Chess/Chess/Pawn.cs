﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(Player player) : base(player, Type.Pawn)
        {
            //Queen can move in any direction any number of spaces in open direction
            base.File = new int[] {0,0,-1,1}; // do plus one on first move 2nd pair
            base.Rank = new int[] {1,2,1,1};//Last two pairs attack only
            base.numberofdirections = 1;
        }
    }
}