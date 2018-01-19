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
    public partial class TimeNodeForm : UserControl
    {
        private Nodes.Filter.TimeNode Node;
        private bool m_init = false;

        public TimeNodeForm(Nodes.Filter.TimeNode node)
        {
            InitializeComponent();
            this.Node = node;
            this.ctrlPriority.Value = this.Node.Priority;
            this.ctrlTarget.Items.AddRange(Nodes.Filter.TimeNode.TimeKindText);
            this.ctrlTarget.SelectedIndex = (int)this.Node.Kind;
            this.ctrlDateTime1.Value = this.Node.Time1;
            this.ctrlDateTime2.Value = this.Node.Time2;
            this.ctrlMethod.Items.AddRange(Nodes.Filter.TimeNode.TimeMethodTypeText);
            this.ctrlMethod.SelectedIndex = (int)this.Node.MethodType;
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

        private void ctrlPriority_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Priority = (int)this.ctrlPriority.Value;
            NotifyChange();
        }

        private void ctrlTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.Kind = (TimeNode.TimeKind)this.ctrlTarget.SelectedIndex;
            NotifyChange();
        }

        private void ctrlDateTime1_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Time1 = new DateTime(
                this.ctrlDateTime1.Value.Year,
                this.ctrlDateTime1.Value.Month,
                this.ctrlDateTime1.Value.Day);
            NotifyChange();
        }

        private void ctrlDateTime2_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Time2 = new DateTime(
                this.ctrlDateTime2.Value.Year,
                this.ctrlDateTime2.Value.Month,
                this.ctrlDateTime2.Value.Day);
            NotifyChange();
        }

        private void ctrlMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.MethodType = (TimeNode.TimeMethodType)this.ctrlMethod.SelectedIndex;
            switch (this.Node.MethodType)
            {
                case TimeNode.TimeMethodType.IN_RANGE:
                case TimeNode.TimeMethodType.OUT_RANGE:
                    this.ctrlDateTime2.Enabled = true;
                    break;

                default:
                    this.ctrlDateTime2.Enabled = false;
                    break;
            }
            NotifyChange();
        }
    }
}
