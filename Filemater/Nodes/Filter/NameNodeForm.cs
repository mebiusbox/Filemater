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
    public partial class NameNodeForm : UserControl
    {
        private Nodes.Filter.NameNode m_node;
        private bool m_init = false;

        public NameNodeForm(Nodes.Filter.NameNode node)
        {
            InitializeComponent();
            this.m_node = node;
            this.ctrlPriority.Value = this.m_node.Priority;
            this.ctrlWord.Text = this.m_node.Pattern;
            this.ctrlOptionCaseSensitive.Checked = this.m_node.PMatch.OptionCaseSensitive;
            this.ctrlOptionZenkakuSensitive.Checked = this.m_node.PMatch.OptionZenkakuSensitive;
            this.ctrlOptionLike.Checked = false;
            this.ctrlOptionWildcard.Checked = false;
            this.ctrlOptionRegularExp.Checked = false;

            switch (this.m_node.PMatch.OptionAlgo)
            {
                case libpixy.net.Tools.PatternMatch.MatchAlgo.LIKE:
                    this.ctrlOptionLike.Checked = true;
                    break;

                case libpixy.net.Tools.PatternMatch.MatchAlgo.WILDCARD:
                    this.ctrlOptionWildcard.Checked = true;
                    break;

                case libpixy.net.Tools.PatternMatch.MatchAlgo.REGEXP:
                    this.ctrlOptionRegularExp.Checked = true;
                    break;
            }

            this.ctrlTarget.Items.AddRange(Nodes.Filter.NameNode.SearchTargetText);
            this.ctrlTarget.SelectedIndex = (int)this.m_node.Target;
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
            this.m_node.Priority = (int)this.ctrlPriority.Value;
            NotifyChange();
        }

        private void ctrlTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_node.Target = (Nodes.Filter.NameNode.SearchTarget)this.ctrlTarget.SelectedIndex;
            NotifyChange();
        }

        private void ctrlWord_TextChanged(object sender, EventArgs e)
        {
            this.m_node.Pattern = this.ctrlWord.Text;
            NotifyChange();
        }

        private void ctrlOptionCaseSensitive_CheckedChanged(object sender, EventArgs e)
        {
            this.m_node.PMatch.OptionCaseSensitive = this.ctrlOptionCaseSensitive.Checked;
            NotifyChange();
        }

        private void ctrlOptionZenkakuSensitive_CheckedChanged(object sender, EventArgs e)
        {
            this.m_node.PMatch.OptionZenkakuSensitive = this.ctrlOptionZenkakuSensitive.Checked;
            NotifyChange();
        }

        private void ctrlOptionLike_CheckedChanged(object sender, EventArgs e)
        {
            this.m_node.PMatch.OptionAlgo = libpixy.net.Tools.PatternMatch.MatchAlgo.LIKE;
            NotifyChange();
        }

        private void ctrlOptionWildcard_CheckedChanged(object sender, EventArgs e)
        {
            this.m_node.PMatch.OptionAlgo = libpixy.net.Tools.PatternMatch.MatchAlgo.WILDCARD;
            NotifyChange();
        }

        private void ctrlOptionRegularExp_CheckedChanged(object sender, EventArgs e)
        {
            this.m_node.PMatch.OptionAlgo = libpixy.net.Tools.PatternMatch.MatchAlgo.REGEXP;
            NotifyChange();
        }
    }
}
