using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InWordCheckEditor
{
    class WorksheetReader
    {

        private DataInfo wordDataInfo;

        public DataInfo getWordDataInfo() => wordDataInfo;
        public WorksheetReader(WorkbookSetting workbook)
        {
            wordDataInfo = new DataInfo();

            this.setLevelWordInfo(workbook);
            
           
        }

        

        public void setLevelWordInfo(WorkbookSetting workbook)
        {
            string wordTemp;
            List<string> words = new List<string>();
            ExcelWorksheet worksheet = workbook.getWorksheet();
            int wordCnt = Int32.Parse(worksheet.Cells["A1"].Value.ToString());
            
            for(int index = 1; index <= wordCnt; index++)
            {
                wordTemp = worksheet.Cells["A" + (index + 2)].Value.ToString();

                words.Add(wordTemp);
            } // 단어들을 리스트에 넣는 과정

            wordDataInfo.setWordCnt(wordCnt);
            wordDataInfo.setWords(words);
            

        }

    }
}
