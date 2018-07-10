using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE_2;
using System.Collections.Generic;
using System.Linq;

namespace ALE2_UnitTestProject
{
    [TestClass]
    public class AutomatonUnitTest
    {
        [TestMethod]
        public void shouldGetState()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");

            Assert.IsNotNull(automaton.getState("B"));
        }
        [TestMethod]
        public void shouldGenerateAlphabet()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");
            automaton.getState("A").addTransition("a", automaton.getState("B"));
            automaton.getState("A").addTransition("b", automaton.getState("B"));
            automaton.getState("B").addTransition("a", automaton.getState("B"));
            automaton.getState("B").addTransition("b", automaton.getState("B"));
            automaton.generateAlphabet();

            List<string> alphabet = new List<string>();
            alphabet.Add("a");
            alphabet.Add("b");

            Assert.AreEqual(alphabet[0], automaton.alphabet[0]);
        }
        [TestMethod]
        public void shouldBeDfa()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");
            automaton.getState("A").addTransition("a", automaton.getState("B"));
            automaton.getState("A").addTransition("b", automaton.getState("B"));
            automaton.getState("B").addTransition("a", automaton.getState("B"));
            automaton.getState("B").addTransition("b", automaton.getState("B"));
            automaton.generateAlphabet();

            List<string> alphabet = new List<string>();
            alphabet.Add("a");
            alphabet.Add("b");

            Assert.IsTrue(automaton.isDfa());
        }
        [TestMethod]
        public void shouldNotBeDfa()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");
            automaton.getState("A").addTransition("a", automaton.getState("B"));
            automaton.getState("B").addTransition("a", automaton.getState("B"));
            automaton.getState("B").addTransition("b", automaton.getState("B"));
            automaton.generateAlphabet();

            Assert.IsFalse(automaton.isDfa());
        }

        [TestMethod]
        public void wordShouldBeValid()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");
            automaton.getState("A").addTransition("a", automaton.getState("B"));
            automaton.getState("B").addTransition("a", automaton.getState("B"));
            automaton.getState("B").addTransition("b", automaton.getState("B"));
            automaton.getState("B").setFinal();
            automaton.generateAlphabet();

            Assert.IsTrue(automaton.validateWord("aa",automaton.states[0]));
        }
        [TestMethod]
        public void wordShouldNotBeValid()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");
            automaton.getState("A").addTransition("a", automaton.getState("B"));
            automaton.getState("B").addTransition("a", automaton.getState("B"));
            automaton.getState("B").addTransition("b", automaton.getState("B"));
            automaton.generateAlphabet();

            //because there is not final state
            Assert.IsFalse(automaton.validateWord("aa", automaton.states[0]));
        }
        [TestMethod]
        public void shouldHaveEmptyTransition()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");
            automaton.getState("A").addTransition("a", automaton.getState("A"));
            automaton.getState("A").addTransition("_", automaton.getState("B"));
            automaton.generateAlphabet();

            Assert.IsTrue(automaton.checkForEmptyTransitions(automaton.getState("A")));
        }
        [TestMethod]
        public void shouldNotHaveEmptyTransition()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");
            automaton.getState("A").addTransition("a", automaton.getState("A"));
            automaton.generateAlphabet();

            //because there is not final state
            Assert.IsFalse(automaton.checkForEmptyTransitions(automaton.getState("A")));
        }
        [TestMethod]
        public void shouldGenerateWords()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");
            automaton.getState("A").addTransition("a", automaton.getState("B"));
            automaton.getState("A").addTransition("b", automaton.getState("B"));
            automaton.generateAlphabet();

            //because there is not final state
            Assert.IsTrue(automaton.generateWords("",new List<State>(),automaton.states[0]));
        }
        [TestMethod]
        public void shouldNotGenerateWords()
        {
            Automaton automaton = new Automaton();
            automaton.addState("A");
            automaton.addState("B");
            automaton.getState("A").addTransition("a", automaton.getState("B"));
            automaton.getState("A").addTransition("a", automaton.getState("A"));
            automaton.getState("A").addTransition("b", automaton.getState("B"));
            automaton.generateAlphabet();

            //because there is not final state
            Assert.IsFalse(automaton.generateWords("", new List<State>(), automaton.states[0]));
        }
    }
}
