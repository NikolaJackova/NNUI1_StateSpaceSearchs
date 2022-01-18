using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01.BreadthFirstSearch
{
    class BreadthFirstSearch
    {
        public SearchSystemController<BreadthFirstSearchNode> BreadthFirstSearchSystem { get; set; }
        public Queue<BreadthFirstSearchNode> Fringe { get; set; }
        public IList<BreadthFirstSearchNode> Explored { get; set; }
        public BreadthFirstSearchNode InitNode { get; set; }
        public BreadthFirstSearch(BreadthFirstSearchNode initNode, State finalState, int rows = 2, int columns = 3)
        {
            BreadthFirstSearchSystem = new SearchSystemController<BreadthFirstSearchNode>(finalState, rows, columns);
            Fringe = new Queue<BreadthFirstSearchNode>();
            Explored = new List<BreadthFirstSearchNode>();
            InitNode = initNode;
        }

        public Stack<BreadthFirstSearchNode> Search(out int iteration)
        {
            iteration = 0;
            Fringe.Enqueue(InitNode);
            while (Fringe.Count != 0)
            {
                BreadthFirstSearchNode node = Fringe.Dequeue();
                Explored.Add(node);
                if (BreadthFirstSearchSystem.IsFinalState(node))
                {
                    Stack<BreadthFirstSearchNode> breadthFirstSearchPath = new Stack<BreadthFirstSearchNode>();
                    BreadthFirstSearchSystem.ReconstructPath(node, breadthFirstSearchPath);
                    return breadthFirstSearchPath;
                }
                IList<BreadthFirstSearchNode> children = BreadthFirstSearchSystem.Successor(node);
                foreach (var item in children)
                {
                    if (!Explored.Any(nodeInCollection => item.Equals(nodeInCollection)) && !Fringe.Any(nodeInCollection => item.Equals(nodeInCollection)))
                    {
                        Fringe.Enqueue(item);
                    }
                }
                iteration++;
            }
            return null;
        }
    }
}
