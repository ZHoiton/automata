using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE_2
{
    public class Regex
    {
        private const char loop_sign = '*';
        private const char and_sign = '.';
        private const char or_sign = '|';
        public Automaton automaton;

        public Regex()
        {
            automaton = new Automaton();

        }

        public void generateAutomaton(State start_state, State end_state, string regex)
        {
            if (regex.Length > 0)
            {
                //getting the sign so we now what operation to perform
                string current_sign = regex[0].ToString();

                //cleaning the string from the sign and the string
                regex = regex.Substring(2, regex.Length - 3);

                if (current_sign == "|")
                {
                    string first_part = getPart(regex);

                    regex = removePart(regex, first_part);
                    string second_part = regex;

                    //if the firstpart is one simphol just add the transition as 
                    //it doesnt have any more expresions inside, and the same for all of the rest
                    if (first_part.Length == 1)
                    {
                        start_state.addTransition(first_part, end_state);
                    }
                    else
                    {
                        generateAutomaton(start_state, end_state, first_part);
                    }
                    if (second_part.Length == 1)
                    {
                        start_state.addTransition(second_part, end_state);
                    }
                    else
                    {
                        generateAutomaton(start_state, end_state, second_part);
                    }
                }
                else if (current_sign == ".")
                {
                    string first_part = getPart(regex);

                    regex = removePart(regex, first_part);
                    string second_part = regex;

                    State new_state = new State(automaton.getNewIndex());
                    automaton.states.Add(new_state);
                    if (first_part.Length == 1)
                    {
                        start_state.addTransition(first_part, new_state);
                    }
                    else
                    {
                        generateAutomaton(start_state, new_state, first_part);
                    }
                    if (second_part.Length == 1)
                    {
                        new_state.addTransition(second_part, end_state);
                    }
                    else
                    {
                        generateAutomaton(new_state, end_state, second_part);
                    }
                }
                else
                {
                    State new_first_state = new State(automaton.getNewIndex());
                    automaton.states.Add(new_first_state);

                    State new_second_state = new State(automaton.getNewIndex());
                    automaton.states.Add(new_second_state);

                    State new_third_state = new State(automaton.getNewIndex());
                    automaton.states.Add(new_third_state);

                    State new_forth_state = new State(automaton.getNewIndex());
                    automaton.states.Add(new_forth_state);

                    start_state.addTransition("_", new_first_state);

                    new_first_state.addTransition("_", new_second_state);

                    //new_second_state.addTransition("_", new_third_state);

                    new_third_state.addTransition("_", new_forth_state);

                    new_forth_state.addTransition("_", new_first_state);
                    new_forth_state.addTransition("_", end_state);
                    new_third_state.addTransition("_", new_second_state);

                    if (regex.Length == 1)
                    {
                        new_second_state.addTransition(regex, new_third_state);
                    }
                    else
                    {
                        generateAutomaton(new_second_state, new_third_state, regex);
                    }
                }
            }
        }

        /// <summary>
        /// returns a part of the expresion 
        /// example:
        ///     .(a,b),|(c,v)
        ///     it will return .(a,b)
        /// </summary>
        /// <param name="regex_string"></param>
        /// <returns></returns>
        private string getPart(string regex_string)
        {
            if (regex_string[0].Equals('.') || regex_string[0].Equals('|') || regex_string[0].Equals('*'))
            {
                int bracket_count = 0;
                for (int counter = 0; counter < regex_string.Length; counter++)
                {
                    if (regex_string[counter].Equals('('))
                    {
                        bracket_count++;
                    }
                    else if (regex_string[counter].Equals(')'))
                    {
                        bracket_count--;
                    }
                    else if ((counter != 0 && counter != 1) && bracket_count == 0)
                    {
                        string part = regex_string.Substring(0, counter);
                        return part;
                    }
                }
            }
            else
            {
                string[] parts = regex_string.Split(',');
                return parts[0];
            }
            return regex_string;
        }

        /// <summary>
        /// removes a given string from another string
        /// </summary>
        /// <param name="regex_string">master string</param>
        /// <param name="remove_string">string which has to be removed fromt he master</param>
        /// <returns></returns>
        private string removePart(string regex_string, string remove_string)
        {
            int index = regex_string.IndexOf(remove_string);
            string cleanPath = (index < 0)
                ? regex_string
                : regex_string.Remove(index, remove_string.Length + 1);
            return cleanPath;

        }
    }
}
