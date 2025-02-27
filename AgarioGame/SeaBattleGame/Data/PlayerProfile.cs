using System;
using System.Text.Json;
using AgarioGame.Engine.Utilities;

namespace AgarioGame.SeaBattleGame.Data
{
    public class PlayerProfile
    {
        public string NickName { get; set; }
        public int RoundWins { get; set; }
        public int RoundLosses { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public PlayerProfile() { }

        public PlayerProfile(string nickName)
        {
            NickName = nickName;
            RoundWins = 0;
            RoundLosses = 0;
            Wins = 0;
            Losses = 0;
        }
        public void Initialize()
        {
            var user = DataUtility.Load<PlayerProfile>(GetFileName());
            LoadStatistics(user);
        }
        private void LoadStatistics(PlayerProfile user)
        {
            if (!string.IsNullOrEmpty(user.NickName))
            {
                NickName = user.NickName;
            }
            RoundWins = user.RoundWins;
            RoundLosses = user.RoundLosses;
            Wins = user.Wins;
            Losses = user.Losses;
        }
        public void Save()
        {
            DataUtility.Save(this, GetFileName());
        }
        private string GetFileName()
        {
            return $"{NickName}.json";
        }
    }
}
