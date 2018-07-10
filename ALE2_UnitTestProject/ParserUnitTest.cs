using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE_2;

namespace ALE2_UnitTestProject
{
    [TestClass]
    public class ParserUnitTest
    {
        [TestMethod]
        public void shouldAddStates()
        {
            Parser parser = new Parser();
            parser.addStates("A,f,w");

            Assert.AreEqual(parser.getAutomation().states[1].name, "f");
        }
        [TestMethod]
        public void shouldAddTranstion()
        {
            Parser parser = new Parser();
            parser.addStates("A,f,w");
            parser.addTranstionToState("A,e,w");

            Assert.AreEqual(parser.getAutomation().states[0].transitions[0].target.name, "w");
        }

        [TestMethod]
        public void shouldAddFinal()
        {
            Parser parser = new Parser();
            parser.addStates("A,f,w");
            parser.addFinals("f");

            Assert.IsTrue(parser.getAutomation().getState("f").is_final);
        }
        [TestMethod]
        public void shouldAddLetterToAutomaton()
        {
            Parser parser = new Parser();
            parser.addAlphabet("a,b,c");

            Assert.AreEqual(parser.getAutomation().getAlphabetToString(), "a,b,c");
        }
        [TestMethod]
        public void shouldAddLetterToAutomatonAtIndex()
        {
            Parser parser = new Parser();
            parser.addAlphabet("a,b,c");

            Assert.AreEqual(parser.getAutomation().alphabet[1], "b");
        }
    }
}
