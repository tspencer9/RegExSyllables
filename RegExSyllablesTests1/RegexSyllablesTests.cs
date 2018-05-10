using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegExSyllables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExSyllables.Tests
{
    [TestClass()]
    public class RegexSyllablesTests
    {
        [TestMethod()]
        public void TestFindReadingLevelTest()
        {
            RegexSyllables example = new RegexSyllables();

            Assert.AreEqual(example.TestFindReadingLevel(90), "5th grade");
        }
    }
}