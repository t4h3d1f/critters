using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critters
{
    class Ant :Critter
    {
        private bool toggleWalk = false;
        

        public override Color getColor()
        {
            return Color.Red;
        }

        public override string toString()
        {
            return "%";
        }


    }
}
