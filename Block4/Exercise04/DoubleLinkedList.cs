using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04
{
    public class DoubleLinkedList<T>
    {
        private DoubleLinkedListNode<T> head;
        public DoubleLinkedListNode<T> Head
        {
            get
            {
                return head;
            }
            private set
            {
                head = value;
            }
        }

        private DoubleLinkedListNode<T> tail;
        public DoubleLinkedListNode<T> Tail
        {
            get
            {
                return tail;
            }
            private set
            {
                tail = value;
            }
        }

        private int count;
        public int Count
        {
            get
            {
                return count;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Count couldn't be negative.");
                }
                count = value;
            }
        }

        public DoubleLinkedList<T> Insert(T value, int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException("Index couldn't be negative or greater than Count.");
            }

            int counter = 0;
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value);
            DoubleLinkedListNode<T> iterator = Head;
            DoubleLinkedListNode<T> prev = null;

            while (iterator != null && counter < index)
            {
                counter++;
                prev = iterator;
                iterator = iterator.Next;
            }

            node.Previous = prev;
            node.Next = iterator;

            if (prev != null)
            {
                prev.Next = node;
            }

            if (iterator != null)
            {
                iterator.Previous = node;
            }

            if (counter == 0)
            {
                Head = node;
            }

            Count++;

            if (counter == Count - 1)
            {
                Tail = node;
            }

            return this;
        }
    }
}