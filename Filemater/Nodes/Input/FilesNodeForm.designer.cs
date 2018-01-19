namespace Filemater.Nodes
{
    partial class FilesNodeForm
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
            this.ctrlTargets = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlRemoveTarget = new System.Windows.Forms.Button();
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
            // ctrlTargets
            // 
            this.ctrlTargets.AllowDrop = true;
            this.ctrlTargets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlTargets.FormattingEnabled = true;
            this.ctrlTargets.HorizontalScrollbar = true;
            this.ctrlTargets.ItemHeight = 12;
            this.ctrlTargets.Location = new System.Drawing.Point(16, 72);
            this.ctrlTargets.Name = "ctrlTargets";
            this.ctrlTargets.Size = new System.Drawing.Size(272, 232);
            this.ctrlTargets.TabIndex = 9;
            this.ctrlTargets.DragDrop += new System.Windows.Forms.DragEventHandler(this.ctrlTargets_DragDrop);
            this.ctrlTargets.DragEnter += new System.Windows.Forms.DragEventHandler(this.ctrlTargets_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "対象: 追加する場合は↓にドラッグ＆ドロップしてください";
            // 
            // ctrlRemoveTarget
            // 
            this.ctrlRemoveTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlRemoveTarget.Location = new System.Drawing.Point(16, 312);
            this.ctrlRemoveTarget.Name = "ctrlRemoveTarget";
            this.ctrlRemoveTarget.Size = new System.Drawing.Size(75, 23);
            this.ctrlRemoveTarget.TabIndex = 12;
            this.ctrlRemoveTarget.Text = "削除";
            this.ctrlRemoveTarget.UseVisualStyleBackColor = true;
            this.ctrlRemoveTarget.Click += new System.EventHandler(this.ctrlRemoveTarget_Click);
            // 
            // ctrlOptionRecursive
            // 
            this.ctrlOptionRecursive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlOptionRecursive.AutoSize = true;
            this.ctrlOptionRecursive.Location = new System.Drawing.Point(16, 352);
            this.ctrlOptionRecursive.Name = "ctrlOptionRecursive";
            this.ctrlOptionRecursive.Size = new System.Drawing.Size(92, 16);
            this.ctrlOptionRecursive.TabIndex = 13;
            this.ctrlOptionRecursive.Text = "サブディレクトリ";
            this.ctrlOptionRecursive.UseVisualStyleBackColor = true;
            this.ctrlOptionRecursive.CheckedChanged += new System.EventHandler(this.ctrlOptionRecursive_CheckedChanged);
            // 
            // ctrlOptionFile
            // 
            this.ctrlOptionFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlOptionFile.AutoSize = true;
            this.ctrlOptionFile.Location = new System.Drawing.Point(16, 376);
            this.ctrlOptionFile.Name = "ctrlOptionFile";
            this.ctrlOptionFile.Size = new System.Drawing.Size(58, 16);
            this.ctrlOptionFile.TabIndex = 14;
            this.ctrlOptionFile.Text = "ファイル";
            this.ctrlOptionFile.UseVisualStyleBackColor = true;
            this.ctrlOptionFile.CheckedChanged += new System.EventHandler(this.ctrlOptionFile_CheckedChanged);
            // 
            // ctrlOptionFolder
            // 
            this.ctrlOptionFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctrlOptionFolder.AutoSize = true;
            this.ctrlOptionFolder.Location = new System.Drawing.Point(80, 376);
            this.ctrlOptionFolder.Name = "ctrlOptionFolder";
            this.ctrlOptionFolder.Size = new System.Drawing.Size(59, 16);
            this.ctrlOptionFolder.TabIndex = 15;
            this.ctrlOptionFolder.Text = "フォルダ";
            this.ctrlOptionFolder.UseVisualStyleBackColor = true;
            this.ctrlOptionFolder.CheckedChanged += new System.EventHandler(this.ctrlOptionFolder_CheckedChanged);
            // 
            // FilesInputNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlOptionFolder);
            this.Controls.Add(this.ctrlOptionFile);
            this.Controls.Add(this.ctrlOptionRecursive);
            this.Controls.Add(this.ctrlRemoveTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlTargets);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "FilesInputNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.ListBox ctrlTargets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ctrlRemoveTarget;
        private System.Windows.Forms.CheckBox ctrlOptionRecursive;
        private System.Windows.Forms.CheckBox ctrlOptionFile;
        private System.Windows.Forms.CheckBox ctrlOptionFolder;
    }
}
