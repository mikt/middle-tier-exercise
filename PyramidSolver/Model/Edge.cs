namespace PyramidSolver.Model
{
    /// <summary>
    /// A simple class to describe a one weighted directed graph.
    /// If bi-direction is required, create two opporsite edges.
    /// </summary>
    public class Edge
    {
        public Edge(int weight, Node node)
        {
            Weight = weight;
            ToNode = node;
        }

        public int Weight { get; set; }
        public Node ToNode { get; set; }
    }
}
