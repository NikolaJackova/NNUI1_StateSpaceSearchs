using System;
using System.Collections.Generic;
using NNUI1_01.AStarSearch;
using NNUI1_01.IterativeDeepingSearch;
namespace NNUI1_01
{
    /*
    1. odeber poslední stav z fronty stavů k procházení
    2. zjisti následníky tohoto stavu
    3. přidej stav do pole stavového prostoru
    4. pro každého následníka zjisti zda už není ve stavovém prostoru
    5. pokud není přidej následníka do fronty k procházení
    6. prováděj dokud fronta k procházení není prázdná
     */
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

        public static void DoBreadthFirstSearch()
        {
            Console.WriteLine("BreadthFirstSearch ...");
            BreadthFirstSearch.BreadthFirstSearchNode breadthFirstSearchInit = new BreadthFirstSearch.BreadthFirstSearchNode(null, null, new State(new int[2, 3] { { 4, 0, 3 }, { 5, 2, 1 } }), 0);
            State finalStateBreadth = new State(new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } });
            BreadthFirstSearch.BreadthFirstSearch breadthFirstSearch = new BreadthFirstSearch.BreadthFirstSearch(breadthFirstSearchInit, finalStateBreadth, 2, 3);
            Stack<BreadthFirstSearch.BreadthFirstSearchNode> breadthSearchedPath = breadthFirstSearch.Search();
            WritePath(breadthSearchedPath);
            Console.WriteLine("BreadthFirstSearch done");
        }

        public static void DoAStarSearch()
        {
            Console.WriteLine("A*Search ...");
            AStarNode aStartInit = new AStarNode(null, null, new State(new int[3, 3] { { 7, 2, 4 }, { 5, 0, 6 }, { 8, 3, 1 } }), 0);
            State finalStateAStart = new State(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
            AStarSearch.AStarSearch AStarSearch = new AStarSearch.AStarSearch(aStartInit, finalStateAStart);
            Stack<AStarNode> aStarNodePath = AStarSearch.Search();
            WritePath(aStarNodePath);
            Console.WriteLine("A*Search done");
        }
        static void Main(string[] args)
        {
            DoBreadthFirstSearch();

            Console.WriteLine("IterativeDeepingSearch ...");
            Console.WriteLine("IterativeDeepingSearch done");
            DoAStarSearch();
            Console.ReadKey(); 

        }
    }
}
