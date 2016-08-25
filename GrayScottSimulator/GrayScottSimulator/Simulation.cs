using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayScottSimulator
{
    public class Simulation
    {
        private Equation equation;       
        Grid grid;        

        public Simulation(Grid grid, Equation equation)
        {
            this.grid = grid;
            this.equation = equation;
        }

        public void RunSimulation()
        {
            grid.UpdateCellColour();                          
            equation.RunCalculations();
        }

        public void DrawSimulation()
        {
            grid.Draw();
        }
    }
}
         
