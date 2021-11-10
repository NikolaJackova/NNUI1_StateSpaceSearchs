using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01.AStarSearch
{
    class AStarSearchSystem
    {
        public readonly static int Rows = 3;
        public readonly static int Columns = 3;
        public AStarNode InitNode { get; set; }
        public State FinalState { get; set; }
        public Action[] Actions { get; set; }

        public AStarSearchSystem(AStarNode initNode, State finalState, Action[] actions)
        {
            InitNode = initNode;
            FinalState = finalState;
            Actions = actions;
        }

        public bool IsFinalState(AStarNode node)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (!(FinalState.Board[i, j] == node.State.Board[i, j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public IList<AStarNode> Successor(AStarNode node)
        {
            IList<AStarNode> nodes = new List<AStarNode>();
            for (int i = 0; i < Actions.Length; i++)
            {
                int[] locationOfZero = GetPositionOfNumberInState(0, node.State);
                Action action = Actions[i];
                if (IsValidAction(action, locationOfZero))
                {
                    nodes.Add(ApplyAction(action, node, locationOfZero));
                }
            }
            return nodes;
        }

        private bool IsValidAction(Action action, int[] locationOfZero)
        {
            bool isValid = true;
            switch (action)
            {
                case Action.UP:
                    if (locationOfZero[0] == 0)
                    {
                        isValid = false;
                    }
                    break;
                case Action.DOWN:
                    if (locationOfZero[0] == Rows - 1)
                    {
                        isValid = false;
                    }
                    break;
                case Action.LEFT:
                    if (locationOfZero[1] == 0)
                    {
                        isValid = false;
                    }
                    break;
                case Action.RIGHT:
                    if (locationOfZero[1] == Columns - 1)
                    {
                        isValid = false;
                    }
                    break;
            }
            return isValid;
        }

        private AStarNode ApplyAction(Action action, AStarNode nodeOrigin, int[] locationOfZero)
        {
            AStarNode node = new AStarNode(nodeOrigin, action);
            int x = locationOfZero[0];
            int y = locationOfZero[1];
            int temp = node.State.Board[x, y];
            switch (action)
            {
                case Action.UP:
                    node.State.Board[x, y] = node.State.Board[x - 1, y];
                    node.State.Board[x - 1, y] = temp;
                    break;
                case Action.RIGHT:
                    node.State.Board[x, y] = node.State.Board[x, y + 1];
                    node.State.Board[x, y + 1] = temp;
                    break;
                case Action.DOWN:
                    node.State.Board[x, y] = node.State.Board[x + 1, y];
                    node.State.Board[x + 1, y] = temp;
                    break;
                case Action.LEFT:
                    node.State.Board[x, y] = node.State.Board[x, y - 1];
                    node.State.Board[x, y - 1] = temp;
                    break;
                default:
                    throw new ArgumentException("Not a valid action!");
            }
            return node;
        }
        public int[] GetPositionOfNumberInTarget(int currentNumber)
        {
            return GetPositionOfNumberInState(currentNumber, FinalState);
        }
        private int[] GetPositionOfNumberInState(int currentNumber, State state)
        {
            int[] position = new int[2];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (currentNumber == state.Board[i, j])
                    {
                        position[0] = i;
                        position[1] = j;
                    }
                }
            }
            return position;
        }
    }
}
