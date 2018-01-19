namespace Filemater.Nodes.Output
{
    partial class ProgramNodeForm
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
            this.ctrlProgram = new System.Windows.Forms.TextBox();
            this.ctrlProgramSelect = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlArguments = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlWorkdir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ctrlWindowStyle = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPriority
            // 
            this.ctrlPriority.Location = new System.Drawing.Point(97, 8);
            this.ctrlPriority.Name = "ctrlPriority";
            this.ctrlPriority.Size = new System.Drawing.Size(56, 19);
            this.ctrlPriority.TabIndex = 44;
            this.ctrlPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlPriority.ValueChanged += new System.EventHandler(this.ctrlPriority_ValueChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 43;
            this.label1.Text = "優先度 :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlProgram
            // 
            this.ctrlProgram.AllowDrop = true;
            this.ctrlProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlProgram.Location = new System.Drawing.Point(97, 40);
            this.ctrlProgram.Name = "ctrlProgram";
            this.ctrlProgram.Size = new System.Drawing.Size(188, 19);
            this.ctrlProgram.TabIndex = 46;
            this.ctrlProgram.TextChanged += new System.EventHandler(this.ctrlProgram_TextChanged);
            // 
            // ctrlProgramSelect
            // 
            this.ctrlProgramSelect.Location = new System.Drawing.Point(97, 64);
            this.ctrlProgramSelect.Name = "ctrlProgramSelect";
            this.ctrlProgramSelect.Size = new System.Drawing.Size(75, 23);
            this.ctrlProgramSelect.TabIndex = 47;
            this.ctrlProgramSelect.Text = "参照...";
            this.ctrlProgramSelect.UseVisualStyleBackColor = true;
            this.ctrlProgramSelect.Click += new System.EventHandler(this.ctrlProgramSelect_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "プログラム :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(26, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "引数 :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlArguments
            // 
            this.ctrlArguments.AllowDrop = true;
            this.ctrlArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlArguments.Location = new System.Drawing.Point(97, 93);
            this.ctrlArguments.Name = "ctrlArguments";
            this.ctrlArguments.Size = new System.Drawing.Size(188, 19);
            this.ctrlArguments.TabIndex = 49;
            this.ctrlArguments.TextChanged += new System.EventHandler(this.ctrlArguments_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 12);
            this.label4.TabIndex = 52;
            this.label4.Text = "作業フォルダ :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlWorkdir
            // 
            this.ctrlWorkdir.AllowDrop = true;
            this.ctrlWorkdir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlWorkdir.Location = new System.Drawing.Point(97, 118);
            this.ctrlWorkdir.Name = "ctrlWorkdir";
            this.ctrlWorkdir.Size = new System.Drawing.Size(188, 19);
            this.ctrlWorkdir.TabIndex = 51;
            this.ctrlWorkdir.TextChanged += new System.EventHandler(this.ctrlWorkdir_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(26, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 54;
            this.label5.Text = "表示状態 :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlWindowStyle
            // 
            this.ctrlWindowStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlWindowStyle.FormattingEnabled = true;
            this.ctrlWindowStyle.Location = new System.Drawing.Point(97, 143);
            this.ctrlWindowStyle.Name = "ctrlWindowStyle";
            this.ctrlWindowStyle.Size = new System.Drawing.Size(121, 20);
            this.ctrlWindowStyle.TabIndex = 55;
            this.ctrlWindowStyle.SelectedIndexChanged += new System.EventHandler(this.ctrlWindowStyle_SelectedIndexChanged);
            // 
            // ProgramNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlWindowStyle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctrlWorkdir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlArguments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlProgramSelect);
            this.Controls.Add(this.ctrlProgram);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "ProgramNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ctrlProgram;
        private System.Windows.Forms.Button ctrlProgramSelect;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ctrlArguments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ctrlWorkdir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ctrlWindowStyle;
    }
}
