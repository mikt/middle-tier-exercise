using System.Collections.Generic;
using System.Text;

namespace PyramidSolver.Model
{
    /// <summary>
    /// A common class to describe the produced result by solving the problem
    /// </summary>
    public class SolverResult
    {
        private List<Node> Path { get; set; }
        private int Cost { get; set; }

        public SolverResult(List<Node> path)
        {
            Path = path;
            Cost = PathCost(path);
        }

        public int GetCost()
        {
            return Cost;
        }

        public List<Node> GetPath()
        {
            return Path;
        }

        private int PathCost(List<Node> path)
        {
            int cost = 0;
            foreach (var node in path)
            {
                cost += node.Value;
            }

            return cost;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Max sum: {Cost}");
            sb.Append("Path: ");
            foreach (var p in Path)
            {
                sb.Append($"{p.Value}, ");
            }

            return sb.ToString();
        }
    }
}
