using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01.DepthFirstSearch
{
    class DepthFirstSearchNode : Node
    {
        public DepthFirstSearchNode(Action? action, DepthFirstSearchNode parent, State state, int depth) : base(action, parent, state, depth)
        {
        }
        public override Node CreateNewNodeFromOrigin(Action? action)
        {
            return new DepthFirstSearchNode(action, this, DeepCopyState(), Depth + 1);
        }
    }
}
