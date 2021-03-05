using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<string> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<string>();
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get { return this.money; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }
        public List<string> BagOfProducts
        {
            get { return this.bagOfProducts; }
        }

        public void BuyProduct(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} bought {product.Name}");

                this.Money -= product.Cost;
                this.bagOfProducts.Add(product.Name);
            }
        }

        public override string ToString()
        {
            string person = $"{this.Name} - ";

            if (this.bagOfProducts.Count == 0)
            {
                person += "Nothing bought";
            }
            else
            {
                person += string.Join(", ", this.bagOfProducts);
            }

            return person;
        }
    }
}
