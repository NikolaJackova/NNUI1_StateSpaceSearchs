namespace NNUI1_01.IterativeDeepingSearch
{
    class IterativeDeepingNode : Node
    {

        public IterativeDeepingNode(Action? action, IterativeDeepingNode parent, State state, int depth) :base(action, parent, state, depth)
        {
        }
        public override Node CreateNewNodeFromOrigin(Action? action)
        {
            return new IterativeDeepingNode(action, this, DeepCopyState(), Depth + 1);
        }
    }
}
