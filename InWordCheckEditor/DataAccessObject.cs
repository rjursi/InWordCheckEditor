using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml;

using System.IO;
namespace InWordCheckEditor
{
    class DataAccessObject
    {

        ExcelPackage excel;
        ExcelWorksheet worksheet;
        FileInfo excelFile;
        WikiWordParser parser;
        WorkbookMaker workbookMaker;

        ValueObject vo;

        

        public void setWorkbook(WorkbookMaker workbookMaker)
        {

            this.workbookMaker = workbookMaker;
            setExcel();

        }


        public void setExcel()
        { 
            this.excel = workbookMaker.getExcel();

            setExcelFile();
            setWorkSheet();
            
            
            
        }

        public void setExcelFile()
        {
            this.excelFile = workbookMaker.getExcelFile();
        }

        
       
        public void setWorkSheet()
        {

            this.worksheet = this.excel.Workbook.Worksheets[1];
            // set WorkSheet for saving data
            
        }

        public ExcelWorksheet getWorkSheet() => this.worksheet;
        //public ValueObject getReadVo() => this.ReadVo;

      
        public void setDataInfo(WikiWordParser parser)
        {

            this.parser = parser;
            vo = new ValueObject();

            vo.setColumnTitle(this.parser.getTitle());
            vo.setCntInCol(this.parser.getWordCnt());
            //.setWords(this.parser.getWords());
            // set Words array


            
        }


        public void writeData(ValueObject vo)
        {
            worksheet.Cells["A1"].Value = this.vo.getColumnTitle();

            for(int index = 1; index <= this.vo.getCntInCol(); index++)
            {
                worksheet.Cells["A" + (index+2)].Value = vo.getWords()[index-1];
            }


            saveData();
        }

    
         
        private void saveData()
        {
            
            excel.SaveAs(excelFile);

            // Excel File Save
        }

        public bool checkData()
        {

            string wordTemp;
            ValueObject vo = new ValueObject();


            try
            {
                wordTemp = worksheet.Cells["A1"].Value.ToString();
            }
            catch (NullReferenceException)
            {
                return true;
            }

            return false;
                          
        }

        public WordInfo readData()
        {
            string wordTemp;
                   
            WordInfo wordInfo = new WordInfo();

            List <string> words = new List<string>();


            for (int index = 1; index <= vo.getCntInCol(); index++)
            {
                //worksheet.Cells["A" + (index + 2)].Value = ReadVo.getWords()[index - 1];

                try { 
                    wordTemp = worksheet.Cells["A" + (index + 2)].Value.ToString(); 
                }
                catch (NullReferenceException)
                {
                    wordTemp = "";
                }
                words.Add(wordTemp);
                
            }

            wordInfo.setWords(words);

            return wordInfo;
        }

    }
}
