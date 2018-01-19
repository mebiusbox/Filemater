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
    /// <summary>
    /// 
    /// </summary>
    public class SizeNode : IFilterNode
    {
        #region Field

        /// <summary>
        /// 
        /// </summary>
        public enum SizeMethodType
        {
            LESS = 0,
            MORE,
            SAME,
            IN_RANGE,
            OUT_RANGE
        }

        public static string[] SizeMethodTypeText = {
            "ÇÊÇËè¨Ç≥Ç¢",
            "ÇÊÇËëÂÇ´Ç¢",
            "ìØÇ∂",
            "îÕàÕì‡",
            "îÕàÕäO"
        };

        public static string[] SizeMethodTypeTextEn = {
            "less",
            "more",
            "same",
            "in-range",
            "out-range"
        };

        public enum SizeUnit
        {
            BYTE = 0,
            KB,
            MB,
            GB
        }

        public static string[] SizeUnitText = {
            "Byte",
            "KB",
            "MB",
            "GB"
        };

        public long Size1 = 0;
        public long Size2 = 0;
        public SizeMethodType MethodType = SizeMethodType.LESS;
        public SizeUnit Unit = SizeUnit.BYTE;

        private ISizeMethod m_method;
        private long m_size1;
        private long m_size2;

        #endregion

        #region SizeMethod classes

        public abstract class ISizeMethod
        {
            public abstract bool Eval(long value, long size1, long size2);
        }

        public class SizeMethodLess : ISizeMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (value < size1);
            }
        }

        public class SizeMethodMore : ISizeMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (value > size1);
            }
        }

        public class SizeMethodSame : ISizeMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (value == size1);
            }
        }

        public class SizeMethodInRange : ISizeMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (size1 <= value && value <= size2);
            }
        }

        public class SizeMethodOutRange : ISizeMethod
        {
            public override bool Eval(long value, long size1, long size2)
            {
                return (value < size1 || size2 < value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static ISizeMethod CreateMethod(SizeMethodType type)
        {
            switch (type)
            {
                case SizeMethodType.LESS:
                    return new SizeMethodLess();

                case SizeMethodType.MORE:
                    return new SizeMethodMore();

                case SizeMethodType.SAME:
                    return new SizeMethodSame();

                case SizeMethodType.IN_RANGE:
                    return new SizeMethodInRange();

                case SizeMethodType.OUT_RANGE:
                    return new SizeMethodOutRange();
            }

            return null;
        }

        #endregion

        #region Constructor / Destructor

        public SizeNode()
        {
            this.Text = "Size";
        }

        #endregion

        #region override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new SizeNodeForm(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Exec()
        {
            m_method = CreateMethod(this.MethodType);
            m_size1 = ConvSizeUnit(Size1);
            m_size2 = ConvSizeUnit(Size2);

            if (m_method != null && m_method.Eval(this.Input.Size, m_size1, m_size2))
            {
                Dispatch(0, this.Input);
            }
            else
            {
                Dispatch(1, this.Input);
            }

            m_method = null;
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

            w.WriteElementString("Size1", this.Size1.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Size2", this.Size2.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Method", SizeMethodTypeTextEn[(int)this.MethodType]);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Unit", SizeUnitText[(int)this.Unit]);
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
            this.Size1 = Int32.Parse(r.ReadElementString("Size1"));
            this.Size2 = Int32.Parse(r.ReadElementString("Size2"));
            this.MethodType = (SizeMethodType)libpixy.net.Utils.ArrayUtils.IndexOf(SizeMethodTypeTextEn, r.ReadElementString("Method"));
            this.Unit = (SizeUnit)libpixy.net.Utils.ArrayUtils.IndexOf(SizeUnitText, r.ReadElementString("Unit"));
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private long ConvSizeUnit(long size)
        {
            switch (this.Unit)
            {
                case SizeUnit.BYTE:
                    return size;

                case SizeUnit.KB:
                    return size * 1000;

                case SizeUnit.MB:
                    return size * 1000 * 1000;

                case SizeUnit.GB:
                    return size * 1000 * 1000 * 1000;
            }

            return size;
        }
    }
}
