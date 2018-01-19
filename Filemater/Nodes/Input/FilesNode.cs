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
using System.Runtime.InteropServices;
using System.Xml;

namespace Filemater.Nodes.Input
{
    /// <summary>
    /// 
    /// </summary>
    public class FilesNode : IInputNode
    {
        #region Attributes 

        public List<string> Files;
        public bool OptionRecursive = true;
        public bool OptionFile = true;
        public bool OptionFolder = false;
        public bool RequestBuild = true;

        #endregion Attributes

        #region Constructor / Destructor

        public FilesNode()
        {
            this.Text = "Files";
            this.Files = new List<string>();
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new FilesNodeForm(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Exec()
        {
            Dispatch(0, this.Input);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ExecInput()
        {
            if (this.RequestBuild)
            {
                this.InputFiles.Clear();
                BuildList();
                this.RequestBuild = false;
            }
        }

        #endregion

        #region Build

        /// <summary>
        /// 
        /// </summary>
        private void BuildList()
        {
            libpixy.net.Shell.ShellItem desktop = libpixy.net.Shell.ShellItem.DesktopItem;
            uint eaten;
            IntPtr ppidl;
            libpixy.net.Shell.API.SFGAO attr;
            foreach (string path in Files)
            {
                eaten = 0;
                ppidl = IntPtr.Zero;
                attr = libpixy.net.Shell.API.SFGAO.FOLDER;
                if (desktop.ShellFolder.ParseDisplayName(
                    IntPtr.Zero, IntPtr.Zero, path,
                    ref eaten, out ppidl, ref attr) != libpixy.net.Shell.API.S_OK)
                {
                    continue;
                }

                if ((attr & libpixy.net.Shell.API.SFGAO.FOLDER) == 0)
                {
                    if (OptionFile)
                    {
                        // File
                        libpixy.net.Shell.ShellItem item = new libpixy.net.Shell.ShellItem(desktop, ppidl);
                        File file = new File();
                        file.ShellItem = item;
                        this.InputFiles.Add(file);
                    }
                    else
                    {
                        Marshal.FreeCoTaskMem(ppidl);
                    }
                }
                else
                {
                    // Folder
                    IntPtr shellFolderPtr;
                    if (desktop.ShellFolder.BindToObject(
                        ppidl, IntPtr.Zero,
                        ref libpixy.net.Shell.API.IID_IShellFolder,
                        out shellFolderPtr) == libpixy.net.Shell.API.S_OK)
                    {
                        libpixy.net.Shell.ShellItem parent = new libpixy.net.Shell.ShellItem(desktop, ppidl, shellFolderPtr);

                        if (OptionFolder)
                        {
                            File file = new File();
                            file.ShellItem = parent;
                            this.InputFiles.Add(file);
                        }

                        EnumFiles(parent);
                    }
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        private void EnumFiles(libpixy.net.Shell.ShellItem parent)
        {
            if (parent == null)
            {
                return;
            }

            if (OptionFile)
            {
                if (!parent.ExpandFiles(IntPtr.Zero))
                {
                    return;
                }
            }

            if (OptionFile || OptionFolder)
            {
                if (!parent.ExpandFolders(IntPtr.Zero))
                {
                    return;
                }
            }

            BuildFromFolders(parent);
            BuildFromFiles(parent);

            if (OptionRecursive)
            {
                foreach (libpixy.net.Shell.ShellItem item in parent.SubFolders)
                {
                    EnumFiles(item);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        private void BuildFromFiles(libpixy.net.Shell.ShellItem parent)
        {
            if (OptionFile)
            {
                foreach (libpixy.net.Shell.ShellItem item in parent.SubFiles)
                {
                    File file = new File();
                    file.ShellItem = item;
                    this.InputFiles.Add(file);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        private void BuildFromFolders(libpixy.net.Shell.ShellItem parent)
        {
            if (OptionFolder)
            {
                foreach (libpixy.net.Shell.ShellItem item in parent.SubFolders)
                {
                    File file = new File();
                    file.ShellItem = item;
                    this.InputFiles.Add(file);
                }
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
            foreach (string s in this.Files)
            {
                w.WriteElementString("Path", s);
                w.WriteWhitespace("\r\n");
            }

            w.WriteElementString("OptionRecursive", this.OptionRecursive ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("OptionFile", this.OptionFile ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("OptionFolder", this.OptionFolder ? "y" : "n");
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
            while (r.IsStartElement("Path"))
            {
                this.Files.Add(r.ReadElementString("Path"));
            }
            this.OptionRecursive = (r.ReadElementString("OptionRecursive") == "y");
            this.OptionFile = (r.ReadElementString("OptionFile") == "y");
            this.OptionFolder = (r.ReadElementString("OptionFolder") == "y");
        }

        #endregion
    }
}
