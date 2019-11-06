using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Yapilari
{
    public class Tree
    {
        private TreeNode kok;
        private string dugumler;
        public Tree()
        {
        }
        public Tree(TreeNode kok)
        {
            this.kok = kok;
        }
        public int DugumSayisi()
        {
            return DugumSayisi(kok);
        }
        public int DugumSayisi(TreeNode dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                count = 1;
                count += DugumSayisi(dugum.Sol);
                count += DugumSayisi(dugum.Sag);
            }
            return count;
        }
        public int YaprakSayisi()
        {
            return YaprakSayisi(kok);
        }
        public int YaprakSayisi(TreeNode dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                if ((dugum.Sol == null) && (dugum.Sag == null))
                    count = 1;
                else
                    count = count + YaprakSayisi(dugum.Sol) + YaprakSayisi(dugum.Sag);
            }
            return count;
        }
        public string DugumleriYazdir()
        {
            return dugumler;
        }
        public string PreOrder()
        {
            dugumler = "";
            return PreOrderInt(kok);
        }
        private string PreOrderInt(TreeNode dugum)
        {
            if (dugum == null)
                return "";
            return Ziyaret(dugum);
            PreOrderInt(dugum.Sol);
            PreOrderInt(dugum.Sag);
        }
        public string InOrder()
        {
            dugumler = "";
            return InOrderInt(kok);
        }
        private string InOrderInt(TreeNode dugum)
        {
            if (dugum == null)
                return "";
            InOrderInt(dugum.Sol);
            return Ziyaret(dugum);
            InOrderInt(dugum.Sag);
        }
        private string Ziyaret(TreeNode dugum)
        {
            return dugumler += dugum.Veri.Ad + " ";
        }
        public string PostOrder()
        {
            dugumler = "";
            return PostOrderInt(kok);
        }
        private string PostOrderInt(TreeNode dugum)
        {
            if (dugum == null)
                return "";
            PostOrderInt(dugum.Sol);
            PostOrderInt(dugum.Sag);
            return Ziyaret(dugum);
        }
        public void Ekle(Urun deger)
        {
            TreeNode tempParent = new TreeNode();
            TreeNode tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                if ((int)deger.UrunNumarasi == (int)tempSearch.Veri.UrunNumarasi)
                    return;
                else if ((int)deger.UrunNumarasi < (int)tempSearch.Veri.UrunNumarasi)
                    tempSearch = tempSearch.Sol;
                else
                    tempSearch = tempSearch.Sag;
            }
            TreeNode eklenecek = new TreeNode(deger);
            if (kok == null)
                kok = eklenecek;
            else if ((int)deger.UrunNumarasi < (int)tempParent.Veri.UrunNumarasi)
                tempParent.Sol = eklenecek;
            else
                tempParent.Sag = eklenecek;
        }
        public TreeNode Ara(int anahtar)
        {
            return AraInt(kok, anahtar);
        }
        private TreeNode AraInt(TreeNode dugum,int anahtar)
        {
            if (dugum == null)
                return null;
            else if ((int)dugum.Veri.UrunNumarasi == anahtar)
                return dugum;
            else if ((int)dugum.Veri.UrunNumarasi > anahtar)
                return (AraInt(dugum.Sol, anahtar));
            else
                return (AraInt(dugum.Sag, anahtar));
        }

        private int DerinlikBulInt(TreeNode dugum)
        {
            if (dugum == null)
                return 0;
            else
            {
                int solYukseklik = 0, sagYukseklik = 0;
                solYukseklik = DerinlikBulInt(dugum.Sol);
                sagYukseklik = DerinlikBulInt(dugum.Sag);
                if (solYukseklik > sagYukseklik)
                    return solYukseklik + 1;
                else
                    return sagYukseklik + 1;
            }
        }
        public int DerinlikBul()
        {
            return DerinlikBulInt(kok);
        }

        public TreeNode MinDeger()
        {
            TreeNode tempSol = kok;
            while (tempSol.Sol != null)
                tempSol = tempSol.Sol;
            return tempSol;
        }

        public TreeNode MaksDeger()
        {
            TreeNode tempSag = kok;
            while (tempSag.Sag != null)
                tempSag = tempSag.Sag;
            return tempSag;
        }

        private TreeNode Successor(TreeNode silDugum)
        {
            TreeNode successorParent = silDugum;
            TreeNode successor = silDugum;
            TreeNode current = silDugum.Sag;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.Sol;
            }
            if (successor != silDugum.Sag)
            {
                successorParent.Sol = successor.Sag;
                successor.Sag = silDugum.Sag;
            }
            return successor;
        }
        public bool Sil(int deger)
        {
            TreeNode current = kok;
            TreeNode parent = kok;
            bool isSol = true;
            while ((int)current.Veri.UrunNumarasi != deger)
            {
                parent = current;
                if (deger < (int)current.Veri.UrunNumarasi)
                {
                    isSol = true;
                    current = current.Sol;
                }
                else
                {
                    isSol = false;
                    current = current.Sag;
                }
                if (current == null)
                    return false;
            }
            if (current.Sol == null && current.Sag == null)
            {
                if (current == kok)
                    kok = null;
                else if (isSol)
                    parent.Sol = null;
                else
                    parent.Sag = null;
            }
            else if (current.Sag == null)
            {
                if (current == kok)
                    kok = current.Sol;
                else if (isSol)
                    parent.Sol = current.Sol;
                else
                    parent.Sag = current.Sol;
            }
            else if (current.Sol == null)
            {
                if (current == kok)
                    kok = current.Sag;
                else if (isSol)
                    parent.Sol = current.Sag;
                else
                    parent.Sag = current.Sag;
            }
            else
            {
                TreeNode successor = Successor(current);
                if (current == kok)
                    kok = successor;
                else if (isSol)
                    parent.Sol = successor;
                else
                    parent.Sag = successor;
                successor.Sol = current.Sol;
            }
            return true;
        }
    }
}
