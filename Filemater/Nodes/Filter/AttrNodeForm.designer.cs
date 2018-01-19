namespace Filemater.Nodes.Filter
{
    partial class AttrNodeForm
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
            this.ctrlReadOnly = new System.Windows.Forms.CheckBox();
            this.ctrlArchive = new System.Windows.Forms.CheckBox();
            this.ctrlSystem = new System.Windows.Forms.CheckBox();
            this.ctrlHidden = new System.Windows.Forms.CheckBox();
            this.ctrlMaskReadOnly = new System.Windows.Forms.CheckBox();
            this.ctrlMaskArchive = new System.Windows.Forms.CheckBox();
            this.ctrlMaskSystem = new System.Windows.Forms.CheckBox();
            this.ctrlMaskHidden = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrlPriority
            // 
            this.ctrlPriority.Location = new System.Drawing.Point(88, 8);
            this.ctrlPriority.Name = "ctrlPriority";
            this.ctrlPriority.Size = new System.Drawing.Size(56, 19);
            this.ctrlPriority.TabIndex = 38;
            this.ctrlPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ctrlPriority.ValueChanged += new System.EventHandler(this.ctrlPriority_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 37;
            this.label1.Text = "優先度:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "対象:";
            // 
            // ctrlReadOnly
            // 
            this.ctrlReadOnly.AutoSize = true;
            this.ctrlReadOnly.Location = new System.Drawing.Point(112, 40);
            this.ctrlReadOnly.Name = "ctrlReadOnly";
            this.ctrlReadOnly.Size = new System.Drawing.Size(72, 16);
            this.ctrlReadOnly.TabIndex = 40;
            this.ctrlReadOnly.Text = "読取専用";
            this.ctrlReadOnly.UseVisualStyleBackColor = true;
            this.ctrlReadOnly.CheckedChanged += new System.EventHandler(this.ctrlReadOnly_CheckedChanged);
            // 
            // ctrlArchive
            // 
            this.ctrlArchive.AutoSize = true;
            this.ctrlArchive.Location = new System.Drawing.Point(112, 64);
            this.ctrlArchive.Name = "ctrlArchive";
            this.ctrlArchive.Size = new System.Drawing.Size(70, 16);
            this.ctrlArchive.TabIndex = 41;
            this.ctrlArchive.Text = "アーカイブ";
            this.ctrlArchive.UseVisualStyleBackColor = true;
            this.ctrlArchive.CheckedChanged += new System.EventHandler(this.ctrlArchive_CheckedChanged);
            // 
            // ctrlSystem
            // 
            this.ctrlSystem.AutoSize = true;
            this.ctrlSystem.Location = new System.Drawing.Point(112, 88);
            this.ctrlSystem.Name = "ctrlSystem";
            this.ctrlSystem.Size = new System.Drawing.Size(62, 16);
            this.ctrlSystem.TabIndex = 42;
            this.ctrlSystem.Text = "システム";
            this.ctrlSystem.UseVisualStyleBackColor = true;
            this.ctrlSystem.CheckedChanged += new System.EventHandler(this.ctrlSystem_CheckedChanged);
            // 
            // ctrlHidden
            // 
            this.ctrlHidden.AutoSize = true;
            this.ctrlHidden.Location = new System.Drawing.Point(112, 112);
            this.ctrlHidden.Name = "ctrlHidden";
            this.ctrlHidden.Size = new System.Drawing.Size(45, 16);
            this.ctrlHidden.TabIndex = 43;
            this.ctrlHidden.Text = "隠し";
            this.ctrlHidden.UseVisualStyleBackColor = true;
            this.ctrlHidden.CheckedChanged += new System.EventHandler(this.ctrlHidden_CheckedChanged);
            // 
            // ctrlMaskReadOnly
            // 
            this.ctrlMaskReadOnly.AutoSize = true;
            this.ctrlMaskReadOnly.Location = new System.Drawing.Point(88, 41);
            this.ctrlMaskReadOnly.Name = "ctrlMaskReadOnly";
            this.ctrlMaskReadOnly.Size = new System.Drawing.Size(15, 14);
            this.ctrlMaskReadOnly.TabIndex = 44;
            this.ctrlMaskReadOnly.UseVisualStyleBackColor = true;
            this.ctrlMaskReadOnly.CheckedChanged += new System.EventHandler(this.ctrlMaskReadOnly_CheckedChanged);
            // 
            // ctrlMaskArchive
            // 
            this.ctrlMaskArchive.AutoSize = true;
            this.ctrlMaskArchive.Location = new System.Drawing.Point(88, 65);
            this.ctrlMaskArchive.Name = "ctrlMaskArchive";
            this.ctrlMaskArchive.Size = new System.Drawing.Size(15, 14);
            this.ctrlMaskArchive.TabIndex = 45;
            this.ctrlMaskArchive.UseVisualStyleBackColor = true;
            this.ctrlMaskArchive.CheckedChanged += new System.EventHandler(this.ctrlMaskArchive_CheckedChanged);
            // 
            // ctrlMaskSystem
            // 
            this.ctrlMaskSystem.AutoSize = true;
            this.ctrlMaskSystem.Location = new System.Drawing.Point(88, 89);
            this.ctrlMaskSystem.Name = "ctrlMaskSystem";
            this.ctrlMaskSystem.Size = new System.Drawing.Size(15, 14);
            this.ctrlMaskSystem.TabIndex = 46;
            this.ctrlMaskSystem.UseVisualStyleBackColor = true;
            this.ctrlMaskSystem.CheckedChanged += new System.EventHandler(this.ctrlMaskSystem_CheckedChanged);
            // 
            // ctrlMaskHidden
            // 
            this.ctrlMaskHidden.AutoSize = true;
            this.ctrlMaskHidden.Location = new System.Drawing.Point(88, 113);
            this.ctrlMaskHidden.Name = "ctrlMaskHidden";
            this.ctrlMaskHidden.Size = new System.Drawing.Size(15, 14);
            this.ctrlMaskHidden.TabIndex = 47;
            this.ctrlMaskHidden.UseVisualStyleBackColor = true;
            this.ctrlMaskHidden.CheckedChanged += new System.EventHandler(this.ctrlMaskHidden_CheckedChanged);
            // 
            // AttrFilterNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ctrlMaskHidden);
            this.Controls.Add(this.ctrlMaskSystem);
            this.Controls.Add(this.ctrlMaskArchive);
            this.Controls.Add(this.ctrlMaskReadOnly);
            this.Controls.Add(this.ctrlHidden);
            this.Controls.Add(this.ctrlSystem);
            this.Controls.Add(this.ctrlArchive);
            this.Controls.Add(this.ctrlReadOnly);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrlPriority);
            this.Controls.Add(this.label1);
            this.Name = "AttrFilterNodeForm";
            this.Size = new System.Drawing.Size(300, 400);
            ((System.ComponentModel.ISupportInitialize)(this.ctrlPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown ctrlPriority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ctrlReadOnly;
        private System.Windows.Forms.CheckBox ctrlArchive;
        private System.Windows.Forms.CheckBox ctrlSystem;
        private System.Windows.Forms.CheckBox ctrlHidden;
        private System.Windows.Forms.CheckBox ctrlMaskReadOnly;
        private System.Windows.Forms.CheckBox ctrlMaskArchive;
        private System.Windows.Forms.CheckBox ctrlMaskSystem;
        private System.Windows.Forms.CheckBox ctrlMaskHidden;
    }
}
