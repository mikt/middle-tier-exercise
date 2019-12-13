using Microsoft.VisualStudio.TestTools.UnitTesting;
using PyramidSolver.Model;
using PyramidSolver.Parser;
using PyramidSolver.SolverStrategy;
using System.Linq;

namespace PyramidTests
{
    [TestClass]
    public class GreedySolverTest
    {
        readonly ISolverStrategy _solver = new GreedySolver();

        readonly Graph _graph1;
        private readonly SolverResult _result1;

        readonly Graph _graph2;
        private readonly SolverResult _result2;

        public GreedySolverTest()
        {
            IParser parser = new SimpleParser();
            _graph1 = parser.ParseFile("input1.txt");
            _result1 = _solver.GetSolution(_graph1);

            _graph2 = parser.ParseFile("input2.txt");
            _result2 = _solver.GetSolution(_graph2);
        }

        /// <summary>
        /// We were told the solution to the simple solution, so all solvers should at least be able to produce that
        /// </summary>
        [TestMethod]
        public void TestKnownResult()
        {
            Assert.AreEqual(16, _result1.GetCost());
            Assert.AreEqual(_result1.GetPath()[0].Value, 1);
            Assert.AreEqual(_result1.GetPath()[1].Value, 8);
            Assert.AreEqual(_result1.GetPath()[2].Value, 5);
            Assert.AreEqual(_result1.GetPath()[3].Value, 2);
        }

        //Rule 3
        [TestMethod]
        public void TestBottomIsReached()
        {
            Assert.IsTrue(_graph1.GetExitNodes().Contains(_result1.GetPath().Last()));
            Assert.IsTrue(_graph2.GetExitNodes().Contains(_result2.GetPath().Last()));
        }
    }
}
