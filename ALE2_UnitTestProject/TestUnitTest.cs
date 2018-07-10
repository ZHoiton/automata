using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE_2;

namespace ALE2_UnitTestProject
{
    [TestClass]
    public class TestUnitTest
    {
        [TestMethod]
        public void automataShouldNotBeDfa()
        {
            Test test = new Test();
            test.setDfa("n");
            Assert.IsFalse(test.dfa);
        }
        [TestMethod]
        public void automataShouldBeFinite()
        {
            Test test = new Test();
            test.setFinite("y");
            Assert.IsTrue(test.finite);
        }
        [TestMethod]
        public void wordShouldFail()
        {
            Test test = new Test();
            test.addWord("aaa", "n");
            Assert.IsFalse(test.words[0].is_accepted);
        }
    }
}
