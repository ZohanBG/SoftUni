using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    interface IBuyer
    {
        public int Food { get; }

        void BuyFood();
    }
}
