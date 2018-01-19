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
    public partial class ID3TagNodeForm : UserControl
    {
        public Nodes.Filter.ID3TagNode Node = null;
        private bool m_init = false;

        public ID3TagNodeForm(Nodes.Filter.ID3TagNode node)
        {
            InitializeComponent();
            this.Node = node;
            this.ctrlPriority.Value = this.Node.Priority;
            this.ctrlSearchWord.Text = this.Node.Word;
            this.ctrlNumber1.Maximum = Int32.MaxValue;
            this.ctrlNumber1.Value = this.Node.Number1;
            this.ctrlNumber2.Maximum = Int32.MaxValue;
            this.ctrlNumber2.Value = this.Node.Number2;
            this.ctrlNumberMethod.Items.AddRange(Util.NumberChecker.MethodTypeText);
            this.ctrlNumberMethod.SelectedIndex = (int)this.Node.NumberMethod;
            this.ctrlTarget.Items.AddRange(Nodes.Filter.ID3TagNode.TagItemText);
            this.ctrlTarget.SelectedIndex = (int)this.Node.Target;
            this.m_init = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void NotifyChange()
        {
            if (m_init)
            {
                Global.RaiseEvent(Global.ModifyDocumentEvent);
            }
        }

        private void UpdateControls()
        {
            switch (Nodes.Filter.ID3TagNode.TagItemMode[(int)this.Node.Target])
            {
                case Nodes.Filter.ID3TagNode.ModeType.STRING:
                    this.ctrlModeNumber.Enabled = false;
                    this.ctrlModeString.Checked = true;
                    break;

                case Nodes.Filter.ID3TagNode.ModeType.NUMBER:
                    this.ctrlModeNumber.Enabled = true;
                    this.ctrlModeNumber.Checked = true;
                    break;
            }
        }

        private void ctrlPriority_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Priority = (int)this.ctrlPriority.Value;
            NotifyChange();
        }

        private void ctrlTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.Target = (ID3TagNode.TagItem)this.ctrlTarget.SelectedIndex;
            UpdateControls();
            NotifyChange();
        }

        private void ctrlSearchWord_TextChanged(object sender, EventArgs e)
        {
            this.Node.Word = this.ctrlSearchWord.Text;
            NotifyChange();
        }

        private void ctrlNumber1_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Number1 = (long)this.ctrlNumber1.Value;
            NotifyChange();
        }

        private void ctrlNumber2_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Number2 = (long)this.ctrlNumber2.Value;
            NotifyChange();
        }

        private void ctrlNumberMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.NumberMethod = (Util.NumberChecker.MethodType)this.ctrlNumberMethod.SelectedIndex;
            switch (this.Node.NumberMethod)
            {
                case Util.NumberChecker.MethodType.IN_RANGE:
                case Util.NumberChecker.MethodType.OUT_RANGE:
                    this.ctrlNumber2.Enabled = true;
                    break;

                default:
                    this.ctrlNumber2.Enabled = false;
                    break;
            }
            NotifyChange();
        }

        private void ctrlModeString_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ctrlModeString.Checked)
            {
                this.Node.Mode = ID3TagNode.ModeType.STRING;
                NotifyChange();
            }
        }

        private void ctrlModeNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ctrlModeNumber.Checked)
            {
                this.Node.Mode = ID3TagNode.ModeType.NUMBER;
                NotifyChange();
            }
        }
    }
}
