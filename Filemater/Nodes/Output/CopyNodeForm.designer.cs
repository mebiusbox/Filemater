namespace Filemater.Nodes.Output
{
    partial class CopyNodeForm
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
            this.ctrlOutputLocationSelect = new System.Windows.Forms.Button();
            this.ctrlOutputLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlPriority = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlOutputLocationSelect
            // 
            this.ctrlOutputLocationSelect.Location = new System.Drawing.Point(88, 64);
            this.ctrlOutputLocationSelect.Name = "ctrlOutputLocationSelect";
            this.ctrlOutputLocationSelect.Size = new System.Drawing.Size(75, 23);
            this.ctrlOutputLocationSelect.TabIndex = 52;
            this.ctrlOutputLocationSelect.Text = "参照...";
            this.ctrlOutputLocationSelect.UseVisualStyleBackColor = true;
            this.ctrlOutputLocationSelect.Click += new System.EventHandler(this.ctrlOutputLocationSelect_Click);
            // 
            // ctrlOutputLocation
            // 
            this.ctrlOutputLocation.AllowDrop = true;
            this.ctrlOutputLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlOutputLocation.Location = new System.Drawing.Point(88, 40);
            this.ctrlOutputLocation.Name = "ctrlOutputLocation";
            this.ctrlOutputLocation.Size = new System.Drawing.Size(200, 19);
            this.ctrlOutputLocation.TabIndex = 51;
            this.ctrlOutputLocation.TextChanged += new System.EventHandler(this.ctrlOutputLocation_TextChanged);
            this.ctrlOutputLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.ctrlOutputLocation_DragDrop);
            this.ctrlOutputLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.ctrlOutputLocation_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "場所:";
            // 
            // ctrlPriority
            // 
            this.ctrlPriority.Location = new System.Drawing.Point(88, 8);
            this.ctrlPriority.Name = "ctrlPriority";
            this.ctrlPriority.Size = new System.Drawing.Size(56, 19);
            this.ctrlPriority.TabIndex = 49;
            this.ctrlPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlPriority.ValueChanged += new System.EventHandler(this.ctrlPriority_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "優先度:";
            // 
            // CopyOutputNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlOutputLocationSelect);
            this.Controls.Add(this.ctrlOutputLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "CopyOutputNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ctrlOutputLocationSelect;
        private System.Windows.Forms.TextBox ctrlOutputLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
