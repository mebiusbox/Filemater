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
using System.Drawing;
using Fireball.Docking;

namespace Filemater.Window
{
    public class FileInfoWindow : DockableWindow
    {
        private TabPage tabBasic;
        private ListView listViewBasic;
        private TabPage tabExif;
        private ListView listViewExif;
        private TextBox ctrlFilename;
        private TabPage tabPage1;
        private ListView listViewID3Tag;
        private ContextMenuStrip contextMenuBasic;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem cmenuBasicCopy;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem cmenuBasicGetImageSize;
        private ToolStripMenuItem cmenuBasicGetMD5;
        private ToolStripMenuItem cmenuBasicGetSHA1;
        private ToolStripMenuItem cmenuBasicGetSHA256;
        private ToolStripMenuItem cmenuBasicGetSHA512;
        private TabControl tabControl1;
        private bool m_isSetBasic;
        private bool m_isSetExif;
        private bool m_isSetID3;
        private File m_current;
        private ContextMenuStrip contextMenuExif;
        private ContextMenuStrip contextMenuID3;
        private ToolStripMenuItem cmenuExifCopy;
        private ToolStripMenuItem cmenuID3Copy;
        private string m_copy_string;

        /// <summary>
        /// 
        /// </summary>
        public FileInfoWindow()
        {
            InitializeComponent();
            ClearContent();
            this.Text = "FileInfo";
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileInfoWindow));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBasic = new System.Windows.Forms.TabPage();
            this.listViewBasic = new System.Windows.Forms.ListView();
            this.tabExif = new System.Windows.Forms.TabPage();
            this.listViewExif = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listViewID3Tag = new System.Windows.Forms.ListView();
            this.ctrlFilename = new System.Windows.Forms.TextBox();
            this.contextMenuBasic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenuBasicCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmenuBasicGetImageSize = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuBasicGetMD5 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuBasicGetSHA1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuBasicGetSHA256 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmenuBasicGetSHA512 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuExif = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenuExifCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuID3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmenuID3Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabBasic.SuspendLayout();
            this.tabExif.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuBasic.SuspendLayout();
            this.contextMenuExif.SuspendLayout();
            this.contextMenuID3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabBasic);
            this.tabControl1.Controls.Add(this.tabExif);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(292, 234);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabBasic
            // 
            this.tabBasic.Controls.Add(this.listViewBasic);
            this.tabBasic.Location = new System.Drawing.Point(4, 21);
            this.tabBasic.Name = "tabBasic";
            this.tabBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasic.Size = new System.Drawing.Size(284, 209);
            this.tabBasic.TabIndex = 0;
            this.tabBasic.Text = "基本情報";
            // 
            // listViewBasic
            // 
            this.listViewBasic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewBasic.FullRowSelect = true;
            this.listViewBasic.GridLines = true;
            this.listViewBasic.Location = new System.Drawing.Point(3, 3);
            this.listViewBasic.MultiSelect = false;
            this.listViewBasic.Name = "listViewBasic";
            this.listViewBasic.Size = new System.Drawing.Size(278, 203);
            this.listViewBasic.TabIndex = 0;
            this.listViewBasic.UseCompatibleStateImageBehavior = false;
            this.listViewBasic.View = System.Windows.Forms.View.Details;
            this.listViewBasic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewBasic_MouseClick);
            // 
            // tabExif
            // 
            this.tabExif.Controls.Add(this.listViewExif);
            this.tabExif.Location = new System.Drawing.Point(4, 21);
            this.tabExif.Name = "tabExif";
            this.tabExif.Padding = new System.Windows.Forms.Padding(3);
            this.tabExif.Size = new System.Drawing.Size(284, 209);
            this.tabExif.TabIndex = 1;
            this.tabExif.Text = "Exif";
            // 
            // listViewExif
            // 
            this.listViewExif.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewExif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewExif.FullRowSelect = true;
            this.listViewExif.GridLines = true;
            this.listViewExif.Location = new System.Drawing.Point(3, 3);
            this.listViewExif.MultiSelect = false;
            this.listViewExif.Name = "listViewExif";
            this.listViewExif.Size = new System.Drawing.Size(278, 203);
            this.listViewExif.TabIndex = 0;
            this.listViewExif.UseCompatibleStateImageBehavior = false;
            this.listViewExif.View = System.Windows.Forms.View.Details;
            this.listViewExif.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewExif_MouseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listViewID3Tag);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(284, 209);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "ID3Tag";
            // 
            // listViewID3Tag
            // 
            this.listViewID3Tag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewID3Tag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewID3Tag.FullRowSelect = true;
            this.listViewID3Tag.GridLines = true;
            this.listViewID3Tag.Location = new System.Drawing.Point(3, 3);
            this.listViewID3Tag.MultiSelect = false;
            this.listViewID3Tag.Name = "listViewID3Tag";
            this.listViewID3Tag.Size = new System.Drawing.Size(278, 203);
            this.listViewID3Tag.TabIndex = 0;
            this.listViewID3Tag.UseCompatibleStateImageBehavior = false;
            this.listViewID3Tag.View = System.Windows.Forms.View.Details;
            this.listViewID3Tag.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewID3Tag_MouseClick);
            // 
            // ctrlFilename
            // 
            this.ctrlFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlFilename.Location = new System.Drawing.Point(8, 8);
            this.ctrlFilename.Name = "ctrlFilename";
            this.ctrlFilename.Size = new System.Drawing.Size(272, 19);
            this.ctrlFilename.TabIndex = 1;
            // 
            // contextMenuBasic
            // 
            this.contextMenuBasic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenuBasicCopy,
            this.toolStripSeparator1,
            this.cmenuBasicGetImageSize,
            this.cmenuBasicGetMD5,
            this.cmenuBasicGetSHA1,
            this.cmenuBasicGetSHA256,
            this.cmenuBasicGetSHA512});
            this.contextMenuBasic.Name = "contextMenuBasic";
            this.contextMenuBasic.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuBasic.Size = new System.Drawing.Size(200, 142);
            this.contextMenuBasic.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenu_ItemClicked);
            // 
            // cmenuBasicCopy
            // 
            this.cmenuBasicCopy.Name = "cmenuBasicCopy";
            this.cmenuBasicCopy.Size = new System.Drawing.Size(199, 22);
            this.cmenuBasicCopy.Tag = "copy-to-clipboard";
            this.cmenuBasicCopy.Text = "クリップボードへコピー";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // cmenuBasicGetImageSize
            // 
            this.cmenuBasicGetImageSize.Name = "cmenuBasicGetImageSize";
            this.cmenuBasicGetImageSize.Size = new System.Drawing.Size(199, 22);
            this.cmenuBasicGetImageSize.Tag = "get-image-size";
            this.cmenuBasicGetImageSize.Text = "画像サイズを取得";
            // 
            // cmenuBasicGetMD5
            // 
            this.cmenuBasicGetMD5.Name = "cmenuBasicGetMD5";
            this.cmenuBasicGetMD5.Size = new System.Drawing.Size(199, 22);
            this.cmenuBasicGetMD5.Tag = "get-hash-md5";
            this.cmenuBasicGetMD5.Text = "ハッシュ値(MD5)を算出";
            // 
            // cmenuBasicGetSHA1
            // 
            this.cmenuBasicGetSHA1.Name = "cmenuBasicGetSHA1";
            this.cmenuBasicGetSHA1.Size = new System.Drawing.Size(199, 22);
            this.cmenuBasicGetSHA1.Tag = "get-hash-sha1";
            this.cmenuBasicGetSHA1.Text = "ハッシュ値(SHA1)を算出";
            // 
            // cmenuBasicGetSHA256
            // 
            this.cmenuBasicGetSHA256.Name = "cmenuBasicGetSHA256";
            this.cmenuBasicGetSHA256.Size = new System.Drawing.Size(199, 22);
            this.cmenuBasicGetSHA256.Tag = "get-hash-sha256";
            this.cmenuBasicGetSHA256.Text = "ハッシュ値(SHA256)を算出";
            // 
            // cmenuBasicGetSHA512
            // 
            this.cmenuBasicGetSHA512.Name = "cmenuBasicGetSHA512";
            this.cmenuBasicGetSHA512.Size = new System.Drawing.Size(199, 22);
            this.cmenuBasicGetSHA512.Tag = "get-hash-sha512";
            this.cmenuBasicGetSHA512.Text = "ハッシュ値(SHA512)を算出";
            // 
            // contextMenuExif
            // 
            this.contextMenuExif.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenuExifCopy});
            this.contextMenuExif.Name = "contextMenuExif";
            this.contextMenuExif.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuExif.Size = new System.Drawing.Size(168, 26);
            this.contextMenuExif.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuExif_ItemClicked);
            // 
            // cmenuExifCopy
            // 
            this.cmenuExifCopy.Name = "cmenuExifCopy";
            this.cmenuExifCopy.Size = new System.Drawing.Size(167, 22);
            this.cmenuExifCopy.Tag = "copy-to-clipboard";
            this.cmenuExifCopy.Text = "クリップボードへコピー";
            // 
            // contextMenuID3
            // 
            this.contextMenuID3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmenuID3Copy});
            this.contextMenuID3.Name = "contextMenuID3";
            this.contextMenuID3.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuID3.Size = new System.Drawing.Size(168, 26);
            this.contextMenuID3.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuID3_ItemClicked);
            // 
            // cmenuID3Copy
            // 
            this.cmenuID3Copy.Name = "cmenuID3Copy";
            this.cmenuID3Copy.Size = new System.Drawing.Size(167, 22);
            this.cmenuID3Copy.Tag = "copy-to-clipboard";
            this.cmenuID3Copy.Text = "クリップボードへコピー";
            // 
            // FileInfoWindow
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.ctrlFilename);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FileInfoWindow";
            this.Load += new System.EventHandler(this.FileInfoWindow_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FileInfoWindow_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileInfoWindow_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabBasic.ResumeLayout(false);
            this.tabExif.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.contextMenuBasic.ResumeLayout(false);
            this.contextMenuExif.ResumeLayout(false);
            this.contextMenuID3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FileInfoWindow_Load(object sender, EventArgs e)
        {
            Global.FocusResultItemEvent += new Global.FocusResultItemHandler(Global_FocusResultItemEvent);
            Global.ClearResultEvent += new EventHandler(Global_ClearResult);
            Global.NewDocumentEvent += new EventHandler(Global_NewDocument);
            Global.OpenDocumentEvent += new EventHandler(Global_OpenDocument);

            listViewBasic.Columns.Add("Name", 100);
            listViewBasic.Columns.Add("Value", 300);
            listViewExif.Columns.Add("Name", 180);
            listViewExif.Columns.Add("Value", 300);
            listViewID3Tag.Columns.Add("Name", 100);
            listViewID3Tag.Columns.Add("Value", 300);

            ImageList imageList = new ImageList();
            imageList.ColorDepth = ColorDepth.Depth32Bit;
            imageList.ImageSize = new Size(16, 16);
            imageList.Images.Add(Properties.Resources.icon_clipboard);
            imageList.Images.Add(Properties.Resources.icon_magnifier_medium);
            this.contextMenuBasic.ImageList = imageList;
            this.contextMenuExif.ImageList = imageList;
            this.contextMenuID3.ImageList = imageList;
            this.cmenuBasicCopy.ImageIndex = 0;
            this.cmenuBasicGetImageSize.ImageIndex = 1;
            this.cmenuBasicGetMD5.ImageIndex = 1;
            this.cmenuBasicGetSHA1.ImageIndex = 1;
            this.cmenuBasicGetSHA256.ImageIndex = 1;
            this.cmenuBasicGetSHA512.ImageIndex = 1;
            this.cmenuExifCopy.ImageIndex = 0;
            this.cmenuID3Copy.ImageIndex = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ClearContent()
        {
            this.m_current = null;
            this.m_copy_string = "";
            this.m_isSetBasic = false;
            this.m_isSetExif = false;
            this.m_isSetID3 = false;
            this.listViewBasic.Items.Clear();
            this.listViewExif.Items.Clear();
            this.listViewID3Tag.Items.Clear();
            this.ctrlFilename.Text = "";
        }

        #region Event

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private void Global_FocusResultItemEvent(Global.FocusResultItemEventArgs e)
        {
            ClearContent();

            if (e.File != null)
            {
                this.m_current = e.File;
                this.ctrlFilename.Text = System.IO.Path.GetFileName(e.File.ShellItem.Path);
                UpdateActivePage();
            }
        }

        private void Global_ClearResult(object sender, EventArgs e)
        {
            ClearContent();
        }

        private void Global_NewDocument(object sender, EventArgs e)
        {
            ClearContent();
        }

        private void Global_OpenDocument(object sender, EventArgs e)
        {
            ClearContent();
        }

        #endregion

        #region Basic

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        private void UpdateBasicPage(File file)
        {
            if (this.m_isSetBasic) return;

            listViewBasic.BeginUpdate();
            listViewBasic.Items.Clear();
            listViewBasic.Items.Add("ファイル名");
            listViewBasic.Items.Add("パス");
            listViewBasic.Items.Add("サイズ");
            listViewBasic.Items.Add("属性");
            listViewBasic.Items[0].SubItems.Add(System.IO.Path.GetFileName(file.ShellItem.Path));
            listViewBasic.Items[1].SubItems.Add(file.ShellItem.Path);
            listViewBasic.Items[2].SubItems.Add(string.Format("{0}", file.Size));
            listViewBasic.Items[3].SubItems.Add(GetFileAttributeString(file));

            if (file.ReadFlags.ReadImageSize) AddBasicImageSize();
            if (file.ReadFlags.HashMD5) AddHashMD5();
            if (file.ReadFlags.HashSHA1) AddHashSHA1();
            if (file.ReadFlags.HashSHA256) AddHashSHA256();
            if (file.ReadFlags.HashSHA512) AddHashSHA512();
            
            listViewBasic.EndUpdate();

            this.m_isSetBasic = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private string GetFileAttributeString(File file)
        {
            List<string> strings = new List<string>();
            if ((file.Attr & System.IO.FileAttributes.Archive) == System.IO.FileAttributes.Archive)
            {
                strings.Add("アーカイブ");
            }
            if ((file.Attr & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
            {
                strings.Add("読取専用");
            }
            if ((file.Attr & System.IO.FileAttributes.System) == System.IO.FileAttributes.System)
            {
                strings.Add("システム");
            }
            if ((file.Attr & System.IO.FileAttributes.Hidden) == System.IO.FileAttributes.Hidden)
            {
                strings.Add("隠し");
            }

            if (strings.Count > 0)
            {
                return string.Join(", ", strings.ToArray());
            }

            return "";
        }

        private void AddBasicImageSize()
        {
            int idx = this.listViewBasic.Items.Count;
            this.listViewBasic.Items.Add("画像サイズ");
            if (this.m_current.ImageSize != null)
            {
                this.listViewBasic.Items[idx].SubItems.Add(
                    string.Format("{0} x {1}",
                    this.m_current.ImageSize.Value.Width,
                    this.m_current.ImageSize.Value.Height));
            }
            else
            {
                this.listViewBasic.Items[idx].SubItems.Add("-");
            }
        }

        private void AddHashMD5()
        {
            int idx = this.listViewBasic.Items.Count;
            this.listViewBasic.Items.Add("MD5");
            this.listViewBasic.Items[idx].SubItems.Add(this.m_current.HashMD5);
        }

        private void AddHashSHA1()
        {
            int idx = this.listViewBasic.Items.Count;
            this.listViewBasic.Items.Add("SHA1");
            this.listViewBasic.Items[idx].SubItems.Add(this.m_current.HashSHA1);
        }

        private void AddHashSHA256()
        {
            int idx = this.listViewBasic.Items.Count;
            this.listViewBasic.Items.Add("SHA256");
            this.listViewBasic.Items[idx].SubItems.Add(this.m_current.HashSHA256);
        }

        private void AddHashSHA512()
        {
            int idx = this.listViewBasic.Items.Count;
            this.listViewBasic.Items.Add("SHA512");
            this.listViewBasic.Items[idx].SubItems.Add(this.m_current.HashSHA512);
        }

        #endregion

        #region Exif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        private void UpdateExifPage(File file)
        {
            if (this.m_isSetExif) return;

            listViewExif.BeginUpdate();
            listViewExif.Items.Clear();

            if (file.Exif != null)
            {
#if false
                AddExifItem(file.Exif.ImageDescription, "ImageDescription");
                AddExifItem(file.Exif.Make, "Make");
                AddExifItem(file.Exif.Model, "Model");
                AddExifItem(file.Exif.OrientationAsText(), "Orientation");
                AddExifItem(file.Exif.XResolutionAsText(), "XResolution");
                AddExifItem(file.Exif.YResolutionAsText(), "YResolution");
                AddExifItem(file.Exif.ResolutionUnitAsText(), "ResolutionUnit");
                AddExifItem(file.Exif.Software, "Software");
                AddExifItem(file.Exif.DateTime, "DateTime");
                AddExifItem(file.Exif.Artist, "Artist");
                AddExifItem(file.Exif.WhitePointAsText(), "WhitePoint");
                AddExifItem(file.Exif.PrimaryChromaticitiesAsText(), "PrimaryChromaticities");
                AddExifItem(file.Exif.YCbCrCoefficientsAsText(), "YCbCrCoefficientst");
                AddExifItem(file.Exif.YCbCrPositioningAsText(), "YCbCrPositioning");
                AddExifItem(file.Exif.ReferenceBlackWhiteAsText(), "ReferenceBlackWhite");
                AddExifItem(file.Exif.Copyright, "Copyright");
                AddExifItem(file.Exif.ExifIFDPointer, "ExifIFDPointer");

                AddExifItem(file.Exif.ExposureTimeAsText(), "ExposureTime");
                AddExifItem(file.Exif.FNumberAsText(), "FNumber");
                AddExifItem(file.Exif.ExposureProgramAsText(), "ExposureProgram");
                AddExifItem(file.Exif.ISOSpeedRatingsAsText(), "ISOSpeedRatings");
                AddExifItem(file.Exif.ExifVersion, "ExifVersion");
                AddExifItem(file.Exif.DateTimeOriginal, "DateTimeOriginal");
                AddExifItem(file.Exif.DateTimeDigitized, "DateTimeDigitized");
                AddExifItem(file.Exif.ComponentsConfigurationAsText(), "ComponentsConfiguration");
                AddExifItem(file.Exif.CompressedBitsPerPixelAsText(), "CompressedBitsPerPixel");
                AddExifItem(file.Exif.ShutterSpeedValueAsText(), "ShutterSpeedValue");
                AddExifItem(file.Exif.ApertureValueAsText(), "ApertureValue");
                AddExifItem(file.Exif.BrightnessValueAsText(), "BrightnessValue");
                AddExifItem(file.Exif.ExposureBiasValueAsText(), "ExposureBiasValue");
                AddExifItem(file.Exif.MaxApertureValueAsText(), "MaxApertureValue");
                AddExifItem(file.Exif.SubjectDistanceAsText(), "SubjectDistance");
                AddExifItem(file.Exif.MeteringModeAsText(), "MeteringMode");
                AddExifItem(file.Exif.LightSourceAsText(), "LightSource");
                AddExifItem(file.Exif.FlashAsText(), "Flash");
                AddExifItem(file.Exif.FocalLengthAsText(), "FocalLength");
                AddExifItem(file.Exif.MakerNote, "MakerNote");
                AddExifItem(file.Exif.UserComment, "UserComment");
                AddExifItem(file.Exif.SubsecTime, "SubsecTime");
                AddExifItem(file.Exif.SubsecTimeOriginal, "SubsecTimeOriginal");
                AddExifItem(file.Exif.SubsecTimeDigitized, "SubsecTimeDigitized");
                AddExifItem(file.Exif.FlashPixVersion, "FlashPixVersion");
                AddExifItem(file.Exif.ColorSpaceAsText(), "ColorSpace");
                AddExifItem(file.Exif.ExifImageWidthAsText(), "ExifImageWidth");
                AddExifItem(file.Exif.ExifImageHeightAsText(), "ExifImageHeight");
                AddExifItem(file.Exif.RelatedSoundFile, "RelatedSoundFile");
                AddExifItem(file.Exif.InteroperabilityIFDPointer, "InteroperabilityIFDPointer");
                AddExifItem(file.Exif.FocalPlaneXResolutionAsText(), "FocalPlaneXResolution");
                AddExifItem(file.Exif.FocalPlaneYResolutionAsText(), "FocalPlaneYResolution");
                AddExifItem(file.Exif.FocalPlaneResolutionUnitAsText(), "FocalPlaneResolutionUnit");
                AddExifItem(file.Exif.SensingMethodAsText(), "SensingMethod");
                AddExifItem(file.Exif.FileSource, "FileSource");
                AddExifItem(file.Exif.SceneType, "SceneType");
                AddExifItem(file.Exif.CFAPattern, "CFAPattern");
#endif
                AddExifItem(file.Exif.ImageDescription, "画像タイトル");
                AddExifItem(file.Exif.Make, "画像入力機器のメーカー名");
                AddExifItem(file.Exif.Model, "画像入力機器のモデル名");
                AddExifItem(file.Exif.OrientationAsText(), "画像方向");
                AddExifItem(file.Exif.XResolutionAsText(), "画像の幅の解像度");
                AddExifItem(file.Exif.YResolutionAsText(), "画像の高さの解像度");
                AddExifItem(file.Exif.ResolutionUnitAsText(), "画像の幅と高さの解像度の単位");
                AddExifItem(file.Exif.Software, "使用ソフトウェア名");
                AddExifItem(file.Exif.DateTime, "撮影日時");
                AddExifItem(file.Exif.Artist, "アーティスト");
                AddExifItem(file.Exif.WhitePointAsText(), "参照白色点の色度座標値");
                AddExifItem(file.Exif.PrimaryChromaticitiesAsText(), "原色の色度座標値");
                AddExifItem(file.Exif.YCbCrCoefficientsAsText(), "色変換マトリクス係数");
                AddExifItem(file.Exif.YCbCrPositioningAsText(), "YCC の画素構成 (Y と C の位置)");
                AddExifItem(file.Exif.ReferenceBlackWhiteAsText(), "参照黒色点値と参照白色点値");
                AddExifItem(file.Exif.Copyright, "撮影著作権者/編集著作権者");
                AddExifItem(file.Exif.ExifIFDPointer, "Exif タグ");

                AddExifItem(file.Exif.ExposureTimeAsText(), "露出時間");
                AddExifItem(file.Exif.FNumberAsText(), "F値");
                AddExifItem(file.Exif.ExposureProgramAsText(), "露出プログラム");
                AddExifItem(file.Exif.ISOSpeedRatingsAsText(), "ISO スピードレート");
                AddExifItem(file.Exif.ExifVersion, "Exif バージョン");
                AddExifItem(file.Exif.DateTimeOriginal, "原画像データの生成日時");
                AddExifItem(file.Exif.DateTimeDigitized, "デジタルデータの生成日時");
                AddExifItem(file.Exif.ComponentsConfigurationAsText(), "各コンポーネントの意味");
                AddExifItem(file.Exif.CompressedBitsPerPixelAsText(), "画像圧縮モード");
                AddExifItem(file.Exif.ShutterSpeedValueAsText(), "シャッタースピード");
                AddExifItem(file.Exif.ApertureValueAsText(), "絞り値");
                AddExifItem(file.Exif.BrightnessValueAsText(), "輝度値");
                AddExifItem(file.Exif.ExposureBiasValueAsText(), "露出補正値");
                AddExifItem(file.Exif.MaxApertureValueAsText(), "レンズ最小 F 値");
                AddExifItem(file.Exif.SubjectDistanceAsText(), "被写体距離");
                AddExifItem(file.Exif.MeteringModeAsText(), "測光方式");
                AddExifItem(file.Exif.LightSourceAsText(), "光源");
                AddExifItem(file.Exif.FlashAsText(), "フラッシュ");
                AddExifItem(file.Exif.FocalLengthAsText(), "レンズ焦点距離");
                AddExifItem(file.Exif.MakerNote, "メーカーノート");
                AddExifItem(file.Exif.UserComment, "ユーザーコメント");
                AddExifItem(file.Exif.SubsecTime, "Date Time のサブセック");
                AddExifItem(file.Exif.SubsecTimeOriginal, "Date Time Original のサブセック");
                AddExifItem(file.Exif.SubsecTimeDigitized, "Date Time Digitized のサブセック");
                AddExifItem(file.Exif.FlashPixVersion, "対応フラッシュピックスバージョン");
                AddExifItem(file.Exif.ColorSpaceAsText(), "色空間情報");
                AddExifItem(file.Exif.ExifImageWidthAsText(), "画像の幅");
                AddExifItem(file.Exif.ExifImageHeightAsText(), "画像の高さ");
                AddExifItem(file.Exif.RelatedSoundFile, "関連音声ファイル");
                AddExifItem(file.Exif.InteroperabilityIFDPointer, "互換性 IFD へのポインタ");
                AddExifItem(file.Exif.FocalPlaneXResolutionAsText(), "焦点面の幅の解像度");
                AddExifItem(file.Exif.FocalPlaneYResolutionAsText(), "焦点面の高さの解像度");
                AddExifItem(file.Exif.FocalPlaneResolutionUnitAsText(), "焦点面解像度単位");
                AddExifItem(file.Exif.SensingMethodAsText(), "センサー方式");
                AddExifItem(file.Exif.FileSource, "ファイルソース");
                AddExifItem(file.Exif.SceneType, "シーンタイプ");
                AddExifItem(file.Exif.CFAPattern, "CFA パターン");
            }

            listViewExif.EndUpdate();

            this.m_isSetExif = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        private void AddExifItem(libpixy.net.Exif.ExifTags.Param<libpixy.net.Exif.Tag.Rational> value, string name)
        {
            if (value != null)
            {
                ListViewItem item = new ListViewItem();
                item.Text = name;
                item.SubItems.Add(string.Format("{0}/{1}", value.Value.Num, value.Value.Denom));
                this.listViewExif.Items.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="name"></param>
        private void AddExifItem(libpixy.net.Exif.ExifTags.Param<libpixy.net.Exif.Tag.Rational[]> values, string name)
        {
            if (values != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (libpixy.net.Exif.Tag.Rational value in values.Value)
                {
                    sb.Append(string.Format("{0}/{1}, ", value.Num, value.Denom));
                }

                ListViewItem item = new ListViewItem();
                item.Text = name;
                item.SubItems.Add(sb.ToString());
                this.listViewExif.Items.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        private void AddExifItem(libpixy.net.Exif.ExifTags.Param<uint> value, string name)
        {
            if (value != null)
            {
                ListViewItem item = new ListViewItem();
                item.Text = name;
                item.SubItems.Add(string.Format("{0}", value.Value));
                this.listViewExif.Items.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        private void AddExifItem(libpixy.net.Exif.ExifTags.Param<string> value, string name)
        {
            if (value != null && value.Value != null && value.Value.Length > 0)
            {
                ListViewItem item = new ListViewItem();
                item.Text = name;
                item.SubItems.Add(value.Value);
                this.listViewExif.Items.Add(item);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        private void AddExifItem(string value, string name)
        {
            if (value != null && value.Length > 0)
            {
                ListViewItem item = new ListViewItem();
                item.Text = name;
                item.SubItems.Add(value);
                this.listViewExif.Items.Add(item);
            }
        }

        #endregion

        #region ID3Tag

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        private void UpdateID3TagPage(File file)
        {
            if (this.m_isSetID3) return;

            listViewID3Tag.BeginUpdate();
            listViewID3Tag.Items.Clear();

            if (file.ID3Tag != null)
            {
                listViewID3Tag.Items.Add("トラック名");
                listViewID3Tag.Items[0].SubItems.Add(file.ID3Tag.TrackName);

                listViewID3Tag.Items.Add("アーティスト");
                listViewID3Tag.Items[1].SubItems.Add(file.ID3Tag.ArtistName);

                listViewID3Tag.Items.Add("アルバム");
                listViewID3Tag.Items[2].SubItems.Add(file.ID3Tag.AlbumName);

                listViewID3Tag.Items.Add("トラック No");
                if (file.ID3Tag.Track > 0)
                {
                    listViewID3Tag.Items[3].SubItems.Add(file.ID3Tag.Track.ToString());
                }

                listViewID3Tag.Items.Add("ジャンル");
                listViewID3Tag.Items[4].SubItems.Add(file.ID3Tag.Genre);

                listViewID3Tag.Items.Add("年");
                if (file.ID3Tag.Year > 0)
                {
                    listViewID3Tag.Items[5].SubItems.Add(file.ID3Tag.Year.ToString());
                }

                listViewID3Tag.Items.Add("チャンネル");
                if (file.ID3Tag.Channels > 0)
                {
                    listViewID3Tag.Items[6].SubItems.Add(file.ID3Tag.Channels.ToString());
                }

                listViewID3Tag.Items.Add("ビットレート");
                if (file.ID3Tag.BitRate > 0)
                {
                    listViewID3Tag.Items[7].SubItems.Add(file.ID3Tag.BitRate.ToString());
                }

                listViewID3Tag.Items.Add("サンプリングレート");
                if (file.ID3Tag.SampleRate > 0)
                {
                    listViewID3Tag.Items[8].SubItems.Add(file.ID3Tag.SampleRate.ToString());
                }

                listViewID3Tag.Items.Add("長さ");
                if (file.ID3Tag.Length > 0)
                {
                    listViewID3Tag.Items[9].SubItems.Add(ID3TagLengthToString(file.ID3Tag.Length));
                }

                listViewID3Tag.Items.Add("コメント");
                listViewID3Tag.Items[10].SubItems.Add(file.ID3Tag.Comment);
            }

            listViewID3Tag.EndUpdate();

            this.m_isSetID3 = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string ID3TagLengthToString(int length)
        {
            int h = length / (3600);
            int m = (length - h * 3600) / 60;
            int s = length % 60;
            if (h > 0)
            {
                return string.Format("{0}:{1:00}:{2:00}", h, m, s);
            }
            else
            {
                return string.Format("{0}:{1:00}", m, s);
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        private void UpdateActivePage()
        {
            if (this.m_current == null)
            {
                return;
            }

            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    UpdateBasicPage(this.m_current);
                    break;

                case 1:
                    UpdateExifPage(this.m_current);
                    break;

                case 2:
                    UpdateID3TagPage(this.m_current);
                    break;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateActivePage();
        }

        private void FileInfoWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.MainForm.WndFileInfo = null;
        }

        private void FileInfoWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.FocusResultItemEvent -= new Global.FocusResultItemHandler(Global_FocusResultItemEvent);
            Global.ClearResultEvent -= new EventHandler(Global_ClearResult);
            Global.NewDocumentEvent -= new EventHandler(Global_NewDocument);
            Global.OpenDocumentEvent -= new EventHandler(Global_OpenDocument);
        }

        private void listViewBasic_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hti = this.listViewBasic.HitTest(
                this.listViewBasic.PointToClient(Cursor.Position));
            if (hti.Item != null)
            {
                this.m_copy_string = this.listViewBasic.Items[hti.Item.Index].SubItems[1].Text;
            }
            this.contextMenuBasic.Show(Cursor.Position);
        }

        private void listViewExif_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hti = this.listViewExif.HitTest(
                this.listViewExif.PointToClient(Cursor.Position));
            if (hti.Item != null)
            {
                this.m_copy_string = this.listViewExif.Items[hti.Item.Index].SubItems[1].Text;
            }
            this.contextMenuExif.Show(Cursor.Position);
        }

        private void listViewID3Tag_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hti = this.listViewID3Tag.HitTest(
                this.listViewID3Tag.PointToClient(Cursor.Position));
            if (hti.Item != null)
            {
                this.m_copy_string = this.listViewID3Tag.Items[hti.Item.Index].SubItems[1].Text;
            }
            this.contextMenuID3.Show(Cursor.Position);
        }

        private void CopyToClipboard()
        {
            try
            {
                Clipboard.Clear();
                if (m_copy_string.Length > 0)
                {
                    Clipboard.SetText(m_copy_string);
                }
            }
            catch
            {
            }
        }

        private void contextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string command = (string)e.ClickedItem.Tag;
            switch (command)
            {
                case "copy-to-clipboard":
                    CopyToClipboard();
                    break;

                case "get-image-size":
                    if (this.m_current != null && this.m_current.ReadFlags.ReadImageSize == false)
                    {
                        AddBasicImageSize();
                    }
                    break;

                case "get-hash-md5":
                    if (this.m_current != null && this.m_current.ReadFlags.HashMD5 == false)
                    {
                        AddHashMD5();
                    }
                    break;

                case "get-hash-sha1":
                    if (this.m_current != null && this.m_current.ReadFlags.HashSHA1 == false)
                    {
                        AddHashSHA1();
                    }
                    break;

                case "get-hash-sha256":
                    if (this.m_current != null && this.m_current.ReadFlags.HashSHA256 == false)
                    {
                        AddHashSHA256();
                    }
                    break;

                case "get-hash-sha512":
                    if (this.m_current != null && this.m_current.ReadFlags.HashSHA512 == false)
                    {
                        AddHashSHA512();
                    }
                    break;
            }
        }

        private void contextMenuExif_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string command = (string)e.ClickedItem.Tag;
            switch (command)
            {
                case "copy-to-clipboard":
                    CopyToClipboard();
                    break;
            }
        }

        private void contextMenuID3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string command = (string)e.ClickedItem.Tag;
            switch (command)
            {
                case "copy-to-clipboard":
                    CopyToClipboard();
                    break;
            }
        }


    }
}
