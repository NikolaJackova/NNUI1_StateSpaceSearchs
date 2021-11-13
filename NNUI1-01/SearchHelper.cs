using NNUI1_01.AStarSearch;
using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01
{
    static class SearchHelper
    {
        public static bool ExistsInFringe(Node searchingNode, SimplePriorityQueue<AStarNode> fringe)
        {
            foreach (var node in fringe)
            {
                if (searchingNode.Equals(node))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ExistsInList<T>(Node searchingNode, IList<T> explored) where T:Node
        {
            foreach (var node in explored)
            {
                if (searchingNode.Equals(node))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
