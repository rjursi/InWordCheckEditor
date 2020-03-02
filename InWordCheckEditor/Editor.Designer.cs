using System.Drawing;

namespace InWordCheckEditor
{
    partial class Editor
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.initData = new System.ComponentModel.BackgroundWorker();
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.wordChecker = new System.ComponentModel.BackgroundWorker();
            this.menu_editorMain = new System.Windows.Forms.MenuStrip();
            this.menu_callFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_chooseLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_easyLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_normalLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_hardLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_useCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_editorMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TextBox.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.TextBox.Location = new System.Drawing.Point(12, 36);
            this.TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(940, 555);
            this.TextBox.TabIndex = 2;
            this.TextBox.Text = "";
            this.TextBox.SelectionChanged += new System.EventHandler(this.TextBox_SelectionChanged);
            // 
            // wordChecker
            // 
            this.wordChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wordChecker_DoWork);
            // 
            // menu_editorMain
            // 
            this.menu_editorMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_editorMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_callFile,
            this.menu_chooseLevel,
            this.btn_useCheck});
            this.menu_editorMain.Location = new System.Drawing.Point(0, 0);
            this.menu_editorMain.Name = "menu_editorMain";
            this.menu_editorMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menu_editorMain.Size = new System.Drawing.Size(964, 24);
            this.menu_editorMain.TabIndex = 3;
            // 
            // menu_callFile
            // 
            this.menu_callFile.Name = "menu_callFile";
            this.menu_callFile.Size = new System.Drawing.Size(95, 20);
            this.menu_callFile.Text = "파일 불러오기";
            this.menu_callFile.Click += new System.EventHandler(this.menu_callFile_Click);
            // 
            // menu_chooseLevel
            // 
            this.menu_chooseLevel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_easyLevel,
            this.btn_normalLevel,
            this.btn_hardLevel});
            this.menu_chooseLevel.Name = "menu_chooseLevel";
            this.menu_chooseLevel.Size = new System.Drawing.Size(71, 20);
            this.menu_chooseLevel.Text = "등급 선택";
            // 
            // btn_easyLevel
            // 
            this.btn_easyLevel.Name = "btn_easyLevel";
            this.btn_easyLevel.Size = new System.Drawing.Size(98, 22);
            this.btn_easyLevel.Text = "초급";
            this.btn_easyLevel.Click += new System.EventHandler(this.btn_easyLevel_Click);
            // 
            // btn_normalLevel
            // 
            this.btn_normalLevel.Name = "btn_normalLevel";
            this.btn_normalLevel.Size = new System.Drawing.Size(98, 22);
            this.btn_normalLevel.Text = "중급";
            this.btn_normalLevel.Click += new System.EventHandler(this.btn_normalLevel_Click);
            // 
            // btn_hardLevel
            // 
            this.btn_hardLevel.Name = "btn_hardLevel";
            this.btn_hardLevel.Size = new System.Drawing.Size(98, 22);
            this.btn_hardLevel.Text = "고급";
            this.btn_hardLevel.Click += new System.EventHandler(this.btn_hardLevel_Click);
            // 
            // btn_useCheck
            // 
            this.btn_useCheck.Name = "btn_useCheck";
            this.btn_useCheck.Size = new System.Drawing.Size(95, 20);
            this.btn_useCheck.Text = "사용가능 체크";
            this.btn_useCheck.Click += new System.EventHandler(this.btn_useCheck_Click);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 601);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.menu_editorMain);
            this.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.MainMenuStrip = this.menu_editorMain;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Editor";
            this.Text = "InWordCheckEditor";
            this.menu_editorMain.ResumeLayout(false);
            this.menu_editorMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker initData;
        private System.Windows.Forms.RichTextBox TextBox;
        private System.ComponentModel.BackgroundWorker wordChecker;
        private System.Windows.Forms.MenuStrip menu_editorMain;
        private System.Windows.Forms.ToolStripMenuItem menu_callFile;
        private System.Windows.Forms.ToolStripMenuItem menu_chooseLevel;
        private System.Windows.Forms.ToolStripMenuItem btn_easyLevel;
        private System.Windows.Forms.ToolStripMenuItem btn_normalLevel;
        private System.Windows.Forms.ToolStripMenuItem btn_hardLevel;
        private System.Windows.Forms.ToolStripMenuItem btn_useCheck;
    }
}

