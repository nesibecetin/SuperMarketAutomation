using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veri_Yapilari
{
    public class LinkedList : LinkedListADT
    {
        public override void Insert(Urun2 Urun)
        {
            LinkedListNode newLast = new LinkedListNode();
            newLast.llVeri = Urun;
            if (Head == null)
                Head = newLast;
            else
            {
                LinkedListNode oldLast = Head;
                while (oldLast.Next != null)
                {
                    oldLast = oldLast.Next;
                }
                oldLast.Next = newLast;

            }
            Size++;
        }

        public override void Delete(int position)
        {
            int i = 1;
            if (Head != null && position != 0)
            {
                if (position == 1)
                    Head = Head.Next;
                else
                {
                    LinkedListNode posNode = Head;
                    LinkedListNode onceki = Head;
                    while (i != position)
                    {
                        onceki = posNode;
                        posNode = posNode.Next;
                        i++;
                    }
                    onceki.Next = posNode.Next;
                    posNode = null;
                }
            }
            Size--;
        }
        public override LinkedListNode GetElement(int position)
        {
            LinkedListNode retNode = null;
            LinkedListNode tempNode = Head;
            int count = 1;

            while (tempNode != null)
            {
                if (count == position)
                {
                    retNode = tempNode;
                    break;
                }
                tempNode = tempNode.Next;
                count++;
            }
            return retNode;
        }
    }
}
