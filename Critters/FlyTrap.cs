using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This defines a simple class of critters that infect whenever they can and
// otherwise just spin around, looking for critters to infect.  This simple
// strategy turns out to be surpisingly successful.

namespace Critters
{
    class FlyTrap :Critter
    {
        public new Action getMove(CritterInfo info)
        {
            if (info.getFront() == Neighbor.OTHER)
            {
                return Action.INFECT;
            }
            else
            {
                return Action.LEFT;
            }
        }

        public override Color getColor()
        {
            return Color.Red;
        }

        public override string toString()
        {
            return "T";
        }
    }
}
