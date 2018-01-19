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
    public class AttrNode : IFilterNode
    {
        /// <summary>
        /// 
        /// </summary>
        public struct Attr
        {
            public bool Archive;
            public bool ReadOnly;
            public bool Hidden;
            public bool System;
        }

        #region Properties

        public Attr Mask;
        public Attr Value;

        #endregion

        #region Ctor/Dtor
        
        /// <summary>
        /// 
        /// </summary>
        public AttrNode()
        {
            this.Text = "Attr";
            this.Mask.Archive = false;
            this.Mask.ReadOnly = false;
            this.Mask.Hidden = false;
            this.Mask.System = false;
            this.Value.Archive = false;
            this.Value.ReadOnly = false;
            this.Value.Hidden = false;
            this.Value.System = false;
        }

        #endregion

        #region override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new AttrNodeForm(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Exec()
        {
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
            if (this.Mask.Archive)
            {
                if (Test(file.Attr, System.IO.FileAttributes.Archive) != this.Value.Archive)
                {
                    return false;
                }
            }

            if (this.Mask.ReadOnly)
            {
                if (Test(file.Attr, System.IO.FileAttributes.ReadOnly) != this.Value.ReadOnly)
                {
                    return false;
                }
            }

            if (this.Mask.System)
            {
                if (Test(file.Attr, System.IO.FileAttributes.System) != this.Value.System)
                {
                    return false;
                }
            }

            if (this.Mask.Hidden)
            {
                if (Test(file.Attr, System.IO.FileAttributes.Hidden) != this.Value.Hidden)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attr"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        private bool Test(System.IO.FileAttributes attr, System.IO.FileAttributes mask)
        {
            if ((attr & mask) != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            w.WriteElementString("MaskArchive", this.Mask.Archive ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("MaskReadOnly", this.Mask.ReadOnly ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("MaskHidden", this.Mask.Hidden ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("MaskSystem", this.Mask.System ? "y" : "n");
            w.WriteWhitespace("\r\n");

            w.WriteElementString("ValueArchive", this.Value.Archive ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("ValueReadOnly", this.Value.ReadOnly ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("ValueHidden", this.Value.Hidden ? "y" : "n");
            w.WriteWhitespace("\r\n");
            w.WriteElementString("ValueSystem", this.Value.System ? "y" : "n");
            w.WriteWhitespace("\r\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="r"></param>
        public override void Deserialize(System.Xml.XmlReader r)
        {
            base.Deserialize(r);
            this.Mask.Archive = (r.ReadElementString("MaskArchvie") == "y");
            this.Mask.ReadOnly = (r.ReadElementString("MaskReadOnly") == "y");
            this.Mask.Hidden = (r.ReadElementString("MaskHidden") == "y");
            this.Mask.System = (r.ReadElementString("MaskSystem") == "y");
            this.Value.Archive = (r.ReadElementString("ValueArchive") == "y");
            this.Value.ReadOnly = (r.ReadElementString("ValueReadOnly") == "y");
            this.Value.Hidden = (r.ReadElementString("ValueHidden") == "y");
            this.Value.System = (r.ReadElementString("ValueSystem") == "y");
        }

        #endregion
    }
}
