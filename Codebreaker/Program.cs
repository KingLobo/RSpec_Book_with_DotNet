namespace Codebreaker
{
    using System;
    using System.Runtime.InteropServices;

    using Codebreaker.Lib;

    class Program
    {
        static void Main()
        {
            var game = new Game(Console.Out).Start("1234");

            var done = false;
            while (!done)
            {
                var readLine = Console.ReadLine();
                if (string.IsNullOrEmpty(readLine))
                {
                    done = true;
                    continue;
                }

                var guess = readLine.Trim();
                if (guess.Length > 4)
                {
                    guess = guess.Substring(0, 4);
                }

                game.Guess(guess);
                Console.WriteLine();
            }
        }
    }
}
