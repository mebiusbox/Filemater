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
    public class SchematicWindow : DockableWindow
    {
        private System.Windows.Forms.ToolStripComboBox canvasToolbarZoom;
        private System.Windows.Forms.ToolStripButton canvasToolbarZoomIn;
        private System.Windows.Forms.ToolStripButton canvasToolbarZoomOut;
        private ToolStripButton canvasToolbarSnapGrid;
        private ToolStripButton canvasToolbarShowGrid;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton canvasToolbarSimuration;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private File focusResultFile = null;
        private ContextMenuStrip canvasContextMenu;
        private System.ComponentModel.IContainer components;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem moveToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem andToolStripMenuItem;
        private libpixy.net.Controls.Diagram.Port m_activePort = null;
        private Point m_activePortLocation;
        private ToolStripMenuItem nameToolStripMenuItem;
        private ToolStripMenuItem sizeToolStripMenuItem;
        private ToolStripMenuItem timeToolStripMenuItem;
        private ToolStripMenuItem attrToolStripMenuItem;
        private ToolStripMenuItem hashToolStripMenuItem;
        private ToolStripMenuItem imageSizeToolStripMenuItem;
        private ToolStripMenuItem exifToolStripMenuItem;
        private ToolStripMenuItem ID3TagToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem programToolStripMenuItem;
        public libpixy.net.Controls.Diagram.Canvas diagram;

        private static readonly int[] cZoomTable = {
            10, 20, 30, 40, 50, 60, 70, 80, 90, 100,
            110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 
        };

        /// <summary>
        /// 
        /// </summary>
        public libpixy.net.Controls.Diagram.Canvas Diagram
        {
            get { return diagram; }
        }

        #region Ctor/Dtor

        /// <summary>
        /// 
        /// </summary>
        public SchematicWindow()
        {
            InitializeComponent();
            this.Text = "Schematic";
            this.diagram.DrawItem += new libpixy.net.Controls.Diagram.Canvas.DrawItemHandler(this.canvas_DrawItem);
            this.diagram.DrawConnectionItem += new libpixy.net.Controls.Diagram.Canvas.DrawConnectionItemHandler(this.canvas_DrawConnectionItem);
            this.diagram.DragDropLink += new libpixy.net.Controls.Diagram.Canvas.DragDropLinkHandler(canvas_DragDropLink);
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchematicWindow));
            libpixy.net.Controls.Diagram.Document document1 = new libpixy.net.Controls.Diagram.Document();
            this.canvasToolbarZoom = new System.Windows.Forms.ToolStripComboBox();
            this.canvasToolbarZoomIn = new System.Windows.Forms.ToolStripButton();
            this.canvasToolbarZoomOut = new System.Windows.Forms.ToolStripButton();
            this.canvasToolbarSnapGrid = new System.Windows.Forms.ToolStripButton();
            this.canvasToolbarShowGrid = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.canvasToolbarSimuration = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.canvasContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exifToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ID3TagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.andToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagram = new libpixy.net.Controls.Diagram.Canvas();
            this.toolStrip1.SuspendLayout();
            this.canvasContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvasToolbarZoom
            // 
            this.canvasToolbarZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.canvasToolbarZoom.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.canvasToolbarZoom.Name = "canvasToolbarZoom";
            this.canvasToolbarZoom.Size = new System.Drawing.Size(121, 26);
            this.canvasToolbarZoom.SelectedIndexChanged += new System.EventHandler(this.canvasToolbarZoom_SelectedIndexChanged);
            // 
            // canvasToolbarZoomIn
            // 
            this.canvasToolbarZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.canvasToolbarZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("canvasToolbarZoomIn.Image")));
            this.canvasToolbarZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.canvasToolbarZoomIn.Name = "canvasToolbarZoomIn";
            this.canvasToolbarZoomIn.Size = new System.Drawing.Size(23, 23);
            this.canvasToolbarZoomIn.Text = "ズームイン";
            this.canvasToolbarZoomIn.Click += new System.EventHandler(this.canvasToolbarZoomIn_Click);
            // 
            // canvasToolbarZoomOut
            // 
            this.canvasToolbarZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.canvasToolbarZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("canvasToolbarZoomOut.Image")));
            this.canvasToolbarZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.canvasToolbarZoomOut.Name = "canvasToolbarZoomOut";
            this.canvasToolbarZoomOut.Size = new System.Drawing.Size(23, 23);
            this.canvasToolbarZoomOut.Text = "ズームアウト";
            this.canvasToolbarZoomOut.Click += new System.EventHandler(this.canvasToolbarZoomOut_Click);
            // 
            // canvasToolbarSnapGrid
            // 
            this.canvasToolbarSnapGrid.CheckOnClick = true;
            this.canvasToolbarSnapGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.canvasToolbarSnapGrid.Image = ((System.Drawing.Image)(resources.GetObject("canvasToolbarSnapGrid.Image")));
            this.canvasToolbarSnapGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.canvasToolbarSnapGrid.Name = "canvasToolbarSnapGrid";
            this.canvasToolbarSnapGrid.Size = new System.Drawing.Size(23, 23);
            this.canvasToolbarSnapGrid.Text = "グリッドにスナップ";
            this.canvasToolbarSnapGrid.CheckedChanged += new System.EventHandler(this.canvasToolbarSnapGrid_CheckedChanged);
            // 
            // canvasToolbarShowGrid
            // 
            this.canvasToolbarShowGrid.CheckOnClick = true;
            this.canvasToolbarShowGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.canvasToolbarShowGrid.Image = ((System.Drawing.Image)(resources.GetObject("canvasToolbarShowGrid.Image")));
            this.canvasToolbarShowGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.canvasToolbarShowGrid.Name = "canvasToolbarShowGrid";
            this.canvasToolbarShowGrid.Size = new System.Drawing.Size(23, 23);
            this.canvasToolbarShowGrid.Text = "グリッド表示";
            this.canvasToolbarShowGrid.CheckedChanged += new System.EventHandler(this.canvasToolbarShowGrid_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // canvasToolbarSimuration
            // 
            this.canvasToolbarSimuration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.canvasToolbarSimuration.Image = ((System.Drawing.Image)(resources.GetObject("canvasToolbarSimuration.Image")));
            this.canvasToolbarSimuration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.canvasToolbarSimuration.Name = "canvasToolbarSimuration";
            this.canvasToolbarSimuration.Size = new System.Drawing.Size(23, 23);
            this.canvasToolbarSimuration.Text = "シミュレーション実行";
            this.canvasToolbarSimuration.Click += new System.EventHandler(this.canvasToolbarSimuration_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canvasToolbarZoom,
            this.canvasToolbarZoomIn,
            this.canvasToolbarZoomOut,
            this.canvasToolbarShowGrid,
            this.canvasToolbarSnapGrid,
            this.toolStripSeparator1,
            this.canvasToolbarSimuration});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(371, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // canvasContextMenu
            // 
            this.canvasContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nameToolStripMenuItem,
            this.sizeToolStripMenuItem,
            this.timeToolStripMenuItem,
            this.attrToolStripMenuItem,
            this.hashToolStripMenuItem,
            this.imageSizeToolStripMenuItem,
            this.exifToolStripMenuItem,
            this.ID3TagToolStripMenuItem,
            this.toolStripSeparator3,
            this.deleteToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.programToolStripMenuItem,
            this.toolStripSeparator2,
            this.andToolStripMenuItem});
            this.canvasContextMenu.Name = "canvasContextMenu";
            this.canvasContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.canvasContextMenu.Size = new System.Drawing.Size(182, 302);
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.nameToolStripMenuItem.Text = "Filter : Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.sizeToolStripMenuItem.Text = "Filter : Size";
            this.sizeToolStripMenuItem.Click += new System.EventHandler(this.sizeToolStripMenuItem_Click);
            // 
            // timeToolStripMenuItem
            // 
            this.timeToolStripMenuItem.Name = "timeToolStripMenuItem";
            this.timeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.timeToolStripMenuItem.Text = "Filter : Time";
            this.timeToolStripMenuItem.Click += new System.EventHandler(this.timeToolStripMenuItem_Click);
            // 
            // attrToolStripMenuItem
            // 
            this.attrToolStripMenuItem.Name = "attrToolStripMenuItem";
            this.attrToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.attrToolStripMenuItem.Text = "Filter : Attr";
            this.attrToolStripMenuItem.Click += new System.EventHandler(this.attrToolStripMenuItem_Click);
            // 
            // hashToolStripMenuItem
            // 
            this.hashToolStripMenuItem.Name = "hashToolStripMenuItem";
            this.hashToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.hashToolStripMenuItem.Text = "Filter : Hash";
            this.hashToolStripMenuItem.Click += new System.EventHandler(this.hashToolStripMenuItem_Click);
            // 
            // imageSizeToolStripMenuItem
            // 
            this.imageSizeToolStripMenuItem.Name = "imageSizeToolStripMenuItem";
            this.imageSizeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.imageSizeToolStripMenuItem.Text = "Filter : ImageSize";
            this.imageSizeToolStripMenuItem.Click += new System.EventHandler(this.imageSizeToolStripMenuItem_Click);
            // 
            // exifToolStripMenuItem
            // 
            this.exifToolStripMenuItem.Name = "exifToolStripMenuItem";
            this.exifToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.exifToolStripMenuItem.Text = "Filter : Exif";
            this.exifToolStripMenuItem.Click += new System.EventHandler(this.exifToolStripMenuItem_Click);
            // 
            // ID3TagToolStripMenuItem
            // 
            this.ID3TagToolStripMenuItem.Name = "ID3TagToolStripMenuItem";
            this.ID3TagToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.ID3TagToolStripMenuItem.Text = "Filter : ID3Tag";
            this.ID3TagToolStripMenuItem.Click += new System.EventHandler(this.iD3TagToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.deleteToolStripMenuItem.Text = "Output : Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.moveToolStripMenuItem.Text = "Output : Move";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.copyToolStripMenuItem.Text = "Output : Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.programToolStripMenuItem.Text = "Output : Program";
            this.programToolStripMenuItem.Click += new System.EventHandler(this.programToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // andToolStripMenuItem
            // 
            this.andToolStripMenuItem.Name = "andToolStripMenuItem";
            this.andToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.andToolStripMenuItem.Text = "Operator : AND";
            this.andToolStripMenuItem.Click += new System.EventHandler(this.andToolStripMenuItem_Click);
            // 
            // diagram
            // 
            this.diagram.AllowDrop = true;
            this.diagram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diagram.CanvasScale = ((System.Drawing.PointF)(resources.GetObject("diagram.CanvasScale")));
            this.diagram.Document = document1;
            this.diagram.GridSize = 20;
            this.diagram.Location = new System.Drawing.Point(0, 29);
            this.diagram.Name = "diagram";
            this.diagram.NaviArea = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.diagram.NavigateTarget = null;
            this.diagram.NavigationMode = false;
            this.diagram.Size = new System.Drawing.Size(371, 274);
            this.diagram.TabIndex = 2;
            this.diagram.DragDropLink += new libpixy.net.Controls.Diagram.Canvas.DragDropLinkHandler(this.canvas_DragDropLink);
            this.diagram.DrawItem += new libpixy.net.Controls.Diagram.Canvas.DrawItemHandler(this.canvas_DrawItem);
            this.diagram.DrawConnectionItem += new libpixy.net.Controls.Diagram.Canvas.DrawConnectionItemHandler(this.canvas_DrawConnectionItem);
            this.diagram.DragDrop += new System.Windows.Forms.DragEventHandler(this.canvas_DragDrop);
            this.diagram.DragEnter += new System.Windows.Forms.DragEventHandler(this.canvas_DragEnter);
            this.diagram.DragOver += new System.Windows.Forms.DragEventHandler(this.canvas_DragOver);
            this.diagram.DragLeave += new System.EventHandler(this.canvas_DragLeave);
            this.diagram.KeyDown += new System.Windows.Forms.KeyEventHandler(this.canvas_KeyDown);
            // 
            // SchematicWindow
            // 
            this.ClientSize = new System.Drawing.Size(371, 302);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.diagram);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SchematicWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CanvasWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CanvasWindow_FormClosed);
            this.Load += new System.EventHandler(this.CanvasWindow_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.canvasContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        public void Simulate()
        {
            this.Activate();

            Global.ClearResult();
            Forms.ProgressExecNodeForm form = new Forms.ProgressExecNodeForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Global.MainForm.CreateWndResults();
                Global.RaiseUpdateResultEvent(this);
                if (Global.MainForm.WndResult.IsHidden)
                {
                    Global.MainForm.WndResult.Show(
                        Global.MainForm.WndContainer,
                        DockState.Document);
                }
                else
                {
                    DockState oldState = Global.MainForm.WndResult.DockState;
                    DockState newState = oldState;
                    switch (oldState)
                    {
                        case DockState.DockBottomAutoHide:
                            newState = DockState.DockBottom;
                            break;

                        case DockState.DockTopAutoHide:
                            newState = DockState.DockTop;
                            break;

                        case DockState.DockLeftAutoHide:
                            newState = DockState.DockLeft;
                            break;

                        case DockState.DockRightAutoHide:
                            newState = DockState.DockRight;
                            break;
                    }

                    if (oldState != newState)
                    {
                        Global.MainForm.WndResult.Show(
                            Global.MainForm.WndContainer,
                            newState);
                    }

                }
                Global.MainForm.WndResult.Activate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearIONodeWork()
        {
            foreach (libpixy.net.Controls.Diagram.Node node in this.diagram.Document.Nodes)
            {
                if (node is Nodes.IOutputNode)
                {
                    Nodes.IOutputNode inode = node as Nodes.IOutputNode;
                    inode.OutputFiles.Clear();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearNodeWork()
        {
            foreach (libpixy.net.Controls.Diagram.Node node in this.diagram.Document.Nodes)
            {
                if (node is Nodes.INode)
                {
                    Nodes.INode inode = node as Nodes.INode;
                    inode.Clear();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ExecOutputNodes()
        {
            List<File> results = new List<File>();
            results.AddRange(Global.Results);
            results.Reverse();

            foreach (File file in results)
            {
                if (!file.IsOutput) continue;
                if (file.ProcessOutput) continue;

                int nodeId = file.nodeTrack.lastNodeId;
                if (nodeId < 0)
                {
                    continue;
                }

                Nodes.IOutputNode onode = FindOutputNode(nodeId);
                if (onode != null)
                {
                    onode.Input = file;
                    onode.ExecOutput();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Nodes.IOutputNode FindOutputNode(int id)
        {
            foreach (libpixy.net.Controls.Diagram.Node node in this.diagram.Document.Nodes)
            {
                if (node is Nodes.IOutputNode)
                {
                    Nodes.IOutputNode inode = node as Nodes.IOutputNode;
                    if (inode.Id == id)
                    {
                        return inode;
                    }
                }
            }

            return null;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void CreateNodeFromDropFiles(IDataObject data)
        {
            Toolbox.Input.FilesInputButton btn = new global::Filemater.Toolbox.Input.FilesInputButton();
            libpixy.net.Controls.Diagram.Node node = btn.CreateNode();
            node.Location = this.diagram.PointToClient(Cursor.Position);
            if (node is Nodes.Input.FilesNode)
            {
                Nodes.Input.FilesNode inNode = node as Nodes.Input.FilesNode;
                inNode.Files.AddRange((string[])data.GetData(DataFormats.FileDrop, false));
            }
            this.diagram.AddNode(node);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void CreateNodeFromDropToolboxButton(libpixy.net.Controls.Toolbox.IToolboxItem item)
        {
            if (item is Toolbox.Button)
            {
                Toolbox.Button btn = (Toolbox.Button)(item);
                libpixy.net.Controls.Diagram.Node node = btn.CreateNode();
                node.Location = this.diagram.PointToClient(Cursor.Position);
                this.diagram.AddNode(node);
            }
        }

        #endregion Private Methods

        #region Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        void canvas_DragDropLink(libpixy.net.Controls.Diagram.Canvas.DragDropLinkEventArgs e)
        {
            this.m_activePort = e.Port;
            this.m_activePortLocation = e.loc;
            this.canvasContextMenu.Show(Cursor.Position);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CanvasWindow_Load(object sender, EventArgs e)
        {
            this.toolStrip1.ImageList = new ImageList();
            this.toolStrip1.ImageList.ImageSize = new Size(16, 16);
            this.toolStrip1.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_magnifier_zoom);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_magnifier_zoom_out);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_grid);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_grid_snap);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_control);
            this.canvasToolbarZoomIn.ImageIndex = 0;
            this.canvasToolbarZoomOut.ImageIndex = 1;
            this.canvasToolbarShowGrid.ImageIndex = 2;
            this.canvasToolbarSnapGrid.ImageIndex = 3;
            this.canvasToolbarSimuration.ImageIndex = 4;

            this.canvasContextMenu.ImageList = new ImageList();
            this.canvasContextMenu.ImageList.ImageSize = new Size(16, 16);
            this.canvasContextMenu.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            this.canvasContextMenu.ImageList.Images.Add(Properties.Resources.icon_block);
            this.canvasContextMenu.ImageList.Images.Add(Properties.Resources.icon_documents);
            this.canvasContextMenu.ImageList.Images.Add(Properties.Resources.icon_document_copy);
            this.canvasContextMenu.ImageList.Images.Add(Properties.Resources.icon_folder__arrow);
            this.canvasContextMenu.ImageList.Images.Add(Properties.Resources.icon_funnel);
            this.canvasContextMenu.ImageList.Images.Add(Properties.Resources.icon_switch);
            this.canvasContextMenu.ImageList.Images.Add(Properties.Resources.icon_bin);
            this.canvasContextMenu.ImageList.Images.Add(Properties.Resources.icon_application_blue);
            this.nameToolStripMenuItem.ImageIndex = 4;
            this.sizeToolStripMenuItem.ImageIndex = 4;
            this.timeToolStripMenuItem.ImageIndex = 4;
            this.attrToolStripMenuItem.ImageIndex = 4;
            this.hashToolStripMenuItem.ImageIndex = 4;
            this.imageSizeToolStripMenuItem.ImageIndex = 4;
            this.exifToolStripMenuItem.ImageIndex = 4;
            this.ID3TagToolStripMenuItem.ImageIndex = 4;
            this.deleteToolStripMenuItem.ImageIndex = 6;
            this.moveToolStripMenuItem.ImageIndex = 3;
            this.copyToolStripMenuItem.ImageIndex = 2;
            this.programToolStripMenuItem.ImageIndex = 7;
            this.andToolStripMenuItem.ImageIndex = 5;

            foreach (int z in cZoomTable)
            {
                this.canvasToolbarZoom.Items.Add(String.Format("{0}%", z));
            }

            this.canvasToolbarZoom.SelectedIndex = 9;
            this.canvasToolbarShowGrid.Checked = this.diagram.ShowGrid;
            this.canvasToolbarSnapGrid.Checked = this.diagram.SnapGrid;

            Global.ClearResultEvent += new EventHandler(this.Global_ClearResult);
            Global.FocusResultItemEvent += new Global.FocusResultItemHandler(this.Global_FocusResultItem);
            Global.NewDocumentEvent += new EventHandler(this.Global_NewDocument);
            Global.OpenDocumentEvent += new EventHandler(this.Global_OpenDocument);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvasToolbarZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = this.canvasToolbarZoom.SelectedIndex;
            if (idx >= 0 && idx < cZoomTable.Length)
            {
                float scale = (float)cZoomTable[idx] * 0.01f;
                this.diagram.CanvasScale = new System.Drawing.PointF(scale, scale);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvasToolbarZoomIn_Click(object sender, EventArgs e)
        {
            int idx = this.canvasToolbarZoom.SelectedIndex;
            if (idx >= 0 && idx + 1 < cZoomTable.Length)
            {
                this.canvasToolbarZoom.SelectedIndex = idx + 1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvasToolbarZoomOut_Click(object sender, EventArgs e)
        {
            int idx = this.canvasToolbarZoom.SelectedIndex - 1;
            if (idx >= 0 && idx < cZoomTable.Length)
            {
                this.canvasToolbarZoom.SelectedIndex = idx;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvasToolbarSnapGrid_CheckedChanged(object sender, EventArgs e)
        {
            this.diagram.SnapGrid = this.canvasToolbarSnapGrid.Checked;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvasToolbarShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            this.diagram.ShowGrid = this.canvasToolbarShowGrid.Checked;
            this.diagram.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (this.diagram.Document.SelectedCount > 0)
                {
                    this.diagram.RemoveNodes(this.diagram.Document.SelectedNodes);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private void canvas_DrawItem(libpixy.net.Controls.Diagram.Canvas.DrawItemEventArgs e)
        {
            if (this.focusResultFile == null)
            {
                return;
            }

            if (e.Item is Nodes.INode)
            {
                Nodes.INode node = e.Item as Nodes.INode;
                if (!this.focusResultFile.nodeTrack.Exists(node.Id))
                {
                    return;
                }
            }

            Rectangle rc = new Rectangle();
            rc = e.Item.Bounds;
            rc.Inflate(2, 2);
            //Brush brush = new SolidBrush(Color.FromArgb(255, 30, 0));
            libpixy.net.Controls.Diagram.Draw.DrawRoundedRectangle(e.Graphics, rc, 10, Color.FromArgb(240, 240, 240), 2);
            //e.Graphics.FillRectangle(brush, rc);
            //brush.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private void canvas_DrawConnectionItem(libpixy.net.Controls.Diagram.Canvas.DrawConnectionEventArgs e)
        {
            if (this.focusResultFile == null)
            {
                return;
            }

            if (e.Item.Port1.Owner is Nodes.INode && e.Item.Port2.Owner is Nodes.INode)
            {
                Nodes.INode node1 = e.Item.Port1.Owner as Nodes.INode;
                Nodes.INode node2 = e.Item.Port2.Owner as Nodes.INode;
                int portIndex = node1.DestinationPorts.IndexOf(e.Item.Port1);
                if (!this.focusResultFile.nodeTrack.Exists(node1.Id, node2.Id, portIndex))
                {
                    return;
                }
            }
            else
            {
                return;
            }

            libpixy.net.Controls.Diagram.DrawCurvedConnection drawer = new libpixy.net.Controls.Diagram.DrawCurvedConnection();
            drawer.Draw(e.Graphics, e.Item.Port1, e.Item.Port2, Color.FromArgb(240,240,240), 6, false);
            drawer = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private libpixy.net.Controls.Diagram.Node canvas_DeserializeNodeContent(string type)
        {
            Toolbox.Button btn = null;
            switch (type)
            {
                case "Files": btn = new Toolbox.Input.FilesInputButton(); break;
                case "Delete": btn = new Toolbox.Output.DeleteOutputButton(); break;
                case "Move": btn = new Toolbox.Output.MoveOutputButton(); break;
                case "Copy": btn = new Toolbox.Output.CopyOutputButton(); break;
                case "Name": btn = new Toolbox.Filter.NameFilterButton(); break;
                case "Size": btn = new Toolbox.Filter.SizeFilterButton(); break;
                case "Time": btn = new Toolbox.Filter.TimeFilterButton(); break;
                case "Attr": btn = new Toolbox.Filter.AttrFilterButton(); break;
                case "Hash": btn = new Toolbox.Filter.HashFilterButton(); break;
                case "Exif": btn = new Toolbox.Filter.ExifFilterButton(); break;
                case "ImageSize": btn = new Toolbox.Filter.ImageSizeFilterButton(); break;
                case "ID3Tag": btn = new Toolbox.Filter.ID3TagFilterButton(); break;
                case "AND": btn = new Toolbox.Operator.AndOpButton(); break;
            }

            if (btn != null)
            {
                return btn.CreateNode();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvasToolbarSimuration_Click(object sender, EventArgs e)
        {
            Simulate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Work_BeginNodeDispatch(object sender, EventArgs e)
        {
            ClearNodeWork();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.MainForm.WndSchematic = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.ClearResultEvent -= new EventHandler(this.Global_ClearResult);
            Global.FocusResultItemEvent -= new Global.FocusResultItemHandler(this.Global_FocusResultItem);
            Global.NewDocumentEvent -= new EventHandler(this.Global_NewDocument);
            Global.OpenDocumentEvent -= new EventHandler(this.Global_OpenDocument);
        }

        #endregion Event Handlers

        #region DragDrop

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
            {
                CreateNodeFromDropFiles(e.Data);
            }
            else
            {
                DataFormats.Format fmt = DataFormats.GetFormat("libpixy.net.Toolbox.Button");
                if (e.Data.GetDataPresent(fmt.Name))
                {
                    CreateNodeFromDropToolboxButton((libpixy.net.Controls.Toolbox.IToolboxItem)(e.Data.GetData(fmt.Name)));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
            {
                e.Effect = System.Windows.Forms.DragDropEffects.Move;
            }
            else
            {
                DataFormats.Format fmt = DataFormats.GetFormat("libpixy.net.Toolbox.Button");
                if (e.Data.GetDataPresent(fmt.Name))
                {
                    e.Effect = System.Windows.Forms.DragDropEffects.Move;
                }
                else
                {
                    e.Effect = System.Windows.Forms.DragDropEffects.None;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_DragLeave(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canvas_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
        }

        #endregion DragDrop

        #region Global Event Handler

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Global_ClearResult(object sender, EventArgs e)
        {
            this.focusResultFile = null;
            this.diagram.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private void Global_FocusResultItem(Global.FocusResultItemEventArgs e)
        {
            this.focusResultFile = e.File;
            this.diagram.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Global_NewDocument(object sender, EventArgs e)
        {
            this.diagram.Document.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Global_OpenDocument(object sender, EventArgs e)
        {
            this.canvasToolbarZoom.SelectedIndex = (int)(this.diagram.CanvasScale.X * 10.0f) - 1;
            this.canvasToolbarShowGrid.Checked = this.diagram.ShowGrid;
            this.canvasToolbarSnapGrid.Checked = this.diagram.SnapGrid;
        }

        #endregion Global Event Handler

        #region contextMenu

        /// <summary>
        /// 
        /// </summary>
        /// <param name="btn"></param>
        private void CreateNodeAndConnect(Toolbox.Button btn)
        {
            libpixy.net.Controls.Diagram.Node node = btn.CreateNode();
            node.Location = this.m_activePortLocation;
            this.diagram.AddNode(node);
            this.diagram.Document.Link(this.m_activePort, node.SourcePorts[0]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Filter.NameFilterButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Filter.SizeFilterButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Filter.TimeFilterButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void attrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Filter.AttrFilterButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Filter.HashFilterButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Filter.ExifFilterButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Filter.ImageSizeFilterButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iD3TagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Filter.ID3TagFilterButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Output.DeleteOutputButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Output.MoveOutputButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Output.CopyOutputButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Output.ProgramOutputButton());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void andToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNodeAndConnect(new Toolbox.Operator.AndOpButton());
        }

        #endregion

    }
}
