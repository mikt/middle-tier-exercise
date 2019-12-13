using PyramidSolver.Model;
using System;
using System.Collections.Generic;

namespace PyramidSolver.Parser
{
    /// <summary>
    /// Super simple and very naive parser.
    /// There are a lot of optimizations that could be done, but this is not where I put my focus
    /// </summary>
    public class SimpleParser : IParser
    {
        private List<string> _inputLines = new List<string>();
        private List<List<Node>> _nodeGrid = new List<List<Node>>();

        public Graph ParseFile(string filePath)
        {
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            while ((line = file.ReadLine()) != null)
            {
                _inputLines.Add(line);
            }

            file.Close();

            foreach (var x in _inputLines)
            {
                _nodeGrid.Add(new List<Node>());
            }

            for (int inputLineNumber = 0; inputLineNumber < _inputLines.Count; inputLineNumber++)
            {
                //Start by getting the current line 
                var numbersInCurrentLine = GetLineAsList(_inputLines[inputLineNumber]);

                if (inputLineNumber == _inputLines.Count)
                {
                    //We're at the last line, these are the final leafs

                    //Eventually break out
                    break;
                }

                for (int positionNumber = 0; positionNumber < numbersInCurrentLine.Count; positionNumber++)
                {
                    Node n;
                    try
                    {
                        n = _nodeGrid[inputLineNumber][positionNumber];
                    }
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (ArgumentOutOfRangeException e)
#pragma warning restore CS0168 // Variable is declared but never used
                    {
                        //No node exists, store it in the nodegrid, at the current line (starting from 0) as index
                        n = new Node(numbersInCurrentLine[positionNumber], inputLineNumber, positionNumber);
                        _nodeGrid[inputLineNumber].Add(n);
                    }
                }
            }

            AddEdges();

            //Clean up
            Graph g = new Graph(_nodeGrid);
            _nodeGrid = new List<List<Node>>();
            _inputLines = new List<string>();
            return g;
        }

        private void AddEdges()
        {
            foreach (var pyramidLine in _nodeGrid)
            {
                foreach (var node in pyramidLine)
                {
                    var children = FindOrAddChildNodes(node);
                    foreach (var child in children)
                    {
                        //TODO: A for-loop within a for-loop within a for-loop.
                        //One could add the edges while building the structure the first time.
                        //But this worked, and it's a demo project so..
                        try
                        {
                            AddEdgeIfNeeded(node, child);
                        }
#pragma warning disable CS0168 // Variable is declared but never used
                        catch (ArgumentOutOfRangeException e)
#pragma warning restore CS0168 // Variable is declared but never used
                        {
                            continue;
                        }
                    }
                }
            }
        }

        private List<Node> FindOrAddChildNodes(Node node)
        {

            List<Node> results = new List<Node>();
            List<int> nextLineNumbers;
            try
            {
                nextLineNumbers = GetLineAsList(_inputLines[node.LineNumber + 1]);
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentOutOfRangeException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                //These were the child nodes.. nothing more to do
                return results;
            }

            Node directChildNode;
            Node rightChildNode;
            try
            {
                directChildNode = _nodeGrid[node.LineNumber + 1][node.PositionNumber];
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (ArgumentOutOfRangeException e)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                directChildNode = new Node(nextLineNumbers[node.PositionNumber], node.LineNumber + 1, node.PositionNumber);
            }

            try
            {
                rightChildNode = _nodeGrid[node.LineNumber + 1][node.PositionNumber + 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                rightChildNode = new Node(nextLineNumbers[node.PositionNumber + 1], node.LineNumber + 1, node.PositionNumber + 1);
            }

            results.Add(directChildNode);
            results.Add(rightChildNode);
            return results;
        }

        private void AddEdgeIfNeeded(Node node, Node child)
        {
            if (ShouldAddEdge(node, child))
            {
                Edge e = new Edge(child.Value, child);
                node.Edges.Add(e);
            }
        }

        private bool ShouldAddEdge(Node fromNode, Node toNode)
        {
            if (fromNode.Value % 2 == 0)
            {
                return toNode.Value % 2 != 0;
            }
            else
            {
                return toNode.Value % 2 == 0;
            }
        }

        private List<int> GetLineAsList(string line)
        {
            List<int> numbers = new List<int>();
            foreach (var num in line.Split(' '))
            {
                //TODO: Code is obviously not production ready, as there is no error handling..
                numbers.Add(Int32.Parse(num));
            }

            return numbers;
        }
    }
}
