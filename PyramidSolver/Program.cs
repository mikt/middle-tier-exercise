using PyramidSolver.Model;
using PyramidSolver.Parser;
using PyramidSolver.SolverStrategy;
using System;

namespace PyramidSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            IParser p = new SimpleParser();
            Graph g = p.ParseFile("input.txt");
            ISolverStrategy s = new GreedySolver();
            Console.WriteLine(s.GetSolution(g));
        }
    }
}
