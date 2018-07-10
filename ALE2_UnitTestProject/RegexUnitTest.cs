using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALE_2;

namespace ALE2_UnitTestProject
{
    [TestClass]
    public class RegexUnitTest
    {
        [TestMethod]
        public void testRegex()
        {
            Regex regex = new Regex();

            regex.automaton.addState("1");
            regex.automaton.addState("2");
            State start_state = regex.automaton.getState("1");
            start_state.setStart();
            State end_state = regex.automaton.getState("2");
            end_state.setFinal();

            string regex_string = "*(a)";
            //regex_string = regex_string.Replace(" ", "_");
            regex.generateAutomaton(start_state, end_state, regex_string);
            int regex_states = regex.automaton.states.Count;

            Assert.AreEqual(regex_states, 6);
        }
        [TestMethod]
        public void testRegexWithAnd()
        {
            Regex regex = new Regex();

            regex.automaton.addState("1");
            regex.automaton.addState("2");
            State start_state = regex.automaton.getState("1");
            start_state.setStart();
            State end_state = regex.automaton.getState("2");
            end_state.setFinal();

            string regex_string = "*(.(a,b))";
            //regex_string = regex_string.Replace(" ", "_");
            regex.generateAutomaton(start_state, end_state, regex_string);
            int regex_states = regex.automaton.states.Count;

            Assert.AreEqual(regex_states, 7);
        }
    }
}
