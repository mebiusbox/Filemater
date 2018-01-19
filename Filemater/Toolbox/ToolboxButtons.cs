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
using System.Drawing;

namespace Filemater
{
    namespace Toolbox
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class InputButton : Button
        {
            public InputButton(String name, int imageIndex) : base(name, imageIndex)
            {
            }

            static public void SetupNode(ref libpixy.net.Controls.Diagram.Node node)
            {
                node.AddDestinationPort("Out", "File", true);

                node.BackColor = Color.FromArgb(255, 230, 141);
                node.ForeColor = Color.FromArgb(48, 48, 48);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract class OutputButton : Button
        {
            public OutputButton(String name, int imageIndex)
                : base(name, imageIndex)
            {
            }

            static public void SetupNode(ref libpixy.net.Controls.Diagram.Node node)
            {
                node.AddSourcePort("In", "File", true);
                node.BackColor = Color.FromArgb(164, 243, 134);
                node.ForeColor = Color.FromArgb(48, 48, 48);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract class FilterButton : Button
        {
            public FilterButton(String name, int imageIndex)
                : base(name, imageIndex)
            {
            }

            static public void SetupNode(ref libpixy.net.Controls.Diagram.Node node)
            {
                node.AddSourcePort("In", "File", true);
                node.AddDestinationPort("Y", "File", true);
                node.AddDestinationPort("N", "File", true);
                node.BackColor = Color.FromArgb(179, 218, 253);
                node.ForeColor = Color.FromArgb(48, 48, 48);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract class OperatorButton : Button
        {
            public OperatorButton(String name, int imageIndex)
                : base(name, imageIndex)
            {
            }

            static public void SetupNode(ref libpixy.net.Controls.Diagram.Node node)
            {
                node.AddSourcePort("In", "File", true);
                node.AddDestinationPort("Out", "File", true);
                node.BackColor = Color.FromArgb(246, 155, 198);
                node.ForeColor = Color.FromArgb(48, 48, 48);
            }
        }
    }
}
