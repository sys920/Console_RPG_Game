using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class MonsterSelector
    {
        private List<Monster> Monsters { get; set; } 

        public MonsterSelector()
        {
            GenerateMonster();
        }

        public Monster SelectByRandomBaseOnWeekDay()
        {
                
            var today = DateTime.Now.DayOfWeek.ToString();
            
            // Each weekday takes 1 monster randomly  from 5 monsters 
            var randomEnemy = (from monster in Monsters
                         where monster.Weekday.ToString() == today
                        select monster).ToList();

            // Select Random monster from Monster Lists 
            Random rnd = new Random();
            var randomNumber = rnd.Next(0, randomEnemy.Count());

            return randomEnemy[randomNumber];
        }

        private void GenerateMonster()
        {
            Monsters = new List<Monster>();

            //Monday-1
            AddMonster("Bulbasaur", 5, 5, 15, MonsterLevel.Easy, MonsterOfTheDay.Monday);
            AddMonster("Ivysaur", 6, 4, 9, MonsterLevel.Easy, MonsterOfTheDay.Monday);
            AddMonster("Kobaloo", 4, 5, 8, MonsterLevel.Easy, MonsterOfTheDay.Monday);
            AddMonster("Myshine", 6, 5, 7, MonsterLevel.Easy, MonsterOfTheDay.Monday);
            AddMonster("Venusaur", 18, 8, 15, MonsterLevel.Medium, MonsterOfTheDay.Monday);
            AddMonster("Charmander", 17, 9, 18, MonsterLevel.Medium, MonsterOfTheDay.Monday);
            AddMonster("Charizard", 28, 15, 27, MonsterLevel.Hard, MonsterOfTheDay.Monday);

            //Tuesday-2
            AddMonster("Squirtle", 6, 5, 9, MonsterLevel.Easy, MonsterOfTheDay.Tuesday);
            AddMonster("Wartortle", 7, 5, 8, MonsterLevel.Easy, MonsterOfTheDay.Tuesday);
            AddMonster("LLollPrice", 4, 4, 9, MonsterLevel.Easy, MonsterOfTheDay.Tuesday);
            AddMonster("Kobrisub", 5, 3, 10, MonsterLevel.Easy, MonsterOfTheDay.Tuesday);
            AddMonster("Pidgeot", 10, 8, 18, MonsterLevel.Medium, MonsterOfTheDay.Wednesday);
            AddMonster("Rattata", 12, 6, 17, MonsterLevel.Medium, MonsterOfTheDay.Thursday);
            AddMonster("Blastoise", 12, 6, 12, MonsterLevel.Medium, MonsterOfTheDay.Tuesday);
            AddMonster("Charmeleon", 15, 8, 17, MonsterLevel.Medium, MonsterOfTheDay.Tuesday);
            AddMonster("Caterpie", 24, 18, 25, MonsterLevel.Hard, MonsterOfTheDay.Tuesday);

            //Wednesday-3
            AddMonster("Metapod", 6, 7, 12, MonsterLevel.Easy, MonsterOfTheDay.Wednesday);
            AddMonster("Butterfree", 9, 8, 15, MonsterLevel.Easy, MonsterOfTheDay.Wednesday);
            AddMonster("Weedle", 11, 10, 20, MonsterLevel.Medium, MonsterOfTheDay.Wednesday);
            AddMonster("Kakuna", 15, 10, 19, MonsterLevel.Medium, MonsterOfTheDay.Wednesday);
            AddMonster("Beedrill", 25, 8, 17, MonsterLevel.Hard, MonsterOfTheDay.Wednesday);

            //Thursday-4
            AddMonster("Pidgey", 8, 5, 10, MonsterLevel.Easy, MonsterOfTheDay.Thursday);
            AddMonster("Pidgeotto", 8, 8, 9, MonsterLevel.Easy, MonsterOfTheDay.Thursday);
            AddMonster("Pidgeot", 10, 8, 18, MonsterLevel.Medium, MonsterOfTheDay.Wednesday);
            AddMonster("Rattata", 12, 6, 17, MonsterLevel.Medium, MonsterOfTheDay.Thursday);
            AddMonster("PPaticate", 21, 16, 25, MonsterLevel.Hard, MonsterOfTheDay.Thursday);

            //Friday-5
            AddMonster("Spearow", 4, 3, 7, MonsterLevel.Easy, MonsterOfTheDay.Friday);
            AddMonster("Fearow", 5, 8, 9, MonsterLevel.Easy, MonsterOfTheDay.Friday);
            AddMonster("Ekans", 12, 10, 15, MonsterLevel.Medium, MonsterOfTheDay.Friday);
            AddMonster("Arbok", 11, 10, 19, MonsterLevel.Medium, MonsterOfTheDay.Friday);
            AddMonster("Pikachu", 16, 10, 27, MonsterLevel.Hard, MonsterOfTheDay.Friday);

            //Saturday-6
            AddMonster("Raichu", 9, 7, 12, MonsterLevel.Easy, MonsterOfTheDay.Saturday);
            AddMonster("Nomad", 9, 7, 12, MonsterLevel.Easy, MonsterOfTheDay.Saturday);
            AddMonster("Bracuda", 9, 7, 12, MonsterLevel.Easy, MonsterOfTheDay.Saturday);
            AddMonster("Sandshrew", 12, 6, 13, MonsterLevel.Easy, MonsterOfTheDay.Saturday);
            AddMonster("Sandslash", 16, 10, 15, MonsterLevel.Medium, MonsterOfTheDay.Saturday);
            AddMonster("Harimaron", 22, 12, 18, MonsterLevel.Medium, MonsterOfTheDay.Saturday);
            AddMonster("Nidoran", 26, 10, 22, MonsterLevel.Hard, MonsterOfTheDay.Saturday);

            //Sunday-0
            AddMonster("Bouffalant", 8, 5, 10, MonsterLevel.Easy, MonsterOfTheDay.Sunday);
            AddMonster("Nidoqueen", 5, 5, 15, MonsterLevel.Easy, MonsterOfTheDay.Sunday);
            AddMonster("Wartortle", 4, 5, 8, MonsterLevel.Easy, MonsterOfTheDay.Sunday);
            AddMonster("Blastoise", 6, 6, 12, MonsterLevel.Medium, MonsterOfTheDay.Sunday);
            AddMonster("Nidorino", 9, 8, 14, MonsterLevel.Medium, MonsterOfTheDay.Sunday);
            AddMonster("Nidoking", 9, 10, 19, MonsterLevel.Medium, MonsterOfTheDay.Sunday);
            AddMonster("Clefairy", 18, 17, 20, MonsterLevel.Hard, MonsterOfTheDay.Sunday);
        }

        public void AddMonster(string name, int strength, int defense, int hp, MonsterLevel diffculty, MonsterOfTheDay weekday )
        {
            Monsters.Add(new Monster(name, strength, defense, hp, diffculty, weekday));
        }

        public void DisplayMonsterofToday()
        {
            var today = DateTime.Now.DayOfWeek.ToString();

            var todayMosters = (from monster in Monsters
                               where monster.Weekday.ToString() == today
                               select monster).ToList();
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"***** The Monsters of {today} *****");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,8} | {3,8} | {4,8} |", "No", "Name", "Strength", "Defense", "HP"));  
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            var i = 1;
            foreach (var monster in todayMosters)
            {
                //Console.WriteLine($"{i}. {monster.Name} - {monster.Strength} - {monster.Defense} - {monster.OriginalHP}");
                Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,8} | {3,8} | {4,8} |", i, monster.Name, monster.Strength, monster.Defense, monster.OriginalHP));
                i += 1 ;
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }
    }
}
