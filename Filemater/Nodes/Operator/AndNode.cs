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

namespace Filemater.Nodes.Operator
{
    public class AndNode : IOpNode
    {
        public int Count = 0;

        public AndNode()
        {
            this.Text = "AND";
        }

        #region override

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Control Property()
        {
            return new SimpleNodeForm(this);
        }

        public override void Clear()
        {
            base.Clear();
            this.Count = 0;
        }


        /// <summary>
        /// 
        /// </summary>
        public override void Exec()
        {
            this.Count++;
            if (CanExec())
            {
                Dispatch(0, this.Input);
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CanExec()
        {
            List<int> idlist = new List<int>();
            foreach (libpixy.net.Controls.Diagram.Link link in this.SourcePorts[0].Connections)
            {
                if (link.Port1.Owner is INode)
                {
                    INode inode = link.Port1.Owner as INode;
                    try
                    {
                        if (idlist.IndexOf(inode.Id) < 0)
                        {
                            idlist.Add(inode.Id);
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return (Count == idlist.Count);
        }
    }
}
