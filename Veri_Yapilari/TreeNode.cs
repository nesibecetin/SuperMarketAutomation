using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Yapilari
{
    public class TreeNode
    {
        public Urun Veri;
        public TreeNode Sol;
        public TreeNode Sag;

        public TreeNode()
        {
        }

        public TreeNode(Urun veri)
        {
            this.Veri = veri;
            Sol = null;
            Sag = null;
        }
    }
}
