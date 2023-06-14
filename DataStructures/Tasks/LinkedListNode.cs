using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }

        public LinkedListNode(T item, LinkedListNode<T> next)
        {
            Data = item;
            Next = next;
            Previous = null;
        }

        public LinkedListNode(T item)
        {
            Data = item;
            Next = null;
        }
    }

}