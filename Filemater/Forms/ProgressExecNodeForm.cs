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
    public partial class ProgressExecNodeForm : Form
    {
        public int count = 0;

        /// <summary>
        /// 
        /// </summary>
        public ProgressExecNodeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressExecNodeForm_Load(object sender, EventArgs e)
        {
            this.ctrlProgress.Style = ProgressBarStyle.Marquee;
            this.ctrlProgressText.Text = "?%";
            this.backgroundWorker1.RunWorkerAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctrlCancel_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Global.MainForm.WndSchematic.ClearIONodeWork();
            Work work = new Work();

            this.backgroundWorker1.ReportProgress(0);

            // Build file list

            foreach (libpixy.net.Controls.Diagram.Node node in Global.MainForm.Document.Nodes)
            {
                if (node is Nodes.IInputNode)
                {
                    Nodes.IInputNode inode = node as Nodes.IInputNode;
                    inode.ExecInput();
                    work.InputFiles.AddRange(inode.InputFiles);
                }

                if (this.backgroundWorker1.CancellationPending)
                {
                    return;
                }
            }

            // Clear Tracking data

            foreach (File file in work.InputFiles)
            {
                file.nodeTrack.Clear();
            }

            if (this.backgroundWorker1.CancellationPending)
            {
                return;
            }

            // Dispatch nodes

            int count = 0;

            foreach (libpixy.net.Controls.Diagram.Node node in Global.MainForm.Document.Nodes)
            {
                if (this.backgroundWorker1.CancellationPending)
                {
                    return;
                }

                if (node is Nodes.IInputNode)
                {
                    Nodes.IInputNode inode = node as Nodes.IInputNode;
                    foreach (File file in inode.InputFiles)
                    {
                        if (this.backgroundWorker1.CancellationPending)
                        {
                            return;
                        }

                        count++;
                        this.backgroundWorker1.ReportProgress(count * 100 / work.InputFiles.Count);

                        Global.MainForm.WndSchematic.ClearNodeWork();

                        if (file.ShellItem != null)
                        {
                            inode.Input = file;
                            inode.Work = work;
                            inode.Work.NodeTrack.Clear();
                            inode.Work.Done = false;
                            inode.Exec();
                        }
                        else
                        {
                            work.Done = false;
                            file.Status = "missed";
                            Global.WriteLine("[NG] : missed : " + file.ShellItem.Path);
                        }

                        if (work.Done)
                        {
                            // èÓïÒÇéÊìæÇµÇƒÇ®Ç≠
                            long sz = file.Size;
                            System.IO.FileAttributes attr = file.Attr;

                            if (Properties.Settings.Default.OptionGetImageSize)
                            {
                                libpixy.net.Tools.Ref<Size> size = file.ImageSize;
                            }

                            if (Properties.Settings.Default.OptionGetExif)
                            {
                                libpixy.net.Exif.ExifTags exif = file.Exif;
                            }

                            if (Properties.Settings.Default.OptionGetID3Tag)
                            {
                                libpixy.net.Tagutils.ID3Tag tag = file.ID3Tag;
                            }
                            
                            List<NodeTrack.Data> tmp = new List<NodeTrack.Data>();
                            tmp.AddRange(work.NodeTrack.ToArray());
                            tmp.Reverse();
                            file.nodeTrack.AddRange(tmp.ToArray());
                        }
                    }
                }
            }

            // Display results
            //Global.Results.AddRange(work.OutputFiles);
            Global.Results.AddRange(work.InputFiles);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage > 0)
            {
                if (this.ctrlProgress.Style == ProgressBarStyle.Marquee)
                {
                    this.ctrlProgress.Style = ProgressBarStyle.Continuous;
                }

                this.ctrlProgressText.Text = string.Format("{0}%", e.ProgressPercentage);
            }

            this.ctrlProgress.Value = e.ProgressPercentage;
            this.ctrlProgressText.Refresh();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}