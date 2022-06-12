using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using LogicLayer;
using DataAccessLayer;

namespace SynthesisUnitTests
{

    [TestClass]
    public class UnitTestsUsersManager
    {

        private UsersManager usersManager = new UsersManager(new UsersDBMOCK(), new UsersDBMOCK());



        [TestMethod]
        public void AddUser()
        {
            User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            //Adding a user
            usersManager.AddUser(user);

            if (!usersManager.Users.Contains(user))
            {
                Assert.Fail();
            }

            //Adding the same user
            Exception ex = Assert.ThrowsException<Exception>(() => usersManager.AddUser(user));
            Assert.AreEqual("User already exists", ex.Message);

        }

        [TestMethod]
        public void UpdateUser()
        {
            User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            usersManager.AddUser(user);
            //changing username
            User updatedUser = new User(new Account(1, "testNewUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            usersManager.UpdateUser(updatedUser);

            
            //Check if the username for this user is the new username
            if (!(usersManager.Users.First(x=>x.Account.ID==1).Account.Username == "testNewUsername"))
            {
                Assert.Fail();
            }

            //Trying to update a user that doesnt exist(ID 2)
            updatedUser = new User(new Account(2, "testNewUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");

            Exception ex = Assert.ThrowsException<Exception>(() => usersManager.UpdateUser(updatedUser));
            Assert.AreEqual("User doesnt exist", ex.Message);

        }

        [TestMethod]
        public void DeleteUser()
        {
            User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            usersManager.AddUser(user);

            //Deleting the added user
            try
            {
                usersManager.DeleteUser(user);

            }
            catch (Exception ex2)
            {
                Assert.Fail($"No exception expected, however caught {ex2.Message}");

            }
            

            //Deleting a user that doesnt exist
            User NonExistentUser = new User(new Account(2, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            Exception ex = Assert.ThrowsException<Exception>(() => usersManager.DeleteUser(NonExistentUser));
            Assert.AreEqual("User doesnt exist", ex.Message);
        }

        [TestMethod]
        public void GetUserByID()
        {
            //Retrieve a user by its ID
            User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            usersManager.AddUser(user);
            User retrievedUser = usersManager.GetUserByID(1);

            Assert.AreEqual(user, retrievedUser);
        }

        [TestMethod]
        public void RetrieveUserByCredentials()
        {
            //Retrieve user by its username and password
            User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            usersManager.AddUser(user);
            User retrievedUser = usersManager.RetrieveUserByCredentials("testUsername", "testPassword");

            Assert.AreEqual(user, retrievedUser);
        }

        [TestMethod]
        public void TryLogin()
        {
            User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            usersManager.AddUser(user);

            //Check if login returns true if user logs in with valid credentials
            if (!usersManager.TryLogin("testUsername", "testPassword"))
            {
                Assert.Fail("Credentials were correct but the login returned false");
            }

            //Log in with wrong credentials

            if (usersManager.TryLogin("wrongUsername", "wrongPassword"))
            {
                Assert.Fail("Expected result was false, but method returned true");
            }
        }
        

        [TestMethod]
        public void TryRegister()
        {
            User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            usersManager.AddUser(user);

            //Try to register with an already existing username

            Exception ex = Assert.ThrowsException<Exception>(() => usersManager.TryRegister("testUsername", "password"));
            Assert.AreEqual("Username already exists", ex.Message);
        }


    }
}
