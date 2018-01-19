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
using System.Xml;

namespace Filemater.Nodes.Filter
{
    public class ID3TagNode : IFilterNode
    {
        public enum TagItem
        {
            TRACKNAME = 0,
            ARTIST,
            ALBUM,
            TRACKNO,
            GENRE,
            YEAR,
            CHANNELS,
            BITRATE,
            SAMPLERATE,
            LENGTH,
            COMMENT
        }

        public static string[] TagItemText = {
            "トラック名",
            "アーティスト",
            "アルバム",
            "トラック No",
            "ジャンル",
            "年",
            "チャンネル",
            "ビットレート",
            "サンプリングレート",
            "長さ",
            "コメント"
        };

        public static string[] TagItemTextEn = {
            "track-name",
            "artist-name",
            "album-name",
            "track-no",
            "genre",
            "year",
            "channels",
            "bitrate",
            "samplerate",
            "length",
            "comment"
        };


        public static ModeType[] TagItemMode = {
            ModeType.STRING,/* TRACKNAME */
            ModeType.STRING,/* ARTIST */
            ModeType.STRING,/* ALBUM */
            ModeType.NUMBER,/* TRACKNO */
            ModeType.STRING,/* GENRE */
            ModeType.NUMBER,/* YEAR */
            ModeType.NUMBER,/* CHANNELS */
            ModeType.NUMBER,/* BITRATE */
            ModeType.NUMBER,/* SAMPLERATE */
            ModeType.NUMBER,/* LENGTH */
            ModeType.STRING,/* COMMENT */
        };

        public enum ModeType
        {
            STRING = 0,
            NUMBER
        }

        public static string[] ModeTypeTextEn = 
        {
            "string",
            "number"
        };

        #region Properties

        public TagItem Target = TagItem.TRACKNAME;
        public ModeType Mode = ModeType.STRING;
        public string Word = "";
        public long Number1 = 0;
        public long Number2 = 0;
        public Util.NumberChecker.MethodType NumberMethod = Util.NumberChecker.MethodType.LESS;

        #endregion

        private string m_workWord = "";
        private Util.NumberChecker.ILongValueMethod m_workMethod = null;

        #region Ctor/Dtor

        /// <summary>
        /// 
        /// </summary>
        public ID3TagNode()
        {
            this.Text = "ID3Tag";
        }

        #endregion

        #region override

        public override Control Property()
        {
            return new ID3TagNodeForm(this);
        }

        public override void Exec()
        {
            libpixy.net.Tagutils tlu = new libpixy.net.Tagutils();
            libpixy.net.Tagutils.Result taglibResult = tlu.Init();
            tlu.Term();

            if (taglibResult == libpixy.net.Tagutils.Result.SUCCESS)
            {
                m_workWord = this.Word.ToLower();
                m_workMethod = Util.NumberChecker.CreateLongValueMethod(this.NumberMethod);

                if (Process(this.Input))
                {
                    Dispatch(0, this.Input);
                }
                else
                {
                    Dispatch(1, this.Input);
                }
            }
            else
            {
                Dispatch(1, this.Input);
            }
        }

        #endregion

        #region Process

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool Process(File file)
        {
            try
            {
                if (file.ID3Tag == null)
                {
                    return false;
                }

                switch (this.Mode)
                {
                    case ModeType.STRING:
                        return ProcessString(file);

                    case ModeType.NUMBER:
                        return ProcessNumber(file);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool ProcessString(File file)
        {
            switch (this.Target)
            {
                case TagItem.TRACKNAME:
                    return ProcessString(file.ID3Tag.TrackName);

                case TagItem.ARTIST:
                    return ProcessString(file.ID3Tag.ArtistName);

                case TagItem.ALBUM:
                    return ProcessString(file.ID3Tag.AlbumName);

                case TagItem.COMMENT:
                    return ProcessString(file.ID3Tag.Comment);

                case TagItem.GENRE:
                    return ProcessString(file.ID3Tag.Genre);

                case TagItem.CHANNELS:
                    return ProcessString(file.ID3Tag.Channels.ToString());

                case TagItem.BITRATE:
                    return ProcessString(file.ID3Tag.BitRate.ToString());

                case TagItem.SAMPLERATE:
                    return ProcessString(file.ID3Tag.SampleRate.ToString());

                case TagItem.LENGTH:
                    return ProcessString(file.ID3Tag.Length.ToString());

                case TagItem.YEAR:
                    return ProcessString(file.ID3Tag.Year.ToString());

                case TagItem.TRACKNO:
                    return ProcessNumber(file.ID3Tag.Track);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool ProcessNumber(File file)
        {
            switch (this.Target)
            {
                case TagItem.TRACKNAME:
                    return ProcessString(file.ID3Tag.TrackName);

                case TagItem.ARTIST:
                    return ProcessString(file.ID3Tag.ArtistName);

                case TagItem.ALBUM:
                    return ProcessString(file.ID3Tag.AlbumName);

                case TagItem.COMMENT:
                    return ProcessString(file.ID3Tag.Comment);

                case TagItem.GENRE:
                    return ProcessString(file.ID3Tag.Genre);

                case TagItem.CHANNELS:
                    return ProcessNumber(file.ID3Tag.Channels);

                case TagItem.BITRATE:
                    return ProcessNumber(file.ID3Tag.BitRate);

                case TagItem.SAMPLERATE:
                    return ProcessNumber(file.ID3Tag.SampleRate);

                case TagItem.LENGTH:
                    return ProcessNumber(file.ID3Tag.Length);

                case TagItem.YEAR:
                    return ProcessNumber(file.ID3Tag.Year);

                case TagItem.TRACKNO:
                    return ProcessNumber(file.ID3Tag.Track);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        bool ProcessString(string s)
        {
            string str = s.ToLower();
            return (str.IndexOf(m_workWord) >= 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        bool ProcessNumber(long n)
        {
            return m_workMethod.Eval(n, this.Number1, this.Number2);
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

            w.WriteElementString("Target", TagItemTextEn[(int)this.Target]);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Mode", ModeTypeTextEn[(int)this.Mode]);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("PatternValue", this.Word);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Number1", this.Number1.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Number2", this.Number2.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("NumberMethod", Util.NumberChecker.MethodTypeTextEn[(int)this.NumberMethod]);
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
            this.Target = (TagItem)libpixy.net.Utils.ArrayUtils.IndexOf(TagItemTextEn, r.ReadElementString("Target"));
            this.Mode = (ModeType)libpixy.net.Utils.ArrayUtils.IndexOf(ModeTypeTextEn, r.ReadElementString("Mode"));
            this.Word = r.ReadElementString("PatternValue");
            this.Number1 = Int32.Parse(r.ReadElementString("Number1"));
            this.Number2 = Int32.Parse(r.ReadElementString("Number2"));
            this.NumberMethod = (Util.NumberChecker.MethodType)libpixy.net.Utils.ArrayUtils.IndexOf(
                        Util.NumberChecker.MethodTypeTextEn, r.ReadElementString("NumberMethod"));
        }

        #endregion
    }
}
