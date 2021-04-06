using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> party;
		private List<Item> itemPool;


		public WarController()
		{
			party = new List<Character>();
			itemPool = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			if (characterType == nameof(Warrior))
            {
				Character character = new Warrior(name);
				party.Add(character);
            }
			else if (characterType == nameof(Priest))
            {
				Character character = new Priest(name);
				party.Add(character);
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }
            return $"{name} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
            if (itemName == nameof(HealthPotion))
            {
				Item item = new HealthPotion();
				itemPool.Add(item);
            }
			else if (itemName == nameof(FirePotion))
            {
				Item item = new FirePotion();
				itemPool.Add(item);
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }
			return $"{itemName} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
            if (party.Any(x => x.Name==characterName)==false)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            if (itemPool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
			Character character = party.First(x => x.Name == characterName);
			Item item = itemPool[itemPool.Count - 1];
			character.Bag.AddItem(item);
			itemPool.RemoveAt(itemPool.Count - 1);
			return $"{characterName} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			if (party.Any(x => x.Name == characterName) == false)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
			Character character = party.First(x => x.Name == characterName);
			character.UseItem(character.Bag.GetItem(itemName));
			return $"{characterName} used {itemName}.";
		}

		public string GetStats()
		{
			party = party.OrderByDescending(x => x.IsAlive)
				.OrderByDescending(x => x.Health)
				.ToList();
			StringBuilder sb = new StringBuilder();
            foreach (var character in party)
            {
				sb.AppendLine(character.ToString());
            }
			return sb.ToString().TrimEnd();

		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

            if (party.Any(x => x.Name == attackerName) == false)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
			if (party.Any(x => x.Name == receiverName) == false)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}
			Character attacker = party.First(x => x.Name == attackerName);
			Character receiver = party.First(x => x.Name == receiverName);
            if (attacker.GetType().Name != nameof(Warrior))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
			Warrior warrior = (Warrior)attacker;
			warrior.Attack(receiver);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (receiver.IsAlive == false)
            {
				sb.AppendLine($"{receiver.Name} is dead!");
			}
			return sb.ToString().TrimEnd();

		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string receiverName = args[1];

			if (party.Any(x => x.Name == healerName) == false)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (party.Any(x => x.Name == receiverName) == false)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}
			Character healer = party.First(x => x.Name == healerName);
			Character receiver = party.First(x => x.Name == receiverName);
            if (healer.GetType().Name != nameof(Priest))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
			Priest priest = (Priest)healer;
			priest.Heal(receiver);
			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";

		}
	}
}
