using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] dataAnimal = input.Split();
                string[] dataFood = Console.ReadLine().Split();
                string type = dataAnimal[0];
                string name = dataAnimal[1];
                double weight = double.Parse(dataAnimal[2]);
                Animal animal = null;
                if (type == nameof(Owl))
                {
                    animal = new Owl(name, weight, double.Parse(dataAnimal[3]));
                }
                else if (type == nameof(Hen))
                {
                    animal = new Hen(name, weight, double.Parse(dataAnimal[3]));
                }
                else if (type == nameof(Mouse))
                {
                    animal = new Mouse(name, weight, dataAnimal[3]);
                }
                else if (type == nameof(Dog))
                {
                    animal = new Dog(name, weight, dataAnimal[3]);
                }
                else if (type == nameof(Cat))
                {
                    animal = new Cat(name, weight, dataAnimal[3], dataAnimal[4]);
                }
                else if (type == nameof(Tiger))
                {
                    animal = new Tiger(name, weight, dataAnimal[3], dataAnimal[4]);
                }
                string foodType = dataFood[0];
                int quantity = int.Parse(dataFood[1]);
                Food food = null;
                if (foodType == nameof(Meat))
                {
                    food = new Meat(quantity);
                }
                else if (foodType == nameof(Vegetable))
                {
                    food = new Vegetable(quantity);
                }
                else if (foodType == nameof(Fruit))
                {
                    food = new Fruit(quantity);
                }
                else if (foodType == nameof(Seeds))
                {
                    food = new Seeds(quantity);
                }
                Console.WriteLine(animal.ProduceSound());
                animal.EatingFood(food);
                animals.Add(animal);
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
