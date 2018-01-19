namespace Filemater.Nodes.Filter
{
    partial class ID3TagNodeForm
    {
        /// <summary> 
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナで生成されたコード

        /// <summary> 
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlPriority = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlModeNumber = new System.Windows.Forms.RadioButton();
            this.ctrlModeString = new System.Windows.Forms.RadioButton();
            this.ctrlSearchLabel = new System.Windows.Forms.Label();
            this.ctrlSearchWord = new System.Windows.Forms.TextBox();
            this.ctrlNumberMethod = new System.Windows.Forms.ComboBox();
            this.ctrlNumber2 = new System.Windows.Forms.NumericUpDown();
            this.ctrlNumber1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlTarget = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNumber2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNumber1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPriority
            // 
            this.ctrlPriority.Location = new System.Drawing.Point(88, 8);
            this.ctrlPriority.Name = "ctrlPriority";
            this.ctrlPriority.Size = new System.Drawing.Size(56, 19);
            this.ctrlPriority.TabIndex = 0;
            this.ctrlPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlPriority.ValueChanged += new System.EventHandler(this.ctrlPriority_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 39;
            this.label1.Text = "優先度:";
            // 
            // ctrlModeNumber
            // 
            this.ctrlModeNumber.AutoSize = true;
            this.ctrlModeNumber.Location = new System.Drawing.Point(16, 136);
            this.ctrlModeNumber.Name = "ctrlModeNumber";
            this.ctrlModeNumber.Size = new System.Drawing.Size(47, 16);
            this.ctrlModeNumber.TabIndex = 4;
            this.ctrlModeNumber.TabStop = true;
            this.ctrlModeNumber.Text = "数値";
            this.ctrlModeNumber.UseVisualStyleBackColor = true;
            this.ctrlModeNumber.CheckedChanged += new System.EventHandler(this.ctrlModeNumber_CheckedChanged);
            // 
            // ctrlModeString
            // 
            this.ctrlModeString.AutoSize = true;
            this.ctrlModeString.Location = new System.Drawing.Point(16, 72);
            this.ctrlModeString.Name = "ctrlModeString";
            this.ctrlModeString.Size = new System.Drawing.Size(59, 16);
            this.ctrlModeString.TabIndex = 2;
            this.ctrlModeString.TabStop = true;
            this.ctrlModeString.Text = "文字列";
            this.ctrlModeString.UseVisualStyleBackColor = true;
            this.ctrlModeString.CheckedChanged += new System.EventHandler(this.ctrlModeString_CheckedChanged);
            // 
            // ctrlSearchLabel
            // 
            this.ctrlSearchLabel.AutoSize = true;
            this.ctrlSearchLabel.Location = new System.Drawing.Point(48, 99);
            this.ctrlSearchLabel.Name = "ctrlSearchLabel";
            this.ctrlSearchLabel.Size = new System.Drawing.Size(55, 12);
            this.ctrlSearchLabel.TabIndex = 62;
            this.ctrlSearchLabel.Text = "検索文字:";
            // 
            // ctrlSearchWord
            // 
            this.ctrlSearchWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlSearchWord.Location = new System.Drawing.Point(112, 96);
            this.ctrlSearchWord.Name = "ctrlSearchWord";
            this.ctrlSearchWord.Size = new System.Drawing.Size(176, 19);
            this.ctrlSearchWord.TabIndex = 3;
            this.ctrlSearchWord.TextChanged += new System.EventHandler(this.ctrlSearchWord_TextChanged);
            // 
            // ctrlNumberMethod
            // 
            this.ctrlNumberMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlNumberMethod.FormattingEnabled = true;
            this.ctrlNumberMethod.Location = new System.Drawing.Point(200, 160);
            this.ctrlNumberMethod.Name = "ctrlNumberMethod";
            this.ctrlNumberMethod.Size = new System.Drawing.Size(88, 20);
            this.ctrlNumberMethod.TabIndex = 7;
            this.ctrlNumberMethod.SelectedIndexChanged += new System.EventHandler(this.ctrlNumberMethod_SelectedIndexChanged);
            // 
            // ctrlNumber2
            // 
            this.ctrlNumber2.Location = new System.Drawing.Point(128, 160);
            this.ctrlNumber2.Name = "ctrlNumber2";
            this.ctrlNumber2.Size = new System.Drawing.Size(64, 19);
            this.ctrlNumber2.TabIndex = 6;
            this.ctrlNumber2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlNumber2.ValueChanged += new System.EventHandler(this.ctrlNumber2_ValueChanged);
            // 
            // ctrlNumber1
            // 
            this.ctrlNumber1.Location = new System.Drawing.Point(48, 160);
            this.ctrlNumber1.Name = "ctrlNumber1";
            this.ctrlNumber1.Size = new System.Drawing.Size(64, 19);
            this.ctrlNumber1.TabIndex = 5;
            this.ctrlNumber1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlNumber1.ValueChanged += new System.EventHandler(this.ctrlNumber1_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 61;
            this.label2.Text = "対象:";
            // 
            // ctrlTarget
            // 
            this.ctrlTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlTarget.FormattingEnabled = true;
            this.ctrlTarget.Location = new System.Drawing.Point(88, 40);
            this.ctrlTarget.Name = "ctrlTarget";
            this.ctrlTarget.Size = new System.Drawing.Size(200, 20);
            this.ctrlTarget.TabIndex = 1;
            this.ctrlTarget.SelectedIndexChanged += new System.EventHandler(this.ctrlTarget_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 70;
            this.label3.Text = "-";
            // 
            // ID3TagFilterNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlModeNumber);
            this.Controls.Add(this.ctrlModeString);
            this.Controls.Add(this.ctrlSearchLabel);
            this.Controls.Add(this.ctrlSearchWord);
            this.Controls.Add(this.ctrlNumberMethod);
            this.Controls.Add(this.ctrlNumber2);
            this.Controls.Add(this.ctrlNumber1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlTarget);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "ID3TagFilterNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNumber2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNumber1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton ctrlModeNumber;
        private System.Windows.Forms.RadioButton ctrlModeString;
        private System.Windows.Forms.Label ctrlSearchLabel;
        private System.Windows.Forms.TextBox ctrlSearchWord;
        private System.Windows.Forms.ComboBox ctrlNumberMethod;
        private System.Windows.Forms.NumericUpDown ctrlNumber2;
        private System.Windows.Forms.NumericUpDown ctrlNumber1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ctrlTarget;
        private System.Windows.Forms.Label label3;
    }
}
