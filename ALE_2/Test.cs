using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALE_2
{
    public class Test
    {
        private bool _dfa;

        public bool dfa
        {
            get { return _dfa; }
            set { _dfa = value; }
        }
        private bool _finite;

        public bool finite
        {
            get { return _finite; }
            set { _finite = value; }
        }
        private List<Word> _words;

        public List<Word> words
        {
            get { return _words; }
            set { _words = value; }
        }
        public Test()
        {
            this._words = new List<Word>();
        }
        public void setDfa(string dfa_string)
        {
            this._dfa = dfa_string.Equals("y") ? true : false;
        }
        public void setFinite(string finite_string)
        {
            this._finite = finite_string.Equals("y") ? true : false;
        }
        public void addWord(string word, string is_accepted)
        {
            this._words.Add(new Word(word, is_accepted));
        }
        public string toString()
        {
            return "dfa: " + this._dfa + ", finite:" + this._finite;
        }
        
    }
}
