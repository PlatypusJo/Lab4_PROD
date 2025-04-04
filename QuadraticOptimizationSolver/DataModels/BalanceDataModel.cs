using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticOptimizationSolver.DataModels
{
    public class BalanceDataModel : BaseDataModel
    {
        public double[,] MatrixA { get; set; }
        public double[] VectorY { get; set; }
        public double[] Tolerance { get; set; }
        public double[] VectorI { get; set; }
        public double[] VectorX0 { get; set; }
    }
}
