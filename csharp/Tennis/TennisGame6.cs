using System;

namespace Tennis;

public class TennisGame6 : ITennisGame
{
    private int player1Score;
    private int player2Score;
    private string player1Name;
    private string player2Name;
    
    private const int EndGameScoreStarts = 4;

    public TennisGame6(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == player1Name)
            player1Score++;
        else
            player2Score++;
    }

    public string GetScore()
    {
        string result;

        if (player1Score == player2Score)
        {
            // tie score
            result = player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }
        
        else if (player1Score >= EndGameScoreStarts || player2Score >= EndGameScoreStarts)
        {
            // end-game score
            result = (player1Score - player2Score) switch
            {
                1 => $"Advantage {player1Name}",
                -1 => $"Advantage {player2Name}",
                >= 2 => $"Win for {player1Name}",
                <= -2 => $"Win for {player2Name}",
                _ => throw new Exception($"Invalid end game score. Player 1 score: {player1Score}, Player 2 score: {player2Score}")
            };
        }
        else
        {
            // regular score
            var score1 = player1Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };

            var score2 = player2Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };

            result = $"{score1}-{score2}";
        }

        return result;
    }
}