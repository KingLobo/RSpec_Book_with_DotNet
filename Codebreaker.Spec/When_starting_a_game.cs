namespace Codebreaker.Spec
{
    using System.IO;

    using Codebreaker.Lib;

    using Machine.Specifications;

    using Moq;

    using It = Machine.Specifications.It;

    [Subject(typeof(Game), "Starting")]
    public class When_starting_a_game
    {
        Establish context = () =>
            {
                MockTw = new Mock<TextWriter>();
                Game = new Game(MockTw.Object);
            };

        private Because of = () => Game.Start("1234");

        It should_send_a_welcome_message = () => MockTw.Verify(t => t.WriteLine("Welcome to Codebreaker!"));

        It should_prompt_for_the_first_guess = () => MockTw.Verify(t => t.WriteLine("Enter guess:"));

        public static Mock<TextWriter> MockTw;

        public static Game Game;
    }
}
