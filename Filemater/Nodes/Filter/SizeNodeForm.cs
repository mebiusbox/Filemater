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
    public partial class SizeNodeForm : UserControl
    {
        private Nodes.Filter.SizeNode Node;
        private bool m_init = false;

        #region Constructor / Destructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public SizeNodeForm(Nodes.Filter.SizeNode node)
        {
            InitializeComponent();
            Node = node;
            this.ctrlSize1.Maximum = Int64.MaxValue;
            this.ctrlSize1.Value = node.Size1;
            this.ctrlSize2.Maximum = Int64.MaxValue;
            this.ctrlSize2.Value = node.Size2;
            this.ctrlMethod.Items.AddRange(Nodes.Filter.SizeNode.SizeMethodTypeText);
            this.ctrlMethod.SelectedIndex = (int)node.MethodType;
            this.ctrlUnit.Items.AddRange(Nodes.Filter.SizeNode.SizeUnitText);
            this.ctrlUnit.SelectedIndex = (int)node.Unit;
            m_init = true;
        }

        #endregion

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

        private void ctrlSize1_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Size1 = (long)this.ctrlSize1.Value;
            NotifyChange();
        }

        private void ctrlSize2_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Size2 = (long)this.ctrlSize2.Value;
            NotifyChange();
        }

        private void ctrlMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.MethodType = (Nodes.Filter.SizeNode.SizeMethodType)this.ctrlMethod.SelectedIndex;
            switch (this.Node.MethodType)
            {
                case Nodes.Filter.SizeNode.SizeMethodType.IN_RANGE:
                case Nodes.Filter.SizeNode.SizeMethodType.OUT_RANGE:
                    this.ctrlSize2.Enabled = true;
                    break;

                default:
                    this.ctrlSize2.Enabled = false;
                    break;
            }
            NotifyChange();
        }

        private void ctrlUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.Unit = (Nodes.Filter.SizeNode.SizeUnit)this.ctrlUnit.SelectedIndex;
            NotifyChange();
        }
    }
}
