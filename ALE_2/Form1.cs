using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALE_2
{
    public partial class Form1 : Form
    {
        Automaton automaton_from_file;
        Regex regex;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (automaton_from_file == null)
            {
                btn_transform_from_dfa.Enabled = false;
                button1.Enabled = false;
                btn_test_word.Enabled = false;
                btn_test_word_regex.Enabled = false;
                btn_transform_to_dfa_regex.Enabled = false;
            }
        }

        private void btn_open_file_Click(object sender, EventArgs e)
        {
            try
            {
                //ez_katka
                Parser parser = new Parser();
                if (parser.openFile())
                {
                    automaton_from_file = parser.getAutomation();

                    //enabling the buttons 
                    if (automaton_from_file != null)
                    {
                        btn_transform_from_dfa.Enabled = true;
                        button1.Enabled = true;
                        btn_test_word.Enabled = true;
                    }

                    Test test = parser.getTest();

                    label_is_dfa.Text = automaton_from_file.isDfa() ? "yes" : "no";

                    //generating the files
                    string file_name = "graph.dot";
                    automaton_from_file.generateAutomatonGraphVizDiagram(file_name);
                    automaton_from_file.generateAutomatonText("automaton.txt");

                    //test vectors from file
                    list_test_vectors_from_file.Items.Clear();
                    foreach (Word word in test.words)
                    {
                        list_test_vectors_from_file.Items.Add(word.toString());
                    }
                    // is dfa from file
                    list_test_vectors_from_file.Items.Add("is dfa:" + test.dfa);

                    //tests from program
                    list_test_vectors_from_program.Items.Clear();
                    foreach (Word word in test.words)
                    {
                        bool valid_word = automaton_from_file.validateWord(word.word, automaton_from_file.states[0]);

                        if (automaton_from_file.is_pda)
                        {
                            string stack = automaton_from_file.stack;
                            if (stack.Equals(""))
                            {
                                stack = "_";
                            }
                            valid_word = automaton_from_file.validatePushDownWord(word.word, stack, automaton_from_file.states[0]);
                        }

                        string test_string = "word: " + word.word + ", is accepted: " + valid_word;
                        list_test_vectors_from_program.Items.Add(test_string);
                    }
                    list_test_vectors_from_program.Items.Add("is dfa:" + automaton_from_file.isDfa());

                    //graphviz

                    // into a dot-format file
                    string new_file_name = file_name.Substring(0, file_name.Length - 4) + ".jpg";
                    //string locaiton = Directory.GetCurrentDirectory();
                    //creating and opening the image
                    Process process = new Process();
                    process.StartInfo.FileName = ".\\Graphviz2.38\\bin\\dot.exe";
                    process.StartInfo.Arguments = " -Tjpg " + file_name + " -o " + new_file_name;
                    process.StartInfo.CreateNoWindow = true;
                    process.EnableRaisingEvents = true;
                    process.Exited += (sender1, e1) => openFile(sender1, e1, new_file_name);
                    process.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_transform_from_dfa_Click(object sender, EventArgs e)
        {
            try
            {
                List<_2DArrayList> dfa_table = automaton_from_file.getDfaTable();

                Automaton dfa_automaton = automaton_from_file.constructFromDFA(dfa_table);
                string file_name = "dfa_graph.dot";
                int count = 1;
                while (File.Exists(file_name))
                {
                    file_name = count + "_" + file_name;
                    count++;
                }
                string new_file_name = file_name.Substring(0, file_name.Length - 4) + ".jpg";
                dfa_automaton.generateAutomatonGraphVizDiagram(file_name);
                dfa_automaton.generateAutomatonText(file_name.Substring(0, file_name.Length - 4) + "_automaton.txt");

                //creating and opening the image
                Process process = new Process(); 
                process.StartInfo.FileName = ".\\Graphviz2.38\\bin\\dot.exe";
                process.StartInfo.Arguments = " -Tjpg " + file_name + " -o " + new_file_name;
                process.StartInfo.CreateNoWindow = true;
                process.EnableRaisingEvents = true;
                process.Exited += (sender1, e1) => openFile(sender1, e1, new_file_name);
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                list_number_of_words.Items.Clear();
                int number_of_words = 0;
                if (automaton_from_file.generateWords("", new List<State>(), automaton_from_file.states[0]))
                {
                    foreach (string word in automaton_from_file.generated_words)
                    {
                        number_of_words++;
                        list_number_of_words.Items.Add(word);
                    }
                }
                else
                {
                    list_number_of_words.Items.Add("number of words is infinite!");
                }
                label_number_of_words.Text = number_of_words.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_read_regex_Click(object sender, EventArgs e)
        {
            try
            {

                btn_test_word_regex.Enabled = true;
                btn_transform_to_dfa_regex.Enabled = true;
                regex = new Regex();

                regex.automaton.addState("1");
                regex.automaton.addState("2");
                State start_state = regex.automaton.getState("1");
                start_state.setStart();
                State end_state = regex.automaton.getState("2");
                end_state.setFinal();

                string regex_string = txt_regex.Text;
                //regex_string = regex_string.Replace(" ", "_");
                regex.generateAutomaton(start_state, end_state, regex_string);

                string file_name = "regex_graph.dot";
                regex.automaton.generateAutomatonGraphVizDiagram(file_name);
                regex.automaton.generateAutomatonText("regex_automaton.txt");

                list_regex_words.Items.Clear();
                int number_of_words = 0;
                if (regex.automaton.generateWords("", new List<State>(), regex.automaton.states[0]))
                {
                    foreach (string word in regex.automaton.generated_words)
                    {
                        number_of_words++;
                        list_regex_words.Items.Add(word);
                    }
                }
                else
                {
                    list_regex_words.Items.Add("number of words is infinite!");
                }

                label_number_of_words_regex.Text = number_of_words.ToString();

                string new_file_name = file_name.Substring(0, file_name.Length - 4) + ".jpg";

                //creating and opening the image
                Process process = new Process();
                process.StartInfo.FileName = ".\\Graphviz2.38\\bin\\dot.exe";
                process.StartInfo.Arguments = " -Tjpg " + file_name + " -o " + new_file_name;
                process.StartInfo.CreateNoWindow = true;
                process.EnableRaisingEvents = true;
                process.Exited += (sender1, e1) => openFile(sender1, e1, new_file_name);
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void openFile(object sender, EventArgs e, string file_name)
        {
            try
            {
                Process photoViewer = new Process();
                photoViewer.StartInfo.FileName = file_name;
                photoViewer.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_test_word_Click(object sender, EventArgs e)
        {
            try
            {
                bool valid_word = automaton_from_file.validateWord(txt_test_word.Text, automaton_from_file.states[0]);

                if (automaton_from_file.is_pda)
                {
                    string stack = automaton_from_file.stack;
                    if (stack.Equals(""))
                    {
                        stack = "_";
                    }
                    valid_word = automaton_from_file.validatePushDownWord(txt_test_word.Text, stack, automaton_from_file.states[0]);
                }

                label_test_word_result.Text = valid_word ? "Yes" : "No";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_transform_to_dfa_regex_Click(object sender, EventArgs e)
        {
            try
            {
                List<_2DArrayList> dfa_table = regex.automaton.getDfaTable();

                Automaton dfa_automaton = regex.automaton.constructFromDFA(dfa_table);
                string file_name = "dfa_regex_graph.dot";
                int count = 1;
                while (File.Exists(file_name))
                {
                    file_name = count + "_" + file_name;
                    count++;
                }
                string new_file_name = file_name.Substring(0, file_name.Length - 4) + ".jpg";
                dfa_automaton.generateAutomatonGraphVizDiagram(file_name);
                dfa_automaton.generateAutomatonText(file_name.Substring(0, file_name.Length - 4) + "_automaton.txt");

                //creating and opening the image
                Process process = new Process();
                process.StartInfo.FileName = ".\\Graphviz2.38\\bin\\dot.exe";
                process.StartInfo.Arguments = " -Tjpg " + file_name + " -o " + new_file_name;
                process.StartInfo.CreateNoWindow = true;
                process.EnableRaisingEvents = true;
                process.Exited += (sender1, e1) => openFile(sender1, e1, new_file_name);
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_test_word_regex_Click(object sender, EventArgs e)
        {
            try
            {
                bool valid_word = regex.automaton.validateWord(txt_regex_test_word.Text, regex.automaton.states[0]);

                if (regex.automaton.is_pda)
                {
                    string stack = regex.automaton.stack;
                    if (stack.Equals(""))
                    {
                        stack = "_";
                    }
                    valid_word = regex.automaton.validatePushDownWord(txt_regex_test_word.Text, stack, regex.automaton.states[0]);
                }

                label__regex_result.Text = valid_word ? "Yes" : "No";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
