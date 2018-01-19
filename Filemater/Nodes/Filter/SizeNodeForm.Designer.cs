namespace Filemater.Nodes
{
    partial class SizeNodeForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.ctrlPriority = new System.Windows.Forms.NumericUpDown();
            this.ctrlSize1 = new System.Windows.Forms.NumericUpDown();
            this.ctrlSize2 = new System.Windows.Forms.NumericUpDown();
            this.ctrlMethod = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrlUnit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSize1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSize2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "優先度:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 12);
            this.label3.TabIndex = 34;
            this.label3.Text = "サイズ:";
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
            // ctrlSize1
            // 
            this.ctrlSize1.Location = new System.Drawing.Point(88, 40);
            this.ctrlSize1.Name = "ctrlSize1";
            this.ctrlSize1.Size = new System.Drawing.Size(88, 19);
            this.ctrlSize1.TabIndex = 2;
            this.ctrlSize1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlSize1.ValueChanged += new System.EventHandler(this.ctrlSize1_ValueChanged);
            // 
            // ctrlSize2
            // 
            this.ctrlSize2.Location = new System.Drawing.Point(192, 40);
            this.ctrlSize2.Name = "ctrlSize2";
            this.ctrlSize2.Size = new System.Drawing.Size(88, 19);
            this.ctrlSize2.TabIndex = 3;
            this.ctrlSize2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlSize2.ValueChanged += new System.EventHandler(this.ctrlSize2_ValueChanged);
            // 
            // ctrlMethod
            // 
            this.ctrlMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlMethod.FormattingEnabled = true;
            this.ctrlMethod.Location = new System.Drawing.Point(88, 72);
            this.ctrlMethod.Name = "ctrlMethod";
            this.ctrlMethod.Size = new System.Drawing.Size(88, 20);
            this.ctrlMethod.TabIndex = 4;
            this.ctrlMethod.SelectedIndexChanged += new System.EventHandler(this.ctrlMethod_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "単位:";
            // 
            // ctrlUnit
            // 
            this.ctrlUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlUnit.FormattingEnabled = true;
            this.ctrlUnit.Location = new System.Drawing.Point(88, 104);
            this.ctrlUnit.Name = "ctrlUnit";
            this.ctrlUnit.Size = new System.Drawing.Size(64, 20);
            this.ctrlUnit.TabIndex = 5;
            this.ctrlUnit.SelectedIndexChanged += new System.EventHandler(this.ctrlUnit_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "-";
            // 
            // SizeFilterNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctrlUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlMethod);
            this.Controls.Add(this.ctrlSize2);
            this.Controls.Add(this.ctrlSize1);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "SizeFilterNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSize1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlSize2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.NumericUpDown ctrlSize1;
        private System.Windows.Forms.NumericUpDown ctrlSize2;
        private System.Windows.Forms.ComboBox ctrlMethod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ctrlUnit;
        private System.Windows.Forms.Label label4;
    }
}
