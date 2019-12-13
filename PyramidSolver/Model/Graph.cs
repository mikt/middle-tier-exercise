using System.Collections.Generic;
using System.Linq;

namespace PyramidSolver.Model
{
    /// <summary>
    /// A graph object wrapper for the list of list. Expose typical graph information and operations.
    /// There's a tight coupling to this class because of the parser and solver-strategy, which is not ideal.
    /// Since we are now forcing a datastructure of list<list<node>>, which may not be optimal, and is not easy to refactor
    /// But we should also keep in mind it's a small assignment, and we shouldn't build a rocket.
    /// </summary>
    public class Graph
    {
        private readonly List<List<Node>> _map;

        public Graph(List<List<Node>> map)
        {
            _map = map;
        }

        public List<List<Node>> GetMap()
        {
            return _map;
        }

        public List<Node> GetExitNodes()
        {
            return _map.Last();
        }

        public Node GetRoot()
        {
            return _map[0][0];
        }
    }
}
