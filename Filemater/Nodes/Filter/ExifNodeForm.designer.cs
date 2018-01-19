namespace Filemater.Nodes.Filter
{
    partial class ExifNodeForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlTarget = new System.Windows.Forms.ComboBox();
            this.ctrlNumber1 = new System.Windows.Forms.NumericUpDown();
            this.ctrlNumber2 = new System.Windows.Forms.NumericUpDown();
            this.ctrlNumberMethod = new System.Windows.Forms.ComboBox();
            this.ctrlSearchLabel = new System.Windows.Forms.Label();
            this.ctrlSearchWord = new System.Windows.Forms.TextBox();
            this.ctrlConstant = new System.Windows.Forms.ComboBox();
            this.ctrlModeString = new System.Windows.Forms.RadioButton();
            this.ctrlModeConstant = new System.Windows.Forms.RadioButton();
            this.ctrlModeNumber = new System.Windows.Forms.RadioButton();
            this.ctrlModeDate = new System.Windows.Forms.RadioButton();
            this.ctrlTime1 = new System.Windows.Forms.DateTimePicker();
            this.ctrlTime2 = new System.Windows.Forms.DateTimePicker();
            this.ctrlTimeMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNumber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNumber2)).BeginInit();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 45;
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
            // ctrlNumber1
            // 
            this.ctrlNumber1.DecimalPlaces = 2;
            this.ctrlNumber1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ctrlNumber1.Location = new System.Drawing.Point(48, 224);
            this.ctrlNumber1.Name = "ctrlNumber1";
            this.ctrlNumber1.Size = new System.Drawing.Size(64, 19);
            this.ctrlNumber1.TabIndex = 7;
            this.ctrlNumber1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlNumber1.ValueChanged += new System.EventHandler(this.ctrlNumber1_ValueChanged);
            // 
            // ctrlNumber2
            // 
            this.ctrlNumber2.DecimalPlaces = 2;
            this.ctrlNumber2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ctrlNumber2.Location = new System.Drawing.Point(128, 224);
            this.ctrlNumber2.Name = "ctrlNumber2";
            this.ctrlNumber2.Size = new System.Drawing.Size(64, 19);
            this.ctrlNumber2.TabIndex = 8;
            this.ctrlNumber2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlNumber2.ValueChanged += new System.EventHandler(this.ctrlNumber2_ValueChanged);
            // 
            // ctrlNumberMethod
            // 
            this.ctrlNumberMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlNumberMethod.FormattingEnabled = true;
            this.ctrlNumberMethod.Location = new System.Drawing.Point(200, 224);
            this.ctrlNumberMethod.Name = "ctrlNumberMethod";
            this.ctrlNumberMethod.Size = new System.Drawing.Size(88, 20);
            this.ctrlNumberMethod.TabIndex = 9;
            this.ctrlNumberMethod.SelectedIndexChanged += new System.EventHandler(this.ctrlNumberMethod_SelectedIndexChanged);
            // 
            // ctrlSearchLabel
            // 
            this.ctrlSearchLabel.AutoSize = true;
            this.ctrlSearchLabel.Location = new System.Drawing.Point(48, 99);
            this.ctrlSearchLabel.Name = "ctrlSearchLabel";
            this.ctrlSearchLabel.Size = new System.Drawing.Size(55, 12);
            this.ctrlSearchLabel.TabIndex = 46;
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
            // ctrlConstant
            // 
            this.ctrlConstant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlConstant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlConstant.FormattingEnabled = true;
            this.ctrlConstant.Location = new System.Drawing.Point(48, 160);
            this.ctrlConstant.Name = "ctrlConstant";
            this.ctrlConstant.Size = new System.Drawing.Size(240, 20);
            this.ctrlConstant.TabIndex = 5;
            this.ctrlConstant.SelectedIndexChanged += new System.EventHandler(this.ctrlConstant_SelectedIndexChanged);
            // 
            // ctrlModeString
            // 
            this.ctrlModeString.AutoSize = true;
            this.ctrlModeString.Enabled = false;
            this.ctrlModeString.Location = new System.Drawing.Point(16, 72);
            this.ctrlModeString.Name = "ctrlModeString";
            this.ctrlModeString.Size = new System.Drawing.Size(59, 16);
            this.ctrlModeString.TabIndex = 2;
            this.ctrlModeString.TabStop = true;
            this.ctrlModeString.Text = "文字列";
            this.ctrlModeString.UseVisualStyleBackColor = true;
            // 
            // ctrlModeConstant
            // 
            this.ctrlModeConstant.AutoSize = true;
            this.ctrlModeConstant.Location = new System.Drawing.Point(16, 136);
            this.ctrlModeConstant.Name = "ctrlModeConstant";
            this.ctrlModeConstant.Size = new System.Drawing.Size(47, 16);
            this.ctrlModeConstant.TabIndex = 4;
            this.ctrlModeConstant.TabStop = true;
            this.ctrlModeConstant.Text = "定数";
            this.ctrlModeConstant.UseVisualStyleBackColor = true;
            // 
            // ctrlModeNumber
            // 
            this.ctrlModeNumber.AutoSize = true;
            this.ctrlModeNumber.Location = new System.Drawing.Point(16, 200);
            this.ctrlModeNumber.Name = "ctrlModeNumber";
            this.ctrlModeNumber.Size = new System.Drawing.Size(47, 16);
            this.ctrlModeNumber.TabIndex = 6;
            this.ctrlModeNumber.TabStop = true;
            this.ctrlModeNumber.Text = "数値";
            this.ctrlModeNumber.UseVisualStyleBackColor = true;
            // 
            // ctrlModeDate
            // 
            this.ctrlModeDate.AutoSize = true;
            this.ctrlModeDate.Location = new System.Drawing.Point(16, 264);
            this.ctrlModeDate.Name = "ctrlModeDate";
            this.ctrlModeDate.Size = new System.Drawing.Size(47, 16);
            this.ctrlModeDate.TabIndex = 10;
            this.ctrlModeDate.TabStop = true;
            this.ctrlModeDate.Text = "日時";
            this.ctrlModeDate.UseVisualStyleBackColor = true;
            // 
            // ctrlTime1
            // 
            this.ctrlTime1.Location = new System.Drawing.Point(48, 288);
            this.ctrlTime1.Name = "ctrlTime1";
            this.ctrlTime1.Size = new System.Drawing.Size(112, 19);
            this.ctrlTime1.TabIndex = 11;
            this.ctrlTime1.ValueChanged += new System.EventHandler(this.ctrlTime1_ValueChanged);
            // 
            // ctrlTime2
            // 
            this.ctrlTime2.Location = new System.Drawing.Point(176, 288);
            this.ctrlTime2.Name = "ctrlTime2";
            this.ctrlTime2.Size = new System.Drawing.Size(112, 19);
            this.ctrlTime2.TabIndex = 12;
            this.ctrlTime2.ValueChanged += new System.EventHandler(this.ctrlTime2_ValueChanged);
            // 
            // ctrlTimeMethod
            // 
            this.ctrlTimeMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlTimeMethod.FormattingEnabled = true;
            this.ctrlTimeMethod.Location = new System.Drawing.Point(48, 320);
            this.ctrlTimeMethod.Name = "ctrlTimeMethod";
            this.ctrlTimeMethod.Size = new System.Drawing.Size(112, 20);
            this.ctrlTimeMethod.TabIndex = 13;
            this.ctrlTimeMethod.SelectedIndexChanged += new System.EventHandler(this.ctrlTimeMethod_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 63;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 64;
            this.label4.Text = "-";
            // 
            // ExifFilterNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlTimeMethod);
            this.Controls.Add(this.ctrlTime2);
            this.Controls.Add(this.ctrlTime1);
            this.Controls.Add(this.ctrlModeDate);
            this.Controls.Add(this.ctrlModeNumber);
            this.Controls.Add(this.ctrlModeConstant);
            this.Controls.Add(this.ctrlModeString);
            this.Controls.Add(this.ctrlSearchLabel);
            this.Controls.Add(this.ctrlSearchWord);
            this.Controls.Add(this.ctrlConstant);
            this.Controls.Add(this.ctrlNumberMethod);
            this.Controls.Add(this.ctrlNumber2);
            this.Controls.Add(this.ctrlNumber1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlTarget);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "ExifFilterNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNumber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlNumber2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ctrlTarget;
        private System.Windows.Forms.NumericUpDown ctrlNumber1;
        private System.Windows.Forms.NumericUpDown ctrlNumber2;
        private System.Windows.Forms.ComboBox ctrlNumberMethod;
        private System.Windows.Forms.Label ctrlSearchLabel;
        private System.Windows.Forms.TextBox ctrlSearchWord;
        private System.Windows.Forms.ComboBox ctrlConstant;
        private System.Windows.Forms.RadioButton ctrlModeString;
        private System.Windows.Forms.RadioButton ctrlModeConstant;
        private System.Windows.Forms.RadioButton ctrlModeNumber;
        private System.Windows.Forms.RadioButton ctrlModeDate;
        private System.Windows.Forms.DateTimePicker ctrlTime1;
        private System.Windows.Forms.DateTimePicker ctrlTime2;
        private System.Windows.Forms.ComboBox ctrlTimeMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
