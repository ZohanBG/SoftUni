using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class BoxOfT<T>
    {
        Stack<T> elements;

        public BoxOfT()
        {
            elements = new Stack<T>();
        }

        public void Add(T element)
        {
            elements.Push(element);
        }

        public T Remove()
        {
            T removedElement = elements.Pop();
            return removedElement;
        }

        public int Count { get { return elements.Count; } }
    }
}
