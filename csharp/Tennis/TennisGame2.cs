using System;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private readonly string player1Name;
        private readonly string player2Name;

        private const int UseAdvantageScoringFrom = 4;
        private const int PostAdvantageWinDifference = 2;
        
        private const string ZeroPointName = "Love";
        private const string OnePointName = "Fifteen";
        private const string TwoPointName = "Thirty";
        private const string ThreePointName = "Forty";
        private const string PreAdvantageEqualName = "All";
        private const string PostAdvantageEqualName = "Deuce";


        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            
            p1point = 0;
            p2point = 0;
        }
        
        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                P1Score();
            else if (playerName == player2Name)
                P2Score();
            else
                throw new Exception($"invalid player name: {playerName}");
        }

        public string GetScore()
        {
            // equal scores
            if (p1point == p2point)
            {
                return GetEqualScore();
            }
            // pre advantage 
            if (p1point < UseAdvantageScoringFrom && p2point < UseAdvantageScoringFrom)
            {
                return GetPreAdvantageScore();
            }

            return GetPostAdvantageScore();
        }

        private string GetEqualScore()
        {
            if (p1point >= UseAdvantageScoringFrom - 1)
            {
                return PostAdvantageEqualName;
            }
            
            var score = p1point switch
            {
                0 => ZeroPointName,
                1 => OnePointName,
                2 => TwoPointName,
                _ => throw new Exception($"Invalid equal score: {p1point}")
            };
            
            return score + $"-{PreAdvantageEqualName}";
        }

        private string GetPreAdvantageScore()
        {
            string p1Score = "";
            string p2Score = "";
                
            p1Score = p1point switch
            {
                0 => ZeroPointName,
                1 => OnePointName,
                2 => TwoPointName,
                3 => ThreePointName,
                _ => throw new Exception($"Invalid player 1 pre-advantage point: {p1point}")
            };

            p2Score = p2point switch
            {
                0 => ZeroPointName,
                1 => OnePointName,
                2 => TwoPointName,
                3 => ThreePointName,
                _ => throw new Exception($"Invalid player 2 pre-advantage point: {p2point}")
            };
            return p1Score + "-" + p2Score;
        }

        private string GetPostAdvantageScore()
        {
            var leadingPlayerName = p1point > p2point ? player1Name : player2Name;
            var pointDifference = Math.Abs(p1point - p2point);

            if (pointDifference >= PostAdvantageWinDifference)
                return $"Win for {leadingPlayerName}";

            return $"Advantage {leadingPlayerName}";
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }
    }
}

