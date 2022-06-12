using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using LogicLayer;
using DataAccessLayer;
using System;

namespace SynthesisUnitTests
{
    [TestClass]
    public class UnitTestsTournaments
    {

        [TestMethod]
        public void CheckDateValidation()
        {
            //Start date is before end date
            Exception ex = Assert.ThrowsException<Exception>(() => new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(15), DateTime.Now.AddDays(10), 5, 10, "Fontys", new Badminton(), TournamentStatus.Open));
            Assert.AreEqual("Incorrect dates", ex.Message);

        }

        [TestMethod]
        public void CheckPlayersValidation()
        {
            //Min players are more than max players
            Exception ex = Assert.ThrowsException<Exception>(() => new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(10), DateTime.Now.AddDays(30), 20, 10, "Fontys", new Badminton(), TournamentStatus.Open));
            Assert.AreEqual("Min players cannot be more than max players", ex.Message);
        }

        [TestMethod]
        public void AddPlayer()
        {
            Tournament tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(15), DateTime.Now.AddDays(30), 5, 10, "Fontys", new Badminton(), TournamentStatus.Open);

            //Add the same player to the tournament
            tournament.AddPlayer(new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User"));
            Exception ex = Assert.ThrowsException<Exception>(() => tournament.AddPlayer(new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User")));
            Assert.AreEqual("User has already entered this tournament", ex.Message);
        }
    }
}