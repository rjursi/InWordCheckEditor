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
            this.btn_initData = new System.Windows.Forms.Button();
            this.wordChecker = new System.ComponentModel.BackgroundWorker();
            this.initData = new System.ComponentModel.BackgroundWorker();
            this.TextBox = new InWordCheckEditor.RichTextBoxIme();
            this.SuspendLayout();
            // 
            // btn_initData
            // 
            this.btn_initData.Location = new System.Drawing.Point(13, 96);
            this.btn_initData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_initData.Name = "btn_initData";
            this.btn_initData.Size = new System.Drawing.Size(431, 38);
            this.btn_initData.TabIndex = 1;
            this.btn_initData.Text = "엑셀 데이터 초기화";
            this.btn_initData.UseVisualStyleBackColor = true;
            this.btn_initData.Click += new System.EventHandler(this.btn_initData_Click);
            // 
            // wordChecker
            // 
            this.wordChecker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wordChecker_DoWork);
            // 
            // initData
            // 
            this.initData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.initData_DoWork);
            // 
            // TextBox
            // 
            this.TextBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.TextBox.Location = new System.Drawing.Point(13, 149);
            this.TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(432, 258);
            this.TextBox.TabIndex = 2;
            this.TextBox.Text = "";
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 415);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.btn_initData);
            this.ImeMode = System.Windows.Forms.ImeMode.HangulFull;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Editor";
            this.Text = "InWordCheckEditor";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_initData;
        private System.ComponentModel.BackgroundWorker wordChecker;
        private System.ComponentModel.BackgroundWorker initData;
        private RichTextBoxIme TextBox;
    }
}

