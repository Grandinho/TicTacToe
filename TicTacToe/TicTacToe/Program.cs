using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            InitGame();
            Console.ReadLine();
        }

        static void InitGame()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("---Welcome to the Tic-Tac-Toe game---");
            Console.WriteLine("-------------------------------------");

            Console.Write("\nEnter name of the first Player: ");
            string playerOneName = Console.ReadLine();
            Console.Write("\nEnter name of the second Player: ");
            string playerTwoName = Console.ReadLine();
            Console.Clear();

            StartGame(playerOneName, playerTwoName);
        }

        static void StartGame(string playerOneName, string playerTwoName)
        {
            Player[] players = new Player[2];
            players[0] = new Player(playerOneName, "O");
            players[1] = new Player(playerTwoName, "X");
            int roundSwitch = 0;
            string playerInput;
            int row = 0;
            int column = 0;
            bool isInputValid;

            //TODO move board to class
            string[,] board = {
            {"1","2","3"},
            {"4","5","6" },
            {"7","8","9" }
            };
            while (true == true)
            {
                //Update board
                Console.Clear();
                CreateBoard(board);


                if (roundSwitch == 2) roundSwitch = 0;


                do
                {
                    Console.Write("{0} Enter field: ", players[roundSwitch].PlayerName);
                    playerInput = Console.ReadLine();
                    isInputValid = GetIndexOfInput(board, playerInput, ref row, ref column);

                    if (!isInputValid)
                    {
                        Console.Clear();
                        CreateBoard(board);
                    }
                } while (isInputValid == false);

                //Change board with X or O
                board[row, column] = players[roundSwitch].PlayerSymbol;

                players[roundSwitch].RoundNumber++;
                if (players[roundSwitch].RoundNumber >= 3)
                    if (players[roundSwitch].WinChecker(board))
                    {
                        Console.Clear();
                        CreateBoard(board);
                        Console.WriteLine("Player {0} has won, congratulations", players[roundSwitch].PlayerName);
                        RestartGame(ref players, ref board);
                    }


                if (players[roundSwitch].RoundNumber >= 5)
                {
                    Console.Clear();
                    CreateBoard(board);
                    Console.WriteLine("It looks that there is no winner. Its draw!");
                    RestartGame(ref players, ref board);
                }

                roundSwitch++;
            }
        }

        static void CreateBoard(string[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("  ");
                    Console.Write(board[i, j]);
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("");
        }

        static bool GetIndexOfInput(string[,] board, string playerInput, ref int row, ref int column)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j].Contains(playerInput))
                    {
                        row = i;
                        column = j;
                        return true;
                    }
                }     
            }
            return false;
        }

        static void RestartGame(ref Player[] player, ref string[,] board)
        {
            player[0].ResetGame();
            player[1].ResetGame();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Actual leaderboard:");
            Console.WriteLine("Player {0} has won: {1} time/s ", player[0].PlayerName, player[0].WinCounter);
            Console.WriteLine("Player {0} has won: {1} time/s ", player[1].PlayerName, player[1].WinCounter);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("If you want to play again press any key!");
            Console.ReadLine();
            int counter = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    counter++;
                    board[i, j] = counter.ToString();
                }
            }

        }


    }
}
