using System;
using System.Collections.Generic;
using System.Linq;

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

            Console.WriteLine($"# Remember, Monster '{Enemy.Name}' is {Enemy.Diffculty} Level");
                  
                       
            while (Enemy.CurrentHP > 0 && Hero.CurrentHP > 0)
            {
                Console.WriteLine($"# {Hero.Name}, You got the power : Strength({Hero.Strength}), Defense({Hero.Defense}), HP({Hero.CurrentHP})");
                Console.WriteLine($"# You've encountered a '{Enemy.Name}' monster! : Strength({Enemy.Strength}), Defense({Enemy.Defense}), HP({Enemy.CurrentHP})");

                Console.WriteLine($"# What will you do?");

                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Use potion");
                Console.WriteLine("3. Run Away!");
                Console.Write("Selet the number of menu : ");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    HeroTurn();
                }
                else if (input == "2")
                {
                    Hero.UsingPotion();
                }
                else if (input == "3")
                {
                    RunAway();
                    break;
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
                finalDamage = DamageCalculator(DamageCompared);
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
            var DamageCompared = Enemy.Strength - Hero.Defense;
            var finalDamage = DamageCompared;

            //Calculator Damage when hero equiped armor  
            if (Hero.EquippedArmor != null)
            {
                DamageCompared = Enemy.Strength - (Hero.Defense + Hero.EquippedArmor.Defense);              
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
                finalDamage = DamageCalculator(DamageCompared);
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
            Console.WriteLine($"# {Enemy.Name} has been defeated!  {Hero.Name} win(s) the battle!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            var heroRewardGold = RewardCalculator(Enemy.Diffculty);
            Hero.GoldCoin= Hero.GoldCoin + heroRewardGold;

            Console.WriteLine($"# {Hero.Name}, Congratulations on winning the battle! you get the new {heroRewardGold} Gold.");
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

            if (Enemy.Diffculty == MonsterLevel.Easy)
            {
                getHeroGold = getRandomNumber.Next(1, 11);               
            }
            else if (Enemy.Diffculty == MonsterLevel.Medium)
            {
                getHeroGold = getRandomNumber.Next(11, 21);        
            }
            else if (Enemy.Diffculty == MonsterLevel.Hard)
            {
                getHeroGold = getRandomNumber.Next(21, 31);                
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

        private void RunAway()
        {     
            Random randomNum = new Random();
            double trueProbability = 1.0;     
            
            var DamageCompared = Enemy.Strength - Hero.Defense;            

            //Whether Hero equipped armor or not
            if  (Hero.EquippedArmor != null)
            {
                DamageCompared = Enemy.Strength - (Hero.Defense + Hero.EquippedArmor.Defense);
            }

            var finalDamage = DamageCompared;
            
            if (DamageCompared > 0 )
            {
                finalDamage = DamageCalculator(DamageCompared);
            }
            else
            {
                finalDamage = -1;
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            if (Enemy.Diffculty == MonsterLevel.Easy)
            {
                //50% return true
                trueProbability = 0.5;

                if (randomNum.NextDouble() < trueProbability)
                {
                    Console.WriteLine($"You ran away from the monster successfully!");
                }
                else
                {
                    Console.WriteLine($"Sorry, you failed to run away, you got {finalDamage} damage(s)");
                    Hero.CurrentHP -= finalDamage;
                } 
                
            }
            else if(Enemy.Diffculty == MonsterLevel.Medium)
            {
                //25% return true
                trueProbability = 0.25;
                if (randomNum.NextDouble() < trueProbability)
                {
                    Console.WriteLine($"You ran away from the monster successfully!");
                }
                else
                {
                    Console.WriteLine($"Sorry, you failed to run away, you got {finalDamage} damage(s)");
                    Hero.CurrentHP -= finalDamage;
                }
            }
            else if (Enemy.Diffculty == MonsterLevel.Hard)
            {     
                //25% return true
                trueProbability = 0.05;
                if (randomNum.NextDouble() < trueProbability)
                {
                    Console.WriteLine($"You ran away from the monster successfully!");
                }
                else
                {
                    Console.WriteLine($"Sorry, you failed to run away, you got {finalDamage} damage(s)");
                    Hero.CurrentHP -= finalDamage;
                }
                
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }
        
    }
}