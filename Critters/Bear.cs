using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Critter class extension for a critter called a 'Bear'
// It is represented by a '/' or a '\'
// Author: Rukmal Weerawarana

namespace Critters
{
    class Bear:Critter
    {
        // private variables to measure the count of the instances and polarity of the bear
        private int count;
        private bool polar;

        // constructor for the critter bear
        public Bear(bool polar)
        {
            this.count = 0;
            this.polar = polar;
        }

        // returns the color of the bear depending on the boolean polar (white if true, black if false)
        public override Color getColor()
        {
            if (this.polar)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }

        // returns the string value of the bear
        public override string toString()
        {
            this.count = this.count + 1;
            if (count % 2 == 1)
            {
                return "/";
            }
            else
            {
                return "\\";
            }
        }

        // returns the move to be made by the bear
        public override Action getMove(CritterInfo info)
        {
            Console.WriteLine(info.getInfectCount() + "  Bear  ");
            if (info.getFront() == Neighbor.OTHER)
            {
                return Action.INFECT;
            }
            else if (info.getFront() == Neighbor.EMPTY)
            {
                return Action.HOP;
            }
            else
            {
                return Action.LEFT;
            }
        }
    }
}
