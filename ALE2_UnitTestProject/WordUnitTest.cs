using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE_2;

namespace ALE2_UnitTestProject
{
    [TestClass]
    public class WordUnitTest
    {
        [TestMethod]
        public void wordShouldBeAccepted()
        {
            Word word = new Word("aaa", "y");
            Assert.IsTrue(word.is_accepted);
        }
        [TestMethod]
        public void wordShouldNotBeAccepted()
        {
            Word word = new Word("aaa", "n");
            Assert.IsFalse(word.is_accepted);
        }

        [TestMethod]
        public void wordShouldBeTheSame()
        {
            Word word = new Word("aaa", "n");
            Assert.AreEqual("aaa", word.word);
        }
    }
}
