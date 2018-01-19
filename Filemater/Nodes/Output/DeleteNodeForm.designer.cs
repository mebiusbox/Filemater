namespace Filemater.Nodes.Output
{
    partial class DeleteNodeForm
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
            this.ctrlDeleteMethod = new System.Windows.Forms.ComboBox();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "削除方法:";
            // 
            // ctrlDeleteMethod
            // 
            this.ctrlDeleteMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlDeleteMethod.FormattingEnabled = true;
            this.ctrlDeleteMethod.Location = new System.Drawing.Point(88, 40);
            this.ctrlDeleteMethod.Name = "ctrlDeleteMethod";
            this.ctrlDeleteMethod.Size = new System.Drawing.Size(144, 20);
            this.ctrlDeleteMethod.TabIndex = 42;
            this.ctrlDeleteMethod.SelectedIndexChanged += new System.EventHandler(this.ctrlDeleteMethod_SelectedIndexChanged);
            // 
            // DeleteOutputNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlDeleteMethod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "DeleteOutputNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ctrlDeleteMethod;
    }
}
