using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise04
{
    public class DoubleLinkedList<T> where T : IComparable
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

        // save the reference of the last node indexed by [] to improve performance
        private struct IndexedNode
        {
            public DoubleLinkedListNode<T> node;
            public int index;
        }
        private IndexedNode lastIndexed = new IndexedNode();

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

        public DoubleLinkedList()
        {
            Count = 0;
            Head = null;
            Tail = null;
        }

        public DoubleLinkedList(params T[] values) : this()
        {
            for (int i = 0; i < values.Length; i++)
            {
                Insert(values[i], i);
            }
        }

        public DoubleLinkedList<T> AddToStart(T value)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value);

            if (Head != null)
            {
                Head.Previous = node;
            }

            node.Next = Head;
            Head = node;
            Count++;

            return this;
        }

        public DoubleLinkedList<T> Append(T value)
        {
            DoubleLinkedListNode<T> node = new DoubleLinkedListNode<T>(value);

            if (Tail != null)
            {
                Tail.Next = node;
            }

            node.Previous = Tail;
            Tail = node;
            Count++;

            return this;
        }

        public DoubleLinkedListNode<T> Find(T value)
        {
            DoubleLinkedListNode<T> iterator = Head;

            while (iterator != null && iterator.Value.CompareTo(value) != 0)
            {
                iterator = iterator.Next;
            }

            return iterator;
        }

        // remove only the first occurrence of value
        public DoubleLinkedList<T> Remove(T value)
        {
            DoubleLinkedListNode<T> node = Find(value);
            DoubleLinkedListNode<T> previous = node.Previous;
            DoubleLinkedListNode<T> next = node.Next;

            if (previous != null)
            {
                previous.Next = next;
            }
            else
            {
                Head = node.Next;
            }

            if (next != null)
            {
                next.Previous = previous;
            }
            else
            {
                Tail = node.Previous;
            }

            Count--;

            return this;
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

            // link new node in the list
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

            // update Head and Tail if necessary
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

        public T[] ToArray()
        {
            T[] array = new T[Count];

            DoubleLinkedListNode<T> iterator = Head;
            int counter = 0;
            while (iterator != null)
            {
                array[counter++] = iterator.Value;
                iterator = iterator.Next;
            }

            return array;
        }

        private T Get(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("Index couldn't be negative or greater than Count.");
            }

            DoubleLinkedListNode<T> iterator;
            int counter;

            if (lastIndexed.node == null)
            {
                iterator = Head;
                counter = 0;
                while (counter != index)
                {
                    iterator = iterator.Next;
                    counter++;
                }
            }
            else
            {
                iterator = lastIndexed.node;
                counter = lastIndexed.index;

                if (counter > index)
                {
                    while (counter != index)
                    {
                        iterator = iterator.Previous;
                        counter--;
                    }
                }
                else if (counter < index)
                {
                    while (counter != index)
                    {
                        iterator = iterator.Next;
                        counter++;
                    }
                }
            }

            lastIndexed.node = iterator;
            lastIndexed.index = counter;

            return iterator.Value;
        }

        public T this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return Head.Value;
                }
                else if (index == Count - 1)
                {
                    return Tail.Value;
                }
                else
                {
                    return Get(index);
                }
            }
        }
    }
}