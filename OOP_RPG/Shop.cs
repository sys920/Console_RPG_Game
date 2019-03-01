using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class Shop
    {
        private List<IShop> ShopItems { get; set; }
        private List<Potion> Potions { get; set; }
        private Hero Hero { get; set; }

        public Shop(Hero hero)
        {
            //Items in the shop 
            ShopItems = new List<IShop>();
            Potions = new List<Potion>();
            GenerateItems();
            Hero = hero;
        }

        private void GenerateItems()
        {
            //ArmorName, Defense, Price
            ShopItems.Add(new Armor("Leather", 4, 8));
            ShopItems.Add(new Armor("BreastPlate", 8, 20));
            ShopItems.Add(new Armor("Augmented Chain", 15, 45));
            ShopItems.Add(new Armor("CorosPlate", 25, 60));

            //WeaponName, Strength, Price
            ShopItems.Add(new Weapon("Recurve bow", 3, 9));
            ShopItems.Add(new Weapon("BigAxe", 6, 22));
            ShopItems.Add(new Weapon("XV sword", 19, 49));
            ShopItems.Add(new Weapon("Arming sword", 29, 65));

            //ShieldName, Defense, Price
            ShopItems.Add(new Shield("Wooden Shield", 3, 10));
            ShopItems.Add(new Shield("Battle Shield", 8, 26));
            ShopItems.Add(new Shield("Dragon Shield", 15, 40));

            //PotionName,HealthRestore, Price
            Potions.Add(new Potion("Health Potion", 4, 5));
            Potions.Add(new Potion("Strong Health Potion", 7, 7));
            Potions.Add(new Potion("Great Health Potion", 14, 10));
            Potions.Add(new Potion("Gold Health Potion", 19, 13));
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
            Console.WriteLine("# Buy Item ");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,-7} | {3,-15} | {4,-7} |", "ID", "Name", "Class", "Feature", "Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");
   
            for (var i = 0; i < ShopItems.Count(); i++)
            {
                Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,-7} | {3,-15} | {4,-7} |", (i + 1), ShopItems[i].Name, ShopItems[i].GetClass(), ShopItems[i].GetDescription(), ShopItems[i].Price + " Gold"));
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.Write("# Select Item ID to buy : ");

            var KeyInputNumber = Hero.GetUserInputNumber();
            var itemIndex = KeyInputNumber - 1;
            var item = ShopItems.ElementAtOrDefault(itemIndex);

            if (KeyInputNumber > ShopItems.Count() || KeyInputNumber <= 0)
            {
                Console.WriteLine("# Select corrent the Item ID : ");                
            }
            else
            {
                item = ShopItems.ElementAtOrDefault(itemIndex);
            }

            if (item != null)
            {
                //Check Hero gold balance
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
            Console.WriteLine(String.Format("{0,3} | {1,-25} | {2,-7} | {3,-7} |", "ID", "Name", "Healing", "Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            for(var i = 0; i < Potions.Count(); i++)
            {
                Console.WriteLine(String.Format("{0,3} | {1,-25} | {2,-7} | {3,-7} |", i+1, Potions[i].Name, Potions[i].HealthRestored + " HP", Potions[i].Price + " Gold"));
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.Write("# Select the Potion ID you want to buy : ");
            var KeyInput = Hero.GetUserInputNumber();

            var shopPotion = Potions.ElementAtOrDefault(0);

            if (KeyInput > Potions.Count() || KeyInput <= 0)
            {
                Console.WriteLine("# Select the corrent Potion ID : ");
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
            var discountRate = 0.5;

            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("# Sell Item");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,-7} | {3,-15} | {4,-7} |", "ID", "Name", "Class", "Feature", "Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            var unEquippedHeroBag = Hero.HeroBag.Where(p => p != Hero.EquippedArmor && p != Hero.EquippedWeapon && p != Hero.EquippedShield).ToList();

            if (unEquippedHeroBag.Count() != 0)
            {

                for (var i = 0; i < unEquippedHeroBag.Count(); i++)
                {
                    Console.WriteLine(String.Format("{0,3} | {1,-20} | {2,-7} | {3,-15} | {4,-7} |", (i + 1), unEquippedHeroBag[i].Name, unEquippedHeroBag[i].GetClass(), unEquippedHeroBag[i].GetDescription(), unEquippedHeroBag[i].Price + " Gold"));
                }
            }
            else
            {
                Console.WriteLine("You don't have any item");
            }
            
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"Selling price is {discountRate * 100}% off of origin price ");
            Console.Write("# Select the Item ID to sell : ");
            var KeyInputNumber = Hero.GetUserInputNumber();


            if (KeyInputNumber > unEquippedHeroBag.Count() || KeyInputNumber <= 0)
            {
                Console.WriteLine("# Select the corrent Item ID : ");
            }
            else
            {                
                var itemIndex = KeyInputNumber - 1;
                var item = unEquippedHeroBag.ElementAtOrDefault(itemIndex);
                //The claculate sell price of item
                Hero.GoldCoin = Hero.GoldCoin + (Convert.ToInt32(unEquippedHeroBag[itemIndex].Price * 0.5));

                Console.WriteLine($"'{unEquippedHeroBag[itemIndex].Name}' was sold, youn earned {Convert.ToInt32(unEquippedHeroBag[itemIndex].Price * discountRate)} gold ");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Hero.HeroBag.Remove(unEquippedHeroBag[itemIndex]);          
            }
        }        
    }
}
