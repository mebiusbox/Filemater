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

namespace Filemater.Nodes
{
    /// <summary>
    /// 
    /// </summary>
    public class NodeSortByPriority : IComparer<INode>
    {
        public int Compare(INode a, INode b)
        {
            if (a.Priority > b.Priority)
            {
                return -1;
            }
            else if (a.Priority < b.Priority)
            {
                return +1;
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class INode : libpixy.net.Controls.Diagram.Node
    {
        public int Priority = 0;
        //private bool disposed = false;

        public File Input = null;
        public Work Work = null;

        private bool Done = false;

        /// <summary>
        /// 
        /// </summary>
        public INode()
        {
        }

#if false
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // managed resource
                }

                // unmanaged resource
                Global.NodeIdMgr.PutId(Id);
            }

            this.disposed = true;
        }
#endif

        public abstract String Desc();
        public abstract Control Property();
        public abstract void Exec();

        /// <summary>
        /// 
        /// </summary>
        public virtual void Clear()
        {
            this.Input = null;
            this.Work = null;
            this.Done = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        public virtual void Dispatch(int portIndex, File file)
        {
            this.Done = true;
            this.Work.PushNodeTrack(this.Id, portIndex);

            if (this.DestinationPorts.Count > 0 && portIndex < this.DestinationPorts.Count)
            {
                libpixy.net.Controls.Diagram.Port port = this.DestinationPorts[portIndex];
                List<INode> nodes = new List<INode>();
                foreach (libpixy.net.Controls.Diagram.Link link in port.Connections)
                {
                    if (link.Port2.Owner is INode)
                    {
                        nodes.Add(link.Port2.Owner as INode);
                    }
                }

                nodes.Sort(new NodeSortByPriority());

                foreach (INode nextNode in nodes)
                {
                    nextNode.Input = file;
                    nextNode.Work = Work;
                    nextNode.Exec();

                    if (this.Work.Done)
                    {
                        break;
                    }
                }
            }

            if (!this.Work.Done)
            {
                this.Work.NodeTrack.Pop();
            }
        }

        #region Serialize

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        public override void Serialize(XmlWriter w)
        {
            base.Serialize(w);
            w.WriteElementString("priority", this.Priority.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public override void Deserialize(XmlReader r)
        {
            base.Deserialize(r);
            this.Priority = Int32.Parse(r.ReadElementString("priority"));
        }

        #endregion

    }
}
