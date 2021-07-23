using System;
using System.Collections.Generic;
using System.Linq;

namespace PrizeGame
{
    public class GameEngine
    {
        static Dictionary<Player, char> playerLetters = new Dictionary<Player, char>();
        public static char GetPlayerLetter(Player player)
        {
            return playerLetters[player];
        }
        
        static void Main(string[] args)
        {
            //Console.SetBufferSize(80, Int16.MaxValue - 1);
            int cols = 10; //  Integer.parseInt(args[0]);
            int rows = 10; //  Integer.parseInt(args[1]);
            int maxRounds = 100;
            Board board = new Board(cols, rows);
            // Player playerA = new MinDistancePlayer();
            // playerLetters[playerA] = 'A';
            // Player playerB = new MyPlayer();
            // playerLetters[playerB] = 'B';
            // Player playerC = new MinDistancePlayer();
            // playerLetters[playerC] = 'C';
            // Player playerD = new HighestPrizePlayer();
            // playerLetters[playerD] = 'D';
            // board.PositionPlayers(playerA, playerB, playerC, playerD);
            // board.PlacePrizesRandomly(0.1, 1, 9);
            
            Console.Out.WriteLine("\nBeginning of the game, nobody has any points: ");
            PrintScore(board);
            Console.Out.WriteLine(BoardToString(board));
            
            int numTurns = 0;
            while (!board.GameOver())
            {
                Player currentPlayer = board.GetCurrentPlayer();
                int score = currentPlayer.Score;
                currentPlayer.Move(board);
                board.AdvanceTurn();
                ++numTurns;
                Console.Out.WriteLine(BoardToString(board));
                if (score != currentPlayer.Score && board.GetPrizes().Any())
                { // they got points
                    //Console.Out.WriteLine("Round " + ((numTurns / 4) + 1) + ": ");
                    int pointsGot = currentPlayer.Score - score;
                    Console.Out.WriteLine($"Player {playerLetters[currentPlayer]} got {pointsGot} point{(pointsGot > 1 ? "s" : "")}");
                    Console.Out.WriteLine("Points so far: ");
                    PrintScore(board);
                }
                if (numTurns % 4 == 0 && numTurns / 4 >= maxRounds)
                {
                    Console.Out.WriteLine("Completed maximum number of rounds");
                    break;
                }
            }
            
            Console.Out.WriteLine("All the prizes are gone. The game is over.");
            Console.Out.WriteLine("Final points:");
            PrintScore(board);

            Console.In.ReadLine();
        }

        private static int ComparePlayers(Player a1, Player a2)
        {
            return a2.Score - a1.Score;
        }
        private static void PrintScore(Board board)
        {
            List<Player> players = new List<Player>(board.GetPlayers());
            players.Sort(ComparePlayers);

            foreach (Player player in players)
            {
                char c = playerLetters[player];
                bool padSpace = player.Score < 10;
                Console.Out.WriteLine(c + ": " + (padSpace ? " " : "") + player.Score + " points (" + player + ")");
            }
            Console.Out.WriteLine("");
        }


        static string BoardToString(Board board)
        {
            string sb = "";
            for (int i = -1; i <= board.GetMaxX() + 1; ++i)
            {
                sb += '*';
            }
            sb += '\n';
            for (int i = board.GetMaxY(); i >= 0; --i)
            {
                sb += '*';
                for (int j = 0; j <= board.GetMaxX(); ++j)
                {
                    BoardObject boardObject;
                    boardObject = board.GetBoardObject(j, i);
                    if (boardObject is EmptySpace)
                    {
                        sb += ' ';
                    }
                    else if (boardObject is Prize)
                    {
                        sb += ((Prize)boardObject).Points;
                    }
                    else if (boardObject is Player)
                    {
                        sb += playerLetters[(Player)boardObject];
                    }
                    else
                    {  // shouldn't matter
                        sb += 'X';
                    }
                }
                sb += '*';
                sb += '\n';
            }
            for (int i = -1; i <= board.GetMaxX() + 1; ++i)
            {
                sb += '*';
            }
            sb += '\n';
            return sb;
        }
    }
}