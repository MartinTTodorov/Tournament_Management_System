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
    public class UnitTestsVolleyball
    {

        SportType volleyball = new Volleyball();
        [TestMethod]
        public void ValidateResults()
        {
            Exception ex = Assert.ThrowsException<Exception>(() => volleyball.ValidateResults(-5, 10));
            Assert.AreEqual("Results can only be positive", ex.Message);


            Exception ex2 = Assert.ThrowsException<Exception>(() => volleyball.ValidateResults(1, 17));
            Assert.AreEqual("Invalid scores for volleyball", ex2.Message);


            Exception ex3 = Assert.ThrowsException<Exception>(() => volleyball.ValidateResults(12, 15));
            Assert.AreEqual("Invalid scores for volleyball", ex3.Message);


            Exception ex4 = Assert.ThrowsException<Exception>(() => volleyball.ValidateResults(15, 17));
            Assert.AreEqual("Invalid scores for volleyball", ex4.Message);


            Exception ex5 = Assert.ThrowsException<Exception>(() => volleyball.ValidateResults(22, 29));
            Assert.AreEqual("Invalid scores for volleyball", ex5.Message);
        }
    }
}
