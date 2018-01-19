namespace Filemater.Nodes
{
    partial class ArgumentsNodeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlPriority = new System.Windows.Forms.NumericUpDown();
            this.ctrlOptionRecursive = new System.Windows.Forms.CheckBox();
            this.ctrlOptionFile = new System.Windows.Forms.CheckBox();
            this.ctrlOptionFolder = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "優先度:";
            // 
            // ctrlPriority
            // 
            this.ctrlPriority.Location = new System.Drawing.Point(64, 13);
            this.ctrlPriority.Name = "ctrlPriority";
            this.ctrlPriority.Size = new System.Drawing.Size(56, 19);
            this.ctrlPriority.TabIndex = 8;
            this.ctrlPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ctrlOptionRecursive
            // 
            this.ctrlOptionRecursive.AutoSize = true;
            this.ctrlOptionRecursive.Location = new System.Drawing.Point(18, 52);
            this.ctrlOptionRecursive.Name = "ctrlOptionRecursive";
            this.ctrlOptionRecursive.Size = new System.Drawing.Size(92, 16);
            this.ctrlOptionRecursive.TabIndex = 13;
            this.ctrlOptionRecursive.Text = "サブディレクトリ";
            this.ctrlOptionRecursive.UseVisualStyleBackColor = true;
            this.ctrlOptionRecursive.CheckedChanged += new System.EventHandler(this.ctrlOptionRecursive_CheckedChanged);
            // 
            // ctrlOptionFile
            // 
            this.ctrlOptionFile.AutoSize = true;
            this.ctrlOptionFile.Location = new System.Drawing.Point(18, 76);
            this.ctrlOptionFile.Name = "ctrlOptionFile";
            this.ctrlOptionFile.Size = new System.Drawing.Size(58, 16);
            this.ctrlOptionFile.TabIndex = 14;
            this.ctrlOptionFile.Text = "ファイル";
            this.ctrlOptionFile.UseVisualStyleBackColor = true;
            this.ctrlOptionFile.CheckedChanged += new System.EventHandler(this.ctrlOptionFile_CheckedChanged);
            // 
            // ctrlOptionFolder
            // 
            this.ctrlOptionFolder.AutoSize = true;
            this.ctrlOptionFolder.Location = new System.Drawing.Point(82, 76);
            this.ctrlOptionFolder.Name = "ctrlOptionFolder";
            this.ctrlOptionFolder.Size = new System.Drawing.Size(59, 16);
            this.ctrlOptionFolder.TabIndex = 15;
            this.ctrlOptionFolder.Text = "フォルダ";
            this.ctrlOptionFolder.UseVisualStyleBackColor = true;
            this.ctrlOptionFolder.CheckedChanged += new System.EventHandler(this.ctrlOptionFolder_CheckedChanged);
            // 
            // ArgumentsNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlOptionFolder);
            this.Controls.Add(this.ctrlOptionFile);
            this.Controls.Add(this.ctrlOptionRecursive);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "ArgumentsNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.CheckBox ctrlOptionRecursive;
        private System.Windows.Forms.CheckBox ctrlOptionFile;
        private System.Windows.Forms.CheckBox ctrlOptionFolder;
    }
}
