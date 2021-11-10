namespace NNUI1_01.IterativeDeepingSearch
{
    class IterativeDeepingNode
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public IterativeDeepingNode Parent { get; set; }
        public int[,] State { get; set; }
        public int Depth { get; set; }

        public IterativeDeepingNode(int id, string action, IterativeDeepingNode parent, int[,] state, int depth)
        {
            Id = id;
            Action = action;
            Parent = parent;
            State = state;
            Depth = depth;
        }

        public IterativeDeepingNode(IterativeDeepingNode node)
        {
            State = new int[IterativeDeepingSearchSystem.Rows, IterativeDeepingSearchSystem.Columns];
            for (int i = 0; i < IterativeDeepingSearchSystem.Rows; i++)
            {
                for (int j = 0; j < IterativeDeepingSearchSystem.Columns; j++)
                {
                    State[i, j] = node.State[i, j];
                }
            }
        }

        public override string ToString()
        {
            string node = "-------------- -\n";
            for (int i = 0; i < IterativeDeepingSearchSystem.Rows; i++)
            {
                for (int j = 0; j < IterativeDeepingSearchSystem.Columns; j++)
                {
                    node += State[i, j].ToString() + " ";
                }
                node += "\n";
            }
            return node;
        }

        public bool Equals(IterativeDeepingNode obj)
        {
            bool result = true;
            for (int i = 0; i < IterativeDeepingSearchSystem.Rows; i++)
            {
                for (int j = 0; j < IterativeDeepingSearchSystem.Columns; j++)
                {
                    if (State[i, j] != obj.State[i, j])
                    {
                        result = false;
                    }
                }
            }
            return result;
        }
    }
}
