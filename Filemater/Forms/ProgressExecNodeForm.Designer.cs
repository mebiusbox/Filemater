namespace Filemater.Forms
{
    partial class ProgressExecNodeForm
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

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrlCancel = new System.Windows.Forms.Button();
            this.ctrlProgressText = new System.Windows.Forms.Label();
            this.ctrlProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // ctrlCancel
            // 
            this.ctrlCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ctrlCancel.Location = new System.Drawing.Point(112, 96);
            this.ctrlCancel.Name = "ctrlCancel";
            this.ctrlCancel.Size = new System.Drawing.Size(75, 23);
            this.ctrlCancel.TabIndex = 7;
            this.ctrlCancel.Text = "Cancel";
            this.ctrlCancel.UseVisualStyleBackColor = true;
            this.ctrlCancel.Click += new System.EventHandler(this.ctrlCancel_Click);
            // 
            // ctrlProgressText
            // 
            this.ctrlProgressText.Location = new System.Drawing.Point(248, 61);
            this.ctrlProgressText.Name = "ctrlProgressText";
            this.ctrlProgressText.Size = new System.Drawing.Size(35, 12);
            this.ctrlProgressText.TabIndex = 6;
            this.ctrlProgressText.Text = "text";
            this.ctrlProgressText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrlProgress
            // 
            this.ctrlProgress.Location = new System.Drawing.Point(16, 56);
            this.ctrlProgress.Name = "ctrlProgress";
            this.ctrlProgress.Size = new System.Drawing.Size(232, 23);
            this.ctrlProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ctrlProgress.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "しばらくお待ちください...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // ProgressExecNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 138);
            this.Controls.Add(this.ctrlCancel);
            this.Controls.Add(this.ctrlProgressText);
            this.Controls.Add(this.ctrlProgress);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProgressExecNodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "作業中";
            this.Load += new System.EventHandler(this.ProgressExecNodeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ctrlCancel;
        private System.Windows.Forms.Label ctrlProgressText;
        private System.Windows.Forms.ProgressBar ctrlProgress;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}