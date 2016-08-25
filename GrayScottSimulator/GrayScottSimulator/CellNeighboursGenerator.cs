using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayScottSimulator
{
    public class CellNeighboursGenerator
    {
        private const int NEIGHBOURS_GRID = 3;

        Cell currentCell;
        Point PositionInGrid;
        private int gridSize;
        private Cell[,] neighbours;

        public CellNeighboursGenerator()
        {              
            neighbours = new Cell[NEIGHBOURS_GRID, NEIGHBOURS_GRID];
        }

        /// <summary>
        /// Calculate the neighbour cells
        /// Represented in a 3x3 two dimentional array of Cells so it can be tested and drawn to the screen.
        /// The top left position of (0, 0) is considered position 'A' incrimenting clockwise until position (0, 1) is 'H'
        /// Each Cell is obtained from the Grid Class CellList.
        /// </summary>
        public void CaluclateNeighbours(Point positionInGrid)
        {
            this.currentCell = Grid.GetCell(positionInGrid);
            this.gridSize = currentCell.gridSize;
            this.PositionInGrid = currentCell.PositionInGrid;

            //Sets the Middle Cell to the current cell. Helps avoid null issues.
            neighbours[1, 1] = Grid.GetCell(PositionInGrid);

            if (PositionInGrid.X == 0)
            {
                if (PositionInGrid.Y == 0)
                {
                    TopLeftCorner();
                    TopLeftCornerFive();
                }
                else if (PositionInGrid.Y == gridSize)
                {
                    BottomLeftCorner();
                    BottomLeftCornerFive();
                }
                else
                {
                    RightThree();
                    TopBottom();
                    LeftSideXZero();
                }
            }
            else if (PositionInGrid.X == gridSize)
            {
                if (PositionInGrid.Y == 0)
                {
                    TopRightCorner();
                    TopRightCornerFive();
                }
                else if (PositionInGrid.Y == gridSize)
                {
                    BottomRightCorner();
                    BottomRightCornerFive();
                }
                else
                {
                    LeftThree();
                    TopBottom();
                    RightSideXMax();
                }
            }
            else if (PositionInGrid.Y == 0)
            {
                BottomThree();
                LeftRight();
                TopYZero();
            }
            else if (PositionInGrid.Y == gridSize)
            {
                TopThree();
                LeftRight();
                BottomYMax();
            }
            else
            {
                //Either of these blocks produce the same result.
                RightThree();
                LeftThree();
                TopBottom();

                //TopThree();
                //BottomThree();
                //LeftRight();
            }

            CreateCellLists();

        }
        private void RightThree()
        {
            neighbours[2, 0] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y - 1)); //C
            neighbours[2, 1] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y));     //D
            neighbours[2, 2] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y + 1)); //E
        }
        private void TopBottom()
        {
            neighbours[1, 0] = Grid.GetCell(new Point(PositionInGrid.X, PositionInGrid.Y - 1));     //B
            neighbours[1, 2] = Grid.GetCell(new Point(PositionInGrid.X, PositionInGrid.Y + 1));     //F
        }
        private void LeftThree()
        {
            neighbours[0, 0] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y - 1)); //A
            neighbours[0, 1] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y));     //H
            neighbours[0, 2] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y + 1)); //G 
        }
        private void TopThree()
        {
            neighbours[0, 0] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y - 1)); //A
            neighbours[1, 0] = Grid.GetCell(new Point(PositionInGrid.X, PositionInGrid.Y - 1));     //B
            neighbours[2, 0] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y - 1)); //C
        }
        private void LeftRight()
        {
            neighbours[0, 1] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y));     //H
            neighbours[2, 1] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y));     //D
        }
        private void BottomThree()
        {
            neighbours[2, 2] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y + 1)); //E
            neighbours[1, 2] = Grid.GetCell(new Point(PositionInGrid.X, PositionInGrid.Y + 1));     //F
            neighbours[0, 2] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y + 1));     //G
        }
        private void LeftSideXZero()
        {
            neighbours[0, 0] = Grid.GetCell(new Point(gridSize, PositionInGrid.Y - 1));           //A
            neighbours[0, 1] = Grid.GetCell(new Point(gridSize, PositionInGrid.Y));               //H
            neighbours[0, 2] = Grid.GetCell(new Point(gridSize, PositionInGrid.Y + 1));            //G
        }
        private void RightSideXMax()
        {
            neighbours[2, 0] = Grid.GetCell(new Point(0, PositionInGrid.Y - 1)); //C
            neighbours[2, 1] = Grid.GetCell(new Point(0, PositionInGrid.Y));     //D
            neighbours[2, 2] = Grid.GetCell(new Point(0, PositionInGrid.Y + 1)); //E              
        }
        private void TopYZero()
        {
            neighbours[0, 0] = Grid.GetCell(new Point(PositionInGrid.X - 1, gridSize)); //A
            neighbours[1, 0] = Grid.GetCell(new Point(PositionInGrid.X, gridSize));     //B
            neighbours[2, 0] = Grid.GetCell(new Point(PositionInGrid.X + 1, gridSize)); //C
        }
        private void BottomYMax()
        {
            neighbours[2, 2] = Grid.GetCell(new Point(PositionInGrid.X + 1, 0));    //E
            neighbours[1, 2] = Grid.GetCell(new Point(PositionInGrid.X, 0));        //F
            neighbours[0, 2] = Grid.GetCell(new Point(PositionInGrid.X - 1, 0));    //G
        }


        //Methods that calculate the neighbours of the four corner cells on every grid
        private void TopLeftCorner()
        {
            neighbours[2, 1] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y));     //D
            neighbours[2, 2] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y + 1)); //E
            neighbours[1, 2] = Grid.GetCell(new Point(PositionInGrid.X, PositionInGrid.Y + 1));     //F
        }
        private void BottomLeftCorner()
        {
            neighbours[1, 0] = Grid.GetCell(new Point(PositionInGrid.X, PositionInGrid.Y - 1));     //B
            neighbours[2, 0] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y - 1)); //C
            neighbours[2, 1] = Grid.GetCell(new Point(PositionInGrid.X + 1, PositionInGrid.Y));     //D
        }
        private void TopRightCorner()
        {
            neighbours[0, 1] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y));        //H
            neighbours[1, 2] = Grid.GetCell(new Point(PositionInGrid.X, PositionInGrid.Y + 1));        //F
            neighbours[0, 2] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y + 1));    //G
        }
        private void BottomRightCorner()
        {
            neighbours[0, 0] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y - 1)); //A
            neighbours[1, 0] = Grid.GetCell(new Point(PositionInGrid.X, PositionInGrid.Y - 1));     //B
            neighbours[0, 1] = Grid.GetCell(new Point(PositionInGrid.X - 1, PositionInGrid.Y));     //H            
        }



        //Methods to calculate the mirror neighbour cells of each corner
        private void TopLeftCornerFive()
        {
            neighbours[0, 0] = Grid.GetCell(new Point(gridSize, gridSize));         //A
            neighbours[1, 0] = Grid.GetCell(new Point(gridSize - 1, gridSize));     //B
            neighbours[2, 0] = Grid.GetCell(new Point(gridSize - 2, gridSize));     //C
            neighbours[0, 1] = Grid.GetCell(new Point(gridSize, gridSize - 1));      //H
            neighbours[0, 2] = Grid.GetCell(new Point(gridSize, gridSize - 2));      //G
        }
        private void BottomLeftCornerFive()
        {
            neighbours[0, 0] = Grid.GetCell(new Point(gridSize, 2));            //A
            neighbours[0, 1] = Grid.GetCell(new Point(gridSize, 1));            //H
            neighbours[2, 2] = Grid.GetCell(new Point(gridSize - 2, 0));        //E
            neighbours[1, 2] = Grid.GetCell(new Point(gridSize - 1, 0));        //F
            neighbours[0, 2] = Grid.GetCell(new Point(gridSize, 0));            //G
        }
        public void TopRightCornerFive()
        {
            neighbours[0, 0] = Grid.GetCell(new Point(2, gridSize));        //A
            neighbours[1, 0] = Grid.GetCell(new Point(1, gridSize));        //B
            neighbours[2, 0] = Grid.GetCell(new Point(0, gridSize));        //C
            neighbours[2, 1] = Grid.GetCell(new Point(0, gridSize - 1));      //D
            neighbours[2, 2] = Grid.GetCell(new Point(0, gridSize - 2));      //E 
        }
        public void BottomRightCornerFive()
        {
            neighbours[2, 2] = Grid.GetCell(new Point(0, 0));     //E
            neighbours[1, 2] = Grid.GetCell(new Point(1, 0));     //F
            neighbours[0, 2] = Grid.GetCell(new Point(2, 0));     //G
            neighbours[2, 0] = Grid.GetCell(new Point(0, 2));     //C
            neighbours[2, 1] = Grid.GetCell(new Point(0, 1));     //D
        }

        public void CreateCellLists()
        {
            for (int x = 0; x < NEIGHBOURS_GRID; x++)
            {
                for (int y = 0; y < NEIGHBOURS_GRID; y++)
                {
                    if ((x == 1 && y == 0) || (x == 0 && y == 1) || (x == 2 && y == 1) || (x == 1 && y == 2))
                    {
                        currentCell.perendicularList.Add(neighbours[x, y]);
                    }
                    if ((x == 0 && y == 0) || (x == 2 && y == 0) || (x == 2 && y == 2) || (x == 0 && y == 2))
                    {
                        currentCell.cornersList.Add(neighbours[x, y]);
                    }
                    currentCell.allNeighboursList.Add(neighbours[x, y]);
                }
            }
            currentCell.allNeighboursList.Remove(Grid.GetCell(PositionInGrid)); //Removes the current center cell from the neighbours list
        }


        //public void NeighboursTest()
        //{
        //    for (int x = 0; x < NEIGHBOURS_GRID; x++)
        //    {
        //        for (int y = 0; y < NEIGHBOURS_GRID; y++)
        //        {
        //            neighbours[x, y].DrawNeighbours(neighbours[x, y].PositionInGrid);                   
        //        }
        //    }
        //}
    }
}
