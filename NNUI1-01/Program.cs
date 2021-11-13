using System;
using System.Collections.Generic;
using NNUI1_01.AStarSearch;
namespace NNUI1_01
{
    class Program
    {

        public static void WritePath<T>(Stack<T> path) where T : Node
        {
            foreach (var item in path)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("Total lenght of path: " + path.Count);
        }

        private static void DoBreadthFirstSearch()
        {
            Console.WriteLine("BreadthFirstSearch ...");
            BreadthFirstSearch.BreadthFirstSearchNode breadthFirstSearchInit = new BreadthFirstSearch.BreadthFirstSearchNode(null, null, new State(new int[2, 3] { { 4, 0, 3 }, { 5, 2, 1 } }), 0);
            State finalStateBreadth = new State(new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } });
            BreadthFirstSearch.BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch.BreadthFirstSearch(breadthFirstSearchInit, finalStateBreadth, 2, 3);
            Stack<BreadthFirstSearch.BreadthFirstSearchNode> breadthSearchedPath = breadthFirstSearch.Search(out int iteration);
            WritePath(breadthSearchedPath);
            Console.WriteLine("BreadthFirstSearch done, iteration: " + iteration);
        }

        private static void DoAStarSearch()
        {
            Console.WriteLine("A*Search ...");
            AStarNode aStartInit = new AStarNode(null, null, new State(new int[3, 3] { { 7, 2, 4 }, { 5, 0, 6 }, { 8, 3, 1 } }), 0);
            State finalStateAStart = new State(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
            AStarSearch.AStarSearch AStarSearch = new AStarSearch.AStarSearch(aStartInit, finalStateAStart);
            Stack<AStarNode> aStarNodePath = AStarSearch.Search(out int iteration);
            WritePath(aStarNodePath);
            Console.WriteLine("A*Search done, iteration: " + iteration);
        }
        private static void DoDepthSearchSearch()
        {
            Console.WriteLine("DepthFirstSearch ...");
            DepthFirstSearch.DepthFirstSearchNode depthFirstSearchInit = new DepthFirstSearch.DepthFirstSearchNode(null, null, new State(new int[2, 3] { { 4, 0, 3 }, { 5, 2, 1 } }), 0);
            State finalStateDepth = new State(new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } });
            DepthFirstSearch.DepthFirstSearch depthFirstSearched = new DepthFirstSearch.DepthFirstSearch(depthFirstSearchInit, finalStateDepth, 2, 3);
            Stack<DepthFirstSearch.DepthFirstSearchNode> depthSearchedPath = depthFirstSearched.Search(out int iteration);
            WritePath(depthSearchedPath);
            Console.WriteLine("DepthFirstSearch done, iteration: " + iteration);
        }

        private static void DoIterativeDeepingSearch()
        {
            Console.WriteLine("IterativeDeepingSearch ...");
            IterativeDeepingSearch.IterativeDeepingNode iterativeDeepingSearchInit = new IterativeDeepingSearch.IterativeDeepingNode(null, null, new State(new int[2, 3] { { 4, 0, 3 }, { 5, 2, 1 } }), 0);
            State finalStateIterative = new State(new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } });
            IterativeDeepingSearch.IterativeDeepingSearch iterativeDeepingSearched = new IterativeDeepingSearch.IterativeDeepingSearch(iterativeDeepingSearchInit, finalStateIterative, 2, 3);
            Stack<IterativeDeepingSearch.IterativeDeepingNode> iterativeSearchedPath = iterativeDeepingSearched.Search(out int iteration);
            WritePath(iterativeSearchedPath);
            Console.WriteLine("IterativeDeepingSearch done, iteration: " + iteration);
        }
        static void Main(string[] args)
        {
            DoBreadthFirstSearch();
            DoDepthSearchSearch();
            DoIterativeDeepingSearch();
            DoAStarSearch();
            Console.ReadKey(); 

        }
    }
}
