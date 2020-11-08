using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO; // For using FileInfo
using System.Windows.Forms;

namespace InWordCheckEditor
{
    class WorkbookSetting
    {
        


        private Excel.Application excelApp;
        private Excel.Workbook excelWorkbook;
        private Excel.Worksheet excelWorksheet;
        
       
        public Excel.Worksheet ExcelWorksheet
        {
            set
            {
                this.excelWorksheet = value;
            }
            get
            {
                return this.excelWorksheet;
            }
        }


        public void SelectWorksheet(int level = 1)
        {
            excelWorksheet = this.excelWorkbook.Worksheets.get_Item(level);   // 엑셀 시트 설정

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

        public bool OpenExcelFile()
        {

            using (OpenFileDialog OpenFileDialog = new OpenFileDialog())
            {

                OpenFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                
                if (OpenFileDialog.ShowDialog() == DialogResult.OK)
                {

                    string filepath = OpenFileDialog.FileName;

                    this.excelApp = new Excel.Application();
                    this.excelWorkbook = excelApp.Workbooks.Open(filepath);

                    MessageBox.Show("한글 데이터를 가져왔습니다.", "데이터 로드 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.SelectWorksheet();
                    return true;
                }

                return false;
            }
        }



    }
}
