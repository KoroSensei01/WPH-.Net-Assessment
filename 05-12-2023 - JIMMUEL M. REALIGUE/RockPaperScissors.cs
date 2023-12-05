using System;
using System.Collections.Generic;

namespace RockPaperScissorsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock-Paper-Scissors Game!");
            Console.Write("Please enter your name: ");
            string playerName = Console.ReadLine();

            int playerHealth = 3;
            int computerHealth = 3;
            bool usedPotion = false;
            Random random = new Random();
            Dictionary<char, string> choices = new Dictionary<char, string>
            {
                {'q', "Rock"},
                {'w', "Paper"},
                {'e', "Scissors"},
                {'p', "Potion"}
            };

            while (playerHealth > 0 && computerHealth > 0)
            {
                Console.WriteLine($"\nPlayer Health: {playerHealth}");
                Console.WriteLine($"Computer Health: {computerHealth}");

                if (playerHealth == 1 && !usedPotion && random.Next(2) == 1)
                {
                    Console.WriteLine("You have been saved by a magical potion!");
                    playerHealth++;
                    usedPotion = true;
                    continue;
                }

                Console.Write("\nChoose your action (q for Rock, w for Paper, e for Scissors, p for Potion): ");
                char playerChoice;
                while (!choices.ContainsKey(playerChoice = char.ToLower(Console.ReadKey().KeyChar)))
                {
                    Console.WriteLine("\nInvalid choice. Please choose again.");
                    Console.Write("Choose your action (q for Rock, w for Paper, e for Scissors, p for Potion): ");
                }
                Console.WriteLine();

                if (playerChoice == 'p')
                {
                    if (!usedPotion)
                    {
                        Console.WriteLine("You drink the magical potion and restore 1 health point.");
                        playerHealth++;
                        usedPotion = true;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("You have already used the potion.");
                        continue;
                    }
                }

                char computerChoice = choices.Keys.ElementAt(random.Next(choices.Count));
                Console.WriteLine($"Computer chooses: {choices[computerChoice]}");

                if (playerChoice == computerChoice)
                {
                    Console.WriteLine("It's a tie!");
                }
                else if ((playerChoice == 'q' && computerChoice == 'e') ||
                         (playerChoice == 'w' && computerChoice == 'q') ||
                         (playerChoice == 'e' && computerChoice == 'w'))
                {
                    Console.WriteLine($"{playerName} wins this turn!");
                    computerHealth--;
                }
                else
                {
                    Console.WriteLine("Computer wins this turn!");
                    playerHealth--;
                }
            }

            if (playerHealth == 0)
            {
                Console.WriteLine($"\nSorry, {playerName}! You lost the game.");
            }
            else
            {
                Console.WriteLine($"\nCongratulations, {playerName}! You won the game!");
            }

            Console.ReadKey();
        }
    }
}
