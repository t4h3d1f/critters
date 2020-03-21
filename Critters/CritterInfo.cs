using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critters
{
    public interface CritterInfo
    {
         Critter.Neighbor getFront();
         Critter.Neighbor getBack();
         Critter.Neighbor getLeft();
         Critter.Neighbor getRight();
         Critter.Direction getDirection();
        int getInfectCount();
    }
}
