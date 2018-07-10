using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE_2
{
    public class _2DArrayList
    {
        private string _state;

        public string state
        {
            get { return _state; }
            set { _state = value; }
        }
        private string[] _transitions;

        public string[] transtions
        {
            get { return _transitions; }
            set { _transitions = value; }
        }
        public _2DArrayList(string state_name, string[] transtions)
        {
            this._state = state_name;
            this._transitions = transtions;
        }
        
    }
}
