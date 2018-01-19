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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace Filemater.Nodes.Filter
{
    /// <summary>
    /// 
    /// </summary>
    public class NameNode : IFilterNode
    {
        public enum SearchTarget
        {
            FILENAME = 0,
            WITHOUT_EXTENSION,
            EXTENSION,
            PATH,
            DIRECTORY
        }

        public static string[] SearchTargetText = {
            "ファイル名",
            "ファイル名（拡張子なし）",
            "拡張子",
            "パス",
            "ディレクトリ"
        };

        public static string[] SearchTargetTextEn = {
            "filename",
            "filename-without-extension",
            "extension",
            "path",
            "directory"
        };

        public libpixy.net.Tools.PatternMatch PMatch = new libpixy.net.Tools.PatternMatch();
        public string Pattern = "";
        public SearchTarget Target = SearchTarget.FILENAME;

        #region Constructor / Destructor 

        public NameNode()
        {
            this.Text = "Name";
        }

        #endregion

        #region override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new NameNodeForm(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Exec()
        {
            this.PMatch.Setup(Pattern);

            string str = GetTargetString(this.Input);
            if (this.PMatch.Match(str))
            {
                Dispatch(0, this.Input);
            }
            else
            {
                Dispatch(1, this.Input);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private string GetTargetString(File file)
        {
            switch (Target)
            {
                case SearchTarget.FILENAME:
                    return System.IO.Path.GetFileName(file.ShellItem.Path);

                case SearchTarget.WITHOUT_EXTENSION:
                    return System.IO.Path.GetFileNameWithoutExtension(file.ShellItem.Path);

                case SearchTarget.EXTENSION:
                    return System.IO.Path.GetExtension(file.ShellItem.Path);

                case SearchTarget.DIRECTORY:
                    return System.IO.Path.GetDirectoryName(file.ShellItem.Path);

                case SearchTarget.PATH:
                    return file.ShellItem.Path;
            }

            return file.ShellItem.Path;
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

            w.WriteElementString("Target", SearchTargetTextEn[(int)this.Target]);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Pattern", this.Pattern);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("OptionCaseSensitive", this.PMatch.OptionCaseSensitive ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("OptionZenkakuSensitive", this.PMatch.OptionZenkakuSensitive ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("OptionAlgo", libpixy.net.Tools.PatternMatch.MatchAlgoTextEn[(int)this.PMatch.OptionAlgo]);
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
            this.Target = (SearchTarget)libpixy.net.Utils.ArrayUtils.IndexOf(SearchTargetTextEn, r.ReadElementString("Target"));
            this.Pattern = r.ReadElementString("Pattern");
            this.PMatch.OptionCaseSensitive = (r.ReadElementString("OptionCaseSensitive") == "y");
            this.PMatch.OptionZenkakuSensitive = (r.ReadElementString("OptionZenkakuSensitive") == "y");
            this.PMatch.OptionAlgo = (libpixy.net.Tools.PatternMatch.MatchAlgo)libpixy.net.Utils.ArrayUtils.IndexOf(libpixy.net.Tools.PatternMatch.MatchAlgoTextEn, r.ReadElementString("OptionAlgo"));
        }
        #endregion
    }
}
