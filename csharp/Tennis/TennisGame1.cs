using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private string player1Name;
        private string player2Name;

        private const int ScoreUsingAdvantageFrom = 4;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                player1Score += 1;
            else
                player2Score += 1;
        }

        private string GetEqualScore()
        {
            switch (player1Score)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

        private string GetAdvantageScore()
        {
            var playerOneLead = player1Score - player2Score;

            switch (playerOneLead)
            {
                case 1:
                    return $"Advantage {player1Name}";
                case >= 2:
                    return $"Win for {player1Name}";
                case -1:
                    return $"Advantage {player2Name}";
                case <= -2:
                    return $"Win for {player2Name}";
                default:
                    throw new Exception($"Invalid lead score: #{playerOneLead}");
            }
        }

        private string GetPreAdvantageScore(int playerScore)
        {
            switch (playerScore)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
                default:
                    throw new Exception("Invalid PreAdvantage player score");
            }
        }

        public string GetScore()
        {
            if (player1Score == player2Score)
                return GetEqualScore();
            
            if (player1Score >= ScoreUsingAdvantageFrom || player2Score >= ScoreUsingAdvantageFrom)
                return GetAdvantageScore();

            return $"{GetPreAdvantageScore(player1Score)}-{GetPreAdvantageScore(player2Score)}";
        }
    }
}

