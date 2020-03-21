using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Class CritterPanel displays a grid of critters

namespace Critters
{
    public partial class CritterPanel : UserControl
    {

        public CritterPanel()
        {
            InitializeComponent();
        }
        private CritterModel myModel;
        private Font myFont;
        private static bool created;

        public static int FONT_SIZE = 12;

        public CritterPanel(CritterModel model)
        {
            InitializeComponent();
            // this prevents someone from trying to create their own copy of
            // the GUI components
            if (created)
                throw new SystemException("Only one world allowed");
            created = true;

            myModel = model;
            // construct font and compute char width once in constructor
            // for efficiency
            myFont = new Font(FontFamily.GenericMonospace, FONT_SIZE + 4, FontStyle.Bold);
            BackColor = Color.Cyan;

            Size = new Size( FONT_SIZE * model.getWidth() + 20, FONT_SIZE * model.getHeight() + 20);
        }
        //added to support visual studio forms designer
        public void setModel(CritterModel model)
        {
            myModel = model;
            // construct font and compute char width once in constructor
            // for efficiency
            myFont = new Font(FontFamily.GenericMonospace, FONT_SIZE + 4, FontStyle.Bold);
            BackColor = Color.Cyan;

            Size = new Size(FONT_SIZE * model.getWidth() + 20, FONT_SIZE * model.getHeight() + 20);
        }
        
        public new void Update()
        {
            Graphics g = CreateGraphics();
            foreach(Critter c in myModel.getCritters())
            {
                Brush clr = new SolidBrush(Color.Cyan);

                Point p = myModel.getPoint(c);
                string appearance = myModel.getAppearance(c);
                Size oldSize = TextRenderer.MeasureText(appearance, myFont);
                g.FillRectangle(clr, new RectangleF(c.oldX*FONT_SIZE, c.oldY*FONT_SIZE, oldSize.Width, oldSize.Height));
                Brush b = new SolidBrush(Color.Black);
                g.DrawString("" + appearance,myFont,b, p.X * FONT_SIZE ,//+11
                             p.Y * FONT_SIZE );//+21
                Brush b2 = new SolidBrush(myModel.getColor(c));
                g.DrawString("" + appearance,myFont,b2, p.X * FONT_SIZE ,//+10
                             p.Y * FONT_SIZE );//+20
            }
            Parent.Update();
            g.Dispose();
        }

    }
}
