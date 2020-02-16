using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InWordCheckEditor
{
    class WordInfo
    {

        private string word;
        private List<string> words;


        public string getWord() => word;
        public List<string> getWords() => words;


        public void setWord(string word)
        {
            this.word = word;
        }

        public void setWords(List<string> words)
        {
            this.words = words;
        }
    }
}
