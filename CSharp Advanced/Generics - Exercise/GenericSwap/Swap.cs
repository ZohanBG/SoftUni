using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwap
{
    class Swap<T>
    {
        private List<T> elements;

        private int firstIndex;

        private int secondIndex;

        public Swap(List<T> elements,int firstIndex,int secondIndex)
        {
            this.elements = elements;
            this.firstIndex = firstIndex;
            this.secondIndex = secondIndex;
        }

        public override string ToString()
        {
            T temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
            StringBuilder sb = new StringBuilder();
            foreach (var element in elements)
            {
                sb.AppendLine($"{element.GetType()}: {element}");
            }
            return sb.ToString();
        }
    }
}
