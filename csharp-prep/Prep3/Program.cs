using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 100);
            int guess = -1;
            int guessCount = 0; 

            Console.WriteLine("Guess the magic number between 1 and 100!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                
                if (int.TryParse(input, out guess))
                {
                    guessCount++; 

                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine($"You guessed it in {guessCount} attempts!");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();

            
            playAgain = response == "yes";
        }

        Console.WriteLine("Thanks for playing!");
    }
}
