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
        public Stack<IterativeDeepingNode> Search(out int iteration)
        {
            iteration = 0;
            Stack<IterativeDeepingNode> recontructedPath;
            do
            {
                recontructedPath = DoIterative(ref iteration, out iteration);
            } while (recontructedPath == null);
            return recontructedPath;
        }
        private Stack<IterativeDeepingNode> DoIterative(ref int iteration, out int outIteration)
        {
            outIteration = iteration;
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
                    Stack<IterativeDeepingNode> iterativeDeepingSearchPath = new Stack<IterativeDeepingNode>();
                    IterativeDeepingSearchSystem.ReconstructPath(node, iterativeDeepingSearchPath);
                    return iterativeDeepingSearchPath;
                }
                depth++;
                iteration++;
            }
            Limit++;
            return null;
        }
    }
}
