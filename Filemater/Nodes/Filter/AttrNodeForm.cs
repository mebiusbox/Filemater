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

namespace Filemater.Nodes.Filter
{
    public partial class AttrNodeForm : UserControl
    {
        private Nodes.Filter.AttrNode Node;
        private bool m_init = false;

        public AttrNodeForm(Nodes.Filter.AttrNode node)
        {
            InitializeComponent();
            this.Node = node;
            this.ctrlPriority.Value = this.Node.Priority;
            this.ctrlMaskArchive.Checked = this.Node.Mask.Archive;
            this.ctrlMaskReadOnly.Checked = this.Node.Mask.ReadOnly;
            this.ctrlMaskSystem.Checked = this.Node.Mask.System;
            this.ctrlMaskHidden.Checked = this.Node.Mask.Hidden;
            this.ctrlArchive.Checked = this.Node.Value.Archive;
            this.ctrlReadOnly.Checked = this.Node.Value.ReadOnly;
            this.ctrlSystem.Checked = this.Node.Value.System;
            this.ctrlHidden.Checked = this.Node.Value.Hidden;
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

        private void ctrlMaskReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.Mask.ReadOnly = this.ctrlMaskReadOnly.Checked;
            NotifyChange();
        }

        private void ctrlReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.Value.ReadOnly = this.ctrlReadOnly.Checked;
            NotifyChange();
        }

        private void ctrlMaskArchive_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.Mask.Archive = this.ctrlMaskArchive.Checked;
            NotifyChange();
        }

        private void ctrlArchive_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.Value.Archive = this.ctrlArchive.Checked;
            NotifyChange();
        }

        private void ctrlMaskSystem_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.Mask.System = this.ctrlMaskSystem.Checked;
            NotifyChange();
        }

        private void ctrlSystem_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.Value.System = this.ctrlSystem.Checked;
            NotifyChange();
        }

        private void ctrlMaskHidden_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.Mask.Hidden = this.ctrlMaskHidden.Checked;
            NotifyChange();
        }

        private void ctrlHidden_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.Value.Hidden = this.ctrlHidden.Checked;
            NotifyChange();
        }

        private void ctrlPriority_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Priority = (int)this.ctrlPriority.Value;
            NotifyChange();
        }
    }
}
