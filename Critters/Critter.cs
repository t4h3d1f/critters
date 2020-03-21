using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Shamelessly stolen from UW CSE 142 course site and ported to C#

// This is the superclass of all of the Critter classes.  Your class should
// extend this class.  The class provides several kinds of constants:
//
//    type Neighbor  : WALL, EMPTY, SAME, OTHER
//    type Action    : HOP, LEFT, RIGHT, INFECT
//    type Direction : NORTH, SOUTH, EAST, WEST
//
// Override the following methods to change the behavior of your Critter:
//
//     public Action getMove(CritterInfo info)
//     public Color getColor()
//     public String toString()
//
// The CritterInfo object passed to the getMove method has the following
// available methods:
//
//     public Neighbor getFront();            neighbor in front of you
//     public Neighbor getBack();             neighbor in back of you
//     public Neighbor getLeft();             neighbor to your left
//     public Neighbor getRight();            neighbor to your right
//     public Direction getDirection();       direction you are facing
//     public boolean frontThreat();          threatening critter in front?
//     public boolean backThreat();           threatening critter in back?
//     public boolean leftThreat();           threatening critter to the left?
//     public boolean rightThreat();          threatening critter to the right?


namespace Critters
{
    public class Critter
    {
        //Used to improve appearance while running
        public int oldX=0;
        public int oldY=0;
        public enum Neighbor
        {
            WALL, EMPTY, SAME, OTHER
        };

        public enum Action
        {
            HOP, LEFT, RIGHT, INFECT
        };

        public enum Direction
        {
            NORTH, SOUTH, EAST, WEST
        };

        // This method should be overriden (default action is turning left)
        public virtual Action getMove(CritterInfo info)
        {
            return Action.LEFT;
        }

        // This method should be overriden (default color is black)
        public virtual Color getColor()
        {
            return Color.Black;
        }

        // This method should be overriden (default display is "?")
        public virtual string toString()
        {
            return "?";
        }

        // This prevents critters from trying to redefine the definition of
        // object equality, which is important for the simulator to work properly.
        public bool equals(Object other)
        {
            return this == other;
        }
    }
}
