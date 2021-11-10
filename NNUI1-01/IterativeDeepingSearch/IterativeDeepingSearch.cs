using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01.IterativeDeepingSearch
{
    class IterativeDeepingSearch
    {
        public IterativeDeepingSearchSystem System { get; set; }
        public int Limit { get; set; }
        public Stack<IterativeDeepingNode> Fringe { get; set; }
        public IList<IterativeDeepingNode> Path { get; set; }
        public IterativeDeepingSearch()
        {
            System = new IterativeDeepingSearchSystem();
            Fringe = new Stack<IterativeDeepingNode>();
            Path = new List<IterativeDeepingNode>();
            Limit = 0;
        }
        public void Search()
        {
            do
            {
                DoIterative();
            } while (Path.Count != 0);
        }
        public void DoIterative()
        {
            int depth = 0;
            Path.Clear();
            Fringe.Push(System.InitNode);
            while (depth <= Limit)
            {
                IterativeDeepingNode node = Fringe.Pop();
                Path.Add(node);
                IList<IterativeDeepingNode> children = System.Successor(node);
                foreach (var item in children)
                {
                    if (!ExistsInPath(item))
                    {
                        Fringe.Push(item);
                    }
                }
                if (System.IsFinalState(node))
                {
                    Console.WriteLine(node.ToString() + " " + depth);
                    Console.WriteLine("I find solution!");
                    Path.Clear();
                    break;
                }
                depth++;
            }
            Limit++;
        }
        private bool ExistsInPath(IterativeDeepingNode nodeA)
        {
            foreach (var item in Path)
            {
                if (nodeA.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
