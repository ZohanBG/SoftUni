using System;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name) 
            : base(name, 50, 25, 40, new Backpack())
        {
            Name = name;
        }

        public string Name { get; private set; }


        public void Heal(Character character)
        {
            this.EnsureAlive();

            if (character.IsAlive == false)
            {

                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);

            }

            character.Health += this.AbilityPoints;

        }
    }
}
