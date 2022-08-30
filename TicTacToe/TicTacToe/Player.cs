using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        //memeber variable
        private string playerName;
        private string winCounter;
        private string playerSymbol;
        private int roundNumber;

        //constructor
        public Player(string playerName, string playerSymbol)
        {
            this.playerName = playerName;
            this.playerSymbol = playerSymbol;
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
        }

        public int RoundNumber { get; set; }



        public string PlayerSymbol
        {
            get
            {
                return this.playerSymbol;
            }
        }

        public bool WinChecker(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2]) return true;
                if (board[0, i] == board[1, i] && board[1, i] == board[1, i]) return true;
            }
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) return true;

            return false;
        }
    }
}
