using System;
using System.Collections.Generic;

namespace NNUI1_01.IterativeDeepingSearch
{
    class IterativeDeepingSearchSystem
    {
        public readonly static int Rows = 3;
        public readonly static int Columns = 3;
        public IterativeDeepingNode InitNode { get; set; }
        public int[,] FinalState { get; set; }
        public string[] Actions { get; set; }

        public IterativeDeepingSearchSystem()
        {
            InitSystem();
        }
        private void InitSystem()
        {
            InitNode = new IterativeDeepingNode(1, string.Empty, null, new int[3, 3] { { 7, 2, 4 }, { 5, 0, 6 }, { 8, 3, 1 } }, 0);
            FinalState = new int[3, 3] { { 5, 4, 1 }, { 2, 6, 7 }, { 0, 8, 3} };
            Actions = new string[] { "N", "L", "D", "P" };
        }
        public IList<IterativeDeepingNode> Successor(IterativeDeepingNode node)
        {
            IList<IterativeDeepingNode> nodes = new List<IterativeDeepingNode>();
            for (int i = 0; i < Actions.Length; i++)
            {
                nodes.Add(ApplyAction(Actions[i], node));
            }
            return nodes;
        }
        public bool IsFinalState(IterativeDeepingNode node)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (!(FinalState[i, j] == node.State[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public IterativeDeepingNode ApplyAction(string action, IterativeDeepingNode nodeOrigin)
        {
            switch (action)
            {
                case "N":
                    return MoveUp(nodeOrigin);
                case "P":
                    return MoveRight(nodeOrigin);
                case "D":
                    return MoveDown(nodeOrigin);
                case "L":
                    return MoveLeft(nodeOrigin);
                default:
                    throw new ArgumentException("Not a valid action!");
            }
        }
        private IterativeDeepingNode MoveLeft(IterativeDeepingNode nodeOrigin)
        {
            IterativeDeepingNode node = new IterativeDeepingNode(nodeOrigin);
            SetAttributes(node, nodeOrigin, "L");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (nodeOrigin.State[i, j] == 0 && j > 0)
                    {
                        int temp = node.State[i, j];
                        node.State[i, j] = node.State[i, j - 1];
                        node.State[i, j - 1] = temp;
                    }
                }
            }
            return node;
        }

        private IterativeDeepingNode MoveDown(IterativeDeepingNode nodeOrigin)
        {
            IterativeDeepingNode node = new IterativeDeepingNode(nodeOrigin);
            SetAttributes(node, nodeOrigin, "D");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (nodeOrigin.State[i, j] == 0 && i < nodeOrigin.State.GetLength(0)-1)
                    {
                        int temp = node.State[i, j];
                        node.State[i, j] = node.State[i + 1, j];
                        node.State[i + 1, j] = temp;
                    }
                }
            }
            return node;
        }

        private IterativeDeepingNode MoveRight(IterativeDeepingNode nodeOrigin)
        {
            IterativeDeepingNode node = new IterativeDeepingNode(nodeOrigin);
            SetAttributes(node, nodeOrigin, "P");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (nodeOrigin.State[i, j] == 0 && j < nodeOrigin.State.GetLength(1)-1)
                    {
                        int temp = node.State[i, j];
                        node.State[i, j] = node.State[i, j + 1];
                        node.State[i, j + 1] = temp;
                    }
                }
            }
            return node;
        }

        private IterativeDeepingNode MoveUp(IterativeDeepingNode nodeOrigin)
        {
            IterativeDeepingNode node = new IterativeDeepingNode(nodeOrigin);
            SetAttributes(node, nodeOrigin, "N");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (nodeOrigin.State[i, j] == 0 && i > 0)
                    {
                        int temp = node.State[i, j];
                        node.State[i, j] = node.State[i - 1, j];
                        node.State[i - 1, j] = temp;
                    }
                }
            }
            return node;
        }

        private void SetAttributes(IterativeDeepingNode newNode, IterativeDeepingNode originNode, string action)
        {
            newNode.Action = action;
            newNode.Depth = originNode.Depth + 1;
            newNode.Id = originNode.Id + 1;
            newNode.Parent = originNode;
        }
    }
}
