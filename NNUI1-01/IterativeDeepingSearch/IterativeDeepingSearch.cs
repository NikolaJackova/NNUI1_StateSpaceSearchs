using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01.IterativeDeepingSearch
{
    class IterativeDeepingSearch
    {
        public SearchSystemController<IterativeDeepingNode> IterativeDeepingSearchSystem { get; set; }
        public int Limit { get; set; }
        public Stack<IterativeDeepingNode> Fringe { get; set; }
        public IList<IterativeDeepingNode> Path { get; set; }
        public IterativeDeepingNode InitNode { get; set; }
        public IterativeDeepingSearch(IterativeDeepingNode initNode, State finalState, int rows = 2, int columns = 3)
        {
            IterativeDeepingSearchSystem = new SearchSystemController<IterativeDeepingNode>(finalState, rows, columns);
            Fringe = new Stack<IterativeDeepingNode>();
            Path = new List<IterativeDeepingNode>();
            Limit = 0;
            InitNode = initNode;
        }
        public void Search()
        {
            Stack<IterativeDeepingNode> node;
            do
            {
                node = DoIterative();
            } while (Path.Count != 0);
            if (node != null)
            {
                Stack<IterativeDeepingNode> path = new Stack<IterativeDeepingNode>();
                //IterativeDeepingSearchSystem.ReconstructPath(node, path);
            }
        }
        public Stack<IterativeDeepingNode> DoIterative()
        {
            int depth = 0;
            Path.Clear();
            Fringe.Push(InitNode);
            while (depth <= Limit)
            {
                IterativeDeepingNode node = Fringe.Pop();
                Path.Add(node);
                IList<IterativeDeepingNode> children = IterativeDeepingSearchSystem.Successor(node);
                foreach (var item in children)
                {
                    if (!Path.Any(nodeInCollection => item.Equals(nodeInCollection)) && !Fringe.Any(nodeInCollection => item.Equals(nodeInCollection)))
                    {
                        
                        Fringe.Push(item);
                    }
                }
                if (IterativeDeepingSearchSystem.IsFinalState(node))
                {
                    Console.WriteLine(node.ToString() + " " + depth);
                    Console.WriteLine("I find solution!");
                    Path.Clear();
                    //return node;
                }
                depth++;
            }
            Limit++;
            return null;
        }
    }
}
