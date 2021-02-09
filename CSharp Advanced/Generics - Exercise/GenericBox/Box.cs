using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBox
{
    public class Box<T>
    {
        private T element;

        public Box(T element)
        {
            this.element = element;
        }

        public override string ToString()
        {
            return $"{element.GetType()}: {element}";
        }
    }
}
