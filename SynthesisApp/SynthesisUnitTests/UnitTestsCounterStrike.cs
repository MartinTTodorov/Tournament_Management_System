using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using LogicLayer;
using DataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SynthesisUnitTests
{
    [TestClass]
    public class UnitTestsCounterStrike
    {
        SportType counterStrike = new CounterStrike();


        [TestMethod]
        public void ValidateResults()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => counterStrike.ValidateResults(-5, 10));
            Assert.AreEqual("Scores can only be positive", ex.Message);


            Exception ex2 = Assert.ThrowsException<Exception>(() => counterStrike.ValidateResults(1, 17));
            Assert.AreEqual("Invalid results for counter strike", ex2.Message);


            Exception ex3 = Assert.ThrowsException<Exception>(() => counterStrike.ValidateResults(12, 15));
            Assert.AreEqual("Invalid results for counter strike", ex3.Message);


            Exception ex4 = Assert.ThrowsException<Exception>(() => counterStrike.ValidateResults(15, 17));
            Assert.AreEqual("Invalid results for counter strike", ex4.Message);


            Exception ex5 = Assert.ThrowsException<Exception>(() => counterStrike.ValidateResults(22, 29));
            Assert.AreEqual("Invalid results for counter strike", ex5.Message);
        }
    }
}
