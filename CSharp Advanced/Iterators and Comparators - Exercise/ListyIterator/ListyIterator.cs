using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>: IEnumerable<T>
    {
        private List<T> elements;

        private int currentIndex;

        public ListyIterator(List<T> elements)
        {
            this.elements = elements;
            currentIndex = 0;
        }
        public bool Move()
        {
            bool hasNext = HasNext();
            if (hasNext)
            {
                currentIndex++;
            }
            return hasNext;
        }

        public bool HasNext()=> currentIndex < elements.Count - 1;

        public void Print()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(elements[currentIndex]);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    }
}
