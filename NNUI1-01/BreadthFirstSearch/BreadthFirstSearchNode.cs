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
            return new BreadthFirstSearchNode(action, this, DeepCopyState(), Depth + 1);
        }
    }
}
