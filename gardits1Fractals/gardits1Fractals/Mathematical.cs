using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gardits1Fractals
{
    public static class Mathematical
    {

        /// <summary>
        /// Converts Degrees to Radians
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        /// <summary>
        /// Gets the middle of a line between two points and returns that Point.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Point GetMidPointOfLine(Point a, Point b)
        {
            return new Point((a.X + b.X) / 2, (a.Y + b.Y) / 2);
        }

        /// <summary>
        /// Gets the mid of two point at 90 degrees to the incomming points.
        /// Equivlant to the center of a square formed by the two points.
        /// </summary>
        /// <param name="startPoint"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public static Point GetMidPointAt90Degrees(Point startPoint, Point endPoint)
        {
            Point midpoint = new Point();
            midpoint.X = (startPoint.X + endPoint.X) / 2 + (startPoint.Y - endPoint.Y) / 2; // ??
            midpoint.Y = (startPoint.Y + endPoint.Y) / 2 - (startPoint.X - endPoint.X) / 2; // ??
            return midpoint;
        }

        /// <summary>
        /// Takes to points and returns the distance between them as an int.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GetLineLength(Point a, Point b)
        {
            return (int)Math.Sqrt(Math.Pow((b.X - a.X), 2 ) + Math.Pow((b.Y - a.Y), 2));
        }

        /// <summary>
        /// Take the length of the hypotenuse.
        /// Takes the angle between the hypotenuse and the desired side.
        /// Returns an int of the line length.
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="hypotenuse"></param>
        /// <returns></returns>
        public static int GetTriSideLength(int angle, int hypotenuse)
        { 
            return (int)(hypotenuse * (Math.Sqrt(2) / 2));
        }

        /// <summary>
        /// Takes startPoint, line length, and line angle.
        /// Returns the destination point that line reaches as type Point.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="length"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static Point GetDestPoint(Point startPoint, int length, double angle)
        {
            double rAngle = ConvertToRadians(angle);
            double xD = Math.Cos(rAngle) * length;
            double yD = Math.Sin(rAngle) * length;
            return new Point(startPoint.X + (int)xD, startPoint.Y + (int)yD);
        }
        
    }
}
