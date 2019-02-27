using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class ItemShop
    {
        private List<InterfaceOfItemShop> Items { get; set; }
        private List<Potion> Potions { get; set; }

        private Hero Hero { get; set; }

        public ItemShop(Hero hero)
        {
            Items = new List<InterfaceOfItemShop>();
            Potions = new List<Potion>();
            GenerateItems();
            Hero = hero;
        }

        private void GenerateItems()
        {
            Items.Add(new Armor("Leather", 4, 8));
            Items.Add(new Armor("BreastPlate", 8, 18));
            Items.Add(new Armor("Augmented Chain", 15, 25));
            Items.Add(new Armor("CorosPlate", 20, 40));

            Items.Add(new Weapon("Recurve bow", 3, 10));
            Items.Add(new Weapon("BigAxe", 6, 20));
            Items.Add(new Weapon("XV sword", 15, 30));
            Items.Add(new Weapon("Arming sword", 25, 50));   

            Items.Add(new Shield("Wooden Shield", 3, 10));
            Items.Add(new Shield("Battle Shield", 4, 12));
            Items.Add(new Shield("Dragon Shield", 7, 15));

            Potions.Add(new Potion("Health Potion", 5, 7));
            Potions.Add(new Potion("Strong Health Potion", 10, 18));
            Potions.Add(new Potion("Great Health Potion", 15, 27));
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("*****  ITEM SHOP ******");
            Console.WriteLine("----------------------------------------------------------------------------------------------");            
            Console.WriteLine("1-Buy Item");
            Console.WriteLine("2-Buy Potion");
            Console.WriteLine("3-Sell Item");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.Write("# Select the Menu : ");

            var KeyInput = Console.ReadLine();

            if (KeyInput == "1")
            {
                BuyItem();
            }
            else if (KeyInput == "2")
            {
                BuyPotion();
            }
            else if (KeyInput == "3")
            {
                SellItem();
            }            
        }              

        public void BuyItem()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("# Buy Item");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,15} | {3,7} |", "ID", "Name", "Feature", "Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");
   
            for (var i = 0; i < Items.Count(); i++)
            {
                Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,15} | {3,7} |", (i + 1), Items[i].Name, Items[i].GetDescription(),Items[i].Price));
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.Write("# Select Item ID to buy : ");

            var KeyInputNumber = Hero.GetUserInputNumber();
            var itemIndex = KeyInputNumber - 1;
            var item = Items.ElementAtOrDefault(itemIndex);

            if (KeyInputNumber > Items.Count() || KeyInputNumber <= 0)
            {
                Console.WriteLine("# Select corrent the Item ID : ");                
            }
            else
            {
                item = Items.ElementAtOrDefault(itemIndex);
            }

            if (item != null)
            {
                // Check Hero gold balance
                if (Hero.GoldCoin >= item.Price)
                {
                    //Check in the hero bag the item in he bought already.
                    var heroBagDuplicateQuery = (from heroItem in Hero.HeroBag
                                                 where heroItem.Name == item.Name
                                                  select heroItem).ToList();
                    if (heroBagDuplicateQuery.Any())
                    {
                        Console.WriteLine("Sorry, You got this weapon already!");
                    }
                    else
                    {
                        //pay for items amd add it to Herobag
                        Hero.GoldCoin -= item.Price;
                        Hero.HeroBag.Add(item);
                        Console.WriteLine($"Buying '{item.Name}' is completed!");
                    }                        
                }
                else
                {
                    Console.WriteLine("You don't have enough gold coins.");
                }
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }

        public void BuyPotion()
        {
            //Display weapon list
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("# Potions");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-25} | {2,7} | {3,7} |", "ID", "Name", "Healing", "Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            var potionNumber = 1;
            foreach (var potion in Potions)
            {
                Console.WriteLine(String.Format("{0,3} | {1,-25} | {2,7} | {3,7} |", potionNumber, potion.Name, potion.HealthRestored, potion.Price));
                potionNumber = potionNumber + 1;
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.Write("# Select the Potion ID you want to buy :");
            var KeyInput = Hero.GetUserInputNumber();

            var shopPotion = Potions.ElementAtOrDefault(0);

            if (KeyInput > Potions.Count() || KeyInput <= 0)
            {
                Console.WriteLine("# Select the corrent Potion ID !");
                shopPotion = null;
            }
            else
            {
                shopPotion = Potions.ElementAtOrDefault(KeyInput - 1);
            }

            if (shopPotion != null)
            {
                if ((Hero.GoldCoin - shopPotion.Price) >= 0)
                {

                    Hero.PotionsBag.Add(shopPotion);
                    Hero.GoldCoin = Hero.GoldCoin - shopPotion.Price;
                    Console.WriteLine($"Buying '{shopPotion.Name}' is Completed!");

                }
                else
                {
                    Console.WriteLine("Sorry, you don't have enough Gold !");
                }
            }
            else
            {
                Console.WriteLine("Sorry,No result!");
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }

        public void SellItem()
        {   
            //Selling discount rate (%)
            var DiscountRate = 0.5;
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("# Sell Item");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,15} | {3,7} |", "ID", "Name", "Feature", "Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            if (Hero.HeroBag.Count() != 0)
            {
                for (var i = 0; i < Hero.HeroBag.Count(); i++)
                {
                    Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,15} | {3,7} |", (i + 1), Hero.HeroBag[i].Name, Hero.HeroBag[i].GetDescription(), Hero.HeroBag[i].Price));
                }
            }
            else
            {
                Console.WriteLine("You don't have any item");
            }
            
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"Selling price is {DiscountRate*100}% off of origin price ");
            Console.Write("# Select the Item ID to sell : ");
            var KeyInputNumber = Hero.GetUserInputNumber();


            if (KeyInputNumber > Hero.HeroBag.Count() || KeyInputNumber <= 0)
            {
                Console.WriteLine("# Select the corrent Item ID : ");
            }
            else
            {                
                var itemIndex = KeyInputNumber - 1;
                var item = Hero.HeroBag.ElementAtOrDefault(itemIndex);
                //The claculate sell price of item
                Hero.GoldCoin = Hero.GoldCoin + (Convert.ToInt32(Hero.HeroBag[itemIndex].Price * 0.5));

                if (Hero.EquippedWeapon != null)
                {
                    if (Hero.EquippedWeapon.Name == Hero.HeroBag[itemIndex].Name)
                    {
                        Hero.EquippedWeapon = null;
                    }
                }

                if (Hero.EquippedArmor != null)
                {
                    if (Hero.EquippedArmor.Name == Hero.HeroBag[itemIndex].Name)
                    {
                        Hero.EquippedArmor = null;
                    }
                }                
                Console.WriteLine($"'{Hero.HeroBag[itemIndex].Name}' was sold, youn earned {Convert.ToInt32(Hero.HeroBag[itemIndex].Price * DiscountRate)} gold ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Hero.HeroBag.Remove(Hero.HeroBag[itemIndex]);              
                
            }
        }        
    }
}
