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
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"***** HERO VS ENEMY *****");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine($"# Remember monster '{Enemy.Name}' is {Enemy.Diffculty} Level");
                  
                       
            while (Enemy.CurrentHP > 0 && Hero.CurrentHP > 0)
            {
                Console.WriteLine($"# {Hero.Name}, you got the power : Strength({Hero.Strength}), Defense({Hero.Defense}), HP({Hero.CurrentHP})");
                Console.WriteLine($"# You've encountered a '{Enemy.Name}' monster! : Strength({Enemy.Strength}), Defense({Enemy.Defense}), HP({Enemy.CurrentHP})");

                Console.WriteLine($"# What will you do?");

                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Fight");
                Console.Write("Selet the number of menu : ");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    HeroTurn();
                }
            }
        }

        private void HeroTurn()
        { 
            //Calculator Damage 
            var DamageCompared = Hero.Strength - Enemy.Defense;
            var finalDamage = DamageCompared;

            //Calculator Damage when hero equiped Weapon  
            if (Hero.EquippedWeapon != null)
            {
                DamageCompared = (Hero.Strength + Hero.EquippedWeapon.Strength) - Enemy.Defense;
                finalDamage = DamageCalculator(DamageCompared);
            }    
                     
            //Hero Attack,  Hero Strength < Enemy Defense
            if (DamageCompared <= 0)
            {
                finalDamage = 1;
                Enemy.CurrentHP -= finalDamage;
            }
            //Hero Hero Attack, Hero Strength > Enemy Defense
            else
            {
                Enemy.CurrentHP -= finalDamage;
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            //Hero attack message
            Console.WriteLine($"# You attack enemy, enemy got {finalDamage} damage(s)! ");

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
            //Calculator Damage 
            var DamageCompared = Enemy.Strength - Hero.Defense ;
            var finalDamage = DamageCompared;

            //Calculator Damage when hero equiped armor  
            if (Hero.EquippedArmor != null)
            {
                DamageCompared = Enemy.Strength - (Hero.Defense + Hero.EquippedArmor.Defense);
                finalDamage = DamageCalculator(DamageCompared);
            }
            //Enemy Attack,  Enemy Strength < Hero Defense
            if (DamageCompared <= 0)
            {
                finalDamage = 1;
                Hero.CurrentHP -= finalDamage;
            }
            //Enemy  Attack  Enemy Strength > Hero Defense
            else
            {
                Hero.CurrentHP -= finalDamage;
            }

            Console.WriteLine($"# '{Enemy.Name}' does {finalDamage} damage(s) to Hero !");

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            if (Hero.CurrentHP <= 0)
            {
                Lose();
            }
        }

        private void Win()
        {
            
            Console.WriteLine($"# {Enemy.Name} has been defeated! {Hero.Name} win(s) the battle!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            var heroRewardGold = RewardCalculator(Enemy.Diffculty);

            Hero.GoldCoin= Hero.GoldCoin + heroRewardGold;

            Console.WriteLine($"# {Hero.Name}, Congratulations on winning the battle! you get the {heroRewardGold} Gold.");
            Console.WriteLine($"# Now, you have total {Hero.GoldCoin} Gold.");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void Lose()
        {
            Console.WriteLine("# You've been defeated! :(  GAME OVER!!!");
            Console.WriteLine("Press any key to restart the game");
            Console.ReadKey();
            var game = new Game();
            game.Start();
        }

        private int RewardCalculator(MonsterLevel diffculty)
        {
            Random getRandomNumber = new Random();
            var getHeroGold = 0;

            if (diffculty.ToString() == "Easy")
            {
                getHeroGold = getRandomNumber.Next(1, 11);               
            }
            else if (diffculty.ToString() == "Medium")
            {
                getHeroGold = getRandomNumber.Next(11, 21);        
            }
            else if (diffculty.ToString() == "Hard")
            {
                getHeroGold = getRandomNumber.Next(12, 31);                
            }          
            
            return getHeroGold;
           
        }

        private int DamageCalculator(int DamageCompared)
        {
            var baseDamage = DamageCompared;
            var MaximumDamage = Convert.ToInt32(baseDamage * 1.5);
            var MinimumDamage = Convert.ToInt32(baseDamage * 0.5);

            Random getRandomNumber = new Random();            
            var finalDamage = getRandomNumber.Next(MinimumDamage, MaximumDamage + 1);
            
            return finalDamage;
        }
    }
}