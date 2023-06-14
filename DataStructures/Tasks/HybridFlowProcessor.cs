using System;
using Tasks.DoNotChange;

using System.Collections.Generic;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private DoublyLinkedList<T> items = new DoublyLinkedList<T>();

        public T Dequeue()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("HybridFlowProcessor is empty");
            }
            T data = items.RemoveAt(0);
            return data;
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("HybridFlowProcessor is empty");
            }

            T item = items.RemoveAt(items.Length - 1);
            return item;
        }

        public void Push(T item)
        {
            items.Add(item);
        }
    }
}
