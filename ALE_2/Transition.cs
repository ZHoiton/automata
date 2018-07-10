using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE_2
{
    public class Transition
    {
        private string _value;

        public string value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string graphVizValue;

        private bool _is_emplty;

        public bool is_empty
        {
            get { return _is_emplty; }
            set { _is_emplty = value; }
        }
        private State _target;

        public State target
        {
            get { return _target; }
            set { _target = value; }
        }

        private string _pushdown_props;

        public string pushdown_props
        {
            get { return _pushdown_props; }
            set { _pushdown_props = value; }
        }
        
        public Transition(string value, State target)
        {
            this._value = value;
            this.graphVizValue = value;
            this._target = target;
            checkValue();
        }
        public Transition(string value, State target,string pushdown_props)
        {
            this._value = value;
            this.graphVizValue = value;
            this._target = target;
            this._pushdown_props = pushdown_props;
            checkValue();
        }
        /// <summary>
        /// if the value of the transition is "_" that means it is empty
        /// </summary>
        private void checkValue()
        {
            is_empty = value.Equals("_") ?  true : false;
        }
        public string toString()
        {
            return "transtion value: " + value + ", is empty: " + is_empty + ", target state: " + target.toString();
        }
    }
}
