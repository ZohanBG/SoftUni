using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<T1,T2,T3>
    {
        public Threeuple(T1 firstElement,T2 secondElement, T3 thirdElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            ThirdElement = thirdElement;
        }
        public T1 FirstElement { get; set; }

        public T2 SecondElement { get; set; }

        public T3 ThirdElement { get; set; }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement} -> {ThirdElement}";
        }
    }
}
