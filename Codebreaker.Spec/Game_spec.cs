namespace Codebreaker.Spec
{
    using System.IO;

    using Codebreaker.Lib;

    using Machine.Specifications;

    using Moq;

    using It = Machine.Specifications.It;

    [Subject(typeof(Game))]
    public class Game_spec
    {
        public static Mock<TextWriter> MockTw;

        public static Game Game;

        Establish context = () =>
        {
            MockTw = new Mock<TextWriter>();
            Game = new Game(MockTw.Object);
        };

        [Subject(typeof(Game), "Starting")]
        public class When_starting_a_game
        {
            Because of = () => Game.Start("1234");

            It should_send_a_welcome_message =
                () => MockTw.Verify(t => t.WriteLine("Welcome to Codebreaker!"));

            It should_prompt_for_the_first_guess =
                () => MockTw.Verify(t => t.WriteLine("Enter guess:"));
        }

        [Subject(typeof(Game), "Guessing")]
        public class When_submitting_a_guess
        {
            Because of = () => Game.Start("1234").Guess("1234");

            It should_send_the_mark_to_output =
                () => MockTw.Verify(t => t.WriteLine("++++"));
        }
    }
}
