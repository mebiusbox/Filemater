/*
 * Copyright (c) 2018 mebiusbox software. All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR AND CONTRIBUTORS ``AS IS'' AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED.  IN NO EVENT SHALL THE AUTHOR OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS
 * OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
 * LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Filemater.Nodes.Output
{
    public partial class ProgramNodeForm : UserControl
    {
        private Nodes.Output.ProgramNode Node = null;
        private bool m_init = false;

        public ProgramNodeForm(Nodes.Output.ProgramNode node)
        {
            InitializeComponent();
            this.ctrlWindowStyle.Items.Add("í èÌ");
            this.ctrlWindowStyle.Items.Add("îÒï\é¶");
            this.ctrlWindowStyle.Items.Add("ç≈ëÂâª");
            this.ctrlWindowStyle.Items.Add("ç≈è¨âª");
            this.Node = node;
            this.ctrlPriority.Value = this.Node.Priority;
            this.ctrlProgram.Text = this.Node.Program;
            this.ctrlArguments.Text = this.Node.Arguments;
            this.ctrlWorkdir.Text = this.Node.Workdir;
            this.ctrlWindowStyle.SelectedIndex = this.Node.WindowStyle;
            this.m_init = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void NotifyChange()
        {
            if (this.m_init)
            {
                Global.RaiseEvent(Global.ModifyDocumentEvent);
            }
        }

        private void ctrlPriority_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Priority = (int)this.ctrlPriority.Value;
            NotifyChange();
        }

        private void ctrlProgram_TextChanged(object sender, EventArgs e)
        {
            this.Node.Program = this.ctrlProgram.Text;
            NotifyChange();
        }

        private void ctrlProgramSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = this.Node.Program;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.ctrlProgram.Text = dlg.FileName;
                this.ctrlWorkdir.Text = System.IO.Path.GetDirectoryName(dlg.FileName);
                this.Node.Program = dlg.FileName;
                this.Node.Workdir = this.ctrlWorkdir.Text;
                NotifyChange();
            }
        }

        private void ctrlArguments_TextChanged(object sender, EventArgs e)
        {
            this.Node.Arguments = this.ctrlArguments.Text;
            NotifyChange();
        }

        private void ctrlWorkdir_TextChanged(object sender, EventArgs e)
        {
            this.Node.Workdir = this.ctrlWorkdir.Text;
            NotifyChange();
        }

        private void ctrlWindowStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.WindowStyle = this.ctrlWindowStyle.SelectedIndex;
            NotifyChange();
        }
    }
}
