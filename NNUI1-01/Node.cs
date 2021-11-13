using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01
{
    abstract class Node
    {
        private static int id = 1;
        public int Id { get; set; }
        public Action? Action { get; set; }
        public Node Parent { get; set; }
        public State State { get; set; }
        public int Depth { get; set; }

        public Node(Action? action, Node parent, State state, int depth)
        {
            Id = id++;
            Action = action;
            Parent = parent;
            State = state;
            Depth = depth;
        }
        public abstract Node CreateNewNodeFromOrigin(Action? action);
        public State DeepCopyState()
        {
            State state = new State(new int[State.Board.GetLength(0), State.Board.GetLength(1)]);
            for (int i = 0; i < State.Board.GetLength(0); i++)
            {
                for (int j = 0; j < State.Board.GetLength(1); j++)
                {
                    state.Board[i, j] = State.Board[i, j];
                }
            }
            return state;
        }
        public bool Equals(Node node)
        {
            return State.Equals(node.State);
        }

        public override string ToString()
        {
            string node = "-------------- -\n";
            node += "[" + Id + " " + Action.ToString() + " " + Depth + " ]\n";
            for (int i = 0; i < State.Board.GetLength(0); i++)
            {
                node += "[";
                for (int j = 0; j < State.Board.GetLength(1); j++)
                {
                    node += State.Board[i, j].ToString() + " ";
                }
                node += "]\n";
            }
            return node;
        }
    }
}
