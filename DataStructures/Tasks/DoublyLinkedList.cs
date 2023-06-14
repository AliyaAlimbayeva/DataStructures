using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;


namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerable<T>
    {
        public DoublyLinkedList()
        {
            head = null;
            Length = 0;
            tail = head;
        }

        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        public int Length { get; private set; }

        public void Add(T e)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(e);
            if (this.head == null)
            {
                this.head = node;
                
            }
            else {
                node.Previous = this.tail;
                tail.Next = node;
                tail = node;
            }
            Length++;
            tail = node;
        }

        public void AddAt(int index, T e)
        {
            if (index == 0)
            {
                var node = new LinkedListNode<T>(e, head);
                head = node;
                Length++;
            }
            else 
            if (index == Length)
            {
                Add(e);
            }
            else if (index > 0 && index < Length)
            {
                var prevNode = GetNodeAt(index - 1);
                var newNode = new LinkedListNode<T>(e);
                newNode.Previous = prevNode;

                var nextNode = prevNode.Next;
                
                prevNode.Next = newNode;
                nextNode.Previous = newNode;
                Length++;
            }            
        }

        public T ElementAt(int index)
        {
            return GetNodeAt(index).Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator(this);
        }

        public void Remove(T item)
        {
            LinkedListNode<T> current = head;
            int index = -1;
            for (int i = 0; i < Length; i++)
            {
                if (current.Data.Equals(item))
                {
                    index = i;
                    break;
                }
                current = current.Next;
            }
            if (index > -1)
            {
                RemoveAt(index);
            }
        }

        public T RemoveAt(int index)
        {
            T result = default(T);
            if (IndexValidation(index)) {
                if (index == 0)
                {
                    result = head.Data;
                    head = head.Next;
                }
                else if (index == Length - 1)
                {
                    result = tail.Data;
                    tail.Previous.Next = null;
                    tail = tail.Previous;
                }
                else
                {
                    LinkedListNode<T> nodeAtIndex = GetNodeAt(index);
                    result = nodeAtIndex.Data;
                    nodeAtIndex.Previous.Next = nodeAtIndex.Next;
                    nodeAtIndex.Next.Previous = nodeAtIndex.Previous;
                }
                Length--;
            }
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private LinkedListNode<T> GetNodeAt(int index)
        {
            IndexValidation(index);

            var result = head;

            for (int i = 0; i < index; i++)
            {
                result = result.Next;
            }

            return result;
        }
        private bool IndexValidation(int index)
        {
            if (index < 0 || index > Length - 1)
            {
                throw new IndexOutOfRangeException("index");
            }
            else
            {
                return true;
            };
        }
        private class ListEnumerator : IEnumerator<T>
        {
            private LinkedListNode<T> current;
            private LinkedListNode<T> head;
            private int currentIndex = -1;
            private int length;

            public ListEnumerator(DoublyLinkedList<T> lst)
            {
                head = lst.head;
                current = lst.head;
                length = lst.Length;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return current.Data;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current => current;

            public void Dispose() { }

            public bool MoveNext()
            {
                if (currentIndex != -1)
                    current = current.Next;
                currentIndex++;
                return (currentIndex < length);
            }

            public void Reset()
            {
                current = head;
                currentIndex = -1;
            }
        }
    }

   
}
