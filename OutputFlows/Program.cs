using MathNet.Numerics.LinearAlgebra.Factorization;
using QuadraticOptimizationSolver.DataModels;
using QuadraticOptimizationSolver.Interfaces;
using QuadraticOptimizationSolver.Solvers;

namespace OutputFlows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IQuadraticOptimizationSolver<BalanceDataModel> solver = new BalanceSolver();
            OutputOriginal(solver);
            OutputV1(solver);
            OutputV1WithConditions(solver);
        }

        static private void OutputOriginal(IQuadraticOptimizationSolver<BalanceDataModel> solver)
        {
            BalanceDataModel original = new BalanceDataModel()
            {
                MatrixA = new double[,] {
                    { 1, -1, -1, 0, 0, 0, 0 },
                    { 0, 0, 1, -1, -1, 0, 0 },
                    { 0, 0, 0, 0, 1, -1, -1 },
                },
                VectorY = new double[] { 0, 0, 0 },
                Tolerance = new double[] { 0.200, 0.121, 0.683, 0.040, 0.102, 0.081, 0.020 },
                VectorI = new double[] { 1, 1, 1, 1, 1, 1, 1 },
                VectorX0 = new double[] { 10.005, 3.033, 6.831, 1.985, 5.093, 4.057, 0.991 }
            };

            double[] result = solver.Solve(original);
            Console.WriteLine("Original: ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"x{i} = {result[i]:F3}");
            }
        }

        static private void OutputV1(IQuadraticOptimizationSolver<BalanceDataModel> solver)
        {
            BalanceDataModel V1 = new BalanceDataModel()
            {
                MatrixA = new double[,] {
                    { 1, -1, -1, 0, 0, 0, 0, -1 },
                    { 0, 0, 1, -1, -1, 0, 0, 0 },
                    { 0, 0, 0, 0, 1, -1, -1, 0 },
                },
                VectorY = new double[] { 0, 0, 0 },
                Tolerance = new double[] { 0.200, 0.121, 0.683, 0.040, 0.102, 0.081, 0.020, 0.667 },
                VectorI = new double[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                VectorX0 = new double[] { 10.005, 3.033, 6.831, 1.985, 5.093, 4.057, 0.991, 6.667 }
            };

            double[] result = solver.Solve(V1);
            Console.WriteLine("V1: ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"x{i} = {result[i]:F3}");
            }
        }

        static private void OutputV1WithConditions(IQuadraticOptimizationSolver<BalanceDataModel> solver)
        {
            BalanceDataModel V1WithConditions = new BalanceDataModel()
            {
                MatrixA = new double[,] {
                    { 1, -1, -1, 0, 0, 0, 0, -1 },
                    { 0, 0, 1, -1, -1, 0, 0, 0 },
                    { 0, 0, 0, 0, 1, -1, -1, 0 },
                    { 1, -10, 0, 0, 0, 0, 0, 0 },
                },
                VectorY = new double[] { 0, 0, 0, 0 },
                Tolerance = new double[] { 0.200, 0.121, 0.683, 0.040, 0.102, 0.081, 0.020, 0.667 },
                VectorI = new double[] { 1, 1, 1, 1, 1, 1, 1, 1 },
                VectorX0 = new double[] { 10.005, 3.033, 6.831, 1.985, 5.093, 4.057, 0.991, 6.667 }
            };

            double[] result = solver.Solve(V1WithConditions);
            Console.WriteLine("V1 with conditions: ");
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"x{i} = {result[i]:F3}");
            }
        }
    }
}