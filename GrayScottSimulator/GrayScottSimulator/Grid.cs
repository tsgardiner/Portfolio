using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayScottSimulator
{
    public class Grid
    {
        //Constants
        private const int GRID_SIZE = 128;      //256   //128    //64
        private const int SEED_SIZE =   84;       //184   //84    //40
        private const int SEED_LOCATION = 44;   //72    //44    //24

        private Point startPosition;
        private static Cell[,] grid;

        private Graphics g;
        private CellNeighboursGenerator neighboursGenerator;
        public static List<Cell> CellList { get; set; }
        private ColourGenerator colourGenerator;

        public Grid(Graphics g, ColourGenerator colourGenerator)
        {
            this.g = g;
            this.colourGenerator = colourGenerator;
            startPosition = new Point(0, 0);
            grid = new Cell[GRID_SIZE, GRID_SIZE];
            CellList = new List<Cell>();

            CreateGrid();
            CreateSeedArea();
            CaculateNeighbourCells();            
        }
        
        //Create Grid of Cells and set each Cells position in the Grid.
        private void CreateGrid()
        {
            for (int gridRow = 0; gridRow < GetGRID_SIZE; gridRow++)
            {
                for (int gridColumn = 0; gridColumn < GetGRID_SIZE; gridColumn++)
                {
                    grid[gridRow, gridColumn] = new Cell(g, GetGRID_SIZE -1);
                    CellList.Add(grid[gridRow, gridColumn]);
                    grid[gridRow, gridColumn].PositionInGrid = new Point(gridRow, gridColumn);
                    
                    grid[gridRow, gridColumn].A = 1;
                    grid[gridRow, gridColumn].B = 0;
                }
            }
        }

        //Create Seed area based on A and B values
        private void CreateSeedArea()
        {
            for (int gridRow = SEED_LOCATION; gridRow < SEED_SIZE; gridRow++)
            {
                for (int gridColumn = SEED_LOCATION; gridColumn < SEED_SIZE; gridColumn++)
                {
                    grid[gridRow, gridColumn].A = 0;
                    grid[gridRow, gridColumn].B = 1;
                }
            }
        }

        public void Draw()
        {
            for (int gridRow = 0; gridRow < GetGRID_SIZE; gridRow++)
            {
                for (int gridColumn = 0; gridColumn < GetGRID_SIZE; gridColumn++)
                {
                    grid[gridRow, gridColumn].Draw(new Point(gridRow, gridColumn)); //New Point (gridRow, gridColumn) Draws Columns first (gridColumn, gridRow) Draws rows first.
                       
                   
                    //if block for testing draw positions of neighbour Cells
                    //if (grid[gridRow, gridColumn].PositionInGrid.X == 1 && grid[gridRow, gridColumn].PositionInGrid.Y == gridSize -1)
                    //{
                    //    grid[gridRow, gridColumn].NeighboursTest();
                    //} 
                }
            }
        }

        //public Bitmap DrawBitmap()
        //{
        //   Bitmap pattern;
        //   for (int gridRow = 0; gridRow < GetGRID_SIZE; gridRow++)
        //    {
        //        for (int gridColumn = 0; gridColumn < GetGRID_SIZE; gridColumn++)
        //        {
        //            grid[gridRow, gridColumn].Draw(new Point(gridRow, gridColumn));
        //        }      
        //    }
        //}

        public static Cell GetCell(Point gridPosition)
        {
            return grid[gridPosition.X, gridPosition.Y];
        }

        public void CaculateNeighbourCells()
        {
            neighboursGenerator = new CellNeighboursGenerator();
            foreach (Cell cell in CellList)
            {
                neighboursGenerator.CaluclateNeighbours(cell.PositionInGrid);           
            }
        }

        public void UpdateCellColour()
        {
            foreach (Cell cell in CellList)
            {
                colourGenerator.CellColourShader(cell);
                cell.CellColourShader(colourGenerator.colour);
            }
        }

        public static int GetGRID_SIZE
        {
            get { return GRID_SIZE; }
        } 
    }
}
