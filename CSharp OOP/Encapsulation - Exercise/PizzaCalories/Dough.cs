using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType,string bakingTechnique,int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        public string FlourType 
        {
            get => flourType;
            private set
            {
                if(value.ToLower()!= "white" && value.ToLower()!= "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value.ToLower();
            }
        }
        public string BakingTechnique 
        {
            get => bakingTechnique;
            private set
            {
                if(value.ToLower()!= "crispy"&& value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value.ToLower();
            }
        }
        public int Weight 
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            } 
        }

        public double GetCalories()
        {
            return  FlourModifire() * BakingTechniqueModifire() * Weight *2;
        }

        private double FlourModifire()
        {
            if(FlourType== "white")
            {
                return 1.5;
            }
            return 1;
        }

        private double BakingTechniqueModifire()
        {
            if (BakingTechnique == "crispy")
            {
                return 0.9;
            }
            else if (BakingTechnique == "chewy")
            {
                return 1.1;
            }
            return 1;
        }
    }
}
