using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Fight
    {
        private List<Monster> Monsters { get; set; }
        private Hero Hero { get; set; }
        private Monster Enemy { get; set; }
                     

        public Fight(Hero hero, Monster enemy)
        {
            Hero = hero;
            Enemy = enemy;           
        }              

        public void Start()
        {            
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine($" '{Enemy.Name}' is {Enemy.Diffculty} Level");
                  
                       
            while (Enemy.CurrentHP > 0 && Hero.CurrentHP > 0)
            {
                Console.WriteLine($" {Hero.Name}, you got the power : Strength({Hero.Strength}), Defense({Hero.Defense}), HP({Hero.CurrentHP})");
                Console.WriteLine($" You've encountered a {Enemy.Name} monster! : Strength({Enemy.Strength}), Defense({Enemy.Defense}), HP({Enemy.CurrentHP}), What will you do?");

                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Fight");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    HeroTurn();
                }
            }
        }

        private void HeroTurn()
        {      
            var DamageCompared = Hero.Strength - Enemy.Defense;
            int heroDamage;

            //Case1. Hero Attack,  Hero Strength < Enemy Defense
            if (DamageCompared <= 0)
            {
                heroDamage = 1;
                Enemy.CurrentHP -= heroDamage;
            }
            //Hero Hero Attack, Hero Strength > Enemy Defense
            else
            {
                heroDamage = DamageCompared;
                Enemy.CurrentHP -= heroDamage;
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            //Hero attack message
            Console.WriteLine($"You attack enemy, enemy got {heroDamage} damage(s)! ");

            if (Enemy.CurrentHP <= 0)
            {
                Win();
            }
            else
            {
                MonsterTurn();
            }
        }

        private void MonsterTurn()
        {            
            var DamageCompared = Enemy.Strength - Hero.Defense;           
            int enemyDamage;

            if (DamageCompared <= 0)
            {
                enemyDamage = 1;
                Hero.CurrentHP -= enemyDamage;
            }
            //Enemy  Attack  Enemy Strength < Hero Defense
            else
            {
                enemyDamage = DamageCompared;
                Hero.CurrentHP -= enemyDamage;
            }

            Console.WriteLine($"'{Enemy.Name}' does {enemyDamage} damage(s) to Hero !");

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            if (Hero.CurrentHP <= 0)
            {
                Lose();
            }
        }

        private void Win()
        {
            
            Console.WriteLine($"{Enemy.Name} has been defeated! {Hero.Name} win(s) the battle!");

            var heroRewardGold = Calculator(Enemy.Diffculty);

            Hero.GoldCoin= Hero.GoldCoin + heroRewardGold;

            Console.WriteLine($"{Hero.Name}, Congratulations on winning the battle! you get the {heroRewardGold} Gold.");
            Console.WriteLine($"Now you have Total {Hero.GoldCoin} Gold.");

        }

        private void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
            var game = new Game();
            game.Start();
        }

        private int Calculator(MonsterLevel diffculty)
        {
            Random getRandomNumber = new Random();
            var getHeroGold = 0;

            if (diffculty.ToString() == "Easy")
            {
                getHeroGold = getRandomNumber.Next(1, 11);
                Console.WriteLine("Moster Easy" + getHeroGold);
            }
            else if (diffculty.ToString() == "Medium")
            {
                getHeroGold = getRandomNumber.Next(11, 21);
                Console.WriteLine("Moster Medium" + getHeroGold);
            }
            else if (diffculty.ToString() == "Hard")
            {
                getHeroGold = getRandomNumber.Next(12, 31);
                Console.WriteLine("Moster Hard" + getHeroGold);
            }          
            
            return getHeroGold;
           
        }
    }
}