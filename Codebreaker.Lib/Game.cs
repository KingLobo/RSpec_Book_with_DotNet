namespace Codebreaker.Lib
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// The game.
    /// </summary>
    public class Game
    {
        private static readonly IEnumerable<int> SecretRange = Enumerable.Range(0, 4);

        private readonly TextWriter textWriter;
        
        private string secret;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="textWriter">
        /// The text writer.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        public Game(TextWriter textWriter)
        {
            if (textWriter == null)
            {
                throw new ArgumentNullException("textWriter");
            }

            this.textWriter = textWriter;
        }

        /// <summary>
        /// The start.
        /// </summary>
        /// <param name="theSecret">
        /// The Secret.
        /// </param>
        public void Start(string theSecret)
        {
            this.secret = theSecret;

            this.textWriter.WriteLine("Welcome to Codebreaker!");
            this.textWriter.WriteLine("Enter guess:");
        }

        /// <summary>
        /// Submit a guess.
        /// </summary>
        /// <param name="guess">
        /// The guess.
        /// </param>
        public void Guess(string guess)
        {
            this.textWriter.WriteLine(
                new string('+', this.ExactMatchCount(guess))
                + new string('-', this.NumberMatchCount(guess)));
        }

        private int NumberMatchCount(string guess)
        {
            return SecretRange.Count(i => this.IsNumberMatch(guess, i));
        }

        private int ExactMatchCount(string guess)
        {
            return SecretRange.Count(i => this.IsExactMatch(guess, i));
        }

        private bool IsNumberMatch(string guess, int index)
        {
            return this.secret.Contains(guess[index].ToString(CultureInfo.InvariantCulture))
                 && !this.IsExactMatch(guess, index);
        }

        private bool IsExactMatch(string guess, int index)
        {
            return guess[index].Equals(this.secret[index]);
        }
    }
}