using Microsoft.VisualStudio.TestTools.UnitTesting;
using PyramidSolver.Model;
using PyramidSolver.Parser;

namespace PyramidTests
{
    [TestClass]
    public class SimpleParserTest
    {
        Graph _graph;
        public SimpleParserTest()
        {
            IParser _parser = new SimpleParser();
            _graph = _parser.ParseFile("input2.txt");
        }

        //Rule 1
        [TestMethod]
        public void TestParsedFileAlwaysGoesDown()
        {
            foreach (var line in _graph.GetMap())
            {
                foreach (var node in line)
                {
                    foreach (var e in node.Edges)
                    {
                        //Check that each edge points to the line below
                        Assert.AreEqual(e.ToNode.LineNumber, node.LineNumber + 1);
                    }
                }
            }
        }

        //Rule 2
        [TestMethod]
        public void TestOddAndEvenNumbers()
        {
            foreach (var line in _graph.GetMap())
            {
                foreach (var node in line)
                {
                    foreach (var e in node.Edges)
                    {
                        if (node.Value % 2 == 0)
                        {
                            Assert.IsFalse(e.ToNode.Value % 2 == 0);
                        }
                        else
                        {
                            Assert.IsTrue(e.ToNode.Value % 2 == 0);
                        }
                    }
                }
            }
        }

        //While this rule is not explicitely defined
        //I understood from the example, that a number does not have a left, direct, and right child
        //it can just have a direct and right child (so everything is a position before the parent, cannot be a child of said parent)
        [TestMethod]
        public void TestDirectAndLeftChild()
        {
            foreach (var line in _graph.GetMap())
            {
                foreach (var node in line)
                {
                    foreach (var e in node.Edges)
                    {
                        //Check that each edge points to the line below
                        Assert.IsTrue(e.ToNode.PositionNumber == node.PositionNumber + 1 || e.ToNode.PositionNumber == node.PositionNumber);
                    }
                }
            }
        }
    }
}
