using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiamondApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondApplication.Tests
{
    [TestClass()]
    public class DiamondTests
    {
        [TestMethod()]
        public void NumberTest()
        {
            Diamond sample = new Diamond(1, "nazwa", 5, "bor", 15);
            int numer = sample.Number;
            Assert.AreEqual(numer, 1);
        }

        
    }
}