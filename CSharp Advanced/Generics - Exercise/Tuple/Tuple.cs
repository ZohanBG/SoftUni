using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<T1,T2>
    {
        private T1 obj1;
        private T2 obj2;

        public Tuple(T1 obj1,T2 obj2)
        {
            this.obj1 = obj1;
            this.obj2 = obj2;
        }

        public override string ToString()
        {
            return $"{obj1} -> {obj2}";
        }
    }
}
