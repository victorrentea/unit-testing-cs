using NUnit.Framework;
using ProdCode.Tdd;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTests.Tdd
{
    class TennisGameTest
    {

        private string GetScoreString(int player1Points, int player2Points)
        {
            var tennisGame = new TennisGame();
            AddPointsToPlayer(tennisGame, player1Points, 1);
            AddPointsToPlayer(tennisGame, player2Points, 2);
            return tennisGame.Score();
        }

        private void AddPointsToPlayer(TennisGame tennisGame, int pointsNumber, int playerNo)
        {
            for (int i = 0; i < pointsNumber; i++)
            {
                tennisGame.PlayerScores(playerNo);
            }
        }

        [Test]
        public void InitialScore()
        {
            Assert.AreEqual("Love - Love", GetScoreString(0, 0));
        }
        
        [Test]
        public void FifteenLove()
        {
            Assert.AreEqual("Fifteen - Love", GetScoreString(1, 0));
        }

        [Test]
        public void LoveFifteen()
        {
            Assert.AreEqual("Love - Fifteen", GetScoreString(0, 1));
        }

        [Test]
        public void FifteenFifteen()
        {
            //1: I am stupid. ie. It's a buggy test
            //2: I want to test smth that was already implemented (TDD: it was already tested) ==> test overlapping ==> DELETE the test
            //3: Leave a "overlapping test" in place if it HAS DOCUMENTATION VALUE
            Assert.AreEqual("Fifteen - Fifteen", GetScoreString(1, 1));
        }

        [Test]
        public void ThirtyLove()
        {
            Assert.AreEqual("Thirty - Love", GetScoreString(2, 0));
        }

        [Test]
        public void FortyLove()
        {
            Assert.AreEqual("Forty - Love", GetScoreString(3, 0));
        } 
        [Test]
        public void Deuce()
        {
            Assert.AreEqual("Deuce", GetScoreString(3, 3));
        }
        [Test]
        public void Deuce4()
        {
            Assert.AreEqual("Deuce", GetScoreString(4, 4));
        }
        [Test]
        public void AdvantagePlayer1()
        {
            Assert.AreEqual("Advantage Player1", GetScoreString(5, 4));
        }
        
        [Test]
        public void AdvantagePlayer2()
        {
            Assert.AreEqual("Advantage Player2", GetScoreString(3, 4));
        }
        [Test]
        public void GameWonPlayer1_KickAss()
        {
            Assert.AreEqual("Game Won Player1", GetScoreString(4, 0));
        }

        
    }
}
