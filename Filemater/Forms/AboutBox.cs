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
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace Filemater.Forms
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();

            //  アセンブリ情報からの製品情報を表示する情報ボックスを初期化します。
            //  アプリケーションのアセンブリ情報設定を次のいずれかにて変更します:
            //  - [プロジェクト] メニューの [プロパティ] にある [アプリケーション] の [アセンブリ情報]
            //  - AssemblyInfo.cs
            this.Text = String.Format("{0} のバージョン情報", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("バージョン {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }

        #region アセンブリ属性アクセサ

        public string AssemblyTitle
        {
            get
            {
                // このアセンブリ上のタイトル属性をすべて取得します
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // 少なくとも 1 つのタイトル属性がある場合
                if (attributes.Length > 0)
                {
                    // 最初の項目を選択します
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // 空の文字列の場合、その項目を返します
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // タイトル属性がないか、またはタイトル属性が空の文字列の場合、.exe 名を返します
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // このアセンブリ上の説明属性をすべて取得します
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // 説明属性がない場合、空の文字列を返します
                if (attributes.Length == 0)
                    return "";
                // 説明属性がある場合、その値を返します
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // このアセンブリ上の製品属性をすべて取得します
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // 製品属性がない場合、空の文字列を返します
                if (attributes.Length == 0)
                    return "";
                // 製品属性がある場合、その値を返します
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // このアセンブリ上の著作権属性をすべて取得します
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // 著作権属性がない場合、空の文字列を返します
                if (attributes.Length == 0)
                    return "";
                // 著作権属性がある場合、その値を返します
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                return "Copyright (C) 2009 Yusuke Kamiyamane. All rights reserved.";
#if false
                // このアセンブリ上の会社属性をすべて取得します
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // 会社属性がない場合、空の文字列を返します
                if (attributes.Length == 0)
                    return "";
                // 会社属性がある場合、その値を返します
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
#endif
            }
        }
        #endregion
    }
}
