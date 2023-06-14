using System;
using Tasks.DoNotChange;

using System.Collections.Generic;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private List<T> items = new List<T>();

        public T Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("HybridFlowProcessor is empty");
            }
            T data = items[0];
            items.RemoveAt(0);
            return data;
        }

        public void Enqueue(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("HybridFlowProcessor is empty");
            }

            T item = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return item;
        }

        public void Push(T item)
        {
            items.Add(item);
        }
    }
}
