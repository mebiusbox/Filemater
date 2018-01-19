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
    public class HashNode : IFilterNode
    {
        public enum HashKind
        {
            MD5 = 0,
            SHA1,
            SHA256,
            SHA512
        }

        public static string[] HashKindText = {
            "MD5",
            "SHA1",
            "SHA2-256",
            "SHA2-512"
        };

        #region Properties

        public HashKind Kind = HashKind.MD5;
        public string Hash = "";

        #endregion

        #region Ctor/Dtor

        public HashNode()
        {
            this.Text = "Hash";
        }

        #endregion

        #region override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new HashNodeForm(this);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Exec()
        {
            string hash_lower = Hash.ToLower();
            if (hash_lower == GetHash(this.Input))
            {
                Dispatch(0, this.Input);
            }
            else
            {
                Dispatch(1, this.Input);
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

            w.WriteElementString("Kind", HashKindText[(int)this.Kind]);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Hash", this.Hash);
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
            this.Kind = (HashKind)libpixy.net.Utils.ArrayUtils.IndexOf(HashKindText, r.ReadElementString("Kind"));
            this.Hash = r.ReadElementString("Hash");
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private string GetHash(File file)
        {
            switch (this.Kind)
            {
                case HashKind.MD5:
                    return file.HashMD5;

                case HashKind.SHA1:
                    return file.HashSHA1;
                
                case HashKind.SHA256:
                    return file.HashSHA256;

                case HashKind.SHA512:
                    return file.HashSHA512;
            }

            return "";
        }
    }
}
