using PyramidSolver.Model;
using System.Collections.Generic;
using System.Linq;

namespace PyramidSolver.SolverStrategy
{
    public class GreedySolver : ISolverStrategy
    {
        public SolverResult GetSolution(Graph graph)
        {
            List<SolverResult> results = new List<SolverResult>();
            foreach (var n in graph.GetExitNodes())
            {
                List<Node> path = new List<Node>();
                if (HasPath(graph.GetRoot(), n, path))
                {
                    SolverResult r = new SolverResult(path);
                    results.Add(r);
                }
            }
            return results.OrderByDescending(x => x.GetCost()).First();
        }

        private bool HasPath(Node from, Node to, List<Node> path)
        {
            path.Add(from);
            if (from == to)
            {
                return true;
            }

            //Due to the (small) complexity of this question, I chose a greedy algorithm
            //Thus it is super important to sort the childs after their weight, or there's a risk
            //That the small child is picked
            //Given there are always (for this question) a max of 2 children, this operation is carried out with low cost
            foreach (var e in from.Edges.OrderByDescending(e => e.Weight))
            {
                if (HasPath(e.ToNode, to, path))
                {
                    return true;
                }
            }
            path.RemoveAt(path.Count - 1);
            return false;
        }
    }
}
