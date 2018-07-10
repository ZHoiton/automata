using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE_2
{
    public class Word
    {
        private string _word;

        public string word
        {
            get
            {
                if (_word == "")
                {
                    return "_";
                }
                else
                {
                    return _word;
                }
            }
            set { _word = value; }
        }
        private bool _is_accepted;

        public bool is_accepted
        {
            get { return _is_accepted; }
            set { _is_accepted = value; }
        }
        public Word(string word, string is_accepted)
        {
            this._word = word;
            this._is_accepted = parseAcceptance(is_accepted);
        }
        private bool parseAcceptance(string is_accepted)
        {
            return is_accepted.Equals("y") ? true : false;
        }
        public string toString()
        {
            return "word: " + this._word + ", is accepted: " + this._is_accepted;
        }
    }
}
