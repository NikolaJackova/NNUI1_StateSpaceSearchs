using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01.DepthFirstSearch
{
    class DepthFirstSearch
    {
        public SearchSystemController<DepthFirstSearchNode> DepthFirstSearchSystem { get; set; }
        public Stack<DepthFirstSearchNode> Fringe { get; set; }
        public IList<DepthFirstSearchNode> Explored { get; set; }
        public DepthFirstSearchNode InitNode { get; set; }
        public DepthFirstSearch(DepthFirstSearchNode initNode, State finalState, int rows = 2, int columns = 3)
        {
            DepthFirstSearchSystem = new SearchSystemController<DepthFirstSearchNode>(finalState, rows, columns);
            Fringe = new Stack<DepthFirstSearchNode>();
            Explored = new List<DepthFirstSearchNode>();
            InitNode = initNode;
        }

        public Stack<DepthFirstSearchNode> Search(out int iteration)
        {
            iteration = 0;
            Fringe.Push(InitNode);
            while (Fringe.Count != 0)
            {
                DepthFirstSearchNode node = Fringe.Pop();
                Explored.Add(node);
                if (DepthFirstSearchSystem.IsFinalState(node))
                {
                    Stack<DepthFirstSearchNode> breadthFirstSearchPath = new Stack<DepthFirstSearchNode>();
                    DepthFirstSearchSystem.ReconstructPath(node, breadthFirstSearchPath);
                    return breadthFirstSearchPath;
                }
                IList<DepthFirstSearchNode> children = DepthFirstSearchSystem.Successor(node);
                foreach (var item in children)
                {
                    if (!Explored.Any(nodeInCollection => item.Equals(nodeInCollection)) && !Fringe.Any(nodeInCollection => item.Equals(nodeInCollection)))
                    {
                        Fringe.Push(item);
                    }
                }
                iteration++;
            }
            return null;
        }
    }
}
