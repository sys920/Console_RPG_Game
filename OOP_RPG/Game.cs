using System;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; }

        public Game()
        {
            Hero = new Hero();            
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Please enter your name:");

            Hero.Name =  Console.ReadLine().ToUpper();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"Hello, {Hero.Name}!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Main();
        }

        private void Main()
        {
            var input = "0";

            while (input != "6")
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
                Console.WriteLine("6. Exit");
                Console.Write("Selet the number of menu : ");
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


                //When Hero lose the game, exit
                if (Hero.CurrentHP <= 0)
                {
                    return;
                }
            }
        }

        private void Stats()
        {
            Hero.ShowStats();

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();           
        }

        private void Inventory()
        {
            Hero.ShowInventory();

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void Fight()
        {
            var monsterSelection = new MonsterSelector();
            var enemy = monsterSelection.SelectByRandomBaseOnWeekDay();
            var fight = new Fight(Hero, enemy);
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
    }
}

