using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Yapilari
{
    public class HashTable
    {

        int tabloBoyutu = 8;
        object[] hashTablosu;

        public HashTable()
        {
            hashTablosu = new HashDugumu[tabloBoyutu];
            for (int i = 0; i < tabloBoyutu; i++)
                hashTablosu[i] = null;
        }
        Heap hp;
        public void Ekle(int anahtar, Urun3 deger)
        {
            int indis = (anahtar % tabloBoyutu);
            if (hashTablosu[indis] == null)
                hashTablosu[indis] = new HashDugumu(anahtar, deger);
            else
            {
                if (hp == null)
                {
                    hp = new Heap(2);
                    HashDugumu hd = (HashDugumu)hashTablosu[indis];
                    Urun3 sonDeger = (Urun3)hd.Deger;
                    hp.Insert(sonDeger);
                }
                else
                {
                    int oldSize = hp.maksBoyut;
                    hp.YenidenBoyutlandir(oldSize++);
                }
                hp.Insert(deger);
                hashTablosu[indis] = null;
                hashTablosu[indis] = new HashDugumu(anahtar, hp);
            }
        }

        public void Sil(int anahtar)
        {
            int indis = (anahtar % tabloBoyutu);
            if (hashTablosu[indis] != null)
            {
                HashDugumu oncekiHashDugumu = null;
                HashDugumu hashDugumu = (HashDugumu)hashTablosu[indis];
                while (hashDugumu.Next != null && hashDugumu.Anahtar != anahtar)
                {
                    oncekiHashDugumu = hashDugumu;
                    hashDugumu = hashDugumu.Next;
                }
                if (hashDugumu.Anahtar == anahtar)
                {
                    if (oncekiHashDugumu == null)
                        hashTablosu[indis] = hashDugumu.Next;
                    else
                        oncekiHashDugumu.Next = hashDugumu.Next;
                }
            }
        }
    }
}
