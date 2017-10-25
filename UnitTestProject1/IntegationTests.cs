using System;
using System.Text;
using System.Collections.Generic;
using BusinessLayer;
using DomainLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
   
    [TestClass]
    public class IntegationTests
    {
        [TestMethod]
        public void CanPlayerBeSavedLoadedAndDeleted()
        {
            Player testPlayer = new Player() {Email = "email", FirstName = "fornavn", LastName = "efternavn", PhoneNr = "12345678"};
            Player facitPlayer = new Player() { Email = "email", FirstName = "fornavn", LastName = "efternavn", PhoneNr = "12345678" };
            testPlayer.PlayerId = BusinessFacade.SavePlayer(testPlayer);
            facitPlayer.PlayerId = testPlayer.PlayerId;

            Assert.AreSame(facitPlayer, BusinessFacade.GetPlayerById(testPlayer.PlayerId));

            BusinessFacade.DeletePlayer(testPlayer);

            Assert.AreNotSame(facitPlayer, BusinessFacade.GetPlayerById(testPlayer.PlayerId));
        }
    }
}
