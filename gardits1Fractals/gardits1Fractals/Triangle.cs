using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace gardits1Fractals
{
    public class Triangle
    {
        Graphics g;
        SolidBrush sb;
        Pen pen; 
        public int Depth { get; set; }

        public Triangle(Graphics g)          
        {
            this.g = g;
        }

        /// <summary>
        /// Gets three points and a colour and draws a Triangle of depth 0
        /// </summary>
        public void Draw(Point pA, Point pB, Point pC, Color c)
        {
            Point[] points = { pA, pB, pC };

            sb = new SolidBrush(c);
            pen = new Pen(sb);

            g.DrawPolygon(pen, points);
            g.FillPolygon(new SolidBrush(c), points);
        }

        /// <summary>
        /// Takes in three points of a triangle.
        /// If depth is greater than 0. 
        /// Three recursive calls are made to draw triangles within the incomming parent triangle.
        /// </summary>
        /// <param name="depth"></param>
        public void SerpinskiTri(int depth, Point pA, Point pB, Point pC)
        {
            //Colour idea not working quite right atm.
            Color[] c = { Color.Blue, Color.Red, Color.Pink, Color.Black, Color.Green, Color.Yellow };
            if (depth == 0)
                Draw(pA, pB, pC, c[depth]);
            else
            {
                SerpinskiTri(depth - 1, pA, Mathematical.GetMidPointOfLine(pA, pB), Mathematical.GetMidPointOfLine(pA, pC));    //Top
                SerpinskiTri(depth - 1, Mathematical.GetMidPointOfLine(pA, pC), Mathematical.GetMidPointOfLine(pB, pC), pC);    //Left                
                SerpinskiTri(depth - 1, Mathematical.GetMidPointOfLine(pA, pB), pB, Mathematical.GetMidPointOfLine(pB, pC));    //Right
            }
   
        }
    }
}
