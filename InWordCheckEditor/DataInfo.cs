
using System.Collections.Generic;


namespace InWordCheckEditor
{
    class DataInfo
    {

        private List<string> words;
        private int wordCnt;

        public List<string> getWords() => words;
        public int getWordCnt() => wordCnt;


        public void setWords(List<string> words)
        {
            this.words = words;
        }

        public void setWordCnt(int wordCnt)
        {
            this.wordCnt = wordCnt;
        }
    }
}
