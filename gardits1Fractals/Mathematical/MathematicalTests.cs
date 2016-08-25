using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using gardits1Fractals;
using System.Drawing;

namespace MathematicalTests
{
    [TestClass]
    public class MathematicalTests
    {
        [TestMethod]
        public void GetSideLengthOfTriangle_Given_Hypotenuse_Angle()
        {
            int angle = 45; //Angle between hypotenuse and line.
            int h = 600;

            int expected = 424;
            int actual = Mathematical.GetTriSideLength(angle, h);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMidPointOfLine_At_90_Degrees()
        {
            Point start = new Point(526, 276);     //Start
            Point end = new Point(1375, 276);      //End

            Point expected = new Point(950, 700);
            Point actual = Mathematical.GetMidPointAt90Degrees(start, end);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindLengthOfLine_Between_Two_Points()
        {
            Point start = new Point(100, 100);     //Start
            Point end = new Point(300, 100);      //End

            int expected = 200;
            int actual = Mathematical.GetLineLength(start, end);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMidPointOfLine()
        {
            Point start = new Point(100, 100);     //Start
            Point end = new Point(300, 100);      //End

            Point expected = new Point(200, 100);
            Point actual = Mathematical.GetMidPointOfLine(start, end);

            Assert.AreEqual(expected, actual);
        }

       
    }
}
