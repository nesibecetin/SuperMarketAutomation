using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Yapilari
{
    public class Heap
    {
        private HeapDugumu[] heap;
        public int maksBoyut;
        private int gecerliBoyut;
        public Heap(int maskHeapBoyutu)
        {
            maksBoyut = maskHeapBoyutu;
            gecerliBoyut = 0;
            heap = new HeapDugumu[maksBoyut];
        }

        public bool IsEmpty()
        {
            return gecerliBoyut == 0;
        }

        public bool Insert(Urun3 deger)
        {
            if (gecerliBoyut == maksBoyut)
                return false;
            HeapDugumu yeniHeapDugumu = new HeapDugumu(deger);
            heap[gecerliBoyut] = yeniHeapDugumu;
            MoveToUp(gecerliBoyut++);
            return true;
        }

        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heap[index];
            while (index > 0 && Convert.ToDouble(((Urun3)heap[parent].Deger).FiyatAraligi) < Convert.ToDouble(((Urun3)bottom.Deger).FiyatAraligi))
            {
                heap[index] = heap[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heap[index] = bottom;
        }

        public string Listele(Heap temp)
        {
            int i = 0;
            string liste = "";
            while (((HeapDugumu)temp.heap[i]) != null)
            {
                liste += ((Urun3)((HeapDugumu)temp.heap[i]).Deger).Ad + Environment.NewLine;
                i++;
            }
            return liste;
        }

        public bool Ara(Heap temp, Urun3 k)
        {
            int i = 0;
            Boolean bulundu = false;
            while (((HeapDugumu)temp.heap[i]) != null)
            {
                if (((Urun3)((HeapDugumu)temp.heap[i]).Deger) == k)
                {
                    bulundu = true;
                    break;
                }
                i++;
            }
            return bulundu;
        }

        public void YenidenBoyutlandir(int yeniBoyut)
        {
            HeapDugumu[] newHeap = new HeapDugumu[yeniBoyut];
            for (int i = 0; i < maksBoyut; i++)
            {
                newHeap[i] = heap[i];
            }
            heap = newHeap;
            maksBoyut = yeniBoyut;
        }
    }
}
