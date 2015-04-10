namespace Codebreaker.Features.Step_Definitions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;

    using Codebreaker;
    using Codebreaker.Lib;

    using FluentAssertions;

    using Moq;

    using TechTalk.SpecFlow;

    [Binding]
    public class Codebreaker_Steps
    {
        public Mock<TextWriter> MockTw;

        [Given(@"I am not playing yet")]
        public void GivenIAmNotPlayingYet()
        {
        }

        [When(@"I start a new game")]
        public void WhenIStartANewGame()
        {
            this.MockTw = new Mock<TextWriter>();
            new Game(this.MockTw.Object).Start();
        }

        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string message)
        {
            this.MockTw.Verify(tw => tw.WriteLine(message));
        }
    }
}