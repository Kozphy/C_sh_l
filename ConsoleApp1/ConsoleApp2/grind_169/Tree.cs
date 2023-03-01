using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.grind_169
{
    internal class Tree
    {
        public class TreeNode
        {
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
            public int value { get; set; }

            public TreeNode(int value) { 
                this.left = null;
                this.right = null;
                this.value = value;
            }

        }
    }
}
