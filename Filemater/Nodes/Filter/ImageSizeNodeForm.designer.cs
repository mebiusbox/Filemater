namespace Filemater.Nodes.Filter
{
    partial class ImageSizeNodeForm
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
            this.ctrlEnableWidth = new System.Windows.Forms.CheckBox();
            this.ctrlWidth1 = new System.Windows.Forms.NumericUpDown();
            this.ctrlWidthMethod = new System.Windows.Forms.ComboBox();
            this.ctrlHeightMethod = new System.Windows.Forms.ComboBox();
            this.ctrlHeight1 = new System.Windows.Forms.NumericUpDown();
            this.ctrlEnableHeight = new System.Windows.Forms.CheckBox();
            this.ctrlWidth2 = new System.Windows.Forms.NumericUpDown();
            this.ctrlHeight2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlWidth1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeight1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlWidth2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeight2)).BeginInit();
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
            // ctrlEnableWidth
            // 
            this.ctrlEnableWidth.AutoSize = true;
            this.ctrlEnableWidth.Location = new System.Drawing.Point(40, 40);
            this.ctrlEnableWidth.Name = "ctrlEnableWidth";
            this.ctrlEnableWidth.Size = new System.Drawing.Size(36, 16);
            this.ctrlEnableWidth.TabIndex = 41;
            this.ctrlEnableWidth.Text = "幅";
            this.ctrlEnableWidth.UseVisualStyleBackColor = true;
            this.ctrlEnableWidth.CheckedChanged += new System.EventHandler(this.ctrlEnableWidth_CheckedChanged);
            // 
            // ctrlWidth1
            // 
            this.ctrlWidth1.Location = new System.Drawing.Point(56, 64);
            this.ctrlWidth1.Name = "ctrlWidth1";
            this.ctrlWidth1.Size = new System.Drawing.Size(56, 19);
            this.ctrlWidth1.TabIndex = 42;
            this.ctrlWidth1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlWidth1.ValueChanged += new System.EventHandler(this.ctrlWidth1_ValueChanged);
            // 
            // ctrlWidthMethod
            // 
            this.ctrlWidthMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlWidthMethod.FormattingEnabled = true;
            this.ctrlWidthMethod.Location = new System.Drawing.Point(192, 64);
            this.ctrlWidthMethod.Name = "ctrlWidthMethod";
            this.ctrlWidthMethod.Size = new System.Drawing.Size(96, 20);
            this.ctrlWidthMethod.TabIndex = 44;
            this.ctrlWidthMethod.SelectedIndexChanged += new System.EventHandler(this.ctrlWidthMethod_SelectedIndexChanged);
            // 
            // ctrlHeightMethod
            // 
            this.ctrlHeightMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ctrlHeightMethod.FormattingEnabled = true;
            this.ctrlHeightMethod.Location = new System.Drawing.Point(192, 128);
            this.ctrlHeightMethod.Name = "ctrlHeightMethod";
            this.ctrlHeightMethod.Size = new System.Drawing.Size(96, 20);
            this.ctrlHeightMethod.TabIndex = 48;
            this.ctrlHeightMethod.SelectedIndexChanged += new System.EventHandler(this.ctrlHeightMethod_SelectedIndexChanged);
            // 
            // ctrlHeight1
            // 
            this.ctrlHeight1.Location = new System.Drawing.Point(56, 128);
            this.ctrlHeight1.Name = "ctrlHeight1";
            this.ctrlHeight1.Size = new System.Drawing.Size(56, 19);
            this.ctrlHeight1.TabIndex = 46;
            this.ctrlHeight1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlHeight1.ValueChanged += new System.EventHandler(this.ctrlHeight1_ValueChanged);
            // 
            // ctrlEnableHeight
            // 
            this.ctrlEnableHeight.AutoSize = true;
            this.ctrlEnableHeight.Location = new System.Drawing.Point(40, 104);
            this.ctrlEnableHeight.Name = "ctrlEnableHeight";
            this.ctrlEnableHeight.Size = new System.Drawing.Size(44, 16);
            this.ctrlEnableHeight.TabIndex = 45;
            this.ctrlEnableHeight.Text = "高さ";
            this.ctrlEnableHeight.UseVisualStyleBackColor = true;
            this.ctrlEnableHeight.CheckedChanged += new System.EventHandler(this.ctrlEnableHeight_CheckedChanged);
            // 
            // ctrlWidth2
            // 
            this.ctrlWidth2.Location = new System.Drawing.Point(128, 64);
            this.ctrlWidth2.Name = "ctrlWidth2";
            this.ctrlWidth2.Size = new System.Drawing.Size(56, 19);
            this.ctrlWidth2.TabIndex = 43;
            this.ctrlWidth2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlWidth2.ValueChanged += new System.EventHandler(this.ctrlWidth2_ValueChanged);
            // 
            // ctrlHeight2
            // 
            this.ctrlHeight2.Location = new System.Drawing.Point(128, 128);
            this.ctrlHeight2.Name = "ctrlHeight2";
            this.ctrlHeight2.Size = new System.Drawing.Size(56, 19);
            this.ctrlHeight2.TabIndex = 47;
            this.ctrlHeight2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlHeight2.ValueChanged += new System.EventHandler(this.ctrlHeight2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 49;
            this.label2.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(116, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 50;
            this.label3.Text = "-";
            // 
            // ImageSizeFilterNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlHeight2);
            this.Controls.Add(this.ctrlWidth2);
            this.Controls.Add(this.ctrlHeightMethod);
            this.Controls.Add(this.ctrlHeight1);
            this.Controls.Add(this.ctrlEnableHeight);
            this.Controls.Add(this.ctrlWidthMethod);
            this.Controls.Add(this.ctrlWidth1);
            this.Controls.Add(this.ctrlEnableWidth);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "ImageSizeFilterNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlWidth1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeight1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlWidth2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlHeight2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ctrlEnableWidth;
        private System.Windows.Forms.NumericUpDown ctrlWidth1;
        private System.Windows.Forms.ComboBox ctrlWidthMethod;
        private System.Windows.Forms.ComboBox ctrlHeightMethod;
        private System.Windows.Forms.NumericUpDown ctrlHeight1;
        private System.Windows.Forms.CheckBox ctrlEnableHeight;
        private System.Windows.Forms.NumericUpDown ctrlWidth2;
        private System.Windows.Forms.NumericUpDown ctrlHeight2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
