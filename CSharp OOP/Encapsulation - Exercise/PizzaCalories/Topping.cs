using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string typeOfTopping;
        private int weight;

        public Topping(string type,int weight)
        {
            TypeOfTopping = type;
            Weight = weight;
        }

        public string TypeOfTopping 
        {
            get => typeOfTopping;
            private set
            {
                if(value.ToLower()!="meat"&& value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    var valueName = value[0].ToString().ToUpper() + value.Substring(1);
                    throw new Exception($"Cannot place {valueName} on top of your pizza.");
                }
                typeOfTopping = value.ToLower();
            } 
        }

        public int Weight 
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    var valueName = this.typeOfTopping[0].ToString().ToUpper() + this.typeOfTopping.Substring(1);
                    throw new Exception($"{valueName} weight should be in the range [1..50].");
                }
                weight = value;
            } 
        }

        public double GetCalories()
        {
            if (TypeOfTopping == "meat")
            {
                return Weight * 2 * 1.2;
            }
            else if (TypeOfTopping == "veggies")
            {
                return Weight * 2 * 0.8;
            }
            else if (TypeOfTopping == "cheese")
            {
                return Weight * 2 * 1.1;
            }
            return Weight * 2 * 0.9;
        }
        
    }
}
