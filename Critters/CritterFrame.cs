using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Class CritterFrame provides the user interface for a simple simulation
// program.

namespace Critters
{
    public partial class CritterFrame : Form
    {
        private CritterModel myModel;
      //  private CritterPanel myPicture;
        private Button[] counts;
        private Button countButton;
        private bool started;
        private static bool created;

        public CritterFrame()
        {
            InitializeComponent();
        }

        public CritterFrame(int width, int height)
        {
            InitializeComponent();
            // this prevents someone from trying to create their own copy of
            // the GUI components
            if (created)
                throw new SystemException("Only one world allowed");
            created = true;

            // create model
            myModel = new CritterModel(width, height);

            // set up critter picture panel
            //   myPicture = new CritterPanel(myModel);
            myPicture.setModel(myModel);
            
            // initially it has not started
            started = false;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Step_Click(object sender, EventArgs e)
        {
            doOneStep();
        }

        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            double ratio = 1000.0 / (1 + Math.Pow(slider.Value, 0.3));
            timer1.Interval = ((int)(ratio - 180));
        }

        private void Debug_Click(object sender, EventArgs e)
        {
            myModel.toggleDebug();
            myPicture.Update();
        }

        private void Next100_Click(object sender, EventArgs e)
        {
            multistep(100);
        }


        // starts the simulation...assumes all critters have already been added
        public void _start()
        {
            // don't let anyone start a second time and remember if we have started
            if (started)
            {
                return;
            }
            // if they didn't add any critters, then nothing to do
            if (myModel.getCounts().Count == 0)
            {
                Console.WriteLine("nothing to simulate--no critters");
                return;
            }
            started = true;
            addClassCounts();
            myModel.updateColorString();
        }

        // add right-hand column showing how many of each critter are alive
        private void addClassCounts()
        {
            Dictionary<string, int> entries = myModel.getCounts();
       
            
            counts = new Button[entries.Count];
            for (int i = 0; i < counts.Length; i++)
            {
                counts[i] = new Button();
                counts[i].AutoSize = true;
                p.Controls.Add(counts[i], 0, i);
            }

            // add simulation count
            countButton = new Button();
            countButton.ForeColor = Color.Blue;
            countButton.AutoSize = true;
            p.Controls.Add(countButton,0,p.Controls.Count);
            

            setCounts();
        }

        private void setCounts()
        {
            int i = 0;
            int max = 0;
            int maxI = 0;
            foreach (KeyValuePair<string,int> entry in myModel.getCounts())
            {
                string ss = string.Format("{0} = {1:d4}", entry.Key,entry.Value);
                counts[i].Text= ss;
                counts[i].ForeColor = (Color.Black);
                if (entry.Value > max)
                {
                    max = entry.Value;
                    maxI = i;
                }
                i++;
            }
            counts[maxI].ForeColor = (Color.Red);
            string s = string.Format("step = {0:d5}", myModel.getSimulationCount());
            countButton.Text=(s);
        }

        // add a certain number of critters of a particular class to the simulation
        public void add(int number, Type c)
        {
            // don't let anyone add critters after simulation starts
            if (started)
            {
                return;
            }
            // temporarily turning on started flag prevents critter constructors
            // from calling add
            started = true;
            myModel.add(number, c);
            started = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            doOneStep();
        }



        // one step of the simulation
        private void doOneStep()
        {
            myModel.update();
            setCounts();
            myPicture.Update();
        }

        // advance the simulation until step % n is 0
        private void multistep(int n)
        {
            timer1.Stop();
            do
            {
                myModel.update();
            } while (myModel.getSimulationCount() % n != 0);
            setCounts();
            myPicture.Update();
        }
    }
}
