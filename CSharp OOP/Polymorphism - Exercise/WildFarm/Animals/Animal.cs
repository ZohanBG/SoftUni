using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Foods;

namespace WildFarm.Animals
{
    public abstract class Animal
    {
        public Animal(string name, 
            double weight,  
            HashSet<string> allowedFoods, 
            double weightModifire)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
            AllowedFoods = allowedFoods;
            WeightModifire = weightModifire;
        }


        public double WeightModifire { get; private set; }


        public HashSet<string> AllowedFoods { get; private set; }


        public string Name { get; private set; }


        public double Weight { get; private set; }


        public int FoodEaten { get; private set; }


        public abstract string ProduceSound();


        public void EatingFood(Food food)
        {
            if (!AllowedFoods.Contains(food.GetType().Name))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
                return;
            }

            FoodEaten += food.Quantity;

            Weight += food.Quantity * WeightModifire;
        }
    }
}
