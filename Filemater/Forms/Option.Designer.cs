namespace Filemater.Forms
{
    partial class OptionForm
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
            this.optGetExif = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optGetID3Tag = new System.Windows.Forms.CheckBox();
            this.optGetImageSize = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // optGetExif
            // 
            this.optGetExif.AutoSize = true;
            this.optGetExif.Checked = global::Filemater.Properties.Settings.Default.OptionGetExif;
            this.optGetExif.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Filemater.Properties.Settings.Default, "OptionGetExif", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optGetExif.Location = new System.Drawing.Point(16, 48);
            this.optGetExif.Name = "optGetExif";
            this.optGetExif.Size = new System.Drawing.Size(120, 16);
            this.optGetExif.TabIndex = 1;
            this.optGetExif.Text = "Exif情報を取得する";
            this.optGetExif.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optGetID3Tag);
            this.groupBox1.Controls.Add(this.optGetImageSize);
            this.groupBox1.Controls.Add(this.optGetExif);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索後の処理";
            // 
            // optGetID3Tag
            // 
            this.optGetID3Tag.AutoSize = true;
            this.optGetID3Tag.Checked = global::Filemater.Properties.Settings.Default.OptionGetID3Tag;
            this.optGetID3Tag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Filemater.Properties.Settings.Default, "OptionGetID3Tag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optGetID3Tag.Location = new System.Drawing.Point(16, 72);
            this.optGetID3Tag.Name = "optGetID3Tag";
            this.optGetID3Tag.Size = new System.Drawing.Size(116, 16);
            this.optGetID3Tag.TabIndex = 2;
            this.optGetID3Tag.Text = "ID3Tag を取得する";
            this.optGetID3Tag.UseVisualStyleBackColor = true;
            // 
            // optGetImageSize
            // 
            this.optGetImageSize.AutoSize = true;
            this.optGetImageSize.Checked = global::Filemater.Properties.Settings.Default.OptionGetImageSize;
            this.optGetImageSize.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Filemater.Properties.Settings.Default, "OptionGetImageSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.optGetImageSize.Location = new System.Drawing.Point(16, 24);
            this.optGetImageSize.Name = "optGetImageSize";
            this.optGetImageSize.Size = new System.Drawing.Size(129, 16);
            this.optGetImageSize.TabIndex = 0;
            this.optGetImageSize.Text = "画像サイズを取得する";
            this.optGetImageSize.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(112, 120);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 153);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "OptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Option";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox optGetImageSize;
        private System.Windows.Forms.CheckBox optGetExif;
        private System.Windows.Forms.CheckBox optGetID3Tag;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
    }
}