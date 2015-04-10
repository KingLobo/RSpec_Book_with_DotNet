namespace Codebreaker
{
    using System;

    using Codebreaker.Lib;

    class Program
    {
        static void Main()
        {
            new Game(Console.Out).Start();

            Console.WriteLine(Environment.NewLine + "Press ENTER to Exit...");
            Console.ReadLine();
        }
    }
}
