using Priority_Queue;
using System;
using System.Collections.Generic;

namespace NNUI1_01.AStarSearch
{
    class AStarSearch
    {
        public SearchSystemController<AStarNode> AStarSearchSystem { get; set; }
        public SimplePriorityQueue<AStarNode> Fringe { get; set; }
        public AStarNode InitNode { get; set; }
        public IList<AStarNode> Explored { get; set; }

        public AStarSearch(AStarNode initNode, State finalState)
        {
            AStarSearchSystem = new SearchSystemController<AStarNode>(finalState, 3);
            InitNode = initNode;
            Fringe = new SimplePriorityQueue<AStarNode>();
            Explored = new List<AStarNode>();
        }

        public void Search()
        {
            int iteration = 0;
            Fringe.Enqueue(InitNode, InitNode.PathTotal);
            while (true)
            {
                AStarNode node = Fringe.Dequeue();
                Explored.Add(node);
                IList<AStarNode> children = AStarSearchSystem.Successor(node);
                foreach (var item in children)
                {
                    if (!SearchHelper.ExistsInList(item, Explored) && !SearchHelper.ExistsInFringe(item, Fringe))
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

        private void ReconstructPath(Node node, Stack<AStarNode> path)
        {
            path.Push((AStarNode)node);
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
                    int[] positioinOfNumberInTarget = AStarSearchSystem.GetPositionOfNumberInState(currentNumber, AStarSearchSystem.FinalState);
                    distance += Math.Abs(i - positioinOfNumberInTarget[0]) + Math.Abs(j - positioinOfNumberInTarget[1]);
                }
            }
            item.PathEval = distance;
        }
    }
}
