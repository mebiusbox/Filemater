using System;
using System.Collections.Generic;
using System.Text;

namespace FileMAX.Toolbox.Operator
{
    public class NotOpButton : OperatorButton
    {
        public NotOpButton()
            : base("NOT", 0)
        {
        }

        public override Mbx.NodeTree.Node CreateNode()
        {
            Mbx.NodeTree.Node node = new Nodes.Operator.NotOpNode();
            SetupNode(ref node);
            return node;
        }
    }
}
