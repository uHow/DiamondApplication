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
            Assert.AreEqual(numer, sample.Number);
        }

        public void NameTest()
        {
            Diamond sample = new Diamond(1, "nazwa", 5, "bor", 15);
            string nazwa = sample.Name;
            Assert.AreEqual(nazwa, sample.Name);
        }

        public void RatioTest()
        {
            Diamond sample = new Diamond(1, "nazwa", 5, "bor", 15);
            double stosunek = sample.Ratio;
            Assert.AreEqual(stosunek, sample.Ratio);
        }

        public void TypeDopingTest()
        {
            Diamond sample = new Diamond(1, "nazwa", 5, "bor", 15);
            string typ = sample.TypeDoping;
            Assert.AreEqual(typ, sample.TypeDoping);
        }

        public void PercentDopingTest()
        {
            Diamond sample = new Diamond(1, "nazwa", 5, "bor", 15);
            double procent = sample.PercentDoping;
            Assert.AreEqual(procent, sample.PercentDoping);
        }
    }
}