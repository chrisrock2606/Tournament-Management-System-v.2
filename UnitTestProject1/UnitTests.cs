using System;
using System.Collections.ObjectModel;
using BusinessLayer;
using DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestShuffle()
        {
            ObservableCollection<Team> TeamList = new ObservableCollection<Team>();
            ObservableCollection<Team> TeamStorage = new ObservableCollection<Team>();
            TeamList.Add(new Team { Bye = true, TeamId = 1, TeamName = "hold 1" });
            TeamList.Add(new Team { Bye = false, TeamId = 2, TeamName = "hold 2" });
            TeamList.Add(new Team { Bye = false, TeamId = 3, TeamName = "hold 3" });
            TeamStorage.Add(new Team { Bye = true, TeamId = 1, TeamName = "hold 1" });
            TeamStorage.Add(new Team { Bye = false, TeamId = 2, TeamName = "hold 2" });
            TeamStorage.Add(new Team { Bye = false, TeamId = 3, TeamName = "hold 3" });
            TeamList = BusinessFacade.ShuffleTeam(TeamList);

            Assert.AreNotSame(TeamStorage, TeamList);
        }
    }
}
