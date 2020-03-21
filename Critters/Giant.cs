using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critters
{
    class Giant : Critter
    {
        private int count;
        private string previousName;
        private static string[] giantNames = {"fee", "fie", "foe", "fum"};
        /// <summary>
        /// test
        /// 
        /// </summary>
	    private int giantIndex;

        // constructor of the critter giant
        public Giant()
        {
            this.count = 0;
            this.giantIndex = 0;
        }

        // returns the color of the giant
        public override Color getColor()
        {
            return Color.Gray;
        }

        // returns the string value of the giant
        public override string toString()
        {
            this.count = this.count + 1;
            if ((this.count - 1) % 6 == 0)
            {
                if (this.giantIndex == 4)
                {
                    this.giantIndex = 0;
                }
                this.giantIndex = this.giantIndex + 1;
                return giantNames[giantIndex - 1];
            }
            else
            {
                this.previousName = giantNames[giantIndex - 1];
            }
            return this.previousName;
        }

        // returns the move to be made by the giant
        public override Action getMove(CritterInfo info)
        {
            if (info.getFront() == Neighbor.OTHER)
            {
                return Action.INFECT;
            }
            else if (info.getFront() != Neighbor.EMPTY)
            {
                return Action.RIGHT;
            }
            else
            {
                return Action.HOP;
            }
        }
    }
}
