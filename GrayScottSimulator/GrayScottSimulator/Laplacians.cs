
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrayScottSimulator
{
    /// <summary>
    /// 
    /// </summary>
    public class Perpendicular : Equation
    {
        public Perpendicular(double feedA, double killB)
            : base(feedA, killB)
        {
            diffA = 0.00002;
            diffB = 0.00001;
        }

        public override void CalculateCellConcentrations(Cell currentCell)
        {
            double totalA = 0;
            double totalB = 0;

            for (int i = 0; i < currentCell.perendicularList.Capacity; i++)
            {
                totalA += currentCell.perendicularList[i].A;
                totalB += currentCell.perendicularList[i].B;
            }

            double h = 2.5 / 127;
            double rh = 1.0 / h / h;
            LapA = rh * (totalA - (4 * currentCell.A));
            LapB = rh * (totalB - (4 * currentCell.B));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Convolution : Equation
    {
         public Convolution(double feedA, double killB)
            : base(feedA, killB)
        {
            diffA = 1;
            diffB = 0.5;
        }

        public override void CalculateCellConcentrations(Cell currentCell)
        {
            double cornersValue = 0.05;
            double perpendicularValue = 0.2;

            double totalCornersA = 0;
            double totatPerpenicularA = 0;
            double totalCornersB = 0;
            double totatPerpenicularB = 0;

            double centerA = (currentCell.A * -1);
            double centerB = (currentCell.B * -1);

            for (int i = 0; i < currentCell.cornersList.Capacity; i++)
            {
                totalCornersA += (currentCell.cornersList[i].A * cornersValue);
                totalCornersB += (currentCell.cornersList[i].B * cornersValue);
                totatPerpenicularA += (currentCell.perendicularList[i].A * perpendicularValue);
                totatPerpenicularB += (currentCell.perendicularList[i].B * perpendicularValue);
            }
            LapA = totalCornersA + totatPerpenicularA + centerA;
            LapB = totalCornersB + totatPerpenicularB + centerB;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class DeltaMeans : Equation
    {
        public DeltaMeans(double feedA, double killB)
            : base(feedA, killB)
        {
            diffA = 1;
            diffB = 0.5;
        }

        public override void CalculateCellConcentrations(Cell currentCell)
        {
            int numberOfNeighbours = 8;
            double totalAverageA = 0;
            double totalAverageB = 0;

            for (int i = 0; i < numberOfNeighbours; i++)
            {
                totalAverageA += currentCell.allNeighboursList[i].A;
                totalAverageB += currentCell.allNeighboursList[i].B;
            }
            totalAverageA = (totalAverageA / numberOfNeighbours);
            totalAverageB = (totalAverageB / numberOfNeighbours);

            LapA = totalAverageA - currentCell.A;
            LapB = totalAverageB - currentCell.B;
        }
    }
}
