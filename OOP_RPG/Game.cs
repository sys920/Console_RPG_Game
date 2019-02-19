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
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");

            Hero.Name = Console.ReadLine();

            Console.WriteLine("Hello " + Hero.Name);

            Main();
        }

        private void Main()
        {
            var input = "0";

            while (input != "4")
            {
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. View Stats");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Fight Monster");
                Console.WriteLine("4. Exit");

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
            var fight = new Fight(Hero);

            fight.Start();
        }
    }
}