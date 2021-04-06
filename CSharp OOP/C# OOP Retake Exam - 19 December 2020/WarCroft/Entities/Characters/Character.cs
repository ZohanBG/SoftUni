using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }


        public string Name 
		{
            get
            {
				return name;
            }
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
		}


        public double BaseHealth { get; private set; }


        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value >= 0 && value <= BaseHealth)
                {
                    health = value;
                }
            }
        }


        public double BaseArmor { get; private set; }


        public double Armor
        {
            get
            {
                return armor;
            }
            private set
            {
                if (value >= 0)
                {
                    armor = value;
                }
            }
        }


        public double AbilityPoints { get; private set; }


        public IBag Bag { get; private set; }


        public bool IsAlive { get; set; } = true;


		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (armor >= hitPoints)
            {
                armor -= hitPoints;
            }
            else
            {
                hitPoints -= armor;
                armor = 0;
                if (health > hitPoints)
                {
                    health -= hitPoints;
                }
                else
                {
                    health = 0;
                    IsAlive = false;
                }
            }
        }


        public void UseItem(Item item)
        {
            this.EnsureAlive();
            item.AffectCharacter(this);
        }

        public override string ToString()
        {
            return $"{Name} - HP: {Health}/{BaseHealth}, AP: {Armor}/{BaseArmor}, Status: {(IsAlive ? "Alive" : "Dead")}";
        }
    }
}