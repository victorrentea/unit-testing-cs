using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdCode.Tdd
{
    public class TennisGame
    {
        private int player1Points;
        private int player2Points;

        public string Score()
        {
            if (player1Points >= 3 && player2Points >= 3)
            {
                if (player1Points == player2Points)
                {
                    return "Deuce";
                }
                if (player1Points - player2Points == 1)
                {
                    return "Advantage Player1";
                }
                if (player2Points - player1Points == 1)
                {
                    return "Advantage Player2";
                }
            }
            if (player1Points >= 4 && player1Points - player2Points >= 2)
            {
                return "Game Won Player1";
            }
            return GetScoreString(player1Points)
                + " - "
                + GetScoreString(player2Points);
        }

        private string GetScoreString(int points)
        {
            switch (points)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty"; 
                default:
                    return "Forty";
                //default:
                //    throw new InvalidOperationException();

            }
        }

        public void PlayerScores(int playerNumber)
        {
            if (playerNumber == 1)
            {
                player1Points++;
            }
            else
            {
                player2Points++;
            }
        }
    }
}
