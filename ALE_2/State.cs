using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE_2
{
    public class State
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        private List<Transition> _transitions;

        public List<Transition> transitions
        {
            get { return _transitions; }
            set { _transitions = value; }
        }
        private bool _has_loop;

        public bool has_loop
        {
            get { return _has_loop; }
            set { _has_loop = value; }
        }
        private bool _is_start;

        public bool is_start
        {
            get { return _is_start; }
            set { _is_start = value; }
        }
        private bool _is_final;

        public bool is_final
        {
            get { return _is_final; }
            set { _is_final = value; }
        }
        public State(string name)
        {
            this._name = name;
            this._is_final = false;
            this._is_start = false;
            this._transitions = new List<Transition>();
        }
        public void setStart()
        {
            this._is_start = true;
        }
        public void setFinal()
        {
            this._is_final = true;
        }

        /// <summary>
        /// checks if one of the state's transitions is coming back to the currrent state
        /// </summary>
        public void checkForLoop()
        {
            foreach (Transition transition in _transitions)
            {
                if (transition.target.name.Equals(this.name))
                {
                    this._has_loop = true;
                    return;
                }
            }
            this._has_loop = false;
        }

        /// <summary>
        ///  checking if the current state is dfa(has transitions with all the letters in the alphabet)
        /// </summary>
        /// <param name="alphabet"> automaton's alphabet</param>
        /// <returns></returns>
        public bool isDfa(List<string> alphabet)
        {
            List<string> outgoing_transitions = new List<string>();
            foreach (Transition transition in this._transitions)
            {
                //if atate has any empty transitions it is an ndfa
                if (transition.is_empty)
                {
                    return false;
                }

                foreach (string o_string in outgoing_transitions)
                {
                    //if the transition is already in the list the state is not dfa as it already has one transition twice
                    if (transition.value.Equals(o_string))
                    {
                        return false;
                    }
                }
                // if the transition is not in the out. list, it's value is added
                outgoing_transitions.Add(transition.value);
            }
            //removing the outgoing list's transitions from the alphabet
            var diff = alphabet.Except(outgoing_transitions).ToList();

            //if something is left then it is NOT dfa
            if (!diff.Any())
            {
                return true;
            } 
            return false;
        }
        /// <summary>
        /// add transition to the list
        /// </summary>
        /// <param name="value">transition name</param>
        /// <param name="target">to which state the transition is going to</param>
        public void addTransition(string value, State target)
        {
            _transitions.Add(new Transition(value, target));
        }

        /// <summary>
        /// add transition to the list
        /// </summary>
        /// <param name="value">transition name</param>
        /// <param name="target">to which state the transition is going to</param>
        /// <param name="pushdown_props">used only on the pushdown automaton</param>
        public void addTransition(string value, State target,string pushdown_props)
        {
            _transitions.Add(new Transition(value, target, pushdown_props));
        }
        public string toString()
        {
            return "name: " + name + ", is starting: " + is_start + ", is final: " + is_final + ", has loops: " + has_loop;
        }
    }
}
