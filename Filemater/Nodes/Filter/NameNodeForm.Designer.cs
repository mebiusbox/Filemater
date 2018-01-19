namespace Filemater.Nodes
{
    partial class NameNodeForm
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
            this.ctrlOptionRegularExp = new System.Windows.Forms.RadioButton();
            this.ctrlOptionWildcard = new System.Windows.Forms.RadioButton();
            this.ctrlOptionLike = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlOptionZenkakuSensitive = new System.Windows.Forms.CheckBox();
            this.ctrlOptionCaseSensitive = new System.Windows.Forms.CheckBox();
            this.ctrlWord = new System.Windows.Forms.TextBox();
            this.ctrlTarget = new System.Windows.Forms.ComboBox();
            this.ctrlPriority = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlOptionRegularExp
            // 
            this.ctrlOptionRegularExp.AutoSize = true;
            this.ctrlOptionRegularExp.Location = new System.Drawing.Point(88, 204);
            this.ctrlOptionRegularExp.Name = "ctrlOptionRegularExp";
            this.ctrlOptionRegularExp.Size = new System.Drawing.Size(71, 16);
            this.ctrlOptionRegularExp.TabIndex = 25;
            this.ctrlOptionRegularExp.TabStop = true;
            this.ctrlOptionRegularExp.Text = "正規表現";
            this.ctrlOptionRegularExp.UseVisualStyleBackColor = true;
            this.ctrlOptionRegularExp.CheckedChanged += new System.EventHandler(this.ctrlOptionRegularExp_CheckedChanged);
            // 
            // ctrlOptionWildcard
            // 
            this.ctrlOptionWildcard.AutoSize = true;
            this.ctrlOptionWildcard.Location = new System.Drawing.Point(88, 180);
            this.ctrlOptionWildcard.Name = "ctrlOptionWildcard";
            this.ctrlOptionWildcard.Size = new System.Drawing.Size(88, 16);
            this.ctrlOptionWildcard.TabIndex = 24;
            this.ctrlOptionWildcard.TabStop = true;
            this.ctrlOptionWildcard.Text = "ワイルドカード";
            this.ctrlOptionWildcard.UseVisualStyleBackColor = true;
            this.ctrlOptionWildcard.CheckedChanged += new System.EventHandler(this.ctrlOptionWildcard_CheckedChanged);
            // 
            // ctrlOptionLike
            // 
            this.ctrlOptionLike.AutoSize = true;
            this.ctrlOptionLike.Location = new System.Drawing.Point(88, 156);
            this.ctrlOptionLike.Name = "ctrlOptionLike";
            this.ctrlOptionLike.Size = new System.Drawing.Size(62, 16);
            this.ctrlOptionLike.TabIndex = 23;
            this.ctrlOptionLike.TabStop = true;
            this.ctrlOptionLike.Text = "あいまい";
            this.ctrlOptionLike.UseVisualStyleBackColor = true;
            this.ctrlOptionLike.CheckedChanged += new System.EventHandler(this.ctrlOptionLike_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "オプション:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "検索文字:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "対象:";
            // 
            // ctrlOptionZenkakuSensitive
            // 
            this.ctrlOptionZenkakuSensitive.AutoSize = true;
            this.ctrlOptionZenkakuSensitive.Location = new System.Drawing.Point(88, 132);
            this.ctrlOptionZenkakuSensitive.Name = "ctrlOptionZenkakuSensitive";
            this.ctrlOptionZenkakuSensitive.Size = new System.Drawing.Size(105, 16);
            this.ctrlOptionZenkakuSensitive.TabIndex = 17;
            this.ctrlOptionZenkakuSensitive.Text = "全角半角を区別";
            this.ctrlOptionZenkakuSensitive.UseVisualStyleBackColor = true;
            this.ctrlOptionZenkakuSensitive.CheckedChanged += new System.EventHandler(this.ctrlOptionZenkakuSensitive_CheckedChanged);
            // 
            // ctrlOptionCaseSensitive
            // 
            this.ctrlOptionCaseSensitive.AutoSize = true;
            this.ctrlOptionCaseSensitive.Location = new System.Drawing.Point(88, 108);
            this.ctrlOptionCaseSensitive.Name = "ctrlOptionCaseSensitive";
            this.ctrlOptionCaseSensitive.Size = new System.Drawing.Size(129, 16);
            this.ctrlOptionCaseSensitive.TabIndex = 16;
            this.ctrlOptionCaseSensitive.Text = "小文字大文字を区別";
            this.ctrlOptionCaseSensitive.UseVisualStyleBackColor = true;
            this.ctrlOptionCaseSensitive.CheckedChanged += new System.EventHandler(this.ctrlOptionCaseSensitive_CheckedChanged);
            // 
            // ctrlWord
            // 
            this.ctrlWord.Location = new System.Drawing.Point(88, 73);
            this.ctrlWord.Name = "ctrlWord";
            this.ctrlWord.Size = new System.Drawing.Size(184, 19);
            this.ctrlWord.TabIndex = 15;
            this.ctrlWord.TextChanged += new System.EventHandler(this.ctrlWord_TextChanged);
            // 
            // ctrlTarget
            // 
            this.ctrlTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlTarget.FormattingEnabled = true;
            this.ctrlTarget.Location = new System.Drawing.Point(88, 40);
            this.ctrlTarget.Name = "ctrlTarget";
            this.ctrlTarget.Size = new System.Drawing.Size(184, 20);
            this.ctrlTarget.TabIndex = 14;
            this.ctrlTarget.SelectedIndexChanged += new System.EventHandler(this.ctrlTarget_SelectedIndexChanged);
            // 
            // ctrlPriority
            // 
            this.ctrlPriority.Location = new System.Drawing.Point(88, 8);
            this.ctrlPriority.Name = "ctrlPriority";
            this.ctrlPriority.Size = new System.Drawing.Size(56, 19);
            this.ctrlPriority.TabIndex = 38;
            this.ctrlPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlPriority.ValueChanged += new System.EventHandler(this.ctrlPriority_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "優先度:";
            // 
            // NameFilterNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlOptionRegularExp);
            this.Controls.Add(this.ctrlOptionWildcard);
            this.Controls.Add(this.ctrlOptionLike);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlOptionZenkakuSensitive);
            this.Controls.Add(this.ctrlOptionCaseSensitive);
            this.Controls.Add(this.ctrlWord);
            this.Controls.Add(this.ctrlTarget);
            this.Name = "NameFilterNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ctrlOptionRegularExp;
        private System.Windows.Forms.RadioButton ctrlOptionWildcard;
        private System.Windows.Forms.RadioButton ctrlOptionLike;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ctrlOptionZenkakuSensitive;
        private System.Windows.Forms.CheckBox ctrlOptionCaseSensitive;
        private System.Windows.Forms.TextBox ctrlWord;
        private System.Windows.Forms.ComboBox ctrlTarget;
        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
    }
}
