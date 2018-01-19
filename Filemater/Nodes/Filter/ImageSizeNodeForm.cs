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
    public partial class ImageSizeNodeForm : UserControl
    {
        private Nodes.Filter.ImageSizeNode Node = null;
        private bool m_init = false;

        public ImageSizeNodeForm(Nodes.Filter.ImageSizeNode node)
        {
            InitializeComponent();
            this.Node = node;
            this.ctrlPriority.Value = this.Node.Priority;
            this.ctrlEnableWidth.Checked = this.Node.EnableWidth;
            this.ctrlWidth1.Maximum = Int32.MaxValue;
            this.ctrlWidth1.Value = this.Node.Width1;
            this.ctrlWidth2.Maximum = Int32.MaxValue;
            this.ctrlWidth2.Value = this.Node.Width2;
            this.ctrlWidthMethod.Items.AddRange(Util.NumberChecker.MethodTypeText);
            this.ctrlWidthMethod.SelectedIndex = (int)this.Node.WidthMethodType;
            this.ctrlEnableHeight.Checked = this.Node.EnableHeight;
            this.ctrlHeight1.Maximum = Int32.MaxValue;
            this.ctrlHeight1.Value = this.Node.Height1;
            this.ctrlHeight2.Maximum = Int32.MaxValue;
            this.ctrlHeight2.Value = this.Node.Height2;
            this.ctrlHeightMethod.Items.AddRange(Util.NumberChecker.MethodTypeText);
            this.ctrlHeightMethod.SelectedIndex = (int)this.Node.HeightMethodType;
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

        /// <summary>
        /// 
        /// </summary>
        private void UpdateControl()
        {
            if (this.Node.WidthMethodType == Util.NumberChecker.MethodType.IN_RANGE ||
                this.Node.WidthMethodType == Util.NumberChecker.MethodType.OUT_RANGE)
            {
                this.ctrlWidth2.Enabled = true;
            }
            else
            {
                this.ctrlWidth2.Enabled = false;
            }

            if (this.Node.HeightMethodType == Util.NumberChecker.MethodType.IN_RANGE ||
                this.Node.HeightMethodType == Util.NumberChecker.MethodType.OUT_RANGE)
            {
                this.ctrlHeight2.Enabled = true;
            }
            else
            {
                this.ctrlHeight2.Enabled = false;
            }
        }

        private void ctrlPriority_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Priority = (int)this.ctrlPriority.Value;
            NotifyChange();
        }

        private void ctrlEnableWidth_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.EnableWidth = this.ctrlEnableWidth.Checked;
            NotifyChange();
        }

        private void ctrlWidth1_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Width1 = (long)this.ctrlWidth1.Value;
            NotifyChange();
        }

        private void ctrlWidth2_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Width2 = (long)this.ctrlWidth2.Value;
            NotifyChange();
        }

        private void ctrlWidthMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.WidthMethodType = (Util.NumberChecker.MethodType)this.ctrlWidthMethod.SelectedIndex;
            UpdateControl();
            NotifyChange();
        }

        private void ctrlEnableHeight_CheckedChanged(object sender, EventArgs e)
        {
            this.Node.EnableHeight = this.ctrlEnableHeight.Checked;
            NotifyChange();
        }

        private void ctrlHeight1_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Height1 = (long)this.ctrlHeight1.Value;
            NotifyChange();
        }

        private void ctrlHeight2_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Height2 = (long)this.ctrlHeight2.Value;
            NotifyChange();
        }

        private void ctrlHeightMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.HeightMethodType = (Util.NumberChecker.MethodType)this.ctrlHeightMethod.SelectedIndex;
            UpdateControl();
            NotifyChange();
        }
    }
}
