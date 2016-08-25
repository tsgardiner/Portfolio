using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gardits1Fractals
{
    public class Tree
    {

        Graphics g;
        SolidBrush sb;
        Pen pen;
        public int Depth { get; set; }

        public Tree(Graphics g)
        {
            this.g = g;
        }

        public void Draw(Point pA, Point pB, Color c)
        {
            sb = new SolidBrush(c);
            pen = new Pen(sb);
            pen.Width = 2;
            g.DrawLine(pen, pA, pB);
        }

        /// <summary>
        /// Takes in a start and end point to form the trunk of the tree.
        /// Also takes in the initial angle of that line.
        /// Recursively forks out two more branches from each line at opposite angles.
        /// Each new branch is 25% shorter than the previous branch.
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <param name="angle"></param>
        public void FractalTree(int depth, Point pA, Point pB, int angle)
        {
            //Colour feature doesn't work yet.
            Color[] c = { Color.Black, Color.Red, Color.Pink, Color.Blue, Color.Green, Color.Yellow };
            if (depth == 0)            
                Draw(pA, pB, c[depth]);
            else
            {
                int lineLength = Mathematical.GetLineLength(pA, pB);
                int offest  = 35;
                //Each new branch is shortend by 25%
                Point branchA = Mathematical.GetDestPoint(pB, lineLength - (int)(lineLength * 0.25), angle - offest);
                Point branchB = Mathematical.GetDestPoint(pB, lineLength - (int)(lineLength * 0.25), angle + offest);

                FractalTree(depth - 1, pA, pB, angle); //This is required to draw the parent of previous recursive call.
                FractalTree(depth - 1, pB, branchA, angle - offest);
                FractalTree(depth - 1, pB, branchB, angle + offest);
            }
            
        }

    }
}
