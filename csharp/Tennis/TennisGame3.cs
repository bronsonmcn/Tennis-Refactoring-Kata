using System;

namespace Tennis
{
    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Player(string name)
        {
            Name = name;
            Points = 0;
        }

        public static Player GetWinningPlayer(Player p1, Player p2)
        {
            return p1.Points > p2.Points ? p1 : p2;
        }
        
        
    }
    public class TennisGame3 : ITennisGame
    {
        private Player _player1;
        private Player _player2;
        
        private readonly string[] _pointNames = { "Love", "Fifteen", "Thirty", "Forty" };


        public TennisGame3(string player1Name, string player2Name)
        {
            _player1 = new Player(player1Name);
            _player2 = new Player(player2Name);
        }

        public string GetScore()
        {
            // pre-advantage
            if (_player1.Points < 4 && _player2.Points < 4 && _player1.Points + _player2.Points < 6)
            {
                return _player1.Points == _player2.Points 
                    ? _pointNames[_player1.Points] + "-All" 
                    : _pointNames[_player1.Points] + "-" + _pointNames[_player2.Points];
            }
            
            // post advantage
            if (_player1.Points == _player2.Points)
                return "Deuce";

            var winningPlayerName = Player.GetWinningPlayer(_player1, _player2).Name;
            var pointDifference = Math.Abs(_player1.Points - _player2.Points);
            
            return pointDifference == 1 
                ? "Advantage " + winningPlayerName 
                : "Win for " + winningPlayerName;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1.Name)
                _player1.Points += 1;
            else if (playerName == _player2.Name)
                _player2.Points += 1;
            else
                throw new Exception($"Invalid player name: {playerName}");
        }
    }
}