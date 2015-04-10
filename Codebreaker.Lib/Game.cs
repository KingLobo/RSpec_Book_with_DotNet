namespace Codebreaker.Lib
{
    using System;
    using System.IO;

    public class Game
    {
        private readonly TextWriter textWriter;

        public Game(TextWriter textWriter)
        {
            if (textWriter == null)
            {
                throw new ArgumentNullException("textWriter");
            }

            this.textWriter = textWriter;
        }

        public void Start()
        {
            this.textWriter.WriteLine("Welcome to Codebreaker!");
            this.textWriter.WriteLine("Enter guess:");
        }
    }
}