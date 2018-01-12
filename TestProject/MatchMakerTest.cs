using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainLayer;
using System.Collections.ObjectModel;

namespace TestProject
{
    [TestClass]
    public class MatchMakerTest
    {
        ObservableCollection<Player> players = new ObservableCollection<Player>();
        ObservableCollection<Match> matches = new ObservableCollection<Match>();

        [TestInitialize]
        public void CreatePlayers()
        {
            foreach (var item in "ABCDEFGHIJKLMNO") //
            {
                Player player = new Player();
                player.FirstName = item.ToString();
                players.Add(player);
            }
        }

        //[TestMethod]
        //public void CreateNewMatches_FourMatchesCreated()
        //{
        //    int maxPlayersInMatch = 4;
        //    int minPlayersInMatch = 3;

        //    MatchMaker mm = new MatchMaker(maxPlayersInMatch, minPlayersInMatch, players);
        //    matches = mm.CreateNewMatches();

        //    Assert.IsTrue(matches.Count == 4);
        //}
    }
}
