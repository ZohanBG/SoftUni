using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal defaultPrice = 3.5M;

        private const double defaultMilliliters = 50;


        public Coffee(string name,double caffeine) 
            : base(name, defaultPrice, defaultMilliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }

    }
}
