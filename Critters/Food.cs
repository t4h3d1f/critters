using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This defines a simple class of critters that sit around waiting to be
// taken over by other critters.

namespace Critters
{

    class Food :Critter
    {
        public new Action getMove(CritterInfo info)
        {
            return Action.INFECT;
        }

        public override Color getColor()
        {
            return Color.Green;
        }

        public override string toString()
        {
            return "F";
        }
    }
}
