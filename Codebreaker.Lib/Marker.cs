namespace Codebreaker.Lib
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// The marker.
    /// </summary>
    public class Marker
    {
        private readonly string secret;

        private readonly string guess;

        private readonly IEnumerable<int> secretRange;

        /// <summary>
        /// Initializes a new instance of the <see cref="Marker"/> class.
        /// </summary>
        /// <param name="secret">
        /// The secret.
        /// </param>
        /// <param name="guess">
        /// The guess.
        /// </param>
        public Marker(string secret, string guess)
        {
            this.secret = secret;
            this.guess = guess;
            this.secretRange = Enumerable.Range(0, this.secret.Length);
        }

        /// <summary>
        /// The number match count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int NumberMatchCount()
        {
            return this.secretRange.Count(this.IsNumberMatch);
        }

        /// <summary>
        /// The exact match count.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int ExactMatchCount()
        {
            return this.secretRange.Count(this.IsExactMatch);
        }

        private bool IsNumberMatch(int index)
        {
            return this.secret.Contains(this.guess[index].ToString(CultureInfo.InvariantCulture))
                   && !this.IsExactMatch(index);
        }

        private bool IsExactMatch(int index)
        {
            return this.guess[index].Equals(this.secret[index]);
        }
    }
}