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
    public class UnitTestsBadminton
    {

        SportType badminton = new Badminton();

        [TestMethod]
        public void ValidateResults()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => badminton.ValidateResults(-5, 10));
            Assert.AreEqual("Scores can only be positive", ex.Message);


            Exception ex2 = Assert.ThrowsException<Exception>(() => badminton.ValidateResults(1, 20));
            Assert.AreEqual("Input scores are invalid", ex2.Message);


            Exception ex3 = Assert.ThrowsException<Exception>(() => badminton.ValidateResults(23, 29));
            Assert.AreEqual("Input scores are invalid", ex3.Message);


            Exception ex4 = Assert.ThrowsException<Exception>(() => badminton.ValidateResults(15, 25));
            Assert.AreEqual("Input scores are invalid", ex4.Message);


            Exception ex5 = Assert.ThrowsException<Exception>(() => badminton.ValidateResults(21, 27));
            Assert.AreEqual("Input scores are invalid", ex5.Message);
        }
    }
}
