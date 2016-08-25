using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gardits1Fractals
{
    public class DragonCurve
    {
        Graphics g;
        SolidBrush sb;
        Pen pen;

        public int Depth { get; set; }

        public DragonCurve(Graphics g)
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
        /// Takes in a start point and end point.
        /// Gets the mid point at 90 degrees of that line. Making the start and end the hypotenuse.
        /// Does two recursive calls. One of each line.
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        public void Dragon(int depth, Point startPoint, Point endPoint)
        {
            Color[] c = { Color.Blue, Color.Red, Color.Pink, Color.Black, Color.Green, Color.Yellow };

            if (depth == 0)
            {
                Draw(startPoint, endPoint, c[depth]);
            }
            else
            {
                //After all my attempts to do this in three lines...
                Point midPoint = Mathematical.GetMidPointAt90Degrees(startPoint, endPoint);
                Dragon(depth - 1, startPoint, midPoint);
                Dragon(depth - 1, endPoint, midPoint);
            }

        }

    }
}
