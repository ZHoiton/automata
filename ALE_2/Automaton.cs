using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.IO;


namespace ALE_2
{
    public class Automaton
    {
        private List<State> _states;

        public List<State> states
        {
            get { return _states; }
            set { _states = value; }
        }
        private List<string> _alphabet;

        public List<string> alphabet
        {
            get { return _alphabet; }
            set { _alphabet = value; }
        }
        private List<string> _generated_words;

        public List<string> generated_words
        {
            get { return _generated_words; }
            set { _generated_words = value; }
        }
        private bool _is_pda;

        public bool is_pda
        {
            get { return _is_pda; }
            set { _is_pda = value; }
        }
        private string _stack;

        public string stack
        {
            get { return _stack; }
            set { _stack = value; }
        }
        private List<string> _words;

        public List<string> words
        {
            get { return _words; }
            set { _words = value; }
        }
        
        public Automaton()
        {
            this._states = new List<State>();
            this._alphabet = new List<string>();
            this._generated_words = new List<string>();
            this._words = new List<string>();
        }

        public void addState(string name)
        {
            this._states.Add(new State(name));
        }
        public void addFinalState(string name)
        {
            State state = new State(name);
            state.setFinal();
            this._states.Add(state);
        }

        public void addLetterToAlphabet(string letter)
        {
            this._alphabet.Add(letter);
        }
        public string getNewIndex()
        {
            string name = states[states.Count - 1].name;
            int new_index = Convert.ToInt16(name) + 1;

            return new_index.ToString();
        }
        public State getState(string state_name)
        {
            foreach (State state in _states)
            {
                if (state.name.Equals(state_name))
                {
                    return state;
                }
            }
            return null;
        }
        public void generateAlphabet()
        {
            List<string> temp_list = new List<string>();
            foreach (State state in states)
            {
                foreach (Transition transition in state.transitions)
                {

                    bool should_add = true;
                    foreach (string transtions_added_name in temp_list)
                    {
                        if (transtions_added_name.Equals(transition.value))
                        {
                            should_add = false;
                        }
                    }
                    if (should_add)
                    {
                        temp_list.Add(transition.value);
                    }
                }
            }
            _alphabet = temp_list;
        }

        /// <summary>
        /// goes trought the whole automaton and checks all the states if they are dfa
        /// </summary>
        /// <returns>true if the automaton is dfa</returns>
        public bool isDfa()
        {
            if (this._alphabet == null)
            {
                Console.WriteLine("!!! alphabet not set !!!");
                return false;
            }
            foreach (State state in states)
            {
                if (!state.isDfa(this._alphabet))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// getting a word as input and going through the automaton to check if it is possible to generate the word using recursion
        /// </summary>
        /// <param name="word">word to be validated</param>
        /// <param name="current_state">the state from which you wish to start checking for the word</param>
        /// <returns>if word is valid it returns true</returns>
        public bool validateWord(string word, State current_state)
        {
            foreach (Transition transition in current_state.transitions)
            {
                bool pass = false;
                if (word.Length > 0)
                {
                    pass = transition.value.Equals(word[0].ToString());
                }
                //proceed if the name of the transition is the same as the first letter in the word or if the transation is empty AND it is not a loop because then we run in an potentinal infinite loop.
                if (pass || transition.is_empty && !transition.target.name.Equals(current_state.name))
                {
                    string new_word = word;
                    //removing the first letter only if the transtion passed is not empty
                    if (!transition.is_empty)
                    {
                        new_word = word.Substring(1, word.Length - 1);
                    }
                    //passing the next state after the transtion
                    State new_state = transition.target;

                    if (new_word.Length > 0)
                    {
                        //recurse with the new props
                        return validateWord(new_word, new_state);
                    }
                    else
                    {
                        if (new_state.is_final)
                        {
                            return true;
                        }
                        else
                        {
                            if (checkForEmptyTransitions(new_state))
                            {
                                return validateWord(new_word, TryGetFinalState(new_state));//
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            if (current_state.is_final && word == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private State TryGetFinalState(State state)
        {
            foreach (Transition transtion in state.transitions)
            {
                if (transtion.target.is_final)
                {
                    return transtion.target;
                }
            }
            return state;
        }
        public bool checkForEmptyTransitions(State state)
        {
            foreach (Transition transition in state.transitions)
            {
                if (transition.is_empty && !transition.target.name.Equals(state.name))
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkForTransition(string key, string stack)
        {
            string new_stack = stack;
            for (int index = new_stack.Length-1; index >= 0; index--)
            {
                if (new_stack.Length > 1)
                {
                    if (new_stack[index].Equals('_'))
                    {
                        new_stack = new_stack.Remove(new_stack.Length-1);
                        continue;
                    }
                    else
                    {
                        if (new_stack[index].Equals(Convert.ToChar(key)))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (new_stack[index].Equals(Convert.ToChar(key)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool validatePushDownWord(string word, string stack, State current_state)
        {
            foreach (Transition transition in current_state.transitions)
            {
                bool pass = false;
                if (word.Length > 0)
                {
                    pass = transition.value.Equals(word[0].ToString());
                }
                //proceed if the name of the transition is the same as the first letter in the word or if the transation is empty AND it is not a loop because then we run in an potentinal infinite loop.
                if (pass || transition.is_empty && !transition.target.name.Equals(current_state.name))
                {
                    string new_word = word;
                    string new_stack = stack;
                    bool should_remove = false;
                    if (transition.pushdown_props != null)
                    {
                        string[] transition_push_props = transition.pushdown_props.Split(',');
                        string key = transition_push_props[0];
                        string value = transition_push_props[1];

                        if (checkForTransition(key, stack))
                        {
                            should_remove = true;
                            new_stack = stack.Substring(0, stack.LastIndexOf(key));
                            //new_stack = removePart(stack, key);
                            new_stack += value;
                        }
                    }
                    //removing the first letter only if the transtion passed is not empty
                    if (!transition.is_empty && should_remove)
                    {
                        new_word = word.Substring(1, word.Length - 1);
                    }
                    //passing the next state after the transtion
                    State new_state = transition.target;

                    if (new_state.is_final && new_stack.Equals("_")&&new_word.Equals(""))
                    {
                        return true;
                    }
                    else
                    {
                        if (!should_remove)
                        {
                            return false;
                        }
                        else
                        {
                            //recurse with the new props
                            return validatePushDownWord(new_word, new_stack, new_state);
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// generating all possible words for this automaton
        /// </summary>
        /// <param name="word">empty string</param>
        /// <param name="path">new list</param>
        /// <param name="current_state">initial state</param>
        /// <returns>if number of words is infinite the method returns false otherwise it returns true</returns>
        public bool generateWords(string word, List<State> path, State current_state)
        {
            foreach (Transition transition in current_state.transitions)
            {
                //checking for loops, if the state was already procesed that means there is a loop somewhere in the path e.g. infinite number of words
                foreach (State path_state in path)
                {
                    if (path_state == transition.target)
                    {
                        return false;
                    }
                }

                //adding to word
                word += transition.value;

                //if the state is final and it doesnt have outgoing transitions add the word to the array, reset the path and remove the last letter fromt he word
                if (transition.target.is_final && transition.target.transitions.Count==0)
                {
                    generated_words.Add(word);
                    word = word.Substring(0, word.Length - 1);
                    path = new List<State>();
                }
                else
                {
                    // if the states is final add the word
                    if (transition.target.is_final)
                    {
                        generated_words.Add(word);
                    }

                    //add the new state to the path
                    path.Add(transition.target);

                    //recurse
                    if (!generateWords(word, path, transition.target))
                    {
                        return false;
                    }
                    word = word.Substring(0, word.Length - 1);
                    path.Remove(transition.target);
                }
            }
            return true;
        }
        public string getAlphabetToString()
        {
            string temp = "";
            for (int index = 0; index < this._alphabet.Count; index++)
            {
                if (index > 0)
                {
                    temp += ",";
                }
                temp += this._alphabet[index];
            }
            return temp;
        }
        public List<_2DArrayList> getDfaTable()
        {
            List<_2DArrayList> dfa_table = new List<_2DArrayList>();
            List<string> procesed_states = new List<string>();
            //adding the fist item
            dfa_table.Add(new _2DArrayList(this.states[0].name, new string[this.alphabet.Count]));

            //loop trought all items in the table
            for (int index = 0; index < dfa_table.Count; index++)
            {
                if (!find(procesed_states,dfa_table[index].state))
                {
                    //add to proceses states
                    procesed_states.Add(dfa_table[index].state);

                    string current_state = dfa_table[index].state;

                    //indexing the loop
                    int letter_index = 0;
                    foreach (string letter_in_alphabet in this.alphabet)
                    {
                        //the new state generated after going trough the transtions
                        string new_states_for_transtion = "";

                        //if the new current state is a concatination of state split it
                        string[] new_states = current_state.Split('.');
                        //loop through the result states
                        foreach (string state_name in new_states)
                        {
                            //find state
                            State found_state = this.getState(state_name);
                            if (found_state != null)
                            {
                                //loop trought all the transitions of the state
                                foreach (Transition transtion in found_state.transitions)
                                {
                                    if (transtion.value.Equals(letter_in_alphabet))
                                    {
                                        //add value to the "new_states_for_transtion" var only if it is not already present 
                                        string[] asd = new_states_for_transtion.Split('.');
                                        if (!isStringContained(asd, transtion.target.name))
                                        {
                                            //add state to the "new_states_for_transtion" var
                                            if (new_states_for_transtion.Length > 0)
                                            {
                                                new_states_for_transtion += ".";
                                            }
                                            //add transition target to the var
                                            new_states_for_transtion += transtion.target.name;
                                        }
                                    }
                                }
                            }
                        }
                        //add the result in the array
                        dfa_table[index].transtions[letter_index] = new_states_for_transtion;
                        letter_index++;
                    }
                    //adding the new states for procesing
                    foreach (string new_state_to_process in dfa_table[index].transtions)
                    {
                        bool should_add = true;
                        for (int state_index = 0; state_index < dfa_table.Count; state_index++)
                        {
                            if (dfa_table[state_index].state.Equals(new_state_to_process))
                            {
                                should_add = false;
                                break;
                            }
                        }
                        if (should_add)
                        {
                            dfa_table.Add(new _2DArrayList(new_state_to_process, new string[this.alphabet.Count]));
                        }
                    }
                }
            }
            return dfa_table;
        }
        public Automaton constructFromDFA(List<_2DArrayList> dfa_table)
        {
            Automaton automaton = new Automaton();

            for (int index = 0; index < dfa_table.Count; index++)
            {
                string state_name = dfa_table[index].state.Replace(".", ",");
                if (state_name == "")
                {
                    state_name = "_";
                }
                bool is_final = false;
                
                string[] states = state_name.Split(',');
                foreach (string state in states)
                {
                    State found_state = this.getState(state);
                    if (found_state!=null)
                    {
                        if (found_state.is_final)
                        {
                            is_final = true;
                            break;
                        }
                    }
                }
                
                if (is_final)
                {
                    automaton.addFinalState(state_name);
                }
                else
                {
                    automaton.addState(state_name);
                }
            }
            //settign the initial state
            automaton.states[0].setStart();

            for (int index = 0; index < dfa_table.Count; index++)
            {
                for (int transition_index = 0; transition_index < dfa_table[index].transtions.Length; transition_index++)
                {
                    string transition_name = dfa_table[index].transtions[transition_index].Replace(".", ",");
                    if (transition_name == "")
                    {
                        transition_name = "_";
                    }
                    automaton.states[index].addTransition(this.alphabet[transition_index], automaton.getState(transition_name));
                }
            }
            automaton.words = this.words;

            return automaton;
        }
        public bool find(List<string> list ,string state_name)
        {
            foreach (string state in list)
            {
                if (state.Equals(state_name))
                {
                    return true;
                }
            }
            return false;
        }
        public bool isStringContained(string[] list, string search_string)
        {
            foreach (string str in list)
            {
                if (search_string.Equals(str))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// generating the .dot file for graphviz
        /// </summary>
        public void generateAutomatonGraphVizDiagram(string file_name_)
        {
            string path = ".\\";
            string file_name = file_name_;
            //if (!File.Exists(path+file_name))
            //{
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path + file_name))
            {
                sw.WriteLine("digraph myAutomaton {");
                sw.WriteLine("  rankdir=LR;");
                sw.WriteLine("\"\" [shape=none]");


                foreach (State state in states)
                {
                    string shape_type = "circle";
                    if (state.is_final)
                    {
                        shape_type = "doublecircle";
                    }
                    sw.WriteLine("\"" + state.name + "\" " + "[shape=" + shape_type + "]");
                }
                sw.WriteLine("");
                //printing the starting state
                foreach (State state in states)
                {
                    if (state.is_start)
                    {
                        sw.WriteLine("\"\" -> " + "\"" + state.name + "\"");
                    }
                }
                //print rest
                foreach (State state in states)
                {
                    foreach (Transition transition in state.transitions)
                    {
                        string props = "";
                        if (transition.pushdown_props != null)
                        {
                            props = " [" + transition.pushdown_props + "]";
                        }
                        sw.WriteLine("\"" + state.name + "\" -> " + "\"" + transition.target.name + "\"" + "[label=\"" + transition.graphVizValue + props + "\"]");
                    }
                }

                sw.WriteLine("}");
            }
            //}

        }

        /// <summary>
        /// generating the .txt file for testing, givign to others and etc.
        /// </summary>
        public void generateAutomatonText(string file_name_)
        {
            string path = ".\\";
            string file_name = file_name_;

            using (StreamWriter sw = File.CreateText(path + file_name))
            {
                sw.WriteLine("#ez_katka");
                sw.Write("alphabet: ");
                generateAlphabet();
                for (int index = 0; index < _alphabet.Count; index++)
                {
                    if (index != 0)
                    {
                        sw.Write(",");
                    }
                    sw.Write(_alphabet[index]);
                }
                sw.WriteLine("");
                sw.WriteLine("#ez_katka");

                sw.Write("states:");
                for (int index = 0; index < states.Count; index++)
                {
                    if (index != 0)
                    {
                        sw.Write(",");
                    }
                    sw.Write(states[index].name);
                }
                sw.WriteLine();
                sw.WriteLine("#ez_katka");
                sw.WriteLine("");

                sw.Write("final: ");
                string final_states = "";
                for (int index = 0; index < states.Count; index++)
                {
                    if (states[index].is_final)
                    {
                        if (final_states.Length != 0)
                        {
                            final_states += ",";
                        }
                        final_states += states[index].name;
                    }
                }
                sw.Write(final_states);
                sw.WriteLine("");
                sw.WriteLine("#ez_katka");
                sw.WriteLine("");

                sw.WriteLine("transitions:");
                foreach (State state in states)
                {
                    foreach (Transition transition in state.transitions)
                    {
                        string props = "";
                        if (transition.pushdown_props != null)
                        {
                            props = " [" + transition.pushdown_props + "]";
                        }
                        sw.WriteLine(state.name + "," + transition.value +props + " --> " + transition.target.name);
                    }
                }
                sw.WriteLine("end.");
                sw.WriteLine("");

                sw.WriteLine("#zob");
                //printing the starting state

                if (words.Count>0)
                {
                    sw.WriteLine("words:");
                    foreach (string word in this.words)
                    {
                        sw.WriteLine(word);
                    }
                    sw.WriteLine("end.");
                }

                string dfa_bool = "y";
                if (!isDfa())
                {
                    dfa_bool = "n";
                }


                sw.WriteLine("dfa:" + dfa_bool);
            }
        }
    }
}
