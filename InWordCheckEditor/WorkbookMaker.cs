using System;
using OfficeOpenXml;
using System.IO; // For using FileInfo



namespace InWordCheckEditor
{
    class WorkbookMaker
    {
        private string directoryPath;
        public ExcelPackage excel;
        public FileInfo excelFile;



        public FileInfo getExcelFile() => excelFile;

        public ExcelPackage getExcel() => excel;


        public WorkbookMaker()
        {
            directoryPath = AppDomain.CurrentDomain.BaseDirectory + "excelData\\";

            
            excelFile = new FileInfo(directoryPath + "words.xlsx");

            excel = new ExcelPackage(excelFile);
            makeDataDirectoryAndFile();



            if (excelFile.Exists == false)
            // 엑셀 파일이 없으면

            {
                excel.Workbook.Worksheets.Add("Words");

                excel.SaveAs(excelFile);
               
            }

        }


        private void makeDataDirectoryAndFile()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);
            if(directoryInfo.Exists == false)
            {
                directoryInfo.Create();
                // Create new Folder   

            }
        }
      
    }
}
