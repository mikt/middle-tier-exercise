using System.Collections.Generic;

namespace PyramidSolver.Model
{
    /// <summary>
    /// A vertex. It contains a value, and its own position in the pyramid
    /// </summary>
    public class Node
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; }
        public int LineNumber { get; set; }
        public int PositionNumber { get; set; }

        public Node(int value, int lineNumber, int positionNumber)
        {
            Value = value;
            LineNumber = lineNumber;
            PositionNumber = positionNumber;
            Edges = new List<Edge>();
        }
    }
}
