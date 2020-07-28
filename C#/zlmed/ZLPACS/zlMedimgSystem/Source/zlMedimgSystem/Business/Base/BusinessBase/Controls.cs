using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace zlMedimgSystem.BusinessBase
{
    static public class ControlEx
    {
        static public  List<TreeNode> GetCheckedTreeNode(TreeNode root)
        {
            List<TreeNode> nodes = new List<TreeNode>();

            if (root.Checked) nodes.Add(root);

            foreach (TreeNode node in root.Nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    List<TreeNode> subNodes = GetCheckedTreeNode(node);
                    if (subNodes.Count > 0) nodes.AddRange(subNodes);
                }
                else
                {
                    if (node.Checked) nodes.Add(node);
                }
            }

            return nodes;
        }
    }
}
