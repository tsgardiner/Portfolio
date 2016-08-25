using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayScottSimulator
{
    public abstract class ColourGenerator
    {
        protected double rgbOfB;
        protected double rgbOfA;
        protected int rgbB;
        protected int rgbA;
        public Color colour { get; set; }

        public abstract void CellColourShader(Cell currentCell);
    }
}
