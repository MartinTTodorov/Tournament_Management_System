using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using LogicLayer;
using DataAccessLayer;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SynthesisUnitTests
{
    [TestClass]
    public class UnitTestsTournamentManager
    {

        private TournamentManager tournamentManager = new TournamentManager(new TournamentsDBMOCK(), new TournamentsDBMOCK());
        [TestMethod]
        public void AddTournament()
        {
            Tournament tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(1), DateTime.Now.AddDays(10), 5, 10, "Fontys", new Badminton(), TournamentStatus.Open);
            //Add a tournament that starts tomorrow, which a tournament isnt allowed to be created less than a week from now
            Exception ex = Assert.ThrowsException<Exception>(() => tournamentManager.AddTournament(tournament));
            Assert.AreEqual("Tournament can only be created at least a week after the current date", ex.Message);

            tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(9), DateTime.Now.AddDays(10), 5, 10, "Fontys", new Badminton(), TournamentStatus.Open);
            tournamentManager.AddTournament(tournament);
            //Add a tournament that already exists
            Exception ex2 = Assert.ThrowsException<Exception>(() => tournamentManager.AddTournament(tournament));
            Assert.AreEqual("The tournament already exists", ex2.Message);
        }

        [TestMethod]
        public void DeleteTournament()
        {
            Tournament tournament = tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(9), DateTime.Now.AddDays(10), 5, 10, "Fontys", new Badminton(), TournamentStatus.Open);
            //Delete an existing tournament
            tournamentManager.AddTournament(tournament);
            tournamentManager.DeleteTournament(tournament);
            
            //Delete a tournament that doesnt exist
            Exception ex2 = Assert.ThrowsException<Exception>(() => tournamentManager.DeleteTournament(tournament));
            Assert.AreEqual("The tournament does not exist", ex2.Message);
        }

        [TestMethod]
        public void AddPlayer()
        {
            //Try to add a player to a tournament that is not open
            Tournament tournament = tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(9), DateTime.Now.AddDays(10), 5, 10, "Fontys", new Badminton(), TournamentStatus.Scheduled);
            Exception ex = Assert.ThrowsException<Exception>(() => tournamentManager.AddPlayer(tournament, new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User")));
            Assert.AreEqual("You cant join a tournament that is not open. This tournament's status is: Scheduled", ex.Message);

            //Add a player to a tournament that has already entered that tournament
            tournament = tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(9), DateTime.Now.AddDays(10), 5, 10, "Fontys", new Badminton(), TournamentStatus.Open);
            tournamentManager.AddPlayer(tournament, new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User"));
            Exception ex2 = Assert.ThrowsException<Exception>(() => tournamentManager.AddPlayer(tournament, new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User")));
            Assert.AreEqual("You have already joined this tournament", ex2.Message);
        }

        [TestMethod]
        public void GetTournamentByID()
        {
            //Retrieve a tournament based on the ID
            Tournament tournament = tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(9), DateTime.Now.AddDays(10), 5, 10, "Fontys", new Badminton(), TournamentStatus.Open);
            tournamentManager.AddTournament(tournament);
            Tournament retrievedTournament = tournamentManager.GetTournamentByID(1);
            Assert.AreEqual(tournament.ID, retrievedTournament.ID);

            //Retrieve a tournament that doesnt exist
            Exception ex = Assert.ThrowsException<Exception>(() => retrievedTournament = tournamentManager.GetTournamentByID(5));
            Assert.AreEqual("Tournament with ID 5 doesn't exist", ex.Message);

        }

        [TestMethod]
        public void CreateMatches()
        {


            //Create matches for a tournament that is not open
            Tournament tournament = tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(5), DateTime.Now.AddDays(10), 1, 10, "Fontys", new Badminton(), TournamentStatus.Scheduled);
            tournament.AddPlayer(new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User"));
            Exception ex = Assert.ThrowsException<Exception>(() => tournamentManager.CreateMatches(tournament));
            Assert.AreEqual("Schedule can be generated only if the tournament is open. Current status: Scheduled", ex.Message);

            //Create matches for a tournament where the start date is not less than 7 days before now
            tournament = tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(9), DateTime.Now.AddDays(10), 1, 10, "Fontys", new Badminton(), TournamentStatus.Open);
            tournament.AddPlayer(new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User"));
            Exception ex2 = Assert.ThrowsException<Exception>(() => tournamentManager.CreateMatches(tournament));
            Assert.AreEqual("Tournament can only be scheduled 7 days prior to the start date", ex2.Message);
            
            //Create matches for a tournament that has not reached its minimum players
            tournament = tournament = new Tournament(1, new RoundRobin(), "Title", "Info", DateTime.Now.AddDays(5), DateTime.Now.AddDays(10), 5, 10, "Fontys", new Badminton(), TournamentStatus.Open);
            Exception ex3 = Assert.ThrowsException<Exception>(() => tournamentManager.CreateMatches(tournament));
            Assert.AreEqual("The tournament did not reach the minimum number of players when it was time to create the matches, so tournament with ID 1 was cancelled", ex3.Message);

        }
    }
}
