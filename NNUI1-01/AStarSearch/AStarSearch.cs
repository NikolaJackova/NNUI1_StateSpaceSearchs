using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NNUI1_01.AStarSearch
{
    class AStarSearch
    {
        public SearchSystemController<AStarNode> AStarSearchSystem { get; set; }
        public SimplePriorityQueue<AStarNode> Fringe { get; set; }
        public AStarNode InitNode { get; set; }
        public IList<AStarNode> Explored { get; set; }

        private AStarNode finalNode;

        public AStarSearch(AStarNode initNode, State finalState, int rows = 3, int columns = 3)
        {
            AStarSearchSystem = new SearchSystemController<AStarNode>(finalState, rows, columns);
            InitNode = initNode;
            Fringe = new SimplePriorityQueue<AStarNode>();
            Explored = new List<AStarNode>();
        }

        public Stack<AStarNode> Search(out int iteration)
        {
            iteration = 0;
            Fringe.Enqueue(InitNode, InitNode.PathTotal);
            while (Fringe.Count != 0)
            {
                AStarNode node = Fringe.Dequeue();
                Explored.Add(node);
                IList<AStarNode> children = AStarSearchSystem.Successor(node);
                foreach (var item in children)
                {
                    if (!Explored.Any(nodeInCollection => item.Equals(nodeInCollection)) && !Fringe.Any(nodeInCollection => item.Equals(nodeInCollection)))
                    {
                        EvaluateNodeWithCost(item);
                        Fringe.Enqueue(item, item.PathTotal);
                    }
                }
                if (AStarSearchSystem.IsFinalState(node))
                {
                    EvaluateNodeWithCost(node);
                    Stack<AStarNode> aStarNodePath = new Stack<AStarNode>();
                    AStarSearchSystem.ReconstructPath(node, aStarNodePath);
                    return aStarNodePath;
                }
                iteration++;
            }
            return null;
        }

        private void EvaluateNodeWithCost(AStarNode item)
        {
            int distance = 0;
            for (int i = 0; i < AStarSearchSystem.Rows; i++)
            {
                for (int j = 0; j < AStarSearchSystem.Columns; j++)
                {
                    int currentNumber = item.State.Board[i, j];
                    int[] positioinOfNumberInTarget = AStarSearchSystem.GetPositionOfNumberInState(currentNumber, AStarSearchSystem.FinalState);
                    distance += Math.Abs(i - positioinOfNumberInTarget[0]) + Math.Abs(j - positioinOfNumberInTarget[1]);
                }
            }
            item.PathEval = distance;
        }
    }
}
