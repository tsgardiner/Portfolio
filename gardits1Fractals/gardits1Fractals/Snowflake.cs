using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gardits1Fractals
{
    public class Snowflake
    {
        Graphics g;
        SolidBrush sb;
        Pen pen;
        public int Depth { get; set; }

        public Snowflake(Graphics g)
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
        /// Takes in two points and a line angle.
        /// Should be called three times at different angles to form a triangle at base 0.
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="pA"></param>
        /// <param name="pB"></param>
        /// <param name="lineAngle"></param>
        public void Koch(int depth, Point pA, Point pB, int lineAngle)
        {
            //Colour does nothing as of now.
            Color[] c = { Color.Blue, Color.Red, Color.Pink, Color.Black, Color.Green, Color.Yellow };
                       
            if (depth == 0)
            {
               Draw(pA, pB, c[depth]);
            }
            else
            { 
                int lineLength = Mathematical.GetLineLength(pA, pB); //Gets inital line length
                int angleDif = 60;
          
                Point left = Mathematical.GetDestPoint(pA, lineLength / 3, lineAngle);
                Point peak = Mathematical.GetDestPoint(left, lineLength / 3, lineAngle - angleDif);
                Point right = Mathematical.GetDestPoint(pA, 2* (lineLength / 3), lineAngle);    

                Koch(depth - 1, pA, left, lineAngle );
                Koch(depth - 1, left, peak, lineAngle - angleDif);
                Koch(depth - 1, peak, right, lineAngle + angleDif);
                Koch(depth - 1, right, pB, lineAngle );
            }
        }
        
        

    }
}
