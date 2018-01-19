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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Filemater.Nodes.Output
{
    /// <summary>
    /// 
    /// </summary>
    public class ProgramNode : IOutputNode
    {
        #region Fields

        public string Program = "";
        public string Arguments = "";
        public string Workdir = "";
        public int WindowStyle = 0;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public ProgramNode()
        {
            this.Text = "Program";
        }

        #endregion Constructor

        #region override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new ProgramNodeForm(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecOutput()
        {
            if (string.IsNullOrEmpty(this.Program) == false)
            {
                string args = this.Arguments;
                string workdir = this.Workdir;

                if (args.IndexOf("$Path") >= 0)
                {
                    args = args.Replace("$Path", "\"" + this.Input.ShellItem.Path + "\"");
                }

                if (workdir.IndexOf("$Dir") >= 0)
                {
                    workdir = workdir.Replace("$Dir", "\"" + System.IO.Path.GetDirectoryName(this.Input.ShellItem.Path) + "\"");
                }

                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = this.Program;
                proc.StartInfo.WorkingDirectory = workdir;
                proc.StartInfo.Arguments = args;
                proc.StartInfo.WindowStyle = (System.Diagnostics.ProcessWindowStyle)this.WindowStyle;
                proc.Start();
                proc.WaitForExit();

                Global.WriteLine("[OK] : program : " + this.Input.ShellItem.Path + " : " + this.Program);
                this.Input.Status = "program";
                this.Input.OutputResult = true;
            }
            else
            {
                Global.WriteLine("[NG] : program : " + this.Input.ShellItem.Path + " : " + this.Program);
                this.Input.Status = "failed";
            }
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
            w.WriteElementString("Program", this.Program);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Arguments", this.Arguments);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Workdir", this.Workdir);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("WindowStyle", this.WindowStyle.ToString());
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
            this.Program = r.ReadElementString("Program");
            this.Arguments = r.ReadElementString("Arguments");
            this.Workdir = r.ReadElementString("Workdir");
            this.WindowStyle = Int32.Parse(r.ReadElementString("WindowStyle"));
        }

        #endregion
    }
}
