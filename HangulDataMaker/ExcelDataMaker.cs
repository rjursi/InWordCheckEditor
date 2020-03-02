using System;
using System.Collections.Generic;
using OfficeOpenXml;

using System.IO;
namespace HangulDataMaker
{
    class ExcelDataMaker
    {

        ExcelPackage excel;
        
        FileInfo excelFile;
        
        private int worksheetCnt;


        public ExcelDataMaker()
        {
            excel = new ExcelPackage();

            excelFile = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "\\words.xlsx");

            makeExcelFile();

        }

        private void makeExcelFile()
        {

            excel.Workbook.Worksheets.Add("Easy");
            excel.Workbook.Worksheets.Add("Normal");
            excel.Workbook.Worksheets.Add("Hard");

            worksheetCnt = excel.Workbook.Worksheets.Count;


            excel.SaveAs(excelFile); 

        }



        public void DataWrite(WikiWordParser parser)
        {

            for(int sheetCnt = 1; sheetCnt <= worksheetCnt; sheetCnt++)
            {
                parser.doParsing(sheetCnt);


                ExcelWorksheet currentWorksheet = excel.Workbook.Worksheets[sheetCnt];
                List<string> words = parser.getWords();
                int wordCnt = parser.getWordCnt();

                currentWorksheet.Cells["A1"].Value = wordCnt;

                for (int colNum = 0; colNum < wordCnt; colNum++)
                {
                    currentWorksheet.Cells["A" + (colNum + 3)].Value = words[colNum];
                }


                parser.setWordsListClear();
            }


            excel.SaveAs(excelFile);


            Console.WriteLine("ExcelDataMaker : 데이터 입력 및 저장을 마쳤습니다.");
        }

    }
}
