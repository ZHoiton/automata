using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE_2;
using System.Collections.Generic;
using System.Linq;

namespace ALE2_UnitTestProject
{
    [TestClass]
    public class StateUnitTest
    {
        [TestMethod]
        public void shouldHaveLoop()
        {
            State state = new State("a");
            state.addTransition("F", state);
            state.checkForLoop();
            Assert.IsTrue(state.has_loop);
        }
        [TestMethod]
        public void shouldNotHaveLoop()
        {
            State state = new State("a");
            state.addTransition("F", new State("s"));
            state.checkForLoop();
            Assert.IsFalse(state.has_loop);
        }
        [TestMethod]
        public void shouldNotBeDFA()
        {
            State state = new State("a");
            state.addTransition("_", new State("s"));
            state.addTransition("a", new State("b"));
            state.checkForLoop();
            List<string> alphabet = new List<string>();
            alphabet.Add("a");

            Assert.IsFalse(state.isDfa(alphabet));
        }
        [TestMethod]
        public void shouldBeDFA()
        {
            State state = new State("a");
            //state.addTransition("_", new State("s"));
            state.addTransition("a", new State("b"));
            state.checkForLoop();
            List<string> alphabet = new List<string>();
            alphabet.Add("a");

            Assert.IsTrue(state.isDfa(alphabet));
        }
    }
}
