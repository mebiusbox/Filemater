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
    public class ImageSizeNode : IFilterNode
    {
        #region Properties

        public bool EnableWidth = true;
        public long Width1 = 0;
        public long Width2 = 0;
        public Util.NumberChecker.MethodType WidthMethodType = Util.NumberChecker.MethodType.LESS;
        public bool EnableHeight = true;
        public long Height1 = 0;
        public long Height2 = 0;
        public Util.NumberChecker.MethodType HeightMethodType = Util.NumberChecker.MethodType.LESS;

        public Util.NumberChecker.ILongValueMethod m_widthMethod = null;
        public Util.NumberChecker.ILongValueMethod m_heightMethod = null;

        #endregion

        #region Ctor/Dtor

        public ImageSizeNode()
        {
            this.Text = "ImageSize";
        }

        #endregion

        #region override

        public override Control Property()
        {
            return new ImageSizeNodeForm(this);
        }

        public override void Exec()
        {
            m_widthMethod = Util.NumberChecker.CreateLongValueMethod(this.WidthMethodType);
            m_heightMethod = Util.NumberChecker.CreateLongValueMethod(this.HeightMethodType);

            if (Process(this.Input))
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
        private bool Process(File file)
        {
            if (!this.EnableWidth && !this.EnableHeight)
            {
                return false;
            }

            if (file.ImageSize == null)
            {
                return false;
            }

            if (this.EnableWidth)
            {
                if (!m_widthMethod.Eval(
                    file.ImageSize.Value.Width, this.Width1, this.Width2))
                {
                    return false;
                }
            }

            if (this.EnableHeight)
            {
                if (!m_heightMethod.Eval(
                    file.ImageSize.Value.Height, this.Height1, this.Height2))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region Serialize

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        public override void Serialize(XmlWriter w)
        {
            base.Serialize(w);

            w.WriteElementString("OptionWidth", this.EnableWidth ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Width1", this.Width1.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Width2", this.Width2.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("WidthMethod", Util.NumberChecker.MethodTypeTextEn[(int)this.WidthMethodType]);
            w.WriteWhitespace("\r\n");

            w.WriteElementString("OptionHeight", this.EnableHeight ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Height1", this.Height1.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Height2", this.Height2.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("HeightMethod", Util.NumberChecker.MethodTypeTextEn[(int)this.HeightMethodType]);
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
            this.EnableWidth = (r.ReadElementString("OptionWidth") == "y");
            this.Width1 = Int32.Parse(r.ReadElementString("Width1"));
            this.Width2 = Int32.Parse(r.ReadElementString("Width2"));
            this.WidthMethodType = (Util.NumberChecker.MethodType)libpixy.net.Utils.ArrayUtils.IndexOf(
                        Util.NumberChecker.MethodTypeTextEn, r.ReadElementString("WidthMethod"));
            this.EnableHeight = (r.ReadElementString("OptionHeight") == "y");
            this.Height1 = Int32.Parse(r.ReadElementString("Height1"));
            this.Height2 = Int32.Parse(r.ReadElementString("Height2"));
            this.HeightMethodType = (Util.NumberChecker.MethodType)libpixy.net.Utils.ArrayUtils.IndexOf(
                        Util.NumberChecker.MethodTypeTextEn, r.ReadElementString("HeightMethod"));
        }

        #endregion
    }
}
