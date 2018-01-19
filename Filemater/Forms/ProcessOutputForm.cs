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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Filemater.Forms
{
    public partial class ProcessOutputForm : Form
    {
        public ProcessOutputForm()
        {
            InitializeComponent();
        }

        private void ctrlCancel_Click(object sender, EventArgs e)
        {
            this.ctrlProgress.Style = ProgressBarStyle.Marquee;
            this.backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<File> results = new List<File>();
            results.AddRange(Global.Results);
            results.Reverse();

            int count = 0;

            foreach (File file in results)
            {
                if (this.backgroundWorker1.CancellationPending)
                {
                    break;
                }

                count++;
                this.backgroundWorker1.ReportProgress(count * 100 / results.Count);

                if (!file.IsOutput) continue;
                if (file.ProcessOutput) continue;
                if (file.nodeTrack.count == 0) continue;

                int nodeId = file.nodeTrack.lastNodeId;
                Nodes.IOutputNode onode = Global.MainForm.WndSchematic.FindOutputNode(nodeId);
                if (onode != null)
                {
                    onode.Input = file;
                    onode.ExecOutput();
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 0)
            {
                this.ctrlProgress.Style = ProgressBarStyle.Continuous;
            }

            this.ctrlProgress.Value = e.ProgressPercentage;
            this.ctrlProgressText.Text = string.Format("{0}%", e.ProgressPercentage);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ProcessOutputForm_Load(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
        }
    }
}