
using System;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
namespace InWordCheckEditor
{
    class WorksheetReader
    {

        private DataInfo wordDataInfo;

        public DataInfo WordDataInfo
        {
            get
            {
                return this.wordDataInfo;
            }
        }
        public WorksheetReader(WorkbookSetting workbookSetting)
        {
            wordDataInfo = new DataInfo();

            this.SetLevelWordInfo(workbookSetting);
            
           
        }

        

        public void SetLevelWordInfo(WorkbookSetting workbookSetting)
        {
            string wordTemp = "";
            List<string> words = new List<string>();
            Excel.Worksheet excelWorksheet = workbookSetting.ExcelWorksheet;
            int wordCnt = excelWorksheet.UsedRange.Rows.Count;
            
            for(int index = 1; index <= wordCnt; index++)
            {
                try
                {
                    wordTemp = excelWorksheet.Cells[index, 1].Value.ToString();
                }
                catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) // 공백일 경우 발생
                {
                    continue;
                }
                finally
                {
                    words.Add(wordTemp);
                }
               
                
            } // 단어들을 리스트에 넣는 과정

            wordDataInfo.WordCnt = wordCnt;
            wordDataInfo.Words = words;
            

        }

    }
}
