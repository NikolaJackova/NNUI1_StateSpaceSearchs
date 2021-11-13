using System;
using System.Collections.Generic;

namespace NNUI1_01
{
    class SearchSystemController<T> where T : Node
    {
        public readonly int Rows;
        public readonly int Columns;
        public State FinalState { get; set; }
        public Action[] Actions { get; set; }

        public SearchSystemController(State finalState, int rowsAndColumns) : this(finalState, rowsAndColumns, rowsAndColumns)
        { }
        public SearchSystemController(State finalState, int rows, int columns)
        {
            FinalState = finalState;
            Rows = rows;
            Columns = columns;
            Actions = (Action[])Enum.GetValues(typeof(Action));
        }
        public bool IsFinalState(Node node)
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
        public bool IsValidAction(Action action, int[] locationOfZero)
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

        public Node ApplyAction(Action action, Node nodeOrigin, int[] locationOfZero)
        {
            Node node = nodeOrigin.CreateNewNodeFromOrigin(action);
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
        public IList<T> Successor(T node)
        {
            IList<T> nodes = new List<T>();
            for (int i = 0; i < Actions.Length; i++)
            {
                int[] locationOfZero = GetPositionOfNumberInState(0, node.State);
                Action action = Actions[i];
                if (IsValidAction(action, locationOfZero))
                {
                    nodes.Add((T)ApplyAction(action, node, locationOfZero));
                }
            }
            return nodes;
        }

        public int[] GetPositionOfNumberInState(int currentNumber, State state)
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
