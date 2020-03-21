using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Critters
{
    static class CritterMain
    {
        /// <summary>
        /// CSE 142 Homework 8 (Critters)
        // Authors: Stuart Reges and Marty Stepp
        // Stolen and ported to C# by Toomas Allen
        //
        // CritterMain provides the main method for a simple simulation program.  Alter
        // the number of each critter added to the simulation if you want to experiment
        // with different scenarios.  You can also alter the width and height passed to
        // the CritterFrame constructor.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CritterFrame frame = new CritterFrame(60, 40);
            
            

            // uncomment each of these lines as you complete these classes
             frame.add(30, typeof(Bear));
            // frame.add(30, Lion.class);
             frame.add(30, typeof(Giant));
            // frame.add(30, Husky.class);

            frame.add(30, typeof(FlyTrap));
            frame.add(30, typeof(Food));

            frame._start();
            Application.Run(frame);
        }
    }
}
