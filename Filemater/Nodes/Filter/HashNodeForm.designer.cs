namespace Filemater.Nodes.Filter
{
    partial class HashNodeForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlHash = new System.Windows.Forms.TextBox();
            this.ctrlTarget = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPriority
            // 
            this.ctrlPriority.Location = new System.Drawing.Point(88, 8);
            this.ctrlPriority.Name = "ctrlPriority";
            this.ctrlPriority.Size = new System.Drawing.Size(56, 19);
            this.ctrlPriority.TabIndex = 40;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 12);
            this.label3.TabIndex = 46;
            this.label3.Text = "ハッシュ値:";
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
            // ctrlHash
            // 
            this.ctrlHash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlHash.Location = new System.Drawing.Point(88, 73);
            this.ctrlHash.Name = "ctrlHash";
            this.ctrlHash.Size = new System.Drawing.Size(200, 19);
            this.ctrlHash.TabIndex = 42;
            this.ctrlHash.TextChanged += new System.EventHandler(this.ctrlHash_TextChanged);
            // 
            // ctrlTarget
            // 
            this.ctrlTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlTarget.FormattingEnabled = true;
            this.ctrlTarget.Location = new System.Drawing.Point(88, 40);
            this.ctrlTarget.Name = "ctrlTarget";
            this.ctrlTarget.Size = new System.Drawing.Size(121, 20);
            this.ctrlTarget.TabIndex = 41;
            this.ctrlTarget.SelectedIndexChanged += new System.EventHandler(this.ctrlTarget_SelectedIndexChanged);
            // 
            // HashFilterNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlHash);
            this.Controls.Add(this.ctrlTarget);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "HashFilterNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ctrlHash;
        private System.Windows.Forms.ComboBox ctrlTarget;
    }
}
