using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ALE_2
{
    public class Parser
    {
        Stream myStream = null;
        StreamReader reader = null;
        
        private Automaton _automation;
        public Automaton automaton
        {
            get { return _automation; }
            set { _automation = value; }
        }
        private Test _test;

        public Test test
        {
            get { return _test; }
            set { _test = value; }
        }
        
        
        public Parser()
        {
            this._automation = new Automaton();
            this._test = new Test();
        }
        public bool openFile()
        {
            openFilesExplorer();
            if (reader != null)
            {
                constructAtomaton();
                return true;
            }
            else
            {
                Console.WriteLine("no file was read");
                return false;
            }
        }
        public void openFilesExplorer()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "C:\\Users\\k_vol\\OneDrive\\Работен плот\\ALE_2";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        myStream = openFileDialog1.OpenFile();
                        reader = new StreamReader(myStream);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        public void constructAtomaton()
        {
            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();
                if (line.Contains("#"))
                {
                    continue;
                }
                else if (line.Contains("states"))
                {
                    //cleaning the string
                    line = line.Replace("states:", String.Empty);
                    line = line.Replace(" ", String.Empty);

                    //adding the states to the automaton
                    addStates(line);

                }
                else if (line.Contains("final"))
                {
                    //cleaning string
                    line = line.Replace("final:", String.Empty);
                    line = line.Replace(" ", String.Empty);

                    //adding final states
                    addFinals(line);
                }
                else if (line.Contains("alphabet"))
                {
                    //cleaning string
                    line = line.Replace("alphabet:", String.Empty);
                    line = line.Replace(" ", String.Empty);

                    //adding final states
                    addAlphabet(line);
                }
                else if (line.Contains("stack"))
                {
                    //cleaning string
                    line = line.Replace("stack:", String.Empty);
                    line = line.Replace(" ", String.Empty);

                    //assigning the autom to pda and setting the stack
                    automaton.is_pda = true;
                    automaton.stack = line;
                }
                else if (line.Contains("transitions"))
                {
                    //starting to read the transitions
                    while (reader.Peek() >= 0)
                    {
                        line = reader.ReadLine();
                        //checking if it is the end
                        if (line.Contains("end."))
                        {
                            break;
                        }

                        //cleaning the string
                        line = line.Replace("-->", ",");
                        line = line.Replace(" ", String.Empty);

                        //adding the transition
                        addTranstionToState(line);
                    }
                }
                else if (line.Contains("dfa"))
                {
                    //cleaning the string
                    line = line.Replace("dfa:", String.Empty);
                    line = line.Replace(" ", String.Empty);

                    //setting dfa
                    test.setDfa(line);
                }
                else if (line.Contains("finite"))
                {
                    //cleaning the string
                    line = line.Replace("finite:", String.Empty);
                    line = line.Replace(" ", String.Empty);

                    //setting dfa
                    test.setFinite(line);
                }
                else if (line.Contains("words"))
                {
                    //starting to read the transitions
                    while (reader.Peek() >= 0)
                    {
                        line = reader.ReadLine();
                        //checking if it is the end
                        if (line.Contains("end."))
                        {
                            break;
                        }

                        //cleaning the string
                        line = line.Replace(" ", String.Empty);

                        try
                        {
                            //adding the word
                            automaton.words.Add(line);
                            string[] word_properties = line.Split(',');
                            test.addWord(word_properties[0], word_properties[1]);
                        }
                        catch (Exception exeption)
                        {
                            Console.WriteLine(exeption.Message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// adding the states in the atomaton from the states: exp fromt eh file read
        /// </summary>
        /// <param name="states_string"> the whole line without the "states:" part</param>
        public void addStates(string states_string)
        {
            string[] states_names = states_string.Split(',');
            for (int index = 0; index < states_names.Length; index++)
            {
                automaton.addState(states_names[index]);
                //setting the initaial state
                if (index == 0)
                {
                    automaton.states[0].setStart();
                }
            }
        }
        /// <summary>
        /// seeting the final states in the automaton
        /// </summary>
        /// <param name="states_string"> the whole line without the "final:" part</param>
        public void addFinals(string states_string)
        {
            string[] final_states_names = states_string.Split(',');
            for (int index = 0; index < final_states_names.Length; index++)
            {
                State state = automaton.getState(final_states_names[index]);
                //if the state is found then its final prop is set to true
                if (state!=null)
                {
                    state.setFinal();
                }                
            }
        }

        /// <summary>
        /// if there is a present alphabet in the file it is set
        /// </summary>
        /// <param name="alphabet_string"> the whole line without the "alphabet:" part</param>
        public void addAlphabet(string alphabet_string)
        {
            string[] alphabet = alphabet_string.Split(',');
            foreach (string letter in alphabet)
            {
                automaton.addLetterToAlphabet(letter);
            }
        }

        /// <summary>
        /// add new transition to the automaton
        /// </summary>
        /// <param name="transition">taking strign format: {start_state},{transition_name},{target_state}</param>
        public void addTranstionToState(string transition)
        {
            try
            {
                string push_down_props = "";
                if (transition.Contains('['))
                {
                    string[] push_down = transition.Split('[');
                    string[] props = push_down[push_down.Length - 1].Split(']');
                    push_down_props = props[0];
                    transition = transition.Replace("[" + push_down_props + "]", "");
                }
                string[] transition_properties = transition.Split(',');

                string state_name_string = transition_properties[0];
                string transition_name_string = transition_properties[1];
                string target_state_string = transition_properties[2];

                State state = automaton.getState(state_name_string);

                //checking if the states excist
                if (state == null)
                {
                    Console.WriteLine("state:" + state_name_string + " not found");
                }
                else
                {
                    State target_state = automaton.getState(target_state_string);
                    if (target_state == null)
                    {
                        Console.WriteLine("target state:" + target_state_string + " not found");
                    }
                    else
                    {
                        if (push_down_props != "")
                        {
                            state.addTransition(transition_name_string, target_state, push_down_props);
                        }
                        else
                        {
                            state.addTransition(transition_name_string, target_state);
                        }
                    }
                }
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }
        }
        public Automaton getAutomation()
        {
            return this._automation;
        }
        public Test getTest()
        {
            return this._test;
        }

        /// <summary>
        /// used for debugging the final result after reading, if everything wnet the way it should
        /// </summary>
        private void debugStates()
        {
            Console.WriteLine("automaton: ");
            Console.WriteLine("alphabet: "+this.automaton.getAlphabetToString());
            foreach (State state in automaton.states)
            {
                Console.WriteLine(state.toString());
                foreach (Transition transition in state.transitions)
                {
                    Console.WriteLine("   "+transition.toString());
                }
            }
        }

        /// <summary>
        /// debugging the test performed of the automaton
        /// </summary>
        private void debugTest()
        {
            Console.WriteLine("test: ");
            Console.WriteLine(test.toString());
            foreach (Word word in test.words)
            {
                Console.WriteLine("   " + word.toString());
            }

        }
    }
}
