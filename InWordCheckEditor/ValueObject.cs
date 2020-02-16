using System;
using System.Collections.Generic;
using System.Text;

namespace InWordCheckEditor
{
    class ValueObject
    {

        private string columnTitle;
        private string word;
        private List<string> words;
        private int cntInCol;
        private List<int> wordLength;
        private List<int> differentWordIndex;


        public void setWordLength(List<int> wordLength)
        {
            this.wordLength = wordLength;
        }

        public void setDifferentwordIndex(List<int> differentWordIndex)
        {
            this.differentWordIndex = differentWordIndex;
        }

        public void setCntInCol(int cntInCol)
        {
            this.cntInCol = cntInCol;
        }
        public void setColumnTitle(string columnTitle)
        {
            this.columnTitle = columnTitle;
        }

        public void setWord(string word)
        {
            this.word = word;
        }

        public void setWords(List<string> words)
        {
            this.words = words;
        }

        public int getCntInCol() => cntInCol;

        public string getColumnTitle() => columnTitle;

        public string getWord() => word;

        public List<string> getWords() => words;

        public List<int> getWordLength() => wordLength;

        public List<int> getDifferentWordIndex() => differentWordIndex;

       
    }


}
