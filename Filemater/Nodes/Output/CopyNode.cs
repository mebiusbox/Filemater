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
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Filemater.Nodes.Output
{
    /// <summary>
    /// 
    /// </summary>
    public class CopyNode : IOutputNode
    {
        #region Fields

        public string Path = "";
        private const int RetryCount = 65535;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public CopyNode()
        {
            this.Text = "Copy";
        }

        #endregion Constructor

        #region override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new CopyNodeForm(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecOutput()
        {
            if (System.IO.Directory.Exists(this.Path))
            {
                if (System.IO.Directory.Exists(this.Input.ShellItem.Path))
                {
                    ProcessDirectory(this.Input);
                }
                else
                {
                    ProcessFile(this.Input);
                }
            }
        }

        #endregion

        #region Process

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        private void ProcessDirectory(File file)
        {
            string filename = System.IO.Path.GetFileName(file.ShellItem.Path);
            string ofname = System.IO.Path.Combine(this.Path, filename);
            if (System.IO.Directory.Exists(ofname))
            {
                int i;
                for (i = 2; i < RetryCount; ++i)
                {
                    ofname = System.IO.Path.Combine(this.Path, string.Format("{0}({1})", filename, i));
                    if (!System.IO.Directory.Exists(ofname))
                    {
                        if (libpixy.net.Fsutils.CopyFile(
                            IntPtr.Zero,
                            file.ShellItem.Path,
                            ofname) == libpixy.net.Fsutils.SUCCESS)
                        {
                            Global.WriteLine("[OK] : copied : " + file.ShellItem.Path + " -> " + ofname);
                            file.Status = "copied";
                            file.OutputResult = true;
                            break;
                        }
                        else
                        {
                            Global.WriteLine("[NG] : copied : " + file.ShellItem.Path + " -> " + ofname);
                            file.Status = "failed";
                        }
                    }
                }
            }
            else
            {
                int ret = libpixy.net.Fsutils.CopyFile(
                    IntPtr.Zero, file.ShellItem.Path, ofname);
                if (ret == libpixy.net.Fsutils.SUCCESS)
                {
                    Global.WriteLine("[OK] : copied : " + file.ShellItem.Path + " -> " + ofname);
                    file.Status = "copied";
                    file.OutputResult = true;
                }
                else
                {
                    Global.WriteLine("[NG] : copied : " + file.ShellItem.Path + " -> " + ofname);
                    file.Status = "failed";
                }
            }

            file.ProcessOutput = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        private void ProcessFile(File file)
        {
            string filename = System.IO.Path.GetFileName(file.ShellItem.Path);
            string ofname = System.IO.Path.Combine(this.Path, filename);
            if (System.IO.File.Exists(ofname))
            {
                string filespec = System.IO.Path.GetFileNameWithoutExtension(filename);
                string fileext = System.IO.Path.GetExtension(filename);
                int i;
                for (i = 2; i < RetryCount; ++i)
                {
                    ofname = System.IO.Path.Combine(this.Path, string.Format("{0}({1})", filespec, i)) + fileext;
                    if (!System.IO.File.Exists(ofname))
                    {
                        if (libpixy.net.Fsutils.CopyFile(
                            IntPtr.Zero,
                            file.ShellItem.Path,
                            ofname) == libpixy.net.Fsutils.SUCCESS)
                        {
                            Global.WriteLine("[OK] : copied : " + file.ShellItem.Path + " -> " + ofname);
                            file.Status = "copied";
                            file.OutputResult = true;
                            break;
                        }
                        else
                        {
                            Global.WriteLine("[NG] : copied : " + file.ShellItem.Path + " -> " + ofname);
                            file.Status = "failed";
                        }
                    }
                }
            }
            else
            {
                int ret = libpixy.net.Fsutils.CopyFile(
                    IntPtr.Zero, file.ShellItem.Path, ofname);
                if (ret == libpixy.net.Fsutils.SUCCESS)
                {
                    Global.WriteLine("[OK] : copied : " + file.ShellItem.Path + " -> " + ofname);
                    file.Status = "copied";
                    file.OutputResult = true;
                }
                else
                {
                    Global.WriteLine("[NG] : copied : " + file.ShellItem.Path + " -> " + ofname);
                    file.Status = "failed";
                }
            }

            file.ProcessOutput = true;
        }

        #endregion

        #region Serialize

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        public override void Serialize(System.Xml.XmlWriter w)
        {
            base.Serialize(w);
            w.WriteElementString("Path", this.Path);
            w.WriteWhitespace("\r\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public override void Deserialize(System.Xml.XmlReader r)
        {
            base.Deserialize(r);
            this.Path = r.ReadElementString("Path");
        }

        #endregion
    }
}
