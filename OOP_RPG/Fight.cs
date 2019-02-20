using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Fight
    {
        private List<Monster> Monsters { get; set; }
        private Hero Hero { get; set; }

        public Fight(Hero game)
        {
            Hero = game;
            Monsters = new List<Monster>();
    
            //Monday-1
            AddMonster("Bulbasaur", 5, 5, 15, MonsterLevel.Easy);
            AddMonster("Ivysaur", 6, 4, 9, MonsterLevel.Easy);
            AddMonster("Venusaur", 18, 8, 15, MonsterLevel.Medium);
            AddMonster("Charmander", 17, 9, 18, MonsterLevel.Medium);
            AddMonster("Charizard", 28, 15, 27, MonsterLevel.Hard);

            //Tuesday-2
            AddMonster("Squirtle", 6, 5, 9, MonsterLevel.Easy);
            AddMonster("Wartortle", 7, 5, 8, MonsterLevel.Easy);
            AddMonster("Blastoise", 12, 6, 12, MonsterLevel.Medium);
            AddMonster("Charmeleon", 15, 8, 17, MonsterLevel.Medium);
            AddMonster("Caterpie", 24, 18, 25, MonsterLevel.Hard);

            //Wednesday-3
            AddMonster("Metapod", 6, 7, 12, MonsterLevel.Easy);
            AddMonster("Butterfree", 9, 8, 15, MonsterLevel.Easy);
            AddMonster("Weedle", 11, 10, 20, MonsterLevel.Medium);
            AddMonster("Kakuna", 15, 10, 19, MonsterLevel.Medium);
            AddMonster("Beedrill", 25, 8, 17, MonsterLevel.Hard);

            //Thursday-4
            AddMonster("Pidgey", 8, 5, 10, MonsterLevel.Easy);
            AddMonster("Pidgeotto", 8, 8, 9, MonsterLevel.Easy);
            AddMonster("Pidgeot", 10, 8, 18, MonsterLevel.Medium);
            AddMonster("Rattata", 12, 6, 17, MonsterLevel.Medium);
            AddMonster("Raticate", 21, 16, 25, MonsterLevel.Hard);

            //Friday-5
            AddMonster("Spearow", 4, 3, 7, MonsterLevel.Easy);
            AddMonster("Fearow", 5, 8, 9, MonsterLevel.Easy);
            AddMonster("Ekans", 12, 10, 15, MonsterLevel.Medium);
            AddMonster("Arbok", 11, 10, 19, MonsterLevel.Medium);
            AddMonster("Pikachu", 16, 10, 27, MonsterLevel.Hard);

            //Saturday-6
            AddMonster("Raichu", 6, 7, 12, MonsterLevel.Easy);
            AddMonster("Sandshrew", 8, 6, 13, MonsterLevel.Easy);
            AddMonster("Sandslash", 12, 10, 15, MonsterLevel.Medium);
            AddMonster("Nidoran", 15, 12, 18, MonsterLevel.Medium);
            AddMonster("Nidoran", 20, 10, 22, MonsterLevel.Hard);

            //Sunday-0
            AddMonster("Nidorina", 8, 5, 10, MonsterLevel.Easy);
            AddMonster("Nidoqueen", 7, 5, 15, MonsterLevel.Easy);
            AddMonster("Nidorino", 9, 8, 14, MonsterLevel.Medium);
            AddMonster("Nidoking", 9, 10, 19, MonsterLevel.Medium);
            AddMonster("Clefairy", 18, 17, 20, MonsterLevel.Hard);

        }
        //Each Moster's difficulty level
        public static class MonsterLevel
        {
            public const string Easy = "Easy";
            public const string Medium = "Medium";
            public const string Hard = "Hard";
        }

        public void AddMonster(string name, int strength, int defense, int hp, string diffculty)
        {
             Monsters.Add(new Monster(name, strength, defense, hp, diffculty));
        }

        public void Start()
        {
            Random rnd = new Random();

            //Set the day for test 
            DateTime dateValue = DateTime.Now;

            //Get weekday from today (Sunday:0 ~ Saturday:6)

            //Default weekday is 0 (Sunday)
            var weekday = (int)dateValue.DayOfWeek;
            var randomNumber = rnd.Next(30, 35);

            var enemy = Monsters[randomNumber];

            // Each weekday takes 1 monster randomly  from 5 monsters 
            if (weekday == 1)
            {
                randomNumber = rnd.Next(0, 5);
                enemy = Monsters[randomNumber];
            }
            else if (weekday == 2)
            {
                randomNumber = rnd.Next(5, 10);
                enemy = Monsters[randomNumber];
            }
            else if (weekday == 3)
            {
                randomNumber = rnd.Next(10, 15);
                enemy = Monsters[randomNumber];
            }
            else if (weekday == 4)
            {
                randomNumber = rnd.Next(15, 20);
                enemy = Monsters[randomNumber];
            }
            else if (weekday == 5)
            {
                randomNumber = rnd.Next(20, 25);
                enemy = Monsters[randomNumber];
            }
            else if (weekday == 6)
            {
                randomNumber = rnd.Next(25, 30);
                enemy = Monsters[randomNumber];
            }

            if (enemy.Diffculty == "Hard")
            {
                Console.WriteLine($"Becareful! '{enemy.Name}' is {enemy.Diffculty} than you think.");
            } else
            {
                Console.WriteLine($" '{enemy.Name}' is {enemy.Diffculty} ");
            }           
                       
            while (enemy.CurrentHP > 0 && Hero.CurrentHP > 0)
            {
                Console.WriteLine($"{Hero.Name}, got Strength({Hero.Strength}), Defense({Hero.Defense}), HP({Hero.CurrentHP})");
                Console.WriteLine($"You've encountered a {enemy.Name}! Strength({enemy.Strength}), Defense({enemy.Defense}), HP({enemy.CurrentHP}), What will you do?");

                Console.WriteLine("-------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Fight");

                var input = Console.ReadLine();

                if (input == "1")
                {                   
                    Battle(enemy, Hero);
                }
            }
        }

        private void Battle(Monster Enemy, Hero Hero)
        {
            var enemy = Enemy;
            var hero = Hero;

            //Compare strength, Defense between hero and enemy 
            var comparedValueOfHero = hero.Strength - enemy.Defense;
            var comparedValueOfEnemy = enemy.Strength - hero.Defense;

            int heroDamage;
            int enemyDamage;

            //Case1. Hero Attack,  Hero Strength < Enemy Defense
            if (comparedValueOfHero <= 0)
            {
                heroDamage = 1;
                enemy.CurrentHP -= heroDamage;
            }
            //Hero Hero Attack, Hero Strength > Enemy Defense
            else
            {
                heroDamage = comparedValueOfHero;
                enemy.CurrentHP -= heroDamage;
            }
            Console.WriteLine("--------------------------------------------------------------------");

            //Hero attack message
            Console.WriteLine($"You attack enemy, enemy got {heroDamage} damage(s)! ");
            //Enemy Attack  Enemy Strength < Hero Defense
            if (comparedValueOfEnemy <= 0)
            {
                enemyDamage = 1;
                hero.CurrentHP -= enemyDamage;
            }
            //Enemy  Attack  Enemy Strength < Hero Defense
            else
            {
                enemyDamage = comparedValueOfEnemy;
                hero.CurrentHP -= enemyDamage;
            }

            Console.WriteLine($"'{enemy.Name}' does {enemyDamage} damage(s) to Hero !");

            Console.WriteLine("--------------------------------------------------------------------");

            //Show the messages for winner and looser 
            if (enemy.CurrentHP <= 0)
            {
                //Enemy attack message
                Console.WriteLine($"{enemy.Name} has been defeated! {Hero.Name} wins the battle!");
                Hero.CurrentHP = Hero.OriginalHP;
                Console.ReadKey();
            }
            else if (hero.CurrentHP <= 0)
            {
                Console.WriteLine($"You've been defeated against {enemy.Name}! :( GAME OVER.");
                Console.WriteLine("Press any key to Exit the game");
                Console.ReadKey();
            }
        }
    }
}