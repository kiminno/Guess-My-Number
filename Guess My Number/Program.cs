using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Guess_My_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
        }

        private static bool IsGuessCorrect(int number)
        {
            int guess = 0;
            bool isInteger = Int32.TryParse(Console.ReadLine(), out guess);

            if (!isInteger || number != guess)
                return false;
            return true;
        }

        private static void PlayGame()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 11);

            int numOfGuessesLeft = 3;

            Console.WriteLine("Please guess a number between 1 and 10. You have 3 chances.");

            bool isGuessCorrect = IsGuessCorrect(number);

            while (!isGuessCorrect)
            {
                numOfGuessesLeft--;
                if (numOfGuessesLeft > 0)
                {
                    Console.WriteLine("Guess again. You have " + numOfGuessesLeft + " chances remaining.");
                    isGuessCorrect = IsGuessCorrect(number);
                }
                else
                {
                    break;
                }
            }

            Console.Write("The number is " + number);

            if (isGuessCorrect)
            {
                Console.WriteLine(". Congratulations!");
            }
            else
            {
                Console.WriteLine(". Better luck next time!");
            }

            Console.WriteLine("Do you want to play again? 'Yes' or 'No'?");
            if (Console.ReadLine() == "Yes")
            {
                PlayGame();
            }
        }
    }
}
