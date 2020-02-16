using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace InWordCheckEditor
{
    class Works
    {

        WikiWordParser parser;
        WorkbookMaker workbookMaker;
        DataAccessObject dao;


        public DataAccessObject getDao() => this.dao;   

        public WordInfo wordInfo;
        private List<string> words;


        private bool isNew = false;


        public Works()
        {
            parser = new WikiWordParser(); // Web Page Load - init
            dao = new DataAccessObject();
            workbookMaker = new WorkbookMaker(); // Make Directory And Files


            dao.setWorkbook(workbookMaker);
            dao.setDataInfo(parser);
            // set excel for control and save data

            isNew = dao.checkData();

            if (isNew)
            {
                this.initWordData();
            }

            wordInfo = dao.readData();
        }


        public void initWordData()
        {
            parser.doParsing();
            // Data parsing at the Wiki

            ValueObject vo = new ValueObject();

            vo.setWords(parser.getWords());
            
            dao.writeData(vo); // write and save excel file
        }


        /*
        public ValueObject wordCheck(string lineString)
        {

            List<int> differentWordIndex = new List<int>();
            List<int> wordLength = new List<int>();

            List<string> lineWordList;
            List<string> differentWords;
            
            ValueObject wordCheckVo;

            wordCheckVo = new ValueObject();


            
            words = ReadVo.getWords();
            lineWordList = lineString.Split(' ').ToList();


            differentWords = lineWordList.Except(words).ToList();

            // differentWords in lineWordList

            for (int i = 0; i < differentWords.Count(); i++)
            {
                differentWordIndex.Add(lineString.IndexOf(differentWords[i]));
                wordLength.Add(differentWords[i].Length);


            }


            wordCheckVo.setDifferentwordIndex(differentWordIndex);
            wordCheckVo.setWordLength(wordLength);


            return wordCheckVo;

        }
        
         */

        //public ValueObject getReadVo() => ReadVo;

        public WordInfo getWordInfo() => wordInfo;
    }
        
        
}
