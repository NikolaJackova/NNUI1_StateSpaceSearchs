using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01.AStarSearch
{
    class AStarNode : Node
    {
        public int PathEval { get; set; } //odhad ceny
        public int PathTotal { get { return Depth + PathEval; } }// hloubka + PathEval

        public AStarNode(Action? action, AStarNode parent, State state, int depth) : base(action, parent, state, depth)
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
            return new AStarNode(action, this, state, Depth + 1);
        }
        public override string ToString()
        {
            return base.ToString() + "\nPath Eval: " + PathEval + " Path Total: " + PathTotal + "\n";
        }
    }
}
