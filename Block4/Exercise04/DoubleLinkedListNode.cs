using System;

namespace Exercise04
{
    public class DoubleLinkedListNode<T>
    {
        private T value;
        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        private DoubleLinkedListNode<T> previous;
        public DoubleLinkedListNode<T> Previous
        {
            get
            {
                return previous;
            }
            set
            {
                previous = value;
            }
        }

        private DoubleLinkedListNode<T> next;
        public DoubleLinkedListNode<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        public DoubleLinkedListNode(T value, DoubleLinkedListNode<T> previous, DoubleLinkedListNode<T> next)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }

        public DoubleLinkedListNode(T value) : this(value, null, null) { }

        public static DoubleLinkedListNode<T> operator ++(DoubleLinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Operand couldn't be null.");
            }
            return node.Next;
        }

        public static DoubleLinkedListNode<T> operator --(DoubleLinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Operand couldn't be null.");
            }
            return node.Previous;
        }
    }
}