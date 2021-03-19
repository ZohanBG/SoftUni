using System;
using System.Collections.Generic;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            while (heroes.Count<n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type == nameof(Druid))
                {
                    heroes.Add(new Druid(name));
                }
                else if (type == nameof(Paladin))
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type == nameof(Rogue))
                {
                    heroes.Add(new Rogue(name));
                }
                else if (type == nameof(Warrior))
                {
                    heroes.Add(new Warrior(name));
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                heroesPower += hero.Power;
            }
            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
