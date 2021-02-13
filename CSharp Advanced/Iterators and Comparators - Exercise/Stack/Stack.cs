using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T>: IEnumerable<T>
    {
        private List<T> elements;

        public Stack()
        {
            elements = new List<T>();
        }

        public void Push(T element)
        {
            elements.Add(element);
        }

        public void Pop()
        {
            if (elements.Count > 0)
            {
                elements.RemoveAt(elements.Count - 1);
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count-1; i >=0 ; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
