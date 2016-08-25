using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gardits1Fractals
{
    public class Cesàro
    {
        Graphics g;
        SolidBrush sb;
        Pen pen;
        public int Depth { get; set; }

        public Cesàro(Graphics g)
        {
            this.g = g;
        }

        public void Draw(Point pA, Point pB, Color c)
        {
            sb = new SolidBrush(c);
            pen = new Pen(sb);
            g.DrawLine(pen, pA, pB);
        }

        /// <summary>
        /// Takes in a start point and end point to form a line.
        /// Should have four calls to form a square at base 0.
        /// The middle of the line gets a tear at a sharp angle towards the center.
        /// The points of each tear don't touch the center. There is a 5% gap between the points and the center.
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="lineAngle"></param>
        public void CesàroFractal(int depth, Point a, Point b, int lineAngle) 
        {
            Color[] c = { Color.Blue, Color.Red, Color.Pink, Color.Black, Color.Green, Color.Yellow };

            if (depth == 0)
            {
                Draw(a, b, c[depth]);
            }
            else
            {
                int angleDif = 87; //Tear angle
                int halfLineLength = Mathematical.GetLineLength(a, b) / 2;
                //Gap stops center points touching and is the base of the tear length.  
                int gap = (int)(halfLineLength * 0.05);                                

                //Two points 5% of half length away from the mid point
                Point left = Mathematical.GetDestPoint(a, halfLineLength - gap, lineAngle);
                Point right = Mathematical.GetDestPoint(a, halfLineLength + gap, lineAngle);
                Point peak = Mathematical.GetDestPoint(left, halfLineLength - gap, lineAngle + angleDif);
                
                CesàroFractal(depth - 1, a, left, lineAngle);
                CesàroFractal(depth - 1, left, peak, lineAngle + angleDif);
                CesàroFractal(depth - 1, peak, right, lineAngle - angleDif);
                CesàroFractal(depth - 1, right, b, lineAngle);
            }
            
        }
    }
}
