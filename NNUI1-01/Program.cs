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
        static void Main(string[] args)
        {
            AStarNode aStartInit = new AStarNode(null, null, new State(new int[3, 3] { { 7, 2, 4 }, { 5, 0, 6 }, { 8, 3, 1 } }), 0);
            State finalState = new State(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
            AStarSearch.AStarSearch search = new AStarSearch.AStarSearch(aStartInit, finalState);
            search.Search();
            Console.ReadKey();
        }
    }
}
