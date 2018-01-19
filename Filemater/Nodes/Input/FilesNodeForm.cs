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

namespace Filemater.Nodes
{
    public partial class FilesNodeForm : UserControl
    {
        private Nodes.Input.FilesNode Node;
        private bool m_init = false;

        public FilesNodeForm(Nodes.Input.FilesNode node)
        {
            InitializeComponent();

            Node = node;
            this.ctrlPriority.Value = this.Node.Priority;
            this.ctrlTargets.Items.AddRange(this.Node.Files.ToArray());
            this.ctrlOptionRecursive.Checked = this.Node.OptionRecursive;
            this.ctrlOptionFile.Checked = this.Node.OptionFile;
            this.ctrlOptionFolder.Checked = this.Node.OptionFolder;
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

        private void ctrlRemoveTarget_Click(object sender, EventArgs e)
        {
            int idx = this.ctrlTargets.SelectedIndex;
            if (idx >= 0 && idx < this.ctrlTargets.Items.Count)
            {
                int sel = this.ctrlTargets.SelectedIndex;
                this.Node.Files.RemoveAt(idx);
                this.ctrlTargets.Items.RemoveAt(idx);
                if (sel < this.ctrlTargets.Items.Count)
                {
                    this.ctrlTargets.SelectedIndex = sel;
                }
                else if (this.ctrlTargets.Items.Count > 0)
                {
                    this.ctrlTargets.SelectedIndex = this.ctrlTargets.Items.Count - 1;
                }
                this.Node.RequestBuild = true;
                NotifyChange();
            }
        }

        private void ctrlOptionRecursive_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.OptionRecursive = this.ctrlOptionRecursive.Checked;
            this.Node.RequestBuild = true;
            NotifyChange();
        }

        private void ctrlOptionFile_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.OptionFile = this.ctrlOptionFile.Checked;
            this.Node.RequestBuild = true;
            NotifyChange();
        }

        private void ctrlOptionFolder_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.OptionFolder = this.ctrlOptionFolder.Checked;
            this.Node.RequestBuild = true;
            NotifyChange();
        }

        private void ctrlTargets_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ctrlTargets_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            this.Node.Files.AddRange(s);
            this.Node.RequestBuild = true;
            this.ctrlTargets.Items.AddRange(s);
            NotifyChange();
        }
    }
}
