namespace Codebreaker.Features.Step_Definitions
{
    using System.IO;

    using Codebreaker.Lib;

    using Moq;

    using TechTalk.SpecFlow;

    [Binding]
    public class Codebreaker_steps
    {
        public Mock<TextWriter> MockTw;

        private Game game;

        [Given(@"I am not playing yet")]
        public void GivenIAmNotPlayingYet()
        {
        }

        [When(@"I start a new game")]
        public void WhenIStartANewGame()
        {
            this.MockTw = new Mock<TextWriter>();
            new Game(this.MockTw.Object).Start("1234");
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string message)
        {
            this.MockTw.Verify(tw => tw.WriteLine(message));
        }

        #region ---- Guessing ----

        [Given(@"the secret code is ""(.*)""")]
        public void GivenTheSecretCodeIs(string secret)
        {
            this.MockTw = new Mock<TextWriter>();
            this.game = new Game(this.MockTw.Object);
            this.game.Start(secret);
        }

        [When(@"I guess ""(.*)""")]
        public void WhenIGuess(string guess)
        {
            this.game.Guess(guess);
        }

        [Then(@"the mark should be ""(.*)""")]
        public void ThenTheMarkShouldBe(string mark)
        {
            this.MockTw.Verify(tw => tw.WriteLine(mark));
        }

        #endregion
    }
}