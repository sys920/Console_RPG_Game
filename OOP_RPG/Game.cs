using System;
using System.Linq;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; }
        private AchievementManager AchievementManager { get; set; }

        public Game()
        {
            Hero = new Hero();
            AchievementManager = new AchievementManager();
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("*******  Welcome Hero!  *******");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.Write("Please enter your name : ");

            Hero.Name = Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"Hello, {Hero.Name}!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Main();
        }

        //Display main menu
        private void Main()
        {
            var input = "0";

            while (input != "9")
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"***** Role Playing Game  V 1.0  *****");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("1. View Hero Stats");
                Console.WriteLine("2. View Hero Inventory");
                Console.WriteLine("3. Fight Monster");
                Console.WriteLine("4. Items Shop");
                Console.WriteLine("5. Today's Monsters");
                Console.WriteLine("6. Game Quest");
                Console.WriteLine("7. Acheivement");           
                Console.WriteLine("9. Exit");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.Write("# Selet the menu : ");
                input = Console.ReadLine();

                if (input == "1")
                {
                    this.Stats();
                }
                else if (input == "2")
                {
                    this.Inventory();
                }
                else if (input == "3")
                {
                    this.Fight();
                }
                else if (input == "4")
                {
                    this.BuyItem();
                }
                else if (input == "5")
                {
                    this.DisplayMonsterOfToday();
                }
                else if (input == "6")
                {
                    this.DisplayQuest();
                }
                else if (input == "7")
                {
                    this.DisplayAchivement();
                }
                else if (input == "8")
                {
                   
                }

                //When Hero lose the game, exit
                if (Hero.CurrentHP <= 0)
                {
                    return;
                }
            }
        }

        //Display Hero Stats
        private void Stats()
        {
            Hero.ShowStats();

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        //Display Hero Inventory
        private void Inventory()
        {
            Hero.ShowInventory();

            Console.WriteLine("1-Equip Weapon");
            Console.WriteLine("2-UnEquip Weapon");
            Console.WriteLine("3-Equip Armor");
            Console.WriteLine("4-UnEquip Armor");
            Console.WriteLine("5-Equip Shield");
            Console.WriteLine("6-UnEquip Shield");

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.Write("Select the menu : ");

            var KeyInput = Console.ReadLine();

            //Equip Weapon
            if (KeyInput == "1")
            {
                var unEquippedWeapons = Hero.GetWeapons().Where(p => p != Hero.EquippedWeapon).ToList();
  
                for (var i = 0; i < unEquippedWeapons.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {unEquippedWeapons[i].Name}");
                }

                Console.Write("Selet the weapon ID : ");
                var index = Hero.GetUserInputNumber() - 1;
                Hero.EquipWeapon(index);

            }

            //Unequip Weapon
            else if (KeyInput == "2")
            {
                Hero.UnEquipWeapon();
            }

            //Equip Armor
            else if (KeyInput == "3")
            {  
                var unEquippedArmors = Hero.GetArmors().Where(p => p != Hero.EquippedArmor).ToList();
                for (var i = 0; i < unEquippedArmors.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {unEquippedArmors[i].Name}");
                }
                Console.Write("Selet the armor ID : ");
                var index = Hero.GetUserInputNumber() - 1;
                Hero.EquipArmor(index);
            }

            //Unequip Armor
            else if (KeyInput == "4")
            {
                Hero.UnEquipArmor();
            }

            //Equip Shield
            else if (KeyInput == "5")
            {
                var unEquippedShield = Hero.GetShield().Where(p => p != Hero.EquippedShield).ToList();

                for (var i = 0; i < unEquippedShield.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {unEquippedShield[i].Name}");
                }

                Console.Write("Selet the shield ID : ");
                var index = Hero.GetUserInputNumber() - 1;
                Hero.EquipShield(index);
            }

            //Unequip Shield
            else if (KeyInput == "6")
            {
                Hero.UnEquipShield();
            }

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void Fight()
        {
            var monsterSelection = new MonsterSelector();
            var enemy = monsterSelection.SelectByRandomBaseOnWeekDay();
            var fight = new Fight(Hero, enemy, AchievementManager);
            fight.Start();
        }

        private void BuyItem()
        {
            var ItemShop = new Shop(Hero);
            ItemShop.Start();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void DisplayMonsterOfToday()
        {
            var MonsterSelector = new MonsterSelector();
            MonsterSelector.DisplayMonsterofToday();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void DisplayQuest()
        {           
            AchievementManager.DisplayQuest();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void DisplayAchivement()
        {
            AchievementManager.DispalyAchievement();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }                
    }
}

