namespace Filemater.Nodes.Filter
{
    partial class TimeNodeForm
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
            this.ctrlDateTime1 = new System.Windows.Forms.DateTimePicker();
            this.ctrlDateTime2 = new System.Windows.Forms.DateTimePicker();
            this.ctrlMethod = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlTarget = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPriority
            // 
            this.ctrlPriority.Location = new System.Drawing.Point(88, 8);
            this.ctrlPriority.Name = "ctrlPriority";
            this.ctrlPriority.Size = new System.Drawing.Size(56, 19);
            this.ctrlPriority.TabIndex = 1;
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
            this.label2.Location = new System.Drawing.Point(44, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "日時:";
            // 
            // ctrlDateTime1
            // 
            this.ctrlDateTime1.Location = new System.Drawing.Point(88, 72);
            this.ctrlDateTime1.Name = "ctrlDateTime1";
            this.ctrlDateTime1.Size = new System.Drawing.Size(112, 19);
            this.ctrlDateTime1.TabIndex = 3;
            this.ctrlDateTime1.ValueChanged += new System.EventHandler(this.ctrlDateTime1_ValueChanged);
            // 
            // ctrlDateTime2
            // 
            this.ctrlDateTime2.Location = new System.Drawing.Point(216, 72);
            this.ctrlDateTime2.Name = "ctrlDateTime2";
            this.ctrlDateTime2.Size = new System.Drawing.Size(112, 19);
            this.ctrlDateTime2.TabIndex = 4;
            this.ctrlDateTime2.ValueChanged += new System.EventHandler(this.ctrlDateTime2_ValueChanged);
            // 
            // ctrlMethod
            // 
            this.ctrlMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlMethod.FormattingEnabled = true;
            this.ctrlMethod.Location = new System.Drawing.Point(88, 104);
            this.ctrlMethod.Name = "ctrlMethod";
            this.ctrlMethod.Size = new System.Drawing.Size(112, 20);
            this.ctrlMethod.TabIndex = 5;
            this.ctrlMethod.SelectedIndexChanged += new System.EventHandler(this.ctrlMethod_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 12);
            this.label3.TabIndex = 45;
            this.label3.Text = "期間:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "対象:";
            // 
            // ctrlTarget
            // 
            this.ctrlTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlTarget.FormattingEnabled = true;
            this.ctrlTarget.Location = new System.Drawing.Point(88, 40);
            this.ctrlTarget.Name = "ctrlTarget";
            this.ctrlTarget.Size = new System.Drawing.Size(112, 20);
            this.ctrlTarget.TabIndex = 2;
            this.ctrlTarget.SelectedIndexChanged += new System.EventHandler(this.ctrlTarget_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 48;
            this.label5.Text = "-";
            // 
            // TimeFilterNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctrlTarget);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlMethod);
            this.Controls.Add(this.ctrlDateTime2);
            this.Controls.Add(this.ctrlDateTime1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "TimeFilterNodeForm";
            this.Size = new System.Drawing.Size(338, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ctrlDateTime1;
        private System.Windows.Forms.DateTimePicker ctrlDateTime2;
        private System.Windows.Forms.ComboBox ctrlMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ctrlTarget;
        private System.Windows.Forms.Label label5;
    }
}
