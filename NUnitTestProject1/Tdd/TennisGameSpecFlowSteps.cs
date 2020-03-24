using NUnit.Framework;
using ProdCode.Tdd;
using System;
using TechTalk.SpecFlow;

namespace NUnitTests.Tdd
{
    [Binding]
    public class TennisGameSpecFlowSteps
    {
        private TennisGame tennisGame;

        [Given(@"an empty tennis game")]
        public void GivenAnEmptyTennisGame()
        {
            tennisGame = new TennisGame();
        }
        
        [Then(@"the score is ""(.*)""")]
        public void ThenTheScoreIs(string expectedScore)
        {
            Assert.AreEqual(expectedScore, tennisGame.Score());
        }

        [When(@"player(.*) scores (.*) point")]
        public void WhenPlayerScoresPoint(int playerNumber, int points)
        {
            for (int i = 0; i< points; i++)
            {
                tennisGame.PlayerScores(playerNumber);
            }
        }

    }
}
