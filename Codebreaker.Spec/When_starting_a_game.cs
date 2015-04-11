namespace Codebreaker.Spec
{
    using System.IO;

    using Codebreaker.Lib;

    using Machine.Specifications;

    using Moq;

    using It = Machine.Specifications.It;

    [Subject("Game")]
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
        public class With_no_matches
        {
            Because of = () =>
                {
                    Game.Start("1234");
                    Game.Guess("5555");
                };

            It should_send_a_mark_with_empty_string =
                () => MockTw.Verify(t => t.WriteLine(string.Empty));
        }

        [Subject(typeof(Game), "Guessing")]
        public class With_1_number_match
        {
            Because of = () =>
            {
                Game.Start("1234");
                Game.Guess("2555");
            };

            It should_send_a_mark_with_1_dash_char =
                () => MockTw.Verify(t => t.WriteLine("-"));
        }

        [Subject(typeof(Game), "Guessing")]
        public class With_1_exact_match
        {
            Because of = () =>
            {
                Game.Start("1234");
                Game.Guess("1555");
            };

            It should_send_a_mark_with_1_dash_char =
                () => MockTw.Verify(t => t.WriteLine("+"));
        }

        [Subject(typeof(Game), "Guessing")]
        public class With_2_numbers_matching
        {
            Because of = () =>
            {
                Game.Start("1234");
                Game.Guess("2355");
            };

            It should_send_a_mark_with_1_dash_char =
                () => MockTw.Verify(t => t.WriteLine("--"));
        }
    }
}
