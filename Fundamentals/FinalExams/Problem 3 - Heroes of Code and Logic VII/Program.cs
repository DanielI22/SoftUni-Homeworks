using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3___Heroes_of_Code_and_Logic_VII
{
    public class Hero
    {
        public string heroName { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

        public Hero(string heroName, int hP, int mP)
        {
            this.heroName = heroName;
            HP = hP;
            MP = mP;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Hero> heroesList = new List<Hero>();
            for(int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int hp = int.Parse(tokens[1]);
                int mp = int.Parse(tokens[2]);

                heroesList.Add(new Hero(name, hp, mp));
            }

            string command = Console.ReadLine();

            while(command != "End")
            {
                string[] tokens = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string heroName = tokens[1];
                Hero curHero = heroesList.Find(hero => hero.heroName == heroName);

                if (action == "CastSpell")
                {
                    int mpNeeded = int.Parse(tokens[2]);
                    string spellName = tokens[3];

                    if(curHero.MP >= mpNeeded)
                    {
                        curHero.MP -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {curHero.MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if(action == "TakeDamage")
                {
                    int damage = int.Parse(tokens[2]);
                    string attacker = tokens[3];

                    curHero.HP -= damage;
                    if(curHero.HP > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {curHero.HP} HP left!");
                    }
                    else
                    {
                        heroesList.Remove(curHero);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if(action == "Recharge")
                {
                    int amount = int.Parse(tokens[2]);
                    int lastMP = curHero.MP;
                    curHero.MP += amount;

                    if(curHero.MP > 200)
                    {
                        amount = 200 - lastMP;
                        curHero.MP = 200;
                    }
                    Console.WriteLine($"{heroName} recharged for {amount} MP!");
                }
                else if(action == "Heal")
                {
                    int amount = int.Parse(tokens[2]);
                    int lastHP = curHero.HP;
                    curHero.HP += amount;
                    if (curHero.HP > 100)
                    {
                        amount = 100 - lastHP;
                        curHero.HP = 100;
                    }
                    Console.WriteLine($"{heroName} healed for {amount} HP!");
                }
                command = Console.ReadLine();
            }

            foreach(Hero hero in heroesList)
            {
                Console.WriteLine(hero.heroName);
                Console.WriteLine("  HP: " + hero.HP);
                Console.WriteLine("  MP: " + hero.MP);
            }
        }
    }
}
