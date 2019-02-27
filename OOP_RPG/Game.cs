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
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Please enter your name:");

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

            while (input != "8")
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"***** Role Playing Game Menu  *****");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("1. View Hero Stats");
                Console.WriteLine("2. View Hero Inventory");
                Console.WriteLine("3. Fight Monster");
                Console.WriteLine("4. Items Shop");
                Console.WriteLine("5. Today's Monsters");
                Console.WriteLine("6. Game Quest");
                Console.WriteLine("7. Acheivement");
                Console.WriteLine("8. Exit");
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

            Console.WriteLine("----------------------------------------------------------------------------------------------");
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

                var weapons = Hero.GetWeapons();

                for (var i = 0; i < weapons.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {weapons[i].Name}");
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
                var armors = Hero.GetArmors();
                for (var i = 0; i < armors.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {armors[i].Name}");
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
                var shields = Hero.GetShield();

                for (var i = 0; i < shields.Count(); i++)
                {
                    Console.WriteLine($"{i + 1} - {shields[i].Name}");
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
            var ItemShop = new ItemShop(Hero);
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

