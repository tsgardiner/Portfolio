using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayScottSimulator
{
    public abstract class Equation
    {
        protected double diffA;
        protected double diffB;
        protected double feedA;
        protected double killB;
        public double LapA { get; set; }
        public double LapB { get; set; }

        public Equation(double feedA, double killB)
        {
            this.feedA = feedA;
            this.killB = killB;
        }

        public void RunCalculations()
        {
            Calculations();
            UpdateCells();
        }

        private void Calculations()
        {
            foreach (Cell cell in Grid.CellList)
            {
                CalculateCellConcentrations(cell);
                cell.tempA = (cell.A + ((diffA * LapA) - (cell.A * cell.B * cell.B) + (feedA * (1 - cell.A))));
                cell.tempB = (cell.B + ((diffB * LapB) + (cell.A * cell.B * cell.B) - (killB + feedA) * cell.B));
            }
        }

        public void UpdateCells()
        {
            foreach (Cell cell in Grid.CellList)
            {
                cell.A = cell.tempA;
                cell.B = cell.tempB;
            }
        }

        public abstract void CalculateCellConcentrations(Cell currentCell);
    }
}
