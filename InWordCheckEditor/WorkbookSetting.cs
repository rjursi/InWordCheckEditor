using System;
using OfficeOpenXml;
using System.IO; // For using FileInfo
using System.Windows.Forms;

namespace InWordCheckEditor
{
    class WorkbookSetting
    {
        


        private ExcelPackage excel;
        private FileInfo excelFile;
        private ExcelWorksheet worksheet;
        
       

        public FileInfo getExcelFile() => excelFile;

        public ExcelPackage getExcel() => excel;

        public ExcelWorksheet getWorksheet() => worksheet;


        public void selectWorksheet(int level = 1)
        {
            worksheet = excel.Workbook.Worksheets[level];
            // 엑셀 시트 설정

            switch (level)
            {
                case 1:
                    MessageBox.Show("초급 단계로 설정되었습니다.", "단계 변경",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show("중급 단계로 설정되었습니다.", "단계 변경", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 3:
                    MessageBox.Show("고급 단계로 설정되었습니다.", "단계 변경", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;


            }



        }

        public bool selectExcelFile()
        {

            string filePath;

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "excelData\\";
                fileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                fileDialog.FilterIndex = 1;
                fileDialog.RestoreDirectory = true;


                if (fileDialog.ShowDialog() == DialogResult.OK)
                {

                    filePath = fileDialog.FileName;

                    excelFile = new FileInfo(filePath);
                    excel = new ExcelPackage(excelFile);

                    MessageBox.Show("한글 데이터를 가져왔습니다.", "데이터 로드 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }

                return false;
            }
        }



    }
}
