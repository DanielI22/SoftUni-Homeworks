using System;
using System.Collections.Generic;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<BaseHero> raidGroup = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());

            while(raidGroup.Count < n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                if(!isValidType(heroType))
                {
                    Console.WriteLine("Invalid hero!");
                }

                if(heroType == "Rogue")
                {
                    raidGroup.Add(new Rogue(heroName));
                }
                else if(heroType == "Druid")
                {
                    raidGroup.Add(new Druid(heroName));
                }
                else if (heroType == "Paladin")
                {
                    raidGroup.Add(new Paladin(heroName));
                }
                else if (heroType == "Warrior")
                {
                    raidGroup.Add(new Warrior(heroName));
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int sum = 0;
            foreach (var item in raidGroup)
            {
                sum += item.Power;
                Console.WriteLine(item.CastAbility()); 
            }

            if(sum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        static bool isValidType(string type)
        {
            if(type == "Warrior" || type == "Rogue" || type == "Druid" || type == "Paladin")
            {
                return true;
            }
            return false;
        }
    }
}
