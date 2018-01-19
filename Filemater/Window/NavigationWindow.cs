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
using System.Drawing;
using System.Windows.Forms;
using Fireball.Docking;

namespace Filemater.Window
{
    public class NavigationWindow : DockableWindow
    {
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox naviToolbarZoom;
        private System.Windows.Forms.ToolStripButton naviToolbarZoomIn;
        private System.Windows.Forms.ToolStripButton naviToolbarZoomOut;
        public libpixy.net.Controls.Diagram.Canvas navi;

        private static readonly int[] cZoomTable = {
            10, 20, 30, 40, 50, 60, 70, 80, 90, 100,
            110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 
        };
    
        public NavigationWindow()
        {
            InitializeComponent();
            this.Text = "Navigator";

            this.toolStrip1.ImageList = new ImageList();
            this.toolStrip1.ImageList.ImageSize = new Size(16, 16);
            this.toolStrip1.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_magnifier_zoom);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_magnifier_zoom_out);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_grid);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_grid_snap);
            this.toolStrip1.ImageList.Images.Add(Properties.Resources.icon_control);
            this.naviToolbarZoomIn.ImageIndex = 0;
            this.naviToolbarZoomOut.ImageIndex = 1;

            this.navi.CanvasScale = new System.Drawing.PointF(0.2f, 0.2f);
            this.navi.NavigationMode = true;

            foreach (int z in cZoomTable)
            {
                this.naviToolbarZoom.Items.Add(String.Format("{0}%", z));
            }
            this.naviToolbarZoom.SelectedIndex = 1;

            Global.OpenDocumentEvent += new EventHandler(this.Global_OpenDocument);

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationWindow));
            libpixy.net.Controls.Diagram.Document document1 = new libpixy.net.Controls.Diagram.Document();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.naviToolbarZoom = new System.Windows.Forms.ToolStripComboBox();
            this.naviToolbarZoomIn = new System.Windows.Forms.ToolStripButton();
            this.naviToolbarZoomOut = new System.Windows.Forms.ToolStripButton();
            this.navi = new libpixy.net.Controls.Diagram.Canvas();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.naviToolbarZoom,
            this.naviToolbarZoomIn,
            this.naviToolbarZoomOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(292, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // naviToolbarZoom
            // 
            this.naviToolbarZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.naviToolbarZoom.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.naviToolbarZoom.Name = "naviToolbarZoom";
            this.naviToolbarZoom.Size = new System.Drawing.Size(121, 26);
            this.naviToolbarZoom.SelectedIndexChanged += new System.EventHandler(this.naviToolbarZoom_SelectedIndexChanged);
            // 
            // naviToolbarZoomIn
            // 
            this.naviToolbarZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.naviToolbarZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("naviToolbarZoomIn.Image")));
            this.naviToolbarZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.naviToolbarZoomIn.Name = "naviToolbarZoomIn";
            this.naviToolbarZoomIn.Size = new System.Drawing.Size(23, 23);
            this.naviToolbarZoomIn.Text = "ズームイン";
            this.naviToolbarZoomIn.Click += new System.EventHandler(this.naviToolbarZoomIn_Click);
            // 
            // naviToolbarZoomOut
            // 
            this.naviToolbarZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.naviToolbarZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("naviToolbarZoomOut.Image")));
            this.naviToolbarZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.naviToolbarZoomOut.Name = "naviToolbarZoomOut";
            this.naviToolbarZoomOut.Size = new System.Drawing.Size(23, 23);
            this.naviToolbarZoomOut.Text = "ズームアウト";
            this.naviToolbarZoomOut.Click += new System.EventHandler(this.naviToolbarZoomOut_Click);
            // 
            // navi
            // 
            this.navi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navi.CanvasScale = ((System.Drawing.PointF)(resources.GetObject("navi.CanvasScale")));
            this.navi.Document = document1;
            this.navi.GridSize = 20;
            this.navi.Location = new System.Drawing.Point(0, 24);
            this.navi.Name = "navi";
            this.navi.NaviArea = new System.Drawing.Rectangle(0, 0, 296, 248);
            this.navi.NavigateTarget = null;
            this.navi.NavigationMode = true;
            this.navi.Size = new System.Drawing.Size(296, 248);
            this.navi.TabIndex = 0;
            // 
            // NavigationWindow
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.navi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NavigationWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NavigationWindow_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NavigationWindow_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void naviToolbarZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = this.naviToolbarZoom.SelectedIndex;
            if (idx >= 0 && idx < cZoomTable.Length)
            {
                float scale = (float)cZoomTable[idx] * 0.01f;
                this.navi.CanvasScale = new System.Drawing.PointF(scale, scale);
            }
        }

        private void naviToolbarZoomIn_Click(object sender, EventArgs e)
        {
            int idx = this.naviToolbarZoom.SelectedIndex;
            if (idx >= 0 && idx + 1 < cZoomTable.Length)
            {
                this.naviToolbarZoom.SelectedIndex = idx + 1;
            }
        }

        private void naviToolbarZoomOut_Click(object sender, EventArgs e)
        {
            int idx = this.naviToolbarZoom.SelectedIndex - 1;
            if (idx >= 0 && idx < cZoomTable.Length)
            {
                this.naviToolbarZoom.SelectedIndex = idx;
            }
        }

        private void Global_OpenDocument(object sender, EventArgs e)
        {
            this.naviToolbarZoom.SelectedIndex = (int)(this.navi.CanvasScale.X * 10.0f) - 1;
        }

        private void NavigationWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.MainForm.WndNavi = null;
        }

        private void NavigationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.OpenDocumentEvent -= new EventHandler(this.Global_OpenDocument);
        }
    }
}
