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
        private AchievementManager AchievementManager { get; set; }
        
       
        public Fight(Hero hero, Monster enemy, AchievementManager achievementManager)
        {
            Hero = hero;
            Enemy = enemy;
            AchievementManager = achievementManager;
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
                //  When Hero has equipped items, Add defense and strength ability
                var EquippedWeaponStrength = 0;
                var EquippedArmorDefense = 0;
                var EquippedShieldDefense = 0;

                if ( Hero.EquippedWeapon != null)
                {
                    EquippedWeaponStrength = Hero.EquippedWeapon.Strength;
                }

                if (Hero.EquippedArmor != null)
                {
                    EquippedArmorDefense = Hero.EquippedArmor.Defense;
                }

                if (Hero.EquippedShield != null)
                {
                    EquippedShieldDefense = Hero.EquippedShield.Defense;
                }

                Console.WriteLine($"# {Hero.Name}, You got the power : Strength({Hero.Strength + EquippedWeaponStrength}), Defense({Hero.Defense + EquippedArmorDefense + EquippedShieldDefense}), HP({Hero.CurrentHP})");
                Console.WriteLine($"# You've encountered a '{Enemy.Name}' monster! : Strength({Enemy.Strength}), Defense({Enemy.Defense}), HP({Enemy.CurrentHP})");

                Console.WriteLine($"# What will you do?");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Use potion");
                Console.WriteLine("3. Run Away!");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.Write("Selet the menu : ");

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
                    //After hero runaway frome the game get out of this while Loop                       
                }               
            }

            //Check Hero currentHP to restart the game or go main menu 
            if ( Hero.CurrentHP <= 0)
            {
                Lose();
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
               DamageCompared += Hero.EquippedWeapon.Strength;
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
                DamageCompared -= Hero.EquippedArmor.Defense;              
            }

            //Calculator Damage when hero equiped shield  
            if (Hero.EquippedShield != null)
            {
                DamageCompared -= Hero.EquippedShield.Defense;
            }

            //Enemy Attack,  Enemy Strength < Hero Defense
            if (DamageCompared <= 0)
            {
                finalDamage = 1;
                Hero.CurrentHP -= finalDamage;
            }            
            else
            {//Enemy  Attack  Enemy Strength > Hero Defense
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

            AchievementManager.SavingMonsterKills(Enemy);

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
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("# You've been defeated! :(  GAME OVER !!!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
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
            else
            {
                throw new NotImplementedException("Diffculty not implement");
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
            var finalDamage = DamageCompared;

            //Whether Hero equipped armor or not
            if  (Hero.EquippedArmor != null)
            {
                DamageCompared -= Hero.EquippedArmor.Defense;
            }

            //Calculator Damage when hero equiped shield  
            if (Hero.EquippedShield != null)
            {
                DamageCompared -= Hero.EquippedShield.Defense;
            }     

            if (DamageCompared > 0 )
            {
                finalDamage = DamageCalculator(DamageCompared);
            }
            else
            {
                finalDamage = 1;
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            //When hero choose to run away, get a final damage or nothing base on random chance 
            if (Enemy.Diffculty == MonsterLevel.Easy)
            {
                //50% return true
                trueProbability = 0.5;

                if (randomNum.NextDouble() < trueProbability)
                {
                    Console.WriteLine($"You ran away from the Easy monster successfully!");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    Enemy.CurrentHP = 0;

                }
                else
                {
                    Console.WriteLine($"Sorry, you failed to run away, you got {finalDamage} damage(s)");
                    Hero.CurrentHP -= finalDamage;
                    MonsterTurn();

                } 
                
            }
            else if(Enemy.Diffculty == MonsterLevel.Medium)
            {
                //25% return true
                trueProbability = 0.25;
                if (randomNum.NextDouble() < trueProbability)
                {
                    Console.WriteLine($"You ran away from the Medium monster successfully!");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    Enemy.CurrentHP = 0;
                }
                else
                {
                    Console.WriteLine($"Sorry, you failed to run away, you got {finalDamage} damage(s)");
                    Hero.CurrentHP -= finalDamage;
                    MonsterTurn();
                }
            }
            else if (Enemy.Diffculty == MonsterLevel.Hard)
            {     
                //5% return true
                trueProbability = 0.05;
                if (randomNum.NextDouble() < trueProbability)
                {
                    Console.WriteLine($"You ran away from the Hard monster successfully!");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    Console.WriteLine("Press any key to return to main menu.");
                    Console.ReadKey();
                    Enemy.CurrentHP = 0;
                    
                }
                else
                {
                    Console.WriteLine($"Sorry, you failed to run away, you got {finalDamage} damage(s)");
                    Hero.CurrentHP -= finalDamage;
                    MonsterTurn();
                }

            }
            else
            {
                throw new NotImplementedException($"Diffculty not implement");
            }

        }        
    }
}