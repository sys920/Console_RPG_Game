using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Fight
    {
        private List<Monster> Monsters { get; }
        private Hero Hero { get; }

        public Fight(Hero game)
        {
            Hero = game;
            Monsters = new List<Monster>();

            AddMonster("Squid", 15, 5, 20);
        }

        private void AddMonster(string name, int strength, int defense, int hp)
        {
            var monster = new Monster();

            monster.Name = name;
            monster.Strength = strength;
            monster.Defense = defense;
            monster.OriginalHP = hp;
            monster.CurrentHP = hp;

            Monsters.Add(monster);
        }

        public void Start()
        {
            var enemy = Monsters[0];

            while (enemy.CurrentHP > 0 && Hero.CurrentHP > 0)
            {
                Console.WriteLine("You've encountered a " + enemy.Name + "! " + enemy.Strength + " Strength/" + enemy.Defense + " Defense/" +
                enemy.CurrentHP + " HP. What will you do?");

                Console.WriteLine("1. Fight");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    HeroTurn(enemy);
                }
            }
        }

        private void HeroTurn(Monster monster)
        {
            var enemy = monster;
            var compare = Hero.Strength - enemy.Defense;
            int damage;

            if (compare <= 0)
            {
                damage = 1;
                enemy.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                enemy.CurrentHP -= damage;
            }

            Console.WriteLine("You did " + damage + " damage!");

            if (enemy.CurrentHP <= 0)
            {
                Win(enemy);
            }
            else
            {
                MonsterTurn(enemy);
            }
        }

        private void MonsterTurn(Monster monster)
        {
            var enemy = monster;
            int damage;
            var compare = enemy.Strength - Hero.Defense;

            if (compare <= 0)
            {
                damage = 1;
                Hero.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                Hero.CurrentHP -= damage;
            }

            Console.WriteLine(enemy.Name + " does " + damage + " damage!");

            if (Hero.CurrentHP <= 0)
            {
                Lose();
            }
        }

        private void Win(Monster monster)
        {
            var enemy = monster;
            Console.WriteLine(enemy.Name + " has been defeated! You win the battle!");
        }

        private void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
        }
    }
}