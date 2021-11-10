using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNUI1_01
{
    class State
    {
        public int[,] Board { get; set; }

        public State(int[,] board)
        {
            Board = board;
        }

        public bool Equals(State state)
        {
            bool result = true;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] != state.Board[i, j])
                    {
                        result = false;
                    }
                }
            }
            return result;
        }
    }
}
