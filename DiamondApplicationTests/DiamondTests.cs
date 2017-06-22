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
            Assert.AreEqual(1, sample.Number);
        }
        [TestMethod()]
        public void NameTest()
        {
            Diamond sample = new Diamond(1, "nazwa", 5, "bor", 15);
            Assert.AreEqual("nazwa", sample.Name);
        }
        [TestMethod()]
        public void RatioTest()
        {
            Diamond sample = new Diamond(1, "nazwa", 5, "bor", 15);
            Assert.AreEqual(5, sample.Ratio);
        }
        [TestMethod()]
        public void TypeDopingTest()
        {
            Diamond sample = new Diamond(1, "nazwa", 5, "bor", 15);
            Assert.AreEqual("bor", sample.TypeDoping);
        }
        [TestMethod()]
        public void PercentDopingTest()
        {
            Diamond sample = new Diamond(1, "nazwa", 5, "bor", 15);
            Assert.AreEqual(15, sample.PercentDoping);
        }
    }
}