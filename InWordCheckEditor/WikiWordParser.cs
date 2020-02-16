using System;
using HtmlAgilityPack;
// Web Parsing Library HtmlAgilityPack
using System.Collections.Generic;




namespace InWordCheckEditor // 프로젝트 경로를 뜻함
{

    class WikiWordParser

     
    {
        private string parsingPagePath = "https://ko.wiktionary.org/wiki/%EB%B6%80%EB%A1%9D:%EC%9E%90%EC%A3%BC_%EC%93%B0%EC%9D%B4%EB%8A%94_%ED%95%9C%EA%B5%AD%EC%96%B4_%EB%82%B1%EB%A7%90_5800";

        List <string> words;
        public string word;
        public int cntInOneCol;

        public string columnTitle;

        private HtmlWeb web;
        private HtmlDocument document;

      

        public int getWordCnt() => cntInOneCol;
        public List <string> getWords() => words;
        public string getTitle() => columnTitle;


        public void setWordCnt()
        {
            cntInOneCol = document.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/div/table[2]/tbody/tr/td[1]/dl/dd").Count;
            // get Word Cnt in One Column
        }
      

        public void setTitle()
        {
            columnTitle = document.DocumentNode.SelectSingleNode("//*[@id=\"mw-content-text\"]/div/table[2]/tbody/tr/td[1]/div").InnerText;

            //Console.WriteLine(columnTitle);
        }


        

        public void doParsing()
        {
          
            for(int index = 1; index <= cntInOneCol; index++)
            {
                word = document.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/div/table[2]/tbody/tr/td[1]/dl/dd[" + index + "]/a")[0].InnerText;
                // get word by using xPath

                Console.WriteLine(word);
                words.Add(word);
            }
          
        }


     

        public WikiWordParser()
        {
            word = "";
            words = new List <string>();

            columnTitle = "";
            cntInOneCol = 0;

           
            web = new HtmlAgilityPack.HtmlWeb();

            document = web.Load(parsingPagePath);

            setWordCnt();
            setTitle();

        }
    }
}
