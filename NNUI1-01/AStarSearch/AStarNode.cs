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
            return new AStarNode(action, this, DeepCopyState(), Depth + 1);
        }
        public override string ToString()
        {
            return base.ToString() + "\nPath Eval: " + PathEval + " Path Total: " + PathTotal + "\n";
        }
    }
}
