using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain;
        do
        {
            Random randomGenerator = new Random();
            bool guessed = false;

            int magicNumber = randomGenerator.Next(1, 100);
            do
            {
                Console.Write("Guess the magic number between 1 and 100: ");
                string guessInput = Console.ReadLine();

                if (!int.TryParse(guessInput, out int guess))
                {
                    Console.WriteLine($"{guessInput} is not a whole number!");
                }
                if (guess < magicNumber)
                    Console.WriteLine("Higher");
                else if (guess > magicNumber)
                    Console.WriteLine("Lower");
                else
                {
                    Console.WriteLine($"Yes! {guess} is the magic number!");
                    guessed = true;
                }
            } while (!guessed);
            Console.Write("Play again? (Y/n) ");
            string playAgainInput = Console.ReadLine();
            if (playAgainInput.ToLower().Equals("n"))
                playAgain = false;
            else
                playAgain = true;

        } while (playAgain);
    }
}