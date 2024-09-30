using System;
using System.Collections.Generic;

class DiceGame
{
    static void Main(string[] args)
    {
        Random random = new Random();

        string playAgain;
        do
        {
            int playerScore = 0;
            int computerScore = 0;

            // Create lists to store the roll history
            List<int> playerRollHistory = new List<int>();
            List<int> computerRollHistory = new List<int>();

            // Allow the user to choose the number of rounds
            Console.WriteLine("Welcome to the Dice Game!");
            Console.Write("How many rounds would you like to play? ");
            string roundsInput = Console.ReadLine() ?? string.Empty;  // Handle potential null input
            int rounds;

            // Handle invalid or null input
            while (!int.TryParse(roundsInput, out rounds) || rounds <= 0)
            {
                Console.WriteLine("Invalid input! Please enter a positive number for rounds:");
                roundsInput = Console.ReadLine() ?? string.Empty;  // Handle potential null input
            }

            Console.WriteLine($"\nYou will play {rounds} rounds against the computer.\n");

            for (int round = 1; round <= rounds; round++)
            {
                Console.WriteLine($"--- Round {round} ---");

                // Player's turn
                Console.WriteLine("Press any key to roll the dice...");
                Console.ReadKey();
                int playerRoll = random.Next(1, 7);
                Console.WriteLine($"You rolled a {playerRoll}!");

                // Store player's roll in history
                playerRollHistory.Add(playerRoll);

                // Computer's turn
                int computerRoll = random.Next(1, 7);
                Console.WriteLine($"The computer rolled a {computerRoll}!\n");

                // Store computer's roll in history
                computerRollHistory.Add(computerRoll);

                // Determine the winner of the round
                if (playerRoll > computerRoll)
                {
                    playerScore++;
                    Console.WriteLine("You win this round!");
                }
                else if (computerRoll > playerRoll)
                {
                    computerScore++;
                    Console.WriteLine("The computer wins this round!");
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }

                Console.WriteLine($"Current score -> You: {playerScore} | Computer: {computerScore}\n");
            }

            // Final result
            Console.WriteLine("--- Final Score ---");
            Console.WriteLine($"You: {playerScore} | Computer: {computerScore}");

            if (playerScore > computerScore)
            {
                Console.WriteLine("Congratulations! You won the game!");
            }
            else if (computerScore > playerScore)
            {
                Console.WriteLine("The computer wins the game! Better luck next time.");
            }
            else
            {
                Console.WriteLine("It's a tie! What a close game!");
            }

            // Display roll history
            Console.WriteLine("\n--- Roll History ---");
            Console.WriteLine("Round\tPlayer Roll\tComputer Roll");
            for (int i = 0; i < playerRollHistory.Count; i++)
            {
                Console.WriteLine($"{i + 1}\t{playerRollHistory[i]}\t\t{computerRollHistory[i]}");
            }

            // Ask if the player wants to play again
            Console.Write("\nDo you want to play again? (yes/no): ");
            playAgain = Console.ReadLine()?.ToLower() ?? "no";  // Handle potential null input

            // Handle invalid input
            while (string.IsNullOrEmpty(playAgain) || (playAgain != "yes" && playAgain != "no"))
            {
                Console.Write("Invalid input! Please enter 'yes' or 'no': ");
                playAgain = Console.ReadLine()?.ToLower() ?? "no";  // Handle potential null input
            }

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing!");
    }
}
