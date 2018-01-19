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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;

namespace Filemater
{
    public partial class Filemater : Form
    {
        #region Attributes

        public libpixy.net.Controls.Diagram.Document Document;
        public Window.SchematicWindow WndSchematic = null;
        public Window.FileInfoWindow WndFileInfo = null;
        public Window.ResultWindow WndResult = null;
        public Window.NavigationWindow WndNavi = null;
        public Window.NodeToolboxWindow WndToolbox = null;
        public Window.PropertyWindow WndProperty = null;
        public string FilePath = "";

        #endregion

        #region Properties

        public Fireball.Docking.DockContainer WndContainer
        {
            get { return this.dockContainer1; }
        }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public Filemater()
        {
            InitializeComponent();
        }

        #endregion Constructor 

        #region Public Methods
        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        private void LoadMenuImages()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(16, 16);
            imgList.ColorDepth = ColorDepth.Depth32Bit;
            imgList.Images.Add(Properties.Resources.icon_document);
            imgList.Images.Add(Properties.Resources.icon_folder_horizontal_open);
            imgList.Images.Add(Properties.Resources.icon_disk_black);
            imgList.Images.Add(Properties.Resources.icon_magnifier);
            imgList.Images.Add(Properties.Resources.icon_magnifier__arrow);
            imgList.Images.Add(Properties.Resources.icon_gear);
            imgList.Images.Add(Properties.Resources.icon_question);
            imgList.Images.Add(Properties.Resources.icon_information);
            imgList.Images.Add(Properties.Resources.icon_home);
            imgList.Images.Add(Properties.Resources.icon_application_blue);
            imgList.Images.Add(Properties.Resources.icon_application);
            imgList.Images.Add(Properties.Resources.icon_control);
            imgList.Images.Add(Properties.Resources.icon_control_red);

            ToolStripDropDownMenu dropDownMenu = this.menuFileNew.Owner as ToolStripDropDownMenu;
            dropDownMenu.ImageList = imgList;

            dropDownMenu = this.menuEditFind.Owner as ToolStripDropDownMenu;
            dropDownMenu.ImageList = imgList;

            dropDownMenu = this.menuViewNodeTreeWindow.Owner as ToolStripDropDownMenu;
            dropDownMenu.ImageList = imgList;

            dropDownMenu = this.menuToolOption.Owner as ToolStripDropDownMenu;
            dropDownMenu.ImageList = imgList;

            dropDownMenu = this.menuHelpContents.Owner as ToolStripDropDownMenu;
            dropDownMenu.ImageList = imgList;

            this.menuFileNew.ImageIndex = 0;
            this.menuFileOpen.ImageIndex = 1;
            this.menuFileSave.ImageIndex = 2;
            this.menuEditFind.ImageIndex = 3;
            this.menuEditFindNext.ImageIndex = 4;
            this.menuEditSimulate.ImageIndex = 11;
            this.menuEditRun.ImageIndex = 12;
            this.menuToolOption.ImageIndex = 5;
            this.menuHelpContents.ImageIndex = 6;
            this.menuHelpAbout.ImageIndex = 7;
            this.menuHelpHome.ImageIndex = 8;
            this.menuViewNodeTreeWindow.ImageIndex = 9;
            this.menuViewNaviWindow.ImageIndex = 9;
            this.menuViewFileInfoWindow.ImageIndex = 9;
            this.menuViewPropertyWindow.ImageIndex = 9;
            this.menuViewToolboxWindow.ImageIndex = 9;
            this.menuViewResultsWindow.ImageIndex = 9;
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadToolbarImages()
        {
            this.mainToolbar.ImageList = new ImageList();
            this.mainToolbar.ImageList.ImageSize = new Size(16, 16);
            this.mainToolbar.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            this.mainToolbar.ImageList.Images.Add(Properties.Resources.icon_document);
            this.mainToolbar.ImageList.Images.Add(Properties.Resources.icon_folder_horizontal_open);
            this.mainToolbar.ImageList.Images.Add(Properties.Resources.icon_disk_black);
            this.mainToolbarNew.ImageIndex = 0;
            this.mainToolbarOpen.ImageIndex = 1;
            this.mainToolbarSave.ImageIndex = 2;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persistString"></param>
        /// <returns></returns>
        private libpixy.net.Controls.Diagram.Node DeserializeNodeContent(string persistString)
        {
            if (persistString == "Filemater.Nodes.Input.FilesNode")
            {
                return new Nodes.Input.FilesNode();
            }
            else if (persistString == "Filemater.Nodes.Input.ArgumentsNode")
            {
                return new Nodes.Input.ArgumentsNode();
            }
            else if (persistString == "Filemater.Nodes.Output.CopyNode")
            {
                return new Nodes.Output.CopyNode();
            }
            else if (persistString == "Filemater.Nodes.Output.MoveNode")
            {
                return new Nodes.Output.MoveNode();
            }
            else if (persistString == "Filemater.Nodes.Output.DeleteNode")
            {
                return new Nodes.Output.DeleteNode();
            }
            else if (persistString == "Filemater.Nodes.Output.ProgramNode")
            {
                return new Nodes.Output.ProgramNode();
            }
            else if (persistString == "Filemater.Nodes.Filter.AttrNode")
            {
                return new Nodes.Filter.ExifNode();
            }
            else if (persistString == "Filemater.Nodes.Filter.ExifNode")
            {
                return new Nodes.Filter.HashNode();
            }
            else if (persistString == "Filemater.Nodes.Filter.HashNode")
            {
                return new Nodes.Filter.ID3TagNode();
            }
            else if (persistString == "Filemater.Nodes.Filter.ID3TagNode")
            {
                return new Nodes.Filter.ID3TagNode();
            }
            else if (persistString == "Filemater.Nodes.Filter.ImageSizeNode")
            {
                return new Nodes.Filter.ImageSizeNode();
            }
            else if (persistString == "Filemater.Nodes.Filter.NameNode")
            {
                return new Nodes.Filter.NameNode();
            }
            else if (persistString == "Filemater.Nodes.Filter.SizeNode")
            {
                return new Nodes.Filter.SizeNode();
            }
            else if (persistString == "Filemater.Nodes.Filter.TimeNode")
            {
                return new Nodes.Filter.TimeNode();
            }
            else if (persistString == "Filemater.Nodes.Operator.AndNode")
            {
                return new Nodes.Operator.AndNode();
            }
            else if (persistString == "Filemater.Nodes.Filter.AttrNode")
            {
                return new Nodes.Filter.AttrNode();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        private void NewDocument()
        {
            this.FilePath = "";
            UpdateTitleText();
            Global.ClearResult();
            Global.RaiseEvent(Global.NewDocumentEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        private void OpenDocument()
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.Filter = "Filemater File (*.fmater)|*.fmater|All file(*.*)|*.*";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Open(this.openFileDialog1.FileName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveDocument()
        {
            if (this.FilePath == "")
            {
                SaveAs();
                UpdateTitleText();
            }
            else
            {
                Save(this.FilePath);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private void Open(string path)
        {
            try
            {
                NewDocument();

                bool readed = false;
                System.IO.StreamReader strm = new System.IO.StreamReader(path);
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreWhitespace = true;
                settings.IgnoreComments = true;
                XmlReader reader = XmlReader.Create(strm, settings);
                reader.Read();
                if (reader.IsStartElement("filemater"))
                {
                    reader.ReadStartElement("filemater");

                    if (reader.IsStartElement("document"))
                    {
                        reader.ReadStartElement("document");
                        this.Document.Deserialize(reader, this.DeserializeNodeContent);
                        reader.ReadEndElement();
                        readed = true;
                    }

                    if (reader.IsStartElement("schematic"))
                    {
                        reader.ReadStartElement("schematic");
                        CreateWndSchematic();
                        this.WndSchematic.Diagram.Deserialize(reader);
                        reader.ReadEndElement();
                    }

                    if (reader.IsStartElement("navigation"))
                    {
                        reader.ReadStartElement("navigation");
                        CreateWndNavi();
                        this.WndNavi.navi.Deserialize(reader);
                        reader.ReadEndElement();
                    }

                    reader.ReadEndElement();
                }

                reader.Close();
                if (readed)
                {
                    this.FilePath = this.openFileDialog1.FileName;
                    Global.RaiseEvent(Global.OpenDocumentEvent);
                }
                else
                {
                    throw new ApplicationException();
                }

                // 引数とレスポンスファイルを処理

                foreach (libpixy.net.Controls.Diagram.Node node in Document.Nodes)
                {
                    if (node is Nodes.Input.ArgumentsNode)
                    {
                        Nodes.Input.ArgumentsNode arguments_node = node as Nodes.Input.ArgumentsNode;
                        arguments_node.Files.AddRange(Global.Arguments);
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("読み込みに失敗しました", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool SaveAs()
        {
            this.saveFileDialog1.Filter = "Filemater File (*.fmater)|*.fmater|All file(*.*)|*.*";
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return Save(this.saveFileDialog1.FileName);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private bool Save(string path)
        {
            try
            {
                System.IO.StreamWriter strm = new System.IO.StreamWriter(path);
                XmlTextWriter writer = new XmlTextWriter(strm);
                writer.WriteStartDocument();
                writer.WriteWhitespace("\r\n");
                writer.WriteStartElement("filemater");
                writer.WriteWhitespace("\r\n");

                if (this.Document != null)
                {
                    writer.WriteStartElement("document");
                    writer.WriteWhitespace("\r\n");
                    this.Document.Serialize(writer);
                    writer.WriteEndElement();
                    writer.WriteWhitespace("\r\n");
                }

                if (this.WndSchematic != null)
                {
                    writer.WriteStartElement("schematic");
                    writer.WriteWhitespace("\r\n");
                    this.WndSchematic.Diagram.Serialize(writer);
                    writer.WriteEndElement();
                    writer.WriteWhitespace("\r\n");
                }

                if (this.WndNavi != null)
                {
                    writer.WriteStartElement("navigation");
                    writer.WriteWhitespace("\r\n");
                    this.WndNavi.navi.Serialize(writer);
                    writer.WriteEndElement();
                    writer.WriteWhitespace("\r\n");
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
                writer.IndentChar = '\t';
                writer.Flush();
                writer.Close();
                this.FilePath = path;
                this.Document.ModifiedFlag = false;
                Global.RaiseEvent(Global.SaveDocumentEvent);
                return true;
            }
            catch
            {
                MessageBox.Show("保存に失敗しました", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateTitleText()
        {
            string str = this.FilePath;
            if (str == "")
            {
                str = "無題";
            }

            if (this.Document.ModifiedFlag)
            {
                str += "*";
            }

            this.Text = "Filemater - " + str;
        }

        /// <summary>
        /// 
        /// </summary>
        private void AutoRun()
        {
            Global.WriteLine("自動実行を開始します。");

            Open(Global.DocumentName);

            Global.WriteLine("シュミレーションを実行します。");

            Global.MainForm.WndSchematic.Simulate();

            Global.WriteLine("処理を実行します。");

            Global.MainForm.WndResult.Run();

            Global.WriteLine("自動実行を終了します。");
        }

        #endregion Private Methods

        #region Docking Window

        /// <summary>
        /// 
        /// </summary>
        private void LoadDockState()
        {
            bool loadDockState = false;
            try
            {
                this.dockContainer1.LoadFromXml(
                    System.IO.Path.Combine(
                        System.IO.Path.GetDirectoryName(Application.ExecutablePath),
                        "DockStateDefault.xml"),
                    new Fireball.Docking.DeserializeDockContent(this.DeserializeDockContent));
                loadDockState = true;
            }
            catch (InvalidOperationException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (ArgumentException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch
            {
            }

            if (!loadDockState)
            {
                CreateWndSchematic();
                CreateWndNavi();
                CreateWndToolbox();
                CreateWndResults();
                CreateWndProperty();
                CreateWndFileInfo();
                this.WndToolbox.Show(dockContainer1, Fireball.Docking.DockState.DockLeft);
                this.WndSchematic.Show(dockContainer1, Fireball.Docking.DockState.Document);
                this.WndResult.Show(dockContainer1, Fireball.Docking.DockState.Document);
                this.WndNavi.Show(dockContainer1, Fireball.Docking.DockState.DockRight);
                this.WndFileInfo.Show(this.WndNavi.Pane, Fireball.Docking.DockAlignment.Bottom, 0.8);
                this.WndProperty.Show(this.WndFileInfo.Pane, this.WndFileInfo);
                this.WndSchematic.Activate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateWndSchematic()
        {
            if (this.WndSchematic != null)
            {
                return;
            }

            this.WndSchematic = new Window.SchematicWindow();
            this.WndSchematic.Diagram.Document = this.Document;
            this.WndSchematic.Diagram.NodeSelected += new EventHandler(CanvasWindow_NodeSelected);
            this.WndSchematic.CloseButton = false;

            if (this.WndNavi != null)
            {
                this.WndNavi.navi.NavigateTarget = this.WndSchematic.Diagram;
                this.WndSchematic.Diagram.NavigateTarget = this.WndNavi.navi;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateWndNavi()
        {
            if (this.WndNavi != null)
            {
                return;
            }

            this.WndNavi = new Window.NavigationWindow();
            this.WndNavi.navi.Document = this.Document;

            if (this.WndSchematic != null)
            {
                this.WndSchematic.Diagram.NavigateTarget = this.WndNavi.navi;
                this.WndNavi.navi.NavigateTarget = this.WndSchematic.Diagram;
                this.WndSchematic.Diagram.SyncNaviTarget();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateWndToolbox()
        {
            if (this.WndToolbox != null)
            {
                return;
            }

            this.WndToolbox = new Window.NodeToolboxWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateWndProperty()
        {
            if (this.WndProperty != null)
            {
                return;
            }

            this.WndProperty = new Window.PropertyWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateWndFileInfo()
        {
            if (this.WndFileInfo != null)
            {
                return;
            }

            this.WndFileInfo = new Window.FileInfoWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateWndResults()
        {
            if (this.WndResult != null)
            {
                return;
            }

            this.WndResult = new Window.ResultWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persistString"></param>
        /// <returns></returns>
        private Fireball.Docking.IDockableWindow DeserializeDockContent(string persistString)
        {
            if (persistString == "Filemater.Window.SchematicWindow")
            {
                CreateWndSchematic();
                return WndSchematic;
            }

            if (persistString == "Filemater.Window.NavigationWindow")
            {
                CreateWndNavi();
                return WndNavi;
            }

            if (persistString == "Filemater.Window.FileInfoWindow")
            {
                CreateWndFileInfo();
                return WndFileInfo;
            }

            if (persistString == "Filemater.Window.NodeToolboxWindow")
            {
                CreateWndToolbox();
                return WndToolbox;
            }

            if (persistString == "Filemater.Window.ResultWindow")
            {
                CreateWndResults();
                return WndResult;
            }

            if (persistString == "Filemater.Window.PropertyWindow")
            {
                CreateWndProperty();
                return WndProperty;
            }
           
            return null;
        }

        #endregion Docking Window

        #region Event Handlers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filemater_Load(object sender, EventArgs e)
        {
            this.Document = new libpixy.net.Controls.Diagram.Document();
            this.Document.Changed += new libpixy.net.Controls.Diagram.ChangedEvent(Document_Changed);

            Global.MainForm = this;
            Global.ModifyDocumentEvent += new EventHandler(Global_ModifyDocument);

            LoadDockState();
            LoadMenuImages();
            LoadToolbarImages();
            UpdateTitleText();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Filemater_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Document.ModifiedFlag && Global.AutoRun == false)
            {
                string title = this.FilePath;
                if (title == "") title = "無題";
                string msg = string.Format("ファイル {0} の内容が変更されています。\n変更を保存しますか？", title);
                DialogResult result = MessageBox.Show(msg, "Filemater", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (this.FilePath == "")
                    {
                        if (!SaveAs())
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    else
                    {
                        if (!Save(this.FilePath))
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            this.dockContainer1.SaveAsXml(
                System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(Application.ExecutablePath),
                    "DockStateDefault.xml"));

            if (this.WndResult != null)
            {
                this.WndResult.SaveResultColumnSetting();
            }

            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void Document_Changed(object sender, libpixy.net.Controls.Diagram.ChangedEventArgs args)
        {
            UpdateTitleText();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CanvasWindow_NodeSelected(object sender, EventArgs e)
        {
            if (this.WndProperty == null)
            {
                return;
            }

            this.WndProperty.Controls.Clear();

            if (Document.SelectedCount>0)
            {
                Nodes.INode node = Document.SelectedNode as Nodes.INode;
                Control ctrl = node.Property();
                ctrl.Dock = DockStyle.Fill;
                this.WndProperty.Controls.Add(ctrl);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Global_ModifyDocument(object sender, EventArgs e)
        {
            this.Document.ModifiedFlag = true;
        }

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
            UpdateTitleText();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuEditFind_Click(object sender, EventArgs e)
        {
            if (this.WndResult != null)
            {
                this.WndResult.SetFocusSearchBox();
            }
        }

        private void menuEditFindNext_Click(object sender, EventArgs e)
        {
            if (this.WndResult != null)
            {
                this.WndResult.FindNext();
            }
        }

        private void menuView_DropDownOpening(object sender, EventArgs e)
        {
#if false
            this.menuViewNodeTreeWindow.Checked = (this.WndSchematic != null);
            this.menuViewToolboxWindow.Checked = (this.WndToolbox != null);
            this.menuViewNaviWindow.Checked = (this.WndNavi != null);
            this.menuViewPropertyWindow.Checked = (this.WndProperty != null);
            this.menuViewFileInfoWindow.Checked = (this.WndFileInfo != null);
            this.menuViewResultsWindow.Checked = (this.WndResult != null);
#endif

            this.menuViewNodeTreeWindow.ImageIndex = (this.WndSchematic != null) ? 9 : -1;
            this.menuViewNaviWindow.ImageIndex = (this.WndNavi != null) ? 9 : -1;
            this.menuViewFileInfoWindow.ImageIndex = (this.WndFileInfo != null) ? 9 : -1;
            this.menuViewPropertyWindow.ImageIndex = (this.WndProperty != null) ? 9 : -1;
            this.menuViewToolboxWindow.ImageIndex = (this.WndToolbox != null) ? 9 : -1;
            this.menuViewResultsWindow.ImageIndex = (this.WndResult != null) ? 9 : -1;
        }

        private void menuViewNodeTreeWindow_Click(object sender, EventArgs e)
        {
            if (this.WndSchematic == null)
            {
                CreateWndSchematic();
                this.WndSchematic.Show(this.WndContainer, Fireball.Docking.DockState.Document);
            }
        }

        private void menuViewToolboxWindow_Click(object sender, EventArgs e)
        {
            if (this.WndToolbox == null)
            {
                CreateWndToolbox();
                this.WndToolbox.Show(this.WndContainer, Fireball.Docking.DockState.DockLeft);
            }
        }

        private void menuViewNaviWindow_Click(object sender, EventArgs e)
        {
            if (this.WndNavi == null)
            {
                CreateWndNavi();
                this.WndNavi.Show(this.WndContainer, Fireball.Docking.DockState.DockRight);
            }
        }

        private void menuViewPropertyWindow_Click(object sender, EventArgs e)
        {
            if (this.WndProperty == null)
            {
                CreateWndProperty();
                this.WndProperty.Show(this.WndContainer, Fireball.Docking.DockState.DockRight);
            }
        }

        private void menuViewFileInfoWindow_Click(object sender, EventArgs e)
        {
            if (this.WndFileInfo == null)
            {
                CreateWndFileInfo();
                this.WndFileInfo.Show(this.WndContainer, Fireball.Docking.DockState.DockRight);
            }
        }

        private void menuViewResultsWindow_Click(object sender, EventArgs e)
        {
            if (this.WndResult == null)
            {
                CreateWndResults();
                this.WndResult.Show(this.WndContainer, Fireball.Docking.DockState.Document);
            }
        }

        private void menuToolOption_Click(object sender, EventArgs e)
        {
            Forms.OptionForm form = new Forms.OptionForm();
            form.ShowDialog();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if false
            Help.ShowHelp(this,
                System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(Application.ExecutablePath),
                    "Filemater.chm"));
#endif
            try
            {
                System.Diagnostics.Process.Start(
                    System.IO.Path.Combine(
                        System.IO.Path.GetDirectoryName(Application.ExecutablePath),
                        "Filemater.chm"));
            }
            catch
            {
            }
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            //Forms.AboutBox form = new Forms.AboutBox();
            Forms.AboutFilemater form = new Forms.AboutFilemater();
            form.ShowDialog();
        }

        private void menuHelpHome_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "http://mebiusbox.crap.jp");
        }

        private void mainToolbarNew_Click(object sender, EventArgs e)
        {
            NewDocument();
        }

        private void mainToolbarOpen_Click(object sender, EventArgs e)
        {
            OpenDocument();
        }

        private void mainToolbarSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void menuEditSimuration_Click(object sender, EventArgs e)
        {
            if (this.WndSchematic != null)
            {
                this.WndSchematic.Simulate();
            }
        }

        private void menuEditRun_Click(object sender, EventArgs e)
        {
            if (this.WndResult != null)
            {
                this.WndResult.Run();
            }
        }

        #endregion Event Handlers

        #region Idle

        /// <summary>
        /// 
        /// </summary>
        public bool AppStillIdle
        {
            get
            {
                NativeMethods.PeekMsg msg;
                return !NativeMethods.PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }

        #region NativeMethods Class
        internal class NativeMethods
        {
            private NativeMethods() { }

            [StructLayout(LayoutKind.Sequential)]
            public struct PeekMsg
            {
                public IntPtr hWnd;
                public Message msg;
                public IntPtr wParam;
                public IntPtr lParam;
                uint time;
                public System.Drawing.Point p;
            }

            [System.Security.SuppressUnmanagedCodeSecurity]
            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            public static extern bool PeekMessage(out PeekMsg msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);
        }
        #endregion

        public void Application_Idle(object sender, EventArgs e)
        {
            while (AppStillIdle && Global.AutoRun && Global.AutoRunExec == false)
            {
                Global.AutoRunExec = true;
                AutoRun();
                Close();
            }
        }

        #endregion Idle
    }
}