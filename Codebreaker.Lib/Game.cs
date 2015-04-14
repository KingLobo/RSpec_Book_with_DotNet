namespace Codebreaker.Lib
{
    using System;
    using System.IO;

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
        /// <returns>
        /// This <see cref="Game"/>.
        /// </returns>
        public Game Start(string theSecret)
        {
            this.secret = theSecret;

            this.textWriter.WriteLine("Welcome to Codebreaker!");
            this.textWriter.WriteLine("Enter guess:");

            return this;
        }

        /// <summary>
        /// Submit a guess.
        /// </summary>
        /// <param name="guess">
        /// The guess.
        /// </param>
        public void Guess(string guess)
        {
            var marker = new Marker(this.secret, guess);

            this.textWriter.WriteLine(
                new string('+', marker.ExactMatchCount())
                + new string('-', marker.NumberMatchCount()));
        }
    }
}