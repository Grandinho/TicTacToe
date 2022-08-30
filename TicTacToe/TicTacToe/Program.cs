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
            //TODO store players in array
            Player playerOne = new Player(playerOneName, "O");
            Player playerTwo = new Player(playerTwoName, "X");
            string symbolInput;
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
            int counter = 0;
            while (true == true)
            {
                counter++;
                CreateBoard(board);

                //Playerone turn
                if (counter % 2 == 1)
                {
                    do
                    {
                        Console.Write("{0} Enter field: ", playerOne.PlayerName);
                        playerInput = Console.ReadLine();
                        symbolInput = playerOne.PlayerSymbol;
                        isInputValid = GetIndexOfInput(board, playerInput, ref row, ref column);

                        if (!isInputValid)
                        {
                            Console.Clear();
                            CreateBoard(board);
                        }
                    } while (isInputValid == false);

                    board[row, column] = symbolInput;
                    playerOne.RoundNumber++;
                    if (playerOne.RoundNumber >= 3)
                        if (playerOne.WinChecker(board))
                        {
                            Console.Clear();
                            CreateBoard(board);
                            Console.WriteLine("{0} has won", playerOne.PlayerName);
                            Console.ReadLine();
                        }

                }
                //Playertwo turn
                else
                {
                    do
                    {
                        Console.Write("{0} Enter field: ", playerTwo.PlayerName);
                        playerInput = Console.ReadLine();
                        symbolInput = playerTwo.PlayerSymbol;
                        isInputValid = GetIndexOfInput(board, playerInput, ref row, ref column);

                        if (!isInputValid)
                        {
                            Console.Clear();
                            CreateBoard(board);
                        }
                    } while (isInputValid == false);

                    board[row, column] = symbolInput;
                    playerTwo.RoundNumber++;
                    if (playerTwo.RoundNumber >= 3)
                        if (playerTwo.WinChecker(board))
                        {
                            Console.Clear();
                            CreateBoard(board);
                            Console.WriteLine("{0} has won", playerTwo.PlayerName);
                            Console.ReadLine();
                        }
                }
                    Console.Clear();
                
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


    }
}
