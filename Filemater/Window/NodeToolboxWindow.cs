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
using Fireball.Docking;

namespace Filemater.Window
{
    public class NodeToolboxWindow : DockableWindow
    {
        private System.Windows.Forms.Panel panel1;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeToolboxWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolbox = new libpixy.net.Controls.Toolbox.Toolbox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.toolbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 266);
            this.panel1.TabIndex = 0;
            this.panel1.ClientSizeChanged += new System.EventHandler(this.panel1_ClientSizeChanged);
            // 
            // toolbox
            // 
            this.toolbox.ButtonBackColor = System.Drawing.Color.White;
            this.toolbox.ButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolbox.ButtonLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.toolbox.FocusBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(236)))), ((int)(((byte)(181)))));
            this.toolbox.FocusForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolbox.FocusItem = null;
            this.toolbox.FocusLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.toolbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolbox.GroupBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(119)))));
            this.toolbox.GroupFont = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Bold);
            this.toolbox.GroupForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolbox.GroupLineColor = System.Drawing.Color.Black;
            this.toolbox.Location = new System.Drawing.Point(0, 0);
            this.toolbox.Name = "toolbox";
            this.toolbox.Rounded = false;
            this.toolbox.SelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(230)))), ((int)(((byte)(232)))));
            this.toolbox.SelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.toolbox.SelectItem = null;
            this.toolbox.SelectLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(106)))), ((int)(((byte)(197)))));
            this.toolbox.Size = new System.Drawing.Size(292, 266);
            this.toolbox.TabIndex = 0;
            // 
            // NodeToolboxWindow
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NodeToolboxWindow";
            this.TabText = "Nodes";
            this.Text = "Nodes";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NodeToolboxWindow_FormClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        void NodeToolboxWindow_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Global.MainForm.WndToolbox = null;
        }

        public NodeToolboxWindow()
        {
            InitializeComponent();

#if true
            this.toolbox.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.toolbox.ImageList.Images.Add(Properties.Resources.icon_block);
            this.toolbox.ImageList.Images.Add(Properties.Resources.icon_documents);
            this.toolbox.ImageList.Images.Add(Properties.Resources.icon_document_copy);
            this.toolbox.ImageList.Images.Add(Properties.Resources.icon_folder__arrow);
            this.toolbox.ImageList.Images.Add(Properties.Resources.icon_funnel);
            this.toolbox.ImageList.Images.Add(Properties.Resources.icon_switch);
            this.toolbox.ImageList.Images.Add(Properties.Resources.icon_bin);
            this.toolbox.ImageList.Images.Add(Properties.Resources.icon_application_blue);
            this.toolbox.ImageList.TransparentColor = Color.FromArgb(0xff, 0x00, 0xff);

            libpixy.net.Controls.Toolbox.ToolboxGroup g = new libpixy.net.Controls.Toolbox.ToolboxGroup();
            g.Text = "Input";
            g.Buttons.Add(new Toolbox.Input.FilesInputButton());
            g.Buttons.Add(new Toolbox.Input.ArgumentsInputButton());
            this.toolbox.Groups.Add(g);
            this.toolbox.RecalcLayout();

            g = new libpixy.net.Controls.Toolbox.ToolboxGroup();
            g.Text = "Output";
            g.Buttons.Add(new Toolbox.Output.DeleteOutputButton());
            g.Buttons.Add(new Toolbox.Output.MoveOutputButton());
            g.Buttons.Add(new Toolbox.Output.CopyOutputButton());
            g.Buttons.Add(new Toolbox.Output.ProgramOutputButton());
            this.toolbox.Groups.Add(g);
            this.toolbox.RecalcLayout();

            g = new libpixy.net.Controls.Toolbox.ToolboxGroup();
            g.Text = "Filter";
            g.Buttons.Add(new Toolbox.Filter.NameFilterButton());
            g.Buttons.Add(new Toolbox.Filter.SizeFilterButton());
            g.Buttons.Add(new Toolbox.Filter.TimeFilterButton());
            g.Buttons.Add(new Toolbox.Filter.AttrFilterButton());
            g.Buttons.Add(new Toolbox.Filter.HashFilterButton());
            g.Buttons.Add(new Toolbox.Filter.ImageSizeFilterButton());
            g.Buttons.Add(new Toolbox.Filter.ExifFilterButton());
            g.Buttons.Add(new Toolbox.Filter.ID3TagFilterButton());
            this.toolbox.Groups.Add(g);
            this.toolbox.RecalcLayout();

            g = new libpixy.net.Controls.Toolbox.ToolboxGroup();
            g.Text = "Operator";
            g.Buttons.Add(new Toolbox.Operator.AndOpButton());
            this.toolbox.Groups.Add(g);
            this.toolbox.RecalcLayout();
#endif
            this.Text = "Nodes";
        }

        public void panel1_ClientSizeChanged(object sender, EventArgs e)
        {
#if true
            this.toolbox.RecalcLayout();
            this.toolbox.Invalidate();
#endif
        }

        public static int ICON_BLCOK = 0;
        public static int ICON_DOCUMENTS = 1;
        public static int ICON_DOCUMENT_COPY = 2;
        public static int ICON_FOLDER_ARROW = 3;
        public static int ICON_FUNNEL = 4;
        public static int ICON_SWITCH = 5;
        private libpixy.net.Controls.Toolbox.Toolbox toolbox;
        public static int ICON_BIN = 6;
        public static int ICON_APPLICATION = 7;
    }
}
