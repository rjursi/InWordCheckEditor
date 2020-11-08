
using System.Collections.Generic;


namespace InWordCheckEditor
{
    class DataInfo
    {

        private List<string> words;
        private int wordCnt;

        public List<string> Words
        {
            set
            {
                this.words = value;
            }
            get
            {
                return this.words;
            }
        }
        
        public int WordCnt
        {
            set
            {
                this.wordCnt = value;
            }
            get
            {
                return this.wordCnt;
            }
        }
    }
}
