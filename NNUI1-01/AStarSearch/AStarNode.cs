using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01.AStarSearch
{
    class AStarNode
    {
        private static int id = 1;
        public int Id { get; set; }
        public Action? Action { get; set; }
        public AStarNode Parent { get; set; }
        public State State { get; set; }
        public int Depth { get; set; }
        public int PathEval { get; set; } //odhad ceny
        public int PathTotal { get { return Depth + PathEval; } }// hloubka + PathEval

        public AStarNode(Action? action, AStarNode parent, State state, int depth, int pathEval)
        {
            Id = id++;
            Action = action;
            Parent = parent;
            State = state;
            Depth = depth;
            PathEval = pathEval;
        }

        public AStarNode(AStarNode node, Action? action)
        {
            State = new State(new int[AStarSearchSystem.Rows, AStarSearchSystem.Columns]);
            for (int i = 0; i < AStarSearchSystem.Rows; i++)
            {
                for (int j = 0; j < AStarSearchSystem.Columns; j++)
                {
                    State.Board[i, j] = node.State.Board[i, j];
                }
            }
            Parent = node;
            Action = action;
            Depth = node.Depth + 1;
            Id = id++;
        }

        public bool Equals(AStarNode obj)
        {
            return State.Equals(obj.State);
        }

        public override string ToString()
        {
            string node = "-------------- -\n";
            node += "[" + Id + " " + Action.ToString() + " " + Depth + " " + PathEval + " " + PathTotal + " ]\n";
            for (int i = 0; i < AStarSearchSystem.Rows; i++)
            {
                node += "[";
                for (int j = 0; j < AStarSearchSystem.Columns; j++)
                {
                    node += State.Board[i, j].ToString() + " ";
                }
                node += "]\n";
            }
            return node;
        }
    }
}
