using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE_2;

namespace ALE2_UnitTestProject
{
    [TestClass]
    public class TransitionUnitTest
    {
        [TestMethod]
        public void transitionShouldBeEmpty()
        {
            Transition transtion = new Transition("_", new State("A"));
            Assert.IsTrue(transtion.is_empty);
        }
        [TestMethod]
        public void transitionShouldNotHavePushDownProps()
        {
            Transition transtion = new Transition("_", new State("A"));
            Assert.IsTrue(transtion.pushdown_props==null);
        }
        [TestMethod]
        public void transitionShouldHavePushDownProps()
        {
            Transition transtion = new Transition("_", new State("A"),"_,a");
            Assert.IsTrue(transtion.pushdown_props != null);
        }
    }
}
