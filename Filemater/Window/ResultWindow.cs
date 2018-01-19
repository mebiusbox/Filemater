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
    public class ResultWindow : DockableWindow
    {
        #region Fields

        private libpixy.net.Controls.CustomListView listView;
        private ToolStripContainer toolStripContainer1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel ctrlResultCount;
        private List<ResultColumn> resultColumns = new List<ResultColumn>();
        private List<File> results = new List<File>();
        private string m_searchPattern = "";
        private int m_searchStart = 0;
        private ResultColumn m_searchTarget = ResultColumn.FILENAME;
        private ListView.ListViewItemCollection m_itemCollection;
        private ListView.SelectedIndexCollection m_selCollection;

        #endregion

        public enum ResultColumn
        {
            CHECKBOX = 0,
            FILENAME,
            PATH,
            SIZE,
            CREATE_TIME,
            UPDATE_TIME,
            IMAGESIZE,
            EXIF_MAKE,
            EXIF_MODEL,
            EXIF_DATETIME,
            EXIF_IMAGESIZE,
            EXIF_ISO_SPEED,
            EXIF_SHUTTER_SPEED,
            EXIF_APERTURE,
            EXIF_EXPOSURE_PROGRAM,
            EXIF_FOCAL_LENGTH,
            ID3TAG_TRACKNAME,
            ID3TAG_ARTIST,
            ID3TAG_ALBUM,
            ID3TAG_YEAR,
            ID3TAG_TRACKNO,
            ID3TAG_GENRE,
            ID3TAG_LENGTH,
            ID3TAG_BITRATE,
            STATUS,
            GOAL_NODE,
            NUM
        }

        public static string[] ResultColumnText = 
        {
            "",/* CHECKBOX */
            "名前", /* FILENAME */
            "パス", /* PATH */
            "サイズ", /* SIZE */
            "作成時間", /* CREATE_TIME */
            "更新時間", /* UPDATE_TIME */
            "画像の大きさ", /* IMAGESIZE */
            "Exif:カメラのメーカー", /* EXIF_MAKE */
            "Exif:カメラのモデル", /* EXIF_MODEL */
            "Exif:撮影時間", /* EXIF_DATETIME */
            "Exif:大きさ", /* EXIF_IMAGESIZE */
            "Exif:ISO感度", /* EXIF_ISO_SPEED */
            "Exif:シャッタースピード", /* EXIF_SHUTTER_SPEED */
            "Exif:絞り値", /* EXIF_APERTURE */
            "Exif:撮影モード",  /* EXIF_EXPOSURE_PROGRAM */
            "Exif:焦点距離", /* EXIF_FOCAL_LENGTH */
            "ID3:トラック名", /* ID3TAG_TRACKNAME */
            "ID3:アーティスト", /* ID3TAG_ARTIST */
            "ID3:アルバム", /* ID3TAG_ALBUM */
            "ID3:年", /* ID3TAG_YEAR */
            "ID3:トラック番号", /* ID3TAG_TRACKNO */
            "ID3:ジャンル", /* ID3TAG_GENRE */
            "ID3:長さ", /* ID3TAG_LENGTH */
            "ID3:ビットレート", /* ID3TAG_BITRATE */
            "ステータス", /* STATUS */
            "最後のノード", /* GOAL_NODE" */
        };

        public static int[] ResultColumnWidth = 
        {
            50, /* CHECKBOX */
            100, /* FILENAME */
            200, /* PATH */
            100, /* SIZE */
            100, /* CREATE_TIME */
            100, /* UPDATE_TIME */
            100, /* IMAGESIZE */
            100, /* EXIF_MAKE */
            200, /* EXIF_MODEL */
            100, /* EXIF_DATETIME */
            100, /* EXIF_IMAGESIZE */
            50, /* EXIF_ISO_SPEED */
            50, /* EXIF_SHUTTER_SPEED */
            50, /* EXIF_APERTURE */
            100,  /* EXIF_EXPOSURE_PROGRAM */
            50, /* EXIF_FOCAL_LENGTH */
            100, /* ID3TAG_TRACKNAME */
            100, /* ID3TAG_ARTIST */
            100, /* ID3TAG_ALBUM */
            20, /* ID3TAG_YEAR */
            20, /* ID3TAG_TRACKNO */
            50, /* ID3TAG_GENRE */
            100, /* ID3TAG_LENGTH */
            20, /* ID3TAG_BITRATE */
            100, /* STATUS */
            100, /* GOAL_NODE */
        };

        public static string[] ResultColumnTextEn = 
        {
            "checkbox",/* CHECKBOX */
            "filename", /* FILENAME */
            "path", /* PATH */
            "size", /* SIZE */
            "ctime", /* CREATE_TIME */
            "utime", /* UPDATE_TIME */
            "imagesize", /* IMAGESIZE */
            "exif-make", /* EXIF_MAKE */
            "exif-model", /* EXIF_MODEL */
            "exif-datetime", /* EXIF_DATETIME */
            "exif-imagesize", /* EXIF_IMAGESIZE */
            "exif-iso-speed", /* EXIF_ISO_SPEED */
            "exif-shutter-speed", /* EXIF_SHUTTER_SPEED */
            "exif-aperture", /* EXIF_APERTURE */
            "exif-exposure-program",  /* EXIF_EXPOSURE_PROGRAM */
            "exif-focal-length", /* EXIF_FOCAL_LENGTH */
            "id3-trackname", /* ID3TAG_TRACKNAME */
            "id3-artist", /* ID3TAG_ARTIST */
            "id3-album", /* ID3TAG_ALBUM */
            "id3-year", /* ID3TAG_YEAR */
            "id3-trackno", /* ID3TAG_TRACKNO */
            "id3-genre", /* ID3TAG_GENRE */
            "id3-length", /* ID3TAG_LENGTH */
            "id3-bitrate", /* ID3TAG_BITRATE */
            "status", /* STATUS */
            "goalnode", /* GOAL_NODE */
        };

        private ResultColumn sortColumn = ResultColumn.FILENAME;
        private SortOrder sortOrder = SortOrder.Ascending;
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.IContainer components;
        private ToolStripButton resultToolbarExec;
        private ToolStripButton resultsToolbarSearch;
        private ToolStripTextBox resultsToolbarSearchBox;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton resultsToolbarCheckUtil;
        private ToolStripMenuItem resultsToolbarCheckAll;
        private ToolStripMenuItem resultsToolbarUncheckAll;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem resultsToolbarCheckSelection;
        private ToolStripMenuItem resultsToolbarUncheckSelection;
        private ToolStripButton resultsToolbarSearchTarget;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton resultsToolbarSearchNext;
        private ContextMenuStrip contextMenuStrip2;

        public static HorizontalAlignment[] ResultColumnAlign = 
        {
            HorizontalAlignment.Center, /* CHECKBOX */
            HorizontalAlignment.Left, /* FILENAME */
            HorizontalAlignment.Left, /* PATH */
            HorizontalAlignment.Right, /* SIZE */
            HorizontalAlignment.Center, /* CREATE_TIME */
            HorizontalAlignment.Center, /* UPDATE_TIME */
            HorizontalAlignment.Left, /* IMAGESIZE */
            HorizontalAlignment.Left, /* EXIF_MAKE */
            HorizontalAlignment.Left, /* EXIF_MODEL */
            HorizontalAlignment.Center, /* EXIF_DATETIME */
            HorizontalAlignment.Left, /* EXIF_IMAGESIZE */
            HorizontalAlignment.Right, /* EXIF_ISO_SPEED */
            HorizontalAlignment.Right, /* EXIF_SHUTTER_SPEED */
            HorizontalAlignment.Right, /* EXIF_APERTURE */
            HorizontalAlignment.Left,  /* EXIF_EXPOSURE_PROGRAM */
            HorizontalAlignment.Right, /* EXIF_FOCAL_LENGTH */
            HorizontalAlignment.Left, /* ID3TAG_TRACKNAME */
            HorizontalAlignment.Left, /* ID3TAG_ARTIST */
            HorizontalAlignment.Left, /* ID3TAG_ALBUM */
            HorizontalAlignment.Center, /* ID3TAG_YEAR */
            HorizontalAlignment.Center, /* ID3TAG_TRACKNO */
            HorizontalAlignment.Left, /* ID3TAG_GENRE */
            HorizontalAlignment.Center, /* ID3TAG_LENGTH */
            HorizontalAlignment.Center, /* ID3TAG_BITRATE */
            HorizontalAlignment.Left, /* STATUS */
            HorizontalAlignment.Left, /* GOAL_NODE */
        };

        public ResultWindow()
        {
            InitializeComponent();

            this.toolStrip1.ImageList = new ImageList();
            this.toolStrip1.ImageList.ImageSize = new Size(16, 16);
            this.toolStrip1.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_magnifier_zoom);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_magnifier_zoom_out);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_grid);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_grid_snap);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_control_red);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_magnifier_left);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_target);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_ui_check_box);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_magnifier);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_magnifier__arrow);
            this.resultsToolbarCheckUtil.ImageIndex = 7;
            this.resultToolbarExec.ImageIndex = 4;
            this.resultsToolbarSearch.ImageIndex = 8;
            this.resultsToolbarSearchNext.ImageIndex = 9;
            this.resultsToolbarSearchTarget.ImageIndex = 6;

            LoadResultColumnSetting();

            this.Text = "Results";
            ResetResultColumns();
            this.listView.HandleCreated += new EventHandler(listView_HandleCreated);
            this.listView.ColumnHeaderClick += new libpixy.net.Controls.CustomListView.ColumnHeaderClickEvent(listView_ColumnHeaderClick);

            Global.ClearResultEvent += new EventHandler(Global_ClearResultEvent);
            Global.UpdateResultEvent += new EventHandler(Global_UpdateResultEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadResultColumnSetting()
        {
            string s = Properties.Settings.Default.ResultsColumn;
            if (s.Length > 0)
            {
                string[] cols = s.Split(new char[] { ',' });
                foreach (string c in cols)
                {
                    int idx = libpixy.net.Utils.ArrayUtils.IndexOf(ResultColumnTextEn, c);
                    if (idx >= 0)
                    {
                        this.resultColumns.Add((ResultColumn)idx);
                    }
                }
            }

            if (this.resultColumns.Count < 2)
            {
                this.resultColumns.Clear();
                this.resultColumns.Add(ResultColumn.CHECKBOX);
                this.resultColumns.Add(ResultColumn.STATUS);
                this.resultColumns.Add(ResultColumn.GOAL_NODE);
                this.resultColumns.Add(ResultColumn.FILENAME);
                this.resultColumns.Add(ResultColumn.SIZE);
                this.resultColumns.Add(ResultColumn.UPDATE_TIME);
                this.resultColumns.Add(ResultColumn.PATH);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SaveResultColumnSetting()
        {
            List<ColumnHeader> cols = new List<ColumnHeader>();
            foreach (ColumnHeader hdr in this.listView.Columns)
            {
                cols.Add(hdr);
            }
            cols.Sort(new libpixy.net.Controls.CustomListView.ListColumnHeaderSortByDisplayIndex());
            string[] strings = new string[cols.Count];
            int i = 0;
            foreach (ColumnHeader hdr in cols)
            {
                int idx = (int)hdr.Tag;
                strings[i++] = ResultColumnTextEn[idx];
            }

            Properties.Settings.Default.ResultsColumn = string.Join(",", strings);
        }

        void listView_HandleCreated(object sender, EventArgs e)
        {
            libpixy.net.Shell.ShellImageList.SetSmallImageList(this.listView);
            libpixy.net.Shell.ShellImageList.SetLargeImageList(this.listView);
        }

        private void ResetResultColumns()
        {
            int idx = 0;
            foreach (ResultColumn col in this.resultColumns)
            {
                this.listView.Columns.Add(ResultColumnText[(int)col]);
                this.listView.Columns[idx].Width = ResultColumnWidth[(int)col];
                this.listView.Columns[idx].TextAlign = ResultColumnAlign[(int)col];
                this.listView.Columns[idx].Tag = (int)col;
                idx++;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultWindow));
            this.listView = new libpixy.net.Controls.CustomListView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ctrlResultCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resultToolbarExec = new System.Windows.Forms.ToolStripButton();
            this.resultsToolbarSearch = new System.Windows.Forms.ToolStripButton();
            this.resultsToolbarSearchBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.resultsToolbarSearchTarget = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.resultsToolbarSearchNext = new System.Windows.Forms.ToolStripButton();
            this.resultsToolbarCheckUtil = new System.Windows.Forms.ToolStripDropDownButton();
            this.resultsToolbarCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolbarUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resultsToolbarCheckSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolbarUncheckSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.CheckBoxes = true;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Margin = new System.Windows.Forms.Padding(3, 3, 3, 32);
            this.listView.Name = "listView";
            this.listView.OwnerDraw = true;
            this.listView.Size = new System.Drawing.Size(392, 294);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.VirtualMode = true;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView_RetrieveVirtualItem);
            this.listView.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.listView_ColumnReordered);
            this.listView.Click += new System.EventHandler(this.listView_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            this.toolStripContainer1.BottomToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.listView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(392, 294);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 25);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(392, 341);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrlResultCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(392, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            // 
            // ctrlResultCount
            // 
            this.ctrlResultCount.Name = "ctrlResultCount";
            this.ctrlResultCount.Size = new System.Drawing.Size(0, 17);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // resultToolbarExec
            // 
            this.resultToolbarExec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resultToolbarExec.Image = ((System.Drawing.Image)(resources.GetObject("resultToolbarExec.Image")));
            this.resultToolbarExec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resultToolbarExec.Name = "resultToolbarExec";
            this.resultToolbarExec.Size = new System.Drawing.Size(23, 22);
            this.resultToolbarExec.Text = "実行";
            this.resultToolbarExec.Click += new System.EventHandler(this.resultToolbarExec_Click);
            // 
            // resultsToolbarSearch
            // 
            this.resultsToolbarSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.resultsToolbarSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resultsToolbarSearch.Image = ((System.Drawing.Image)(resources.GetObject("resultsToolbarSearch.Image")));
            this.resultsToolbarSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resultsToolbarSearch.Name = "resultsToolbarSearch";
            this.resultsToolbarSearch.Size = new System.Drawing.Size(23, 22);
            this.resultsToolbarSearch.Text = "検索";
            this.resultsToolbarSearch.Click += new System.EventHandler(this.resultToolbarSearch_Click);
            // 
            // resultsToolbarSearchBox
            // 
            this.resultsToolbarSearchBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.resultsToolbarSearchBox.Name = "resultsToolbarSearchBox";
            this.resultsToolbarSearchBox.Size = new System.Drawing.Size(150, 25);
            this.resultsToolbarSearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resultsToolbarSearchBox_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resultToolbarExec,
            this.resultsToolbarSearchTarget,
            this.toolStripSeparator3,
            this.toolStripSeparator2,
            this.resultsToolbarSearchNext,
            this.resultsToolbarSearch,
            this.resultsToolbarSearchBox,
            this.resultsToolbarCheckUtil});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(392, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // resultsToolbarSearchTarget
            // 
            this.resultsToolbarSearchTarget.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.resultsToolbarSearchTarget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resultsToolbarSearchTarget.Image = ((System.Drawing.Image)(resources.GetObject("resultsToolbarSearchTarget.Image")));
            this.resultsToolbarSearchTarget.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resultsToolbarSearchTarget.Name = "resultsToolbarSearchTarget";
            this.resultsToolbarSearchTarget.Size = new System.Drawing.Size(23, 22);
            this.resultsToolbarSearchTarget.Text = "検索対象";
            this.resultsToolbarSearchTarget.Click += new System.EventHandler(this.resultsToolbarSearchTarget_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // resultsToolbarSearchNext
            // 
            this.resultsToolbarSearchNext.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.resultsToolbarSearchNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resultsToolbarSearchNext.Image = ((System.Drawing.Image)(resources.GetObject("resultsToolbarSearchNext.Image")));
            this.resultsToolbarSearchNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resultsToolbarSearchNext.Name = "resultsToolbarSearchNext";
            this.resultsToolbarSearchNext.Size = new System.Drawing.Size(23, 22);
            this.resultsToolbarSearchNext.Text = "次を検索";
            this.resultsToolbarSearchNext.Click += new System.EventHandler(this.resultsToolbarSearchNext_Click);
            // 
            // resultsToolbarCheckUtil
            // 
            this.resultsToolbarCheckUtil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.resultsToolbarCheckUtil.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resultsToolbarCheckAll,
            this.resultsToolbarUncheckAll,
            this.toolStripSeparator1,
            this.resultsToolbarCheckSelection,
            this.resultsToolbarUncheckSelection});
            this.resultsToolbarCheckUtil.Image = ((System.Drawing.Image)(resources.GetObject("resultsToolbarCheckUtil.Image")));
            this.resultsToolbarCheckUtil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resultsToolbarCheckUtil.Name = "resultsToolbarCheckUtil";
            this.resultsToolbarCheckUtil.Size = new System.Drawing.Size(29, 22);
            this.resultsToolbarCheckUtil.Text = "チェック";
            // 
            // resultsToolbarCheckAll
            // 
            this.resultsToolbarCheckAll.Name = "resultsToolbarCheckAll";
            this.resultsToolbarCheckAll.Size = new System.Drawing.Size(235, 22);
            this.resultsToolbarCheckAll.Text = "すべてにチェックする";
            this.resultsToolbarCheckAll.Click += new System.EventHandler(this.resultsToolbarCheckAll_Click);
            // 
            // resultsToolbarUncheckAll
            // 
            this.resultsToolbarUncheckAll.Name = "resultsToolbarUncheckAll";
            this.resultsToolbarUncheckAll.Size = new System.Drawing.Size(235, 22);
            this.resultsToolbarUncheckAll.Text = "すべてのチェックをはずす";
            this.resultsToolbarUncheckAll.Click += new System.EventHandler(this.resultsToolbarUncheckAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // resultsToolbarCheckSelection
            // 
            this.resultsToolbarCheckSelection.Name = "resultsToolbarCheckSelection";
            this.resultsToolbarCheckSelection.Size = new System.Drawing.Size(235, 22);
            this.resultsToolbarCheckSelection.Text = "選択している項目をチェックする";
            this.resultsToolbarCheckSelection.Click += new System.EventHandler(this.resultsToolbarCheckSelection_Click);
            // 
            // resultsToolbarUncheckSelection
            // 
            this.resultsToolbarUncheckSelection.Name = "resultsToolbarUncheckSelection";
            this.resultsToolbarUncheckSelection.Size = new System.Drawing.Size(235, 22);
            this.resultsToolbarUncheckSelection.Text = "選択している項目のチェックをはずす";
            this.resultsToolbarUncheckSelection.Click += new System.EventHandler(this.resultsToolbarUncheckSelection_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            // 
            // ResultWindow
            // 
            this.ClientSize = new System.Drawing.Size(392, 366);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResultWindow";
            this.TabText = "Results";
            this.Text = "Results";
            this.Load += new System.EventHandler(this.ResultWindow_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResultWindow_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResultWindow_FormClosing);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void Global_ClearResultEvent(object sender, EventArgs e)
        {
            this.listView.BeginUpdate();
            this.listView.Items.Clear();
            this.listView.VirtualListSize = 0;
            this.listView.EndUpdate();
            this.ctrlResultCount.Text = "0個";
            this.results.Clear();
        }

        public void Global_UpdateResultEvent(object sender, EventArgs e)
        {
            this.results.AddRange(Global.Results);
            this.results.Sort(CreateComparer());
            if (this.sortOrder == SortOrder.Descending)
            {
                this.results.Reverse();
            }

            ResetContent();
        }

        private void ResetContent()
        {
            this.listView.BeginUpdate();
            this.listView.VirtualListSize = this.results.Count;
            this.listView.EndUpdate();
            this.listView.Update();
            this.ctrlResultCount.Text = string.Format("{0}個", this.results.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Find()
        {
            this.m_searchStart = 0;
            this.m_searchPattern = this.resultsToolbarSearchBox.Text;
            if (this.m_searchPattern.Length > 0)
            {
                this.m_searchPattern = this.m_searchPattern.ToLower();
                FindNext();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void FindNext()
        {
            int i;
            for (i = this.m_searchStart; i < this.results.Count; ++i)
            {
                string text = GetItemText(this.results[i], this.m_searchTarget);
                if (text.Length > 0)
                {
                    text = text.ToLower();
                    if (text.IndexOf(this.m_searchPattern) >= 0)
                    {
                        this.listView.BeginUpdate();
                        for (int selIndex = 0; selIndex < this.m_selCollection.Count; ++selIndex)
                        {
                            this.m_itemCollection[this.m_selCollection[selIndex]].Selected = false;
                        }
                        this.m_itemCollection[i].Selected = true;
                        this.listView.EnsureVisible(i);
                        this.listView.EndUpdate();
                        this.m_searchStart = i + 1;
                        break;
                    }
                }
            }

            if (i == this.results.Count)
            {
                MessageBox.Show("見つからないか、最後まで検索しました。", "お知らせ");
                this.m_searchStart = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void SetFocusSearchBox()
        {
            this.resultsToolbarSearchBox.Focus();
            this.resultsToolbarSearchBox.TextBox.SelectAll();
        }

        private void listView_RetrieveVirtualItem(object sender, System.Windows.Forms.RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex < this.results.Count)
            {
                File file = this.results[e.ItemIndex];
                e.Item = new ListViewItem();
                e.Item.StateImageIndex = (file.IsOutput) ? 1 : 0;
                e.Item.ImageIndex = file.ShellItem.ImageIndex;

                e.Item.BackColor = (file.GroupIndex % 2 == 0) ? Color.FromArgb(0xff, 0xff, 0xff) : Color.FromArgb(0xff, 0xff, 0xdd);
                if (file.ProcessOutput)
                {
                    if (file.OutputResult)
                    {
                        e.Item.BackColor = Color.FromArgb(221, 255, 221);
                    }
                    else
                    {
                        e.Item.BackColor = Color.FromArgb(255, 235, 232);
                    }
                }

                for (int i = 0; i < this.resultColumns.Count; ++i)
                {
                    if (i == 0)
                    {
                        e.Item.Text = GetItemText(file, (ResultColumn)this.resultColumns[i]);
                    }
                    else
                    {
                        e.Item.SubItems.Add(GetItemText(file, (ResultColumn)this.resultColumns[i]));
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private string GetItemText(File file, ResultColumn col)
        {
            switch (col)
            {
                case ResultColumn.FILENAME:
                    return System.IO.Path.GetFileName(file.ShellItem.Path);

                case ResultColumn.PATH:
                    return file.ShellItem.Path;
                    
                case ResultColumn.SIZE:
                    return file.Size.ToString("#,##0");

                case ResultColumn.CREATE_TIME:
                    return file.CTime.ToString();

                case ResultColumn.UPDATE_TIME:
                    return file.UTime.ToString();

                case ResultColumn.IMAGESIZE:
                    if (file.ImageSize != null)
                    {
                        return string.Format("{0} x {1}", file.ImageSize.Value.Width, file.ImageSize.Value.Height);
                    }
                    break;

                case ResultColumn.EXIF_MAKE:
                    if (file.Exif != null && file.Exif.Make != null)
                    {
                        return file.Exif.Make.Value;
                    }
                    break;

                case ResultColumn.EXIF_MODEL:
                    if (file.Exif != null && file.Exif.Model != null)
                    {
                        return file.Exif.Model.Value;
                    }
                    break;

                case ResultColumn.EXIF_DATETIME:
                    if (file.Exif != null && file.Exif.DateTime != null)
                    {
                        return file.Exif.DateTime.Value;
                    }
                    break;

                case ResultColumn.EXIF_IMAGESIZE:
                    if (file.Exif != null && file.Exif.ExifImageWidth != null && file.Exif.ExifImageHeight != null)
                    {
                        return string.Format("{0} x {1}", file.Exif.ExifImageWidth.Value, file.Exif.ExifImageHeight.Value);
                    }
                    break;

                case ResultColumn.EXIF_ISO_SPEED:
                    if (file.Exif != null) return file.Exif.ISOSpeedRatingsAsText();
                    break;

                case ResultColumn.EXIF_SHUTTER_SPEED:
                    if (file.Exif != null) return file.Exif.ShutterSpeedValueAsText();
                    break;

                case ResultColumn.EXIF_APERTURE:
                    if (file.Exif != null) return file.Exif.ShutterSpeedValueAsText();
                    break;

                case ResultColumn.EXIF_EXPOSURE_PROGRAM:
                    if (file.Exif != null) return file.Exif.ExposureProgramAsText();
                    break;

                case ResultColumn.EXIF_FOCAL_LENGTH:
                    if (file.Exif != null) return file.Exif.FocalLengthAsText();
                    break;

                case ResultColumn.ID3TAG_TRACKNAME:
                    if (file.ID3Tag != null) return file.ID3Tag.TrackName;
                    break;

                case ResultColumn.ID3TAG_ARTIST:
                    if (file.ID3Tag != null) return file.ID3Tag.ArtistName;
                    break;

                case ResultColumn.ID3TAG_ALBUM:
                    if (file.ID3Tag != null) return file.ID3Tag.AlbumName;
                    break;

                case ResultColumn.ID3TAG_YEAR:
                    if (file.ID3Tag != null) return file.ID3Tag.Year.ToString();
                    break;

                case ResultColumn.ID3TAG_TRACKNO:
                    if (file.ID3Tag != null) return file.ID3Tag.Track.ToString();
                    break;

                case ResultColumn.ID3TAG_GENRE:
                    if (file.ID3Tag != null) return file.ID3Tag.Genre;
                    break;

                case ResultColumn.ID3TAG_LENGTH:
                    if (file.ID3Tag != null) return file.ID3Tag.Length.ToString();
                    break;

                case ResultColumn.ID3TAG_BITRATE:
                    if (file.ID3Tag != null) return file.ID3Tag.BitRate.ToString();
                    break;
            
                case ResultColumn.STATUS:
                    return file.Status;
                    
                case ResultColumn.GOAL_NODE:
                    int nodeId = file.nodeTrack.lastNodeId;
                    libpixy.net.Controls.Diagram.Node node = Global.MainForm.WndSchematic.Diagram.Document.FindNodeById(nodeId);
                    if (node != null)
                    {
                        return node.Name;
                    }
                    break;
            }

            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IComparer<File> CreateComparer()
        {
            switch (this.sortColumn)
            {
                case ResultColumn.FILENAME:
                    return new FileSort.FilenameComparer();

                case ResultColumn.PATH:
                    return new FileSort.PathComparer();

                case ResultColumn.SIZE:
                    return new FileSort.SizeComparer();

                case ResultColumn.CREATE_TIME:
                    return new FileSort.CreateTimeComparer();

                case ResultColumn.UPDATE_TIME:
                    return new FileSort.UpdateTimeComparer();

                case ResultColumn.IMAGESIZE:
                    return new FileSort.ImageSizeComparer();


                case ResultColumn.EXIF_MAKE:
                    return new FileSort.Exif.MakeComparer();

                case ResultColumn.EXIF_MODEL:
                    return new FileSort.Exif.ModelComparer();

                case ResultColumn.EXIF_DATETIME:
                    return new FileSort.Exif.DateTimeComparer();

                case ResultColumn.EXIF_IMAGESIZE:
                    return new FileSort.Exif.ImageSizeComparer();

                case ResultColumn.EXIF_ISO_SPEED:
                    return new FileSort.Exif.ISOSpeedComparer();

                case ResultColumn.EXIF_SHUTTER_SPEED:
                    return new FileSort.Exif.ShutterSpeedComparer();

                case ResultColumn.EXIF_APERTURE:
                    return new FileSort.Exif.ApertureComparer();

                case ResultColumn.EXIF_EXPOSURE_PROGRAM:
                    return new FileSort.Exif.ExposureProgramComparer();

                case ResultColumn.EXIF_FOCAL_LENGTH:
                    return new FileSort.Exif.FocalLengthComparer();


                case ResultColumn.ID3TAG_TRACKNAME:
                    return new FileSort.ID3.TrackNameComparer();

                case ResultColumn.ID3TAG_ARTIST:
                    return new FileSort.ID3.ArtistNameComparer();

                case ResultColumn.ID3TAG_ALBUM:
                    return new FileSort.ID3.AlbumNameComparer();

                case ResultColumn.ID3TAG_YEAR:
                    return new FileSort.ID3.YearComparer();

                case ResultColumn.ID3TAG_TRACKNO:
                    return new FileSort.ID3.TrackNoComparer();

                case ResultColumn.ID3TAG_GENRE:
                    return new FileSort.ID3.GenreComparer();

                case ResultColumn.ID3TAG_LENGTH:
                    return new FileSort.ID3.LengthComparer();

                case ResultColumn.ID3TAG_BITRATE:
                    return new FileSort.ID3.BitRateComparer();


                case ResultColumn.STATUS:
                    return new FileSort.StatusComparer();
                    
                case ResultColumn.GOAL_NODE:
                    return new FileSort.GoalNodeComparer();
            }

            return null;
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView.SelectedIndices.Count > 0 &&
                this.listView.SelectedIndices[0] < this.results.Count)
            {
                Global.RaiseFocusResultItemEvent(
                    this.results[this.listView.SelectedIndices[0]]);
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            Point pt = this.listView.PointToClient(Cursor.Position);
            ListViewHitTestInfo lvii = this.listView.HitTest(pt);
            if (lvii != null && lvii.Item != null)
            {
                if (HitTestCheckBox())
                {
                    return;
                }

                if (lvii.Item.Index < this.results.Count)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(this.results[lvii.Item.Index].ShellItem.Path);
                    }
                    catch
                    {
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            if (Global.AutoRun)
            {
                Forms.ProcessOutputForm form = new Forms.ProcessOutputForm();
                form.ShowDialog();
                this.listView.Invalidate();
            }
            else
            {
                DialogResult res = MessageBox.Show("実行してもよろしいでしょうか？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    Forms.ProcessOutputForm form = new Forms.ProcessOutputForm();
                    form.ShowDialog();
                    this.listView.Invalidate();
                }
            }
        }

        private void resultToolbarExec_Click(object sender, EventArgs e)
        {
            Run();
        }

        private void listView_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {

        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ResultColumn col = (ResultColumn)(int)this.listView.Columns[e.Column].Tag;
            if (col == ResultColumn.CHECKBOX)
            {
                return;
            }

            for (int i = 0; i < this.listView.Columns.Count; ++i)
            {
                this.listView.SetColumnHeaderSort(i, 0);
            }

            if (col == this.sortColumn)
            {
                if (this.sortOrder == SortOrder.Ascending)
                {
                    this.sortOrder = SortOrder.Descending;
                }
                else
                {
                    this.sortOrder = SortOrder.Ascending;
                }
            }
            else
            {
                this.sortColumn = col;
                this.sortOrder = SortOrder.Ascending;
            }

            this.results.Sort(CreateComparer());
            if (this.sortOrder == SortOrder.Descending)
            {
                this.results.Reverse();
            }

            ResetContent();
            
            if (this.sortOrder == SortOrder.Ascending)
            {
                this.listView.SetColumnHeaderSort(e.Column, libpixy.net.Controls.CustomListView.HDF.SORTUP);
            }
            else
            {
                this.listView.SetColumnHeaderSort(e.Column, libpixy.net.Controls.CustomListView.HDF.SORTDOWN);
            }
        }

        private void listView_ColumnHeaderClick(libpixy.net.Controls.CustomListView.ColumnHeaderClickEventArgs e)
        {
            this.contextMenuStrip1.Items.Clear();
            for (int i = 0; i < (int)ResultColumn.NUM; ++i)
            {
                if ((ResultColumn)i == ResultColumn.CHECKBOX)
                {
                    continue;
                }

                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = ResultColumnText[i];
                item.Checked = (this.resultColumns.IndexOf((ResultColumn)i) >= 0);
                item.Tag = i;
                if ((ResultColumn)i == ResultColumn.FILENAME)
                {
                    item.Enabled = false;
                }
                this.contextMenuStrip1.Items.Add(item);
            }
            this.contextMenuStrip1.Show(Cursor.Position);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is ToolStripMenuItem)
            {
                ToolStripMenuItem item = e.ClickedItem as ToolStripMenuItem;
                int col = (int)item.Tag;
                if (item.Checked)
                {
                    int idx = this.resultColumns.IndexOf((ResultColumn)col);
                    this.resultColumns.RemoveAt(idx);
                    this.listView.Columns.RemoveAt(idx);
                }
                else
                {
                    int idx = this.listView.Columns.Count;
                    this.resultColumns.Add((ResultColumn)col);
                    this.listView.Columns.Add(ResultColumnText[col]);
                    this.listView.Columns[idx].Width = ResultColumnWidth[col];
                    this.listView.Columns[idx].TextAlign = ResultColumnAlign[col];
                    this.listView.Columns[idx].Tag = col;
                }
            }
        }

        private void listView_Click(object sender, EventArgs e)
        {
            Point pt = this.listView.PointToClient(Cursor.Position);
            ListViewHitTestInfo hti = this.listView.HitTest(pt);
            if (hti.Item != null && HitTestCheckBox())
            {
                if (hti.Item.Index < this.results.Count)
                {
                    this.results[hti.Item.Index].IsOutput = !this.results[hti.Item.Index].IsOutput;
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool HitTestCheckBox()
        {
            Point pt = this.listView.PointToClient(Cursor.Position);
            List<ColumnHeader> cols = new List<ColumnHeader>();
            foreach (ColumnHeader hdr in this.listView.Columns)
            {
                cols.Add(hdr);
            }
            cols.Sort(new libpixy.net.Controls.CustomListView.ListColumnHeaderSortByDisplayIndex());
            int x = 0;
            foreach (ColumnHeader hdr in cols)
            {
                ResultColumn col = (ResultColumn)(int)hdr.Tag;
                if (col == ResultColumn.CHECKBOX)
                {
                    //if (x <= pt.X && pt.X <= x + hdr.Width)
                    if (x <= pt.X && pt.X <= x + 20)
                    {
                        return true;
                    }
                }

                x += hdr.Width;
            }

            return false;
        }

        private void resultsToolbarCheckAll_Click(object sender, EventArgs e)
        {
            foreach (File file in this.results)
            {
                file.IsOutput = true;
            }

            this.listView.Refresh();
        }

        private void resultsToolbarUncheckAll_Click(object sender, EventArgs e)
        {
            foreach (File file in this.results)
            {
                file.IsOutput = false;
            }

            this.listView.Refresh();
        }

        private void resultsToolbarCheckSelection_Click(object sender, EventArgs e)
        {
            foreach (int i in this.listView.SelectedIndices)
            {
                if (i < this.results.Count)
                {
                    this.results[i].IsOutput = true;
                }
            }

            this.listView.Refresh();
        }

        private void resultsToolbarUncheckSelection_Click(object sender, EventArgs e)
        {
            foreach (int i in this.listView.SelectedIndices)
            {
                if (i < this.results.Count)
                {
                    this.results[i].IsOutput = false;
                }
            }

            this.listView.Refresh();
        }

        private void resultToolbarSearch_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void resultsToolbarSearchNext_Click(object sender, EventArgs e)
        {
            FindNext();
        }

        private void resultsToolbarSearchTarget_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip2.Items.Clear();
            for (int i = 0; i < (int)ResultColumn.NUM; ++i)
            {
                if ((ResultColumn)i == ResultColumn.CHECKBOX)
                {
                    continue;
                }

                foreach (ResultColumn col in this.resultColumns)
                {
                    if (col == (ResultColumn)i)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem();
                        item.Text = ResultColumnText[i];
                        item.Tag = i;
                        if (col == this.m_searchTarget)
                        {
                            item.Checked = true;
                        }
                        this.contextMenuStrip2.Items.Add(item);
                    }
                }
            }
            this.contextMenuStrip2.Show(Cursor.Position);
        }

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem is ToolStripMenuItem)
            {
                ToolStripMenuItem item = e.ClickedItem as ToolStripMenuItem;
                this.m_searchTarget = (ResultColumn)(int)item.Tag;
            }
        }

        private void ResultWindow_Load(object sender, EventArgs e)
        {
            this.m_itemCollection = new ListView.ListViewItemCollection(this.listView);
            this.m_selCollection = new ListView.SelectedIndexCollection(this.listView);
        }

        private void resultsToolbarSearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                resultToolbarSearch_Click(this, new EventArgs());
            }
        }

        private void ResultWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.MainForm.WndResult = null;
        }

        private void ResultWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveResultColumnSetting();

            Global.ClearResultEvent -= new EventHandler(Global_ClearResultEvent);
            Global.UpdateResultEvent -= new EventHandler(Global_UpdateResultEvent);
        }
   }
}
