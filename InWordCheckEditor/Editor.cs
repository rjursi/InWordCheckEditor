﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace InWordCheckEditor
{
    public partial class Editor : Form
    {

        WorkbookSetting workbook;
        WorksheetReader worksheetReader;
        DataInfo wordDataInfo;
        List<string> words;
       



        public Editor()
        {
            InitializeComponent();
              
        }



        private void wordChecker_DoWork(object sender, DoWorkEventArgs e)
        {

            Action findWork = () =>
            {
                
                int index = 0;
                int cursorTemp = TextBox.SelectionStart;
                int finded = 0;


                TextBox.SelectAll();
                TextBox.SelectionColor = Color.Red;
                TextBox.DeselectAll();

               
                for(int cnt = 0; cnt < this.wordDataInfo.getWordCnt(); cnt++)
                {
                    while(index < TextBox.Text.LastIndexOf(words[cnt]))
                    {
                        finded = TextBox.Find(words[cnt], index, TextBox.TextLength, RichTextBoxFinds.None);
                        if (finded == -1)
                        {   
                            break;
                        }

                        TextBox.SelectionColor = Color.Black;
                        
                        index = TextBox.Text.IndexOf(words[cnt], index) + 1;
                        
                    }

                    index = 0;
                }
                
                TextBox.SelectionStart = cursorTemp;
                TextBox.DeselectAll();
                TextBox.SelectionColor = Color.Black;


                // Solution 1. Use .Find and SelectionColor 


            };


            this.TextBox.Invoke(findWork);
            

        }

       

        
        private void menu_callFile_Click(object sender, EventArgs e)
        {

            bool isCalled;

            //MessageBox.Show(strRtf);
            workbook = new WorkbookSetting();
            
            isCalled = workbook.selectExcelFile();

            if (!isCalled)
            {
                return;
            }

            workbook.selectWorksheet();
            // Default easy Level Select


            worksheetReader = new WorksheetReader(workbook);

            wordDataInfo = worksheetReader.getWordDataInfo();

            // Default get word easy level


            this.words = wordDataInfo.getWords();
        }


        private void LevelSelect(int level)
        {

            if (workbook != null)
            {
                workbook.selectWorksheet(level);
                worksheetReader.setLevelWordInfo(workbook);

                wordDataInfo = worksheetReader.getWordDataInfo();
                words = wordDataInfo.getWords();

                if (!wordChecker.IsBusy)
                    wordChecker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("한글 데이터 엑셀 파일이 로드되지 않았습니다.", "데이터 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btn_easyLevel_Click(object sender, EventArgs e)
        {
            int level = 1;

            LevelSelect(level);
            
            
        }

        private void btn_normalLevel_Click(object sender, EventArgs e)
        {
            int level = 2;

            LevelSelect(level);
        }

        private void btn_hardLevel_Click(object sender, EventArgs e)
        {
            int level = 3;

            LevelSelect(level);

        }

        

        private void btn_useCheck_Click(object sender, EventArgs e)
        {
            if (workbook != null)
            {
                if (!wordChecker.IsBusy)
                    wordChecker.RunWorkerAsync();
            }
            else {

                MessageBox.Show("한글 데이터 엑셀 파일이 로드되지 않았습니다.", "데이터 없음", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (!wordChecker.IsBusy) { 
                
                TextBox.SelectionColor = Color.Black;
            }
        }
    }

}


