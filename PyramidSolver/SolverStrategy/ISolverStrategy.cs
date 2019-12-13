using PyramidSolver.Model;

namespace PyramidSolver.SolverStrategy
{
    /// <summary>
    /// The idea is you can have different strategies
    /// It's an overkill for this exercise, but simply to demonstrate the mindset
    /// I would use when facing something like this in more complex work environments.
    /// For instance, one could perhaps use an adapted version of dijkstra
    /// </summary>
    public interface ISolverStrategy
    {
        SolverResult GetSolution(Graph graph);
    }
}
