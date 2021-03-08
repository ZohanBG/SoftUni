using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    class Rebel : IPerson, IGroupable,IBuyer 
    {
        public Rebel(string name,int age,string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = 0;
        }


        public string Group { get; private set; }


        public string Name { get; private set; }


        public int Age { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
