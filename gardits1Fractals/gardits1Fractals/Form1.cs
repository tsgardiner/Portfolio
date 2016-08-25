using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gardits1Fractals
{
    public partial class Form1 : Form
    {

        Graphics g;
        Triangle tri;
        Snowflake snow;
        Tree tree;
        DragonCurve dragon;
        Cesàro cesàro;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            //Smooths the drawing of lines. Increases draw time on higher depth fractals especially the Tree.
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
           
            //Initialise each fractal
            snow = new Snowflake(g);
            tri = new Triangle(g);
            tree = new Tree(g);
            dragon = new DragonCurve(g);
            cesàro = new Cesàro(g);
        }
        
        private void btnTriangle_Click(object sender, EventArgs e)
        {
            g.Clear(SystemColors.Control); // Clear the canvas

            tri.Depth = Int32.Parse(tbDepth.Text);

            Point pA = new Point(950, 40);
            Point pB = new Point(1450, 906);
            Point pC = new Point(450, 906);

            tri.SerpinskiTri(tri.Depth, pA, pB, pC);
        }

        private void btnSnowflake_Click(object sender, EventArgs e)
        {
            g.Clear(SystemColors.Control); // Clear the canvas

            snow.Depth = Int32.Parse(tbDepth.Text);
            Point pA = new Point(650, 250);
            Point pB = new Point(1250, 250);
            Point pC = new Point(950, 770);

            //Seperate calls for each side of the triangle
            snow.Koch(snow.Depth, pA, pB, 0);
            snow.Koch(snow.Depth, pC, pA, -120);
            snow.Koch(snow.Depth, pB, pC, 120);
        }

        private void btnTree_Click(object sender, EventArgs e)
        {
            g.Clear(SystemColors.Control); // Clear the canvas
            tree.Depth = Int32.Parse(tbDepth.Text);

            Point pA = new Point(950, Height);
            Point pB = new Point(950, 756);

            tree.FractalTree(tree.Depth, pA, pB, -90);            
        }

        private void btnDragon_Click(object sender, EventArgs e)
        {
            g.Clear(SystemColors.Control);
                
            dragon.Depth = Int32.Parse(tbDepth.Text);
           
            Point start = new Point(526, 276); 
            Point end = new Point(1375, 276); 
                        
            dragon.Dragon(dragon.Depth, start, end);
        }

        private void btnCesàro_Click(object sender, EventArgs e)
        {
            g.Clear(SystemColors.Control);
            cesàro.Depth = Int32.Parse(tbDepth.Text);

            //Points form a square
            Point topLeft = new Point(650, 250);
            Point topRight = new Point(1250, 250);
            Point bottomLeft = new Point(650, 850);
            Point bottomRight = new Point(1250, 850);

            //Calls the CesaroFractal for each side of the square.
            cesàro.CesàroFractal(cesàro.Depth, topLeft, topRight, 0);
            cesàro.CesàroFractal(cesàro.Depth, topRight, bottomRight, 90);
            cesàro.CesàroFractal(cesàro.Depth, bottomRight, bottomLeft, -180);
            cesàro.CesàroFractal(cesàro.Depth, bottomLeft, topLeft, -90);
        }
                
    }
}
