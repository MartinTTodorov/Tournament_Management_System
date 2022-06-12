using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;

namespace SynthesisUnitTests
{
    [TestClass]
    public class UnitTestsUsers
    {
        [TestMethod]
        public void CreateUser()
        {
            //Invalid email
            Exception ex = Assert.ThrowsException<Exception>(() => new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester", "+123456789", "User"));
            Assert.AreEqual("Invalid email", ex.Message);

            //Valid email, no exception expected
            try
            {
                User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");
            }
            catch (Exception ex2)
            {
                Assert.Fail($"No exception expected, however caught {ex2.Message}");
            }
            
        }

        [TestMethod]
        public void CheckName()
        {
            //First name contains a number
            Exception ex = Assert.ThrowsException<Exception>(() => new User(new Account(1, "testUsername", "testPassword"), "Tes5ter", "Tester", "Tester@gmail.com", "+123456789", "User"));
            Assert.AreEqual("Name cannot contain numbers", ex.Message);

            //First name doesn't contain a number, no exception expected
            try
            {
                User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");

            }
            catch (Exception ex2)
            {

                Assert.Fail($"No exception expected, however caught {ex2.Message}");
            }
        }
        [TestMethod]
        public void checkSurname()
        {
            //Surname contains a number
            Exception ex = Assert.ThrowsException<Exception>(() => new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tes5ter", "Tester@gmail.com", "+123456789", "User"));
            Assert.AreEqual("Name cannot contain numbers", ex.Message);

            //Surname doesnt contain a number, no exception expected
            try
            {
                User user = new User(new Account(1, "testUsername", "testPassword"), "Tester", "Tester", "Tester@gmail.com", "+123456789", "User");

            }
            catch (Exception ex2)
            {

                Assert.Fail($"No exception expected, however caught {ex2.Message}");
            }
        }

        
    }
}
