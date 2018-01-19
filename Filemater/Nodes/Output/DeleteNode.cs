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
    public class DeleteNode : IOutputNode
    {
        public enum DeleteMethodType
        {
            TORECYCLE,
            NORMAL,
            FILLZERO,
            FILL255,
            FILLRANDOM,
            DOD_5220_20_M_SHORT,
            DOD_5220_20_M
        }

        public static string[] DeleteMethodText = {
            "ゴミ箱へ",
            "通常削除",
            "0x00で上書き削除",
            "0xFFで上書き削除",
            "乱数で上書き削除",
            "DoD 5220.22-M Short",
            "DoD 5220.22-M"
        };

        public static string[] DeleteMethodTextEn = {
            "delete-to-recycle",
            "delete-normal",
            "delete-fill-zero",
            "delete-fill-0xff",
            "delete-fill-random",
            "delete-DoD-5220-22-M-Short",
            "delete-DoD-5220-22-M"
        };

        public DeleteMethodType Method = DeleteMethodType.TORECYCLE;

        /// <summary>
        /// 
        /// </summary>
        public DeleteNode()
        {
            this.Text = "Delete";
        }

        #region override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new DeleteNodeForm(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecOutput()
        {
            if (System.IO.Directory.Exists(this.Input.ShellItem.Path))
            {
                this.Input.OutputResult = ProcessDirectory(this.Input.ShellItem.Path);
            }
            else
            {
                this.Input.OutputResult = ProcessFile(this.Input.ShellItem.Path);
            }

            if (this.Input.OutputResult)
            {
                this.Input.Status = "deleted";
            }
            else
            {
                this.Input.Status = "failed";
            }

            this.Input.ProcessOutput = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private bool ProcessDirectory(string path)
        {
            // 特殊な削除方法を適用させるため、独自にそれぞれ削除する

            foreach (string name in System.IO.Directory.GetDirectories(path))
            {
                ProcessDirectory(name);
            }

            foreach (string name in System.IO.Directory.GetFiles(path))
            {
                ProcessFile(name);
            }

            try
            {
                System.IO.Directory.Delete(path, true);
                Global.WriteLine("[OK] : deleted(dir) : " + path + " [ " + DeleteMethodText[(int)this.Method] + " ]");
                return true;
            }
            catch
            {
                Global.WriteLine("[NG] : deleted(dir) : " + path + " [ " + DeleteMethodText[(int)this.Method] + " ]");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private bool ProcessFile(string path)
        {
            int result = libpixy.net.Fsutils.E_FAIL;
            switch (this.Method)
            {
                case DeleteMethodType.TORECYCLE:
                    result = libpixy.net.Fsutils.DeleteFile_ToRecycle(IntPtr.Zero, path);
                    break;

                case DeleteMethodType.NORMAL:
                    result = libpixy.net.Fsutils.DeleteFile(path);
                    break;

                case DeleteMethodType.FILLZERO:
                    result = libpixy.net.Fsutils.DeleteFile_FillZero(path);
                    break;

                case DeleteMethodType.FILL255:
                    result = libpixy.net.Fsutils.DeleteFile_Fill255(path);
                    break;

                case DeleteMethodType.FILLRANDOM:
                    result = libpixy.net.Fsutils.DeleteFile_FillRandom(path);
                    break;

                case DeleteMethodType.DOD_5220_20_M_SHORT:
                    result = libpixy.net.Fsutils.DeleteFile_DoD5220_22_M_Short(path);
                    break;

                case DeleteMethodType.DOD_5220_20_M:
                    result = libpixy.net.Fsutils.DeleteFile_DoD5220_22_M(path);
                    break;
            }

            if (result == libpixy.net.Fsutils.SUCCESS)
            {
                Global.WriteLine("[OK] : deleted : " + path + " [ " + DeleteMethodText[(int)this.Method] + " ]");
                return true;
            }
            else
            {
                Global.WriteLine("[NG] : deleted : " + path + " [ " + DeleteMethodText[(int)this.Method] + " ]");
                return false;
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
            w.WriteElementString("Method", DeleteMethodTextEn[(int)this.Method]);
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
            string method = r.ReadElementString("Method");
            for (int i = 0; i < DeleteMethodTextEn.Length; ++i)
            {
                if (method == DeleteMethodTextEn[i])
                {
                    this.Method = (DeleteMethodType)i;
                    break;
                }
            }
        }

        #endregion
    }
}
