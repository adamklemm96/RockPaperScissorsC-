using System;

namespace RockPaperSccissors
{
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            void showHands(Dictionary<int, string> plays)
            {
                Console.WriteLine("Player1 choose your hand");
                foreach (var hand in plays)
                {
                    Console.WriteLine(hand.Key + " : " + hand.Value);
                }
            }

            void gameProgress(int rounds, int player1Score, int player2Score)
            {
                Console.WriteLine("Rock, Paper, Scissors");
                Console.WriteLine("\nSCORE = " + "Player 1 : " + player1Score + " | " + " Player 2 : " + player2Score + "\n");
                Console.WriteLine("Round " + rounds);
                Console.WriteLine("______________________ \n");
            }

            string checkPlayersOption(string player1option, Dictionary<int,string> plays)
            {
                int player1Play = 0;
                bool correctOption = false;

                while (!correctOption)
                {
                    if (int.TryParse(player1option, out player1Play) && plays.ContainsKey(player1Play))
                    {
                        correctOption = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect entry please try again");
                        showHands(plays);
                        player1option = Console.ReadLine();
                    }
                }

                return plays[player1Play];
            }

            string computerPlay(Dictionary<int, string> plays)
            {
                Random rand = new Random();
                return plays.ElementAt(rand.Next(0, plays.Count)).Value;
            }

            string whoWinTheMatch(string player1Play, string player2Play)
            {
                var winningPlays = new Dictionary<string, string>()
                                       {
                                           {"Paper", "Rock" },
                                           {"Rock", "Scissors" },
                                           {"Scissors", "Paper" }
                                       };
                Console.WriteLine("------------------");
                Console.WriteLine("Player 1 : " + player1Play + " Player 2 : " + player2Play);

                string actualValue;

                if (player1Play == player2Play)
                {
                    Console.WriteLine("It's a draw");
                    return "Draw";
                }
                if (winningPlays.TryGetValue(player1Play, out actualValue) && actualValue == player2Play)
                {
                    Console.WriteLine("You won !");
                    return "Player1";
                }

                Console.WriteLine("You loose");

                return "Computer";
            }

            bool endGame()
            {
                Console.WriteLine("__________");
                Console.WriteLine("To quit game pres 'Q' to continue press any other key");

                if (Console.ReadLine()?.ToUpper() == "Q")
                {
                    return false;
                }

                return true;
            }

            // initialize variables

            var plays = new Dictionary<int, string>()
                            {
                                {1, "Rock" },
                                {2, "Paper"},
                                {3, "Scissors"}
                            };

            string player1Play;
            string player2Play;
            int player1Score = 0;
            int player2Score = 0;
            int rounds = 0;
            bool gameon = true;

            while (gameon)
            {
                rounds++;
                gameProgress(rounds, player1Score, player2Score);
                showHands(plays);
                player1Play = checkPlayersOption(Console.ReadLine(), plays);
                player2Play = computerPlay(plays);
                
                string winner = whoWinTheMatch(player1Play, player2Play);
                if (winner == "Player1")
                {
                    player1Score++;
                }
                else if (winner == "Computer")
                {
                    player2Score++;
                }

                gameon = endGame();
                Console.Clear();
            }
        }
    }
}
