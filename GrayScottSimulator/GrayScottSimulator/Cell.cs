using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayScottSimulator
{
    public class Cell
    {
        //Constants
        private const int CELL_SIZE = 4;
        
        //Lists
        public List<Cell> perendicularList { get; set; }
        public List<Cell> cornersList { get; set; }
        public List<Cell> allNeighboursList { get; set; }    
    
        //Variables
        public double A { get; set; }
        public double B { get; set; }
        public double tempA { get; set; }
        public double tempB { get; set; }
        public Point PositionInGrid { get; set; }
        public int gridSize { get; set; }
        private Graphics g;
        private Brush brush , borderBrush;        
        private Pen pen;
        private Color cellColour { get; set; }
        private Color borderColour;
        //private Brush testingBrush, neighboursBrush;

        public Cell(Graphics g, int gridSize)
        {
            this.g = g;
            this.gridSize = gridSize;
            perendicularList = new List<Cell>();
            cornersList = new List<Cell>();
            allNeighboursList = new List<Cell>();            
            borderColour = Color.Black;         
            brush = new SolidBrush(cellColour);
            borderBrush = new SolidBrush(borderColour);
            pen = new Pen(borderBrush);

            //Stuff for testing
            //testingBrush = new SolidBrush(Color.Blue);
            //neighboursBrush = new SolidBrush(Color.Yellow);
        }

        public void Draw(Point drawPosition)
        {            
            g.FillRectangle(brush, drawPosition.X * GetCELL_SIZE, drawPosition.Y * GetCELL_SIZE, GetCELL_SIZE, GetCELL_SIZE);
            //g.DrawRectangle(pen, drawPosition.X * CELL_SIZE, drawPosition.Y * CELL_SIZE, CELL_SIZE, CELL_SIZE);
        }

        //Local Colour Shader that assigns colour based on the values of A and B. 
        //In this case A is hard coded to 255 in the Red value.
        //Basic method to test colour shading theory.
        //The second 255 value is Red in RGB this makes the colour change between red and white based on the value of B between 0 and 1.
        public void CellColourShader(Color colour)
        {            
            //double rgbOfB = (255 * B);
            //double rgbOfA = (255 * A);
            //int rgbB = (int)rgbOfB;
            //int rgbA = (int)rgbOfA;
            ////Can't use rgbA with Dela Means equation it completely breaks.
            //cellColour = Color.FromArgb(255, rgbB, 0, 0); 
            brush = new SolidBrush(colour);    
        }


        //Draws the current Cell and it's neighbours.           
        //public void DrawNeighbours(Point drawPosition)
        //{
        //    g.FillRectangle(neighboursBrush, drawPosition.X * CELL_SIZE, drawPosition.Y * CELL_SIZE, CELL_SIZE, CELL_SIZE);
        //    g.DrawRectangle(pen, drawPosition.X * CELL_SIZE, drawPosition.Y * CELL_SIZE, CELL_SIZE, CELL_SIZE);
        //}


        public static int GetCELL_SIZE
        {
            get { return CELL_SIZE; }
        } 
    }
}
