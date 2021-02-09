using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCount
{
    public class Count<T>
        where T:IComparable
    {
        private List<T> elements;

        public Count(List<T> elements)
        {
            this.elements = elements;
        }

        public int CountElements(T element)
        {
            int count = 0;
            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i].CompareTo(element) > 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
