using Priority_Queue;
using System;
using System.Collections.Generic;

namespace NNUI1_01.AStarSearch
{
    class AStarSearch
    {
        public AStarSearchSystem AStarSearchSystem { get; set; }
        public SimplePriorityQueue<AStarNode> Fringe { get; set; }
        public IList<AStarNode> Explored { get; set; }

        public AStarSearch(AStarNode initNode, State finalState)
        {
            AStarSearchSystem = new AStarSearchSystem(initNode, finalState, (Action[]) Enum.GetValues(typeof(Action)));
            Fringe = new SimplePriorityQueue<AStarNode>();
            Explored = new List<AStarNode>();
        }

        public void Search()
        {
            int iteration = 0;
            Fringe.Enqueue(AStarSearchSystem.InitNode, AStarSearchSystem.InitNode.PathTotal);
            while (true)
            {
                AStarNode node = Fringe.Dequeue();
                Explored.Add(node);
                IList<AStarNode> children = AStarSearchSystem.Successor(node);
                foreach (var item in children)
                {
                    if (!ExistsInExplored(item) && !ExistsInFringe(item))
                    {
                        EvaluateNodeWithCost(item);
                        Fringe.Enqueue(item, item.PathTotal);
                    }
                }
                if (AStarSearchSystem.IsFinalState(node))
                {
                    EvaluateNodeWithCost(node);
                    Console.WriteLine(node.ToString() + " ");
                    Console.WriteLine("I find solution! " + iteration++);
                    Stack<AStarNode> path = new Stack<AStarNode>();
                    ReconstructPath(node, path);
                    WritePath(path);
                    break;
                }
                iteration++;
                Console.WriteLine(node.ToString());
            }
        }

        private void ReconstructPath(AStarNode node, Stack<AStarNode> path)
        {
            path.Push(node);
            if (node.Parent == null)
            {
                return;
            }
            ReconstructPath(node.Parent, path);
        }

        private void WritePath(Stack<AStarNode> path)
        {
            foreach (var item in path)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Total lenght of path: " + path.Count);
        }

        private void EvaluateNodeWithCost(AStarNode item)
        {
            int distance = 0;
            for (int i = 0; i < AStarSearchSystem.Rows; i++)
            {
                for (int j = 0; j < AStarSearchSystem.Columns; j++)
                {
                    int currentNumber = item.State.Board[i, j];
                    int[] positioinOfNumberInTarget = AStarSearchSystem.GetPositionOfNumberInTarget(currentNumber);
                    distance += Math.Abs(i - positioinOfNumberInTarget[0]) + Math.Abs(j - positioinOfNumberInTarget[1]);
                }
            }
            item.PathEval = distance;
        }

        private bool ExistsInFringe(AStarNode searchingNode)
        {
            foreach (var node in Fringe)
            {
                if (searchingNode.Equals(node))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ExistsInExplored(AStarNode searchingNode)
        {
            foreach (var node in Explored)
            {
                if (searchingNode.Equals(node))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
