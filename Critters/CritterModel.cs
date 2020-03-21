using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// Class CritterModel keeps track of the state of the critter simulation.

namespace Critters
{
    public class CritterModel
    {
        // the following constant indicates how often infect should fail for
        // critters who didn't hop on their previous move (0.0 means no advantage,
        // 1.0 means 100% advantage)
        public static double HOP_ADVANTAGE = 0.2; // 20% advantage

        private int height;
        private int width;
        private Critter[,] grid;
        private Dictionary<Critter, PrivateData> info;
        private Dictionary<string, int> critterCount;
        private bool debugView;
        private int simulationCount;
        private static bool created;
        private Random rand = new Random();

        public CritterModel(int width, int height)
        {
            // this prevents someone from trying to create their own copy of
            // the GUI components
            if (created)
                throw new SystemException("Only one world allowed");
            created = true;

            this.width = width;
            this.height = height;
            grid = new Critter[width,height];
            info = new Dictionary<Critter, PrivateData>();
            critterCount = new Dictionary<string, int>();
            this.debugView = false;
        }

        public Critter[] getCritters()
        {
            return info.Keys.ToArray();
        }

        public Point getPoint(Critter c)
        {
            return info[c].p;
        }

        public Color getColor(Critter c)
        {
            return info[c].color;
        }

        public String getString(Critter c)
        {
            return info[c]._string;
        }

        public void add(int number, Type critter)
        {
            Random r = new Random();
            Critter.Direction[] directions = (Critter.Direction[])Enum.GetValues(typeof(Critter.Direction));
            if (info.Count + number > width * height)
                throw new SystemException("adding too many critters");
            for (int i = 0; i < number; i++)
            {
                Critter next;
                try
                {
                    next = makeCritter(critter);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + critter + " threw an " +
                                       " exception in its constructor.");
                    Environment.Exit(-1);
                    return;
                }
                int x, y;
                do
                {
                    x = r.Next(width);
                    y = r.Next(height);
                } while (grid[x,y] != null);
                grid[x,y] = next;

                Critter.Direction d = directions[r.Next(directions.Length)];
                info.Add(next, new PrivateData(new Point(x, y), d,0,next.getColor(),next.toString()));
            }
            string name = critter.Name;
            if (!critterCount.ContainsKey(name))
                critterCount.Add(name, number);
            else
                critterCount.Add(name, critterCount[name] + number);
        }


        private Critter makeCritter(Type critter)
        {
            ConstructorInfo c = critter.GetConstructors()[0];
            if (critter.Name == "Bear")
            {
                // flip a coin
                Random r = new Random();
                bool b = r.Next(0, 1) < 0.5;
                object[] param = new object[1];
                param[0] = b;
                return (Critter)c.Invoke(param);
            }
            else
            {
                object[] param = new object[0];
                return (Critter)c.Invoke(param);
            }
        }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public string getAppearance(Critter c)
        {
            // Override specified toString if debug flag is true
            if (!debugView)
                return info[c]._string;
            else
            {
                PrivateData data = info[c];
                if (data.direction == Critter.Direction.NORTH) return "^";
                else if (data.direction == Critter.Direction.SOUTH) return "v";
                else if (data.direction == Critter.Direction.EAST) return ">";
                else return "<";
            }
        }

        public void toggleDebug()
        {
            this.debugView = !this.debugView;
        }

        private bool inBounds(int x, int y)
        {
            return (x >= 0 && x < width && y >= 0 && y < height);
        }

        private bool inBounds(Point p)
        {
            return inBounds(p.X, p.Y);
        }

        // returns the result of rotating the given direction clockwise
        private Critter.Direction rotate(Critter.Direction d)
        {
            if (d == Critter.Direction.NORTH) return Critter.Direction.EAST;
            else if (d == Critter.Direction.SOUTH) return Critter.Direction.WEST;
            else if (d == Critter.Direction.EAST) return Critter.Direction.SOUTH;
            else return Critter.Direction.NORTH;
        }

        private Point pointAt(Point p, Critter.Direction d)
        {
            if (d == Critter.Direction.NORTH) return new Point(p.X, p.Y - 1);
            else if (d == Critter.Direction.SOUTH) return new Point(p.X, p.Y + 1);
            else if (d == Critter.Direction.EAST) return new Point(p.X + 1, p.Y);
            else return new Point(p.X - 1, p.Y);
        }

        private Info getInfo(PrivateData data, Type original)
        {
            Critter.Neighbor[] neighbors = new Critter.Neighbor[4];
            Critter.Direction d = data.direction;

            for (int i = 0; i < 4; i++)
            {
                neighbors[i] = getStatus(pointAt(data.p, d), original);
                d = rotate(d);
            }
            return new Info(neighbors, data.direction, data.infectCount);
        }

        private Critter.Neighbor getStatus(Point p, Type original)
        {
            if (!inBounds(p))
                return Critter.Neighbor.WALL;
            else if (grid[p.X,p.Y] == null)
                return Critter.Neighbor.EMPTY;
            else if (grid[p.X,p.Y].GetType() == original)
                return Critter.Neighbor.SAME;
            else
                return Critter.Neighbor.OTHER;
        }


        public void update()
        {
            simulationCount++;
            Object[] list = info.Keys.ToArray();
           // list = list.OrderBy(x => rand.Next()).ToArray();

            // This keeps track of critters that are locked and cannot be 
            // infected this turn. The happens when: 
            // * a Critter is infected
            // * a Critter hops
            HashSet<Critter> locked = new HashSet<Critter>();

            for (int i = 0; i < list.Length; i++)
            // foreach(Critter next in info.Keys)
            {
                Critter next = (Critter)list[i];
                if (info.ContainsKey(next))
                {
                    PrivateData data = info[next];
                    if (data == null)
                    {
                        // happens when creature was infected earlier in this round
                        continue;
                    }

                    Point p = data.p;
                    Point p2 = pointAt(p, data.direction);


                    // try to perform the critter's action
                    Critter.Action move = next.getMove(getInfo(data, next.GetType()));
                    if (move == Critter.Action.LEFT)
                        data.direction = rotate(rotate(rotate(data.direction)));
                    else if (move == Critter.Action.RIGHT)
                        data.direction = rotate(data.direction);
                    else if (move == Critter.Action.HOP)
                    {
                        if (inBounds(p2) && grid[p2.X, p2.Y] == null)
                        {
                            grid[p2.X, p2.Y] = grid[p.X, p.Y];
                            grid[p.X, p.Y] = null;
                            next.oldX = p.X;
                            next.oldY = p.Y;
                            data.p = p2;
                            locked.Add(next); //successful hop locks a critter from
                                              // being infected for the rest of the
                                              // turn
                        }
                    }
                    else if (move == Critter.Action.INFECT)
                    {
                        if (inBounds(p2) && grid[p2.X, p2.Y] != null
                            && grid[p2.X, p2.Y].GetType() != next.GetType()
                            && !locked.Contains(grid[p2.X, p2.Y]))
                        {
                            Critter other = grid[p2.X, p2.Y];
                            // remember the old critter's private data
                            PrivateData oldData = info[other];
                            // then remove that old critter
                            string c1 = other.GetType().Name;
                            critterCount[c1] = critterCount[c1] - 1;
                            string c2 = next.GetType().Name;
                            critterCount[c2] = critterCount[c2] + 1;
                            info.Remove(other);
                            // and add a new one to the grid
                            try
                            {
                                grid[p2.X, p2.Y] = makeCritter(next.GetType());
                                // This critter has been infected and is now locked
                                // for the rest of this turn
                                locked.Add(grid[p2.X, p2.Y]);
                            }
                            catch (Exception e)
                            {
                                throw new SystemException("" + e);
                            }
                            // and add to the map
                            info.Add(grid[p2.X, p2.Y], oldData);
                            // and remember that we infected a critter
                            data.infectCount++;
                        }
                    }
                }
                updateColorString();
            }
        }

        // calling this method causes each critter to update the stored color and
        // text for toString; should be called each time update is performed and
        // once before the simulation begins
        public void updateColorString()
        {
            foreach (Critter next in info.Keys)
            {
                info[next].color = next.getColor();
                info[next]._string = next.toString();
            }
        }

        public Dictionary<string, int> getCounts()
        {
            return critterCount;
        }

        public int getSimulationCount()
        {
            return simulationCount;
        }

        private class PrivateData
        {
            public Point p;
            public Critter.Direction direction;
            public Color color;
            public string _string;
            public int infectCount;

            public PrivateData(Point p, Critter.Direction d,int infectCount,
                           Color color, string _string)
            {
                this.p = p;
                this.direction = d;
                this.infectCount = infectCount;
                this.color = color;
                this._string = _string;
            }

            public string toString()
            {
                return p + " " + direction;
            }
        }

        // an object used to query a critter's state (neighbors, direction)
        private class Info : CritterInfo
        {
            private Critter.Neighbor[] neighbors;
            private Critter.Direction direction;
            private int infectCount;

            public Info(Critter.Neighbor[] neighbors, Critter.Direction d, int infectCount)
            {
                this.neighbors = neighbors;
                this.direction = d;
                this.infectCount = infectCount;
            }

            public Critter.Neighbor getFront()
            {
                return neighbors[0];
            }

            public Critter.Neighbor getBack()
            {
                return neighbors[2];
            }

            public Critter.Neighbor getLeft()
            {
                return neighbors[3];
            }

            public Critter.Neighbor getRight()
            {
                return neighbors[1];
            }

            public Critter.Direction getDirection()
            {
                return direction;
            }

            public int getInfectCount()
            {
                return infectCount;
            }

        }
    }
}

