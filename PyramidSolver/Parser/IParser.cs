using PyramidSolver.Model;

namespace PyramidSolver.Parser
{
    /// <summary>
    /// In case we want to add other (and better) ways of parsing.
    /// </summary>
    public interface IParser
    {
        Graph ParseFile(string filePath);
    }
}
