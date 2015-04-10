namespace Codebreaker
{
    using System;

    using Codebreaker.Lib;

    class Program
    {
        static void Main()
        {
            new Game(Console.Out).Start("1234");

            Console.WriteLine(Environment.NewLine + "Press ENTER to Exit...");
            Console.ReadLine();
        }
    }
}
