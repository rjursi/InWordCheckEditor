using System;
using HtmlAgilityPack;
// Web Parsing Library HtmlAgilityPack
using System.Collections.Generic;




namespace HangulDataMaker // 프로젝트 경로를 뜻함
{

    class WikiWordParser

     
    {
        private string parsingPagePath = "https://ko.wiktionary.org/wiki/%EB%B6%80%EB%A1%9D:%EC%9E%90%EC%A3%BC_%EC%93%B0%EC%9D%B4%EB%8A%94_%ED%95%9C%EA%B5%AD%EC%96%B4_%EB%82%B1%EB%A7%90_5800";

        private List <string> words;
        public string word;
        private int cntInOneCol;

        public string columnTitle;

        private HtmlWeb web;
        private HtmlDocument document;

      

        public int getWordCnt() => cntInOneCol;
        public List <string> getWords() => words;
        //public string getTitle() => columnTitle;

        public void setWordsListClear()
        {
            this.words.Clear();
        }


        private void setWordCnt(int colNum)
        {
            cntInOneCol = document.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/div/table[2]/tbody/tr/td[" + colNum + "]/dl/dd").Count;
            // get Word Cnt in One Column
        }
      

        public void doParsing(int colNum)
        {
            Console.WriteLine("WikiWordParser : 데이터를 가져오는 중입니다....");
            setWordCnt(colNum);

            for(int index = 1; index <= cntInOneCol; index++)
            {
                word = document.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/div/table[2]/tbody/tr/td[" + colNum + "]/dl/dd[" + index + "]/a")[0].InnerText;
                // get word by using xPath

                words.Add(word);
            }
          
        }


     
        public void WebDataLoad()
        {

            Console.WriteLine("WikiWordParser : 웹페이지를 로드 중입니다....");

            web = new HtmlAgilityPack.HtmlWeb();

            document = web.Load(parsingPagePath);

            Console.WriteLine("WikiWordParser : 웹페이지 로드를 마쳤습니다.");
        }


        public WikiWordParser()
        {
            word = "";
            words = new List <string>();

            columnTitle = "";
            cntInOneCol = 0;


            

        }
    }
}
