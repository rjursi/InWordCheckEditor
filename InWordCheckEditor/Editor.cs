using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace InWordCheckEditor
{
    public partial class Editor : Form
    {

        Works works;
        DataAccessObject dao;

        List<string> words;
        WordInfo wordInfo;

      
        public Editor()
        {
            InitializeComponent();

            
            works = new Works();

            

            this.dao = works.getDao();
            this.wordInfo = works.getWordInfo();
            words = wordInfo.getWords();

            this.initData.DoWork += new DoWorkEventHandler(initData_DoWork);
            this.initData.RunWorkerCompleted += new RunWorkerCompletedEventHandler(initData_RunWorkerCompleted);

            this.btn_initData.Click += new EventHandler(btn_initData_Click);

            

              
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
            if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                
                if (!wordChecker.IsBusy)
                    wordChecker.RunWorkerAsync();

            }
            else
            {
                TextBox.SelectionColor = Color.Black;
            }

            
        }

        private void Editor_Load(object sender, EventArgs e)
        {

        }

        private void wordChecker_DoWork(object sender, DoWorkEventArgs e)
        {

            Action findWork = () =>
            {

                int index = 0;
                string searchWord = "";

                int lastIndex = 0;
                int found = -1;
                int cursorIndexTemp = TextBox.SelectionStart;
                int newLineLastIndex = 0;


                newLineLastIndex = TextBox.Text.LastIndexOf("\\n");
                if(newLineLastIndex == -1)
                {
                    newLineLastIndex = 0;
                }
                else
                {
                    index = cursorIndexTemp - newLineLastIndex;
                }

                

                lastIndex = cursorIndexTemp;

                TextBox.Select(index, lastIndex);
                TextBox.SelectionColor = Color.Red;

                for (int i = 0; i < words.Count; i++)
                {

                    searchWord = words[i];
                    

                    while (index < lastIndex)
                    {
                        
                        found = TextBox.Find(searchWord, index, lastIndex, RichTextBoxFinds.None);

                        if(found == -1)
                        {
                            break;
                        }
                        TextBox.SelectionColor = Color.Black;                        
                        index = TextBox.Text.IndexOf(searchWord, index) + 1;
                    }

                    index = newLineLastIndex;
                    // Search point Init
                }

                
                TextBox.SelectionStart = cursorIndexTemp;
                
                TextBox.DeselectAll();
                TextBox.SelectionColor = Color.Black;
                
                
            };


            this.TextBox.Invoke(findWork);
            

        }


    }

}


