namespace Codebreaker.Lib
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text;

    /// <summary>
    /// The game.
    /// </summary>
    public class Game
    {
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
            StringBuilder markBuffer = new StringBuilder();

            for (var i = 0; i < 4; i++)
            {
                if (this.IsExactMatch(guess, i))
                {
                    markBuffer.Append("+");
                }
            }

            for (var i = 0; i < 4; i++)
            {
                if (this.IsNumberMatch(guess, i))
                {
                    markBuffer.Append("-");
                }
            }
            
            this.textWriter.WriteLine(markBuffer.ToString());
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