using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InWordCheckEditor
{
    public partial class Editor : Form
    {

        Works works;
        DataAccessObject dao;
        //List<int> differentWordIndex;

        WordInfo wordInfo;

        public Editor()
        {
            InitializeComponent();
            
            works = new Works();

           
            this.dao = works.getDao();
            this.wordInfo = works.getWordInfo();

            this.initData.DoWork += new DoWorkEventHandler(initData_DoWork);
            this.initData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(initData_RunWorkerCompleted);

            this.btn_initData.Click += new EventHandler(btn_initData_Click);
            this.TextBox.KeyDown += new KeyEventHandler(TextBox_KeyDown);

            //this.wordChecker.DoWork += wordChecker_DoWork;

              
        }


        public void btn_initData_Click(object sender, EventArgs e)
        {


            if (!this.initData.IsBusy)
            {

                this.initData.RunWorkerAsync();
                this.btn_initData.Text = "엑셀 데이터 초기화중...";
                this.btn_initData.Enabled = false;
            }


        }

        private void wordChecker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void initData_DoWork(object sender, DoWorkEventArgs e)
        {
            works.initWordData();

        }

        private void initData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("엑셀 데이터 초기화 작업이 완료되었습니다.", "엑셀 데이터 초기화 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.btn_initData.Text = "엑셀 데이터 초기화";
            this.btn_initData.Enabled = true;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            int start = 0;
            int end = TextBox.Text.LastIndexOf(TextBox.Text);
            string searchWord = "";
            List<string> words;


            words = wordInfo.getWords();
            
            if (e.KeyCode == Keys.Enter)
            {

               

                    /*
                    nowLine = TextBox.GetLineFromCharIndex(TextBox.SelectionStart);

                    lineStringLength = TextBox.Lines[nowLine].Length - 1;
                    string lineString = TextBox.Lines[TextBox.Lines.Length - 1];

                    
                    ValueObject wordCheckVo;
                    
                    wordCheckVo = works.wordCheck(lineString);

                    TextBox.Select(;
                    
                    TextBox.SelectedText = "";

                    for (int i = 0;  i < wordCheckVo.getDifferentWordIndex().Count; i++)
                    {

                        
                        
                        TextBox.Select(TextBox.Lines[TextBox.Lines.Length - 1][wordCheckVo.getDifferentWordIndex()[i]], wordCheckVo.getWordLength()[i]);
                        TextBox.SelectionColor = Color.Red;
                        
                        

                        

                        

                        
                    }

                */


                while(start < end)
                {
                    
                    for(int i = 0; i < words.Count; i++)
                    {
                        searchWord = words[i];
                        TextBox.Find(searchWord, start, TextBox.TextLength, RichTextBoxFinds.MatchCase);
                        TextBox.SelectionBackColor = Color.Red;
                    }
                    
                }

               


            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }


}
