
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
using Fireball.Docking;

namespace Filemater.Window
{
    public class PropertyWindow : DockableWindow
    {
        public PropertyWindow()
        {
            InitializeComponent();
            this.Text = "Property";
            Global.NewDocumentEvent += new EventHandler(Global_NewDocument);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyWindow));
            this.SuspendLayout();
            // 
            // PropertyWindow
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PropertyWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PropertyWindow_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertyWindow_FormClosing);
            this.ResumeLayout(false);

        }

        private void Global_NewDocument(object sender, EventArgs e)
        {
            this.Controls.Clear();
        }

        private void PropertyWindow_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Global.MainForm.WndProperty = null;
        }

        private void PropertyWindow_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Global.NewDocumentEvent -= new EventHandler(Global_NewDocument);
        }
    }
}
