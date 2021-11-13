using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01.BreadthFirstSearch
{
    class BreadthFirstSearchNode : Node
    {
        public BreadthFirstSearchNode(Action? action, BreadthFirstSearchNode parent, State state, int depth) : base(action, parent, state, depth)
        {
        }
        public override Node CreateNewNodeFromOrigin(Action? action)
        {
            State state = new State(new int[State.Board.GetLength(0), State.Board.GetLength(1)]);
            for (int i = 0; i < State.Board.GetLength(0); i++)
            {
                for (int j = 0; j < State.Board.GetLength(1); j++)
                {
                    state.Board[i, j] = State.Board[i, j];
                }
            }
            return new BreadthFirstSearchNode(action, this, state, Depth + 1);
        }
    }
}
