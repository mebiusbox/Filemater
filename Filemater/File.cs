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
using System.IO;
using System.Data;

namespace Filemater
{
    /// <summary>
    /// 
    /// </summary>
    public struct FileInfoFlags
    {
        public bool ReadSize;
        public bool ReadAttr;
        public bool ReadTime;
        public bool HashMD5;
        public bool HashSHA1;
        public bool HashSHA256;
        public bool HashSHA512;
        public bool ReadExif;
        public bool ReadImageSize;
        public bool ReadID3Tag;
    }

    /// <summary>
    /// 
    /// </summary>
    public struct FileInfo
    {
        public long Length;
        public DateTime CTime;
        public DateTime UTime;
        public DateTime ATime;
        public System.IO.FileAttributes Attr;
        public string HashMD5;
        public string HashSHA1;
        public string HashSHA256;
        public string HashSHA512;
        public libpixy.net.Exif.ExifTags Exif;
        public libpixy.net.Tools.Ref<System.Drawing.Size> ImageSize;
        public libpixy.net.Tagutils.ID3Tag ID3Tag;
    }

    /// <summary>
    /// 
    /// </summary>
    public class NodeTrack
    {
        /// <summary>
        /// 
        /// </summary>
        public struct Data
        {
            public int nodeId;
            public int portIndex;
        }

        private List<Data> dataList = new List<Data>();

        /// <summary>
        /// 
        /// </summary>
        public int count
        {
            get { return this.dataList.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int lastNodeId
        {
            get
            {
                if (this.count > 0)
                {
                    return this.dataList[this.count - 1].nodeId;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            this.dataList.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="portIndex"></param>
        public void Add(int nodeId, int portIndex)
        {
            Data data;
            data.nodeId = nodeId;
            data.portIndex = portIndex;
            this.dataList.Add(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="portIndex"></param>
        public void AddRange(Data[] values)
        {
            this.dataList.AddRange(values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="portIndex"></param>
        public void AddRange(IEnumerable<Data> values)
        {
            this.dataList.AddRange(values);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public bool Exists(int nodeId)
        {
            foreach (Data data in this.dataList)
            {
                if (data.nodeId == nodeId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="portIndex"></param>
        /// <returns></returns>
        public bool Exists(int nodeId, int portIndex)
        {
            foreach (Data data in this.dataList)
            {
                if (data.nodeId == nodeId && data.portIndex == portIndex)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="portIndex"></param>
        /// <returns></returns>
        public bool Exists(int nodeId, int nextNodeId, int portIndex)
        {
            bool stepNext = false;
            foreach (Data data in this.dataList)
            {
                if (stepNext)
                {
                    if (data.nodeId == nextNodeId)
                    {
                        return true;
                    }

                    break;
                }
                else
                {
                    if (data.nodeId == nodeId && data.portIndex == portIndex)
                    {
                        stepNext = true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dump()
        {
            Console.WriteLine("<NodeTrack>");
            foreach (Data data in this.dataList)
            {
                Console.WriteLine(string.Format("  {0}({1})", data.nodeId, data.portIndex));
            }
            Console.WriteLine("</NodeTrack>");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class File
    {
        #region Field

        public libpixy.net.Shell.ShellItem m_shellItem = null;
        private FileInfoFlags m_fileInfoFlags = new FileInfoFlags();
        private FileInfo m_fileInfo = new FileInfo();

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public NodeTrack nodeTrack = new NodeTrack();

        /// <summary>
        /// 
        /// </summary>
        public int GroupIndex = 0;

        /// <summary>
        /// 
        /// </summary>
        public bool IsOutput = true;

        /// <summary>
        /// 
        /// </summary>
        public bool ProcessOutput = false;

        /// <summary>
        /// 
        /// </summary>
        public bool OutputResult = false;

        /// <summary>
        /// 存在するかどうか
        /// </summary>
        public bool Exists = true;

        /// <summary>
        /// ステータス
        /// </summary>
        public string Status = "";

        /// <summary>
        /// 
        /// </summary>
        public libpixy.net.Shell.ShellItem ShellItem
        {
            get { return m_shellItem; }
            set
            {
                m_shellItem = value;
                ClearFileInfoFlags();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public long Size
        {
            get
            {
                ReadFileInfo();
                return m_fileInfo.Length;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ATime
        {
            get
            {
                ReadFileInfo();
                return m_fileInfo.ATime;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime UTime
        {
            get
            {
                ReadFileInfo();
                return m_fileInfo.UTime;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CTime
        {
            get
            {
                ReadFileInfo();
                return m_fileInfo.CTime;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.IO.FileAttributes Attr
        {
            get
            {
                ReadFileAttr();
                return m_fileInfo.Attr;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HashMD5
        {
            get
            {
                if (!m_fileInfoFlags.HashMD5)
                {
                    try
                    {
                        libpixy.net.Shell.ShellStreamReader strmReader = new libpixy.net.Shell.ShellStreamReader(this.ShellItem, null, FileAccess.Read);
                        System.Security.Cryptography.MD5CryptoServiceProvider provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
                        byte[] bs = provider.ComputeHash(strmReader);
                        System.Text.StringBuilder result = new StringBuilder();
                        foreach (byte b in bs)
                        {
                            result.Append(b.ToString("x2"));
                        }

                        this.m_fileInfo.HashMD5 = result.ToString();
                    }
                    catch
                    {
                    }

                    this.m_fileInfoFlags.HashMD5 = true;
                }

                return this.m_fileInfo.HashMD5;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HashSHA1
        {
            get
            {
                if (!m_fileInfoFlags.HashSHA1)
                {
                    try
                    {
                        libpixy.net.Shell.ShellStreamReader strmReader = new libpixy.net.Shell.ShellStreamReader(this.ShellItem, null, FileAccess.Read);
                        System.Security.Cryptography.SHA1CryptoServiceProvider provider = new System.Security.Cryptography.SHA1CryptoServiceProvider();
                        byte[] bs = provider.ComputeHash(strmReader);
                        System.Text.StringBuilder result = new StringBuilder();
                        foreach (byte b in bs)
                        {
                            result.Append(b.ToString("x2"));
                        }

                        this.m_fileInfo.HashSHA1 = result.ToString();
                    }
                    catch
                    {
                    }

                    this.m_fileInfoFlags.HashSHA1 = true;
                }

                return this.m_fileInfo.HashSHA1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HashSHA256
        {
            get
            {
                if (!m_fileInfoFlags.HashSHA256)
                {
                    try
                    {
                        libpixy.net.Shell.ShellStreamReader strmReader = new libpixy.net.Shell.ShellStreamReader(this.ShellItem, null, FileAccess.Read);
                        System.Security.Cryptography.SHA256Managed provider = new System.Security.Cryptography.SHA256Managed();
                        byte[] bs = provider.ComputeHash(strmReader);
                        System.Text.StringBuilder result = new StringBuilder();
                        foreach (byte b in bs)
                        {
                            result.Append(b.ToString("x2"));
                        }

                        this.m_fileInfo.HashSHA256 = result.ToString();
                    }
                    catch
                    {
                    }

                    this.m_fileInfoFlags.HashSHA256 = true;
                }

                return this.m_fileInfo.HashSHA256;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HashSHA512
        {
            get
            {
                if (!m_fileInfoFlags.HashSHA512)
                {
                    try
                    {
                        libpixy.net.Shell.ShellStreamReader strmReader = new libpixy.net.Shell.ShellStreamReader(this.ShellItem, null, FileAccess.Read);
                        System.Security.Cryptography.SHA512Managed provider = new System.Security.Cryptography.SHA512Managed();
                        byte[] bs = provider.ComputeHash(strmReader);
                        System.Text.StringBuilder result = new StringBuilder();
                        foreach (byte b in bs)
                        {
                            result.Append(b.ToString("x2"));
                        }

                        this.m_fileInfo.HashSHA512 = result.ToString();
                    }
                    catch
                    {
                    }

                    this.m_fileInfoFlags.HashSHA512 = true;
                }

                return this.m_fileInfo.HashSHA512;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public libpixy.net.Exif.ExifTags Exif
        {
            get
            {
                if (!m_fileInfoFlags.ReadExif)
                {
                    try
                    {
                        m_fileInfo.Exif = libpixy.net.Exif.Utils.GetProperty(this.ShellItem);
                    }
                    catch
                    {
                    }

                    m_fileInfoFlags.ReadExif = true;
                }

                return m_fileInfo.Exif;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public libpixy.net.Tools.Ref<System.Drawing.Size> ImageSize
        {
            get
            {
                if (!m_fileInfoFlags.ReadImageSize)
                {
                    try
                    {
                        libpixy.net.Shell.ShellStreamReader strmReader = new libpixy.net.Shell.ShellStreamReader(this.ShellItem, null, FileAccess.Read);
                        System.Drawing.Image image = System.Drawing.Image.FromStream(strmReader);
                        this.m_fileInfo.ImageSize = new libpixy.net.Tools.Ref<System.Drawing.Size>();
                        this.m_fileInfo.ImageSize.Value = image.Size;
                    }
                    catch
                    {
                    }

                    this.m_fileInfoFlags.ReadImageSize = true;
                }

                return m_fileInfo.ImageSize;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public libpixy.net.Tagutils.ID3Tag ID3Tag
        {
            get
            {
                if (!m_fileInfoFlags.ReadID3Tag)
                {
                    libpixy.net.Tagutils tlu = new libpixy.net.Tagutils();
                    libpixy.net.Tagutils.Result result = tlu.Init();
                    if (result == libpixy.net.Tagutils.Result.SUCCESS)
                    {
                        try
                        {
                            this.m_fileInfo.ID3Tag = tlu.Read(this.ShellItem.Path);
                        }
                        catch
                        {
                        }

                        tlu.Term();
                    }

                    m_fileInfoFlags.ReadID3Tag = true;
                }

                return m_fileInfo.ID3Tag;
            }
        }

        #endregion

        #region Ctor/Dtor

        /// <summary>
        /// 
        /// </summary>
        public File()
        {
        }

        #endregion

        #region FileInfo

        /// <summary>
        /// 
        /// </summary>
        public FileInfoFlags ReadFlags
        {
            get { return m_fileInfoFlags; }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearFileInfoFlags()
        {
            this.m_fileInfoFlags.ReadSize = false;
            this.m_fileInfoFlags.ReadAttr = false;
            this.m_fileInfoFlags.ReadTime = false;
            this.m_fileInfoFlags.HashMD5 = false;
            this.m_fileInfoFlags.HashSHA1 = false;
            this.m_fileInfoFlags.HashSHA256 = false;
            this.m_fileInfoFlags.HashSHA512 = false;
            this.m_fileInfoFlags.ReadExif = false;
            this.m_fileInfoFlags.ReadImageSize = false;
            this.m_fileInfoFlags.ReadID3Tag = false;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadFileInfo()
        {
            if (this.m_fileInfoFlags.ReadSize &&
                this.m_fileInfoFlags.ReadTime)
            {
                return;
            }

            try
            {
                System.IO.FileInfo finfo = new System.IO.FileInfo(ShellItem.Path);
                this.m_fileInfo.Length = finfo.Length;
                this.m_fileInfo.CTime = finfo.CreationTime;
                this.m_fileInfo.UTime = finfo.LastWriteTime;
                this.m_fileInfo.ATime = finfo.LastAccessTime;
                this.m_fileInfoFlags.ReadSize = true;
                this.m_fileInfoFlags.ReadTime = true;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ReadFileAttr()
        {
            if (this.m_fileInfoFlags.ReadAttr)
            {
                return;
            }

            try
            {
                this.m_fileInfo.Attr = System.IO.File.GetAttributes(ShellItem.Path);
                this.m_fileInfoFlags.ReadAttr = true;
            }
            catch
            {
            }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class Work
    {
        public List<File> InputFiles = new List<File>();
        //public List<File> OutputFiles = new List<File>();
        public Stack<NodeTrack.Data> NodeTrack = new Stack<NodeTrack.Data>();
        public bool Done = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeId"></param>
        /// <param name="portIndex"></param>
        public void PushNodeTrack(int nodeId, int portIndex)
        {
            NodeTrack.Data data;
            data.nodeId = nodeId;
            data.portIndex = portIndex;
            this.NodeTrack.Push(data);
        }

        #region Events

        public EventHandler BeginExecEvent;
        public EventHandler EndExecEvent;
        public EventHandler BeginNodeDispatchEvent;
        public ProgressEventHandler ProgressEvent;
        public OutputEventHandler BeginOutputEvent;
        public OutputEventHandler EndOutputEvent;

        public void RaiseBeginExecEvent(object sender)
        {
            if (BeginExecEvent != null)
            {
                BeginExecEvent(sender, new EventArgs());
            }
        }

        public void RaiseEndExecEvent(object sender)
        {
            if (EndExecEvent != null)
            {
                EndExecEvent(sender, new EventArgs());
            }
        }

        public void RaiseBeginNodeDispatchEvent(object sender)
        {
            if (BeginNodeDispatchEvent != null)
            {
                BeginNodeDispatchEvent(sender, new EventArgs());
            }
        }

        public void RaiseProgressEvent(object sender, int progress)
        {
            if (ProgressEvent != null)
            {
                ProgressEventArgs e = new ProgressEventArgs();
                e.Progress = progress;
                ProgressEvent(sender, e);
            }
        }

        public void RaiseBeginOutputEvent(object sender, File file)
        {
            if (BeginOutputEvent != null)
            {
                OutputEventArgs e = new OutputEventArgs();
                e.File = file;
                BeginOutputEvent(sender, e);
            }
        }

        public void RaiseEndOutputEvent(object sender, File file)
        {
            if (EndOutputEvent != null)
            {
                OutputEventArgs e = new OutputEventArgs();
                e.File = file;
                EndOutputEvent(sender, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class ProgressEventArgs
        {
            public int Progress = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public class OutputEventArgs
        {
            public File File;
        }

        public delegate void ProgressEventHandler(object s, ProgressEventArgs e);
        public delegate void OutputEventHandler(object s, OutputEventArgs e);

        #endregion
    }
}
