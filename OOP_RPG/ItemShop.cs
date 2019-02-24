using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class ItemShop
    {
        private List<Armor> Armors { get; set; }
        private List<Weapon> Weapons { get; set; }
        private Hero Hero { get; }

        public ItemShop(Hero hero)
        {
            Armors = new List<Armor>();
            Weapons = new List<Weapon>();
            GenerateArmor();
            GenerateWeapen();
            Hero = hero;
        }

        private void GenerateArmor()
        {
            Armors.Add(new Armor("Leather", 4, 8));
            Armors.Add(new Armor("Breastplate", 8, 18));
            Armors.Add(new Armor("Augmented Chain", 12, 25));
            Armors.Add(new Armor("Breastplate", 15, 23));
        }

        private void GenerateWeapen()
        {
            Weapons.Add(new Weapon("Recurve bow", 3, 10));
            Weapons.Add(new Weapon("BigAxe", 6, 20));
            Weapons.Add(new Weapon("XV sword", 15, 40));
            Weapons.Add(new Weapon("Arming sword", 15, 40));
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("*****  ITEM SHOP ******");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            
            //Display weapon list
            Console.WriteLine("# Weapon");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,7} | {3,7} |", "ID", "Name", "Strenth", "Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            var weaponNumber = 1;
            foreach (var weapon in Weapons)
            {
                Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,7} | {3,7} |", weaponNumber, weapon.Name, weapon.Strength, weapon.Price));
                weaponNumber = weaponNumber + 1;

            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            
            //Display weapon list
            Console.WriteLine("# Armors");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,7} | {3,7} |", "ID", "Name", "Defense", "Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            var armorNumber = 1;
            foreach (var armor in Armors)
            {                
                Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,7} | {3,7} |", armorNumber, armor.Name, armor.Defense, armor.Price));
                armorNumber = armorNumber + 1;
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"# You have {Hero.GoldCoin} Gold now! Buy Armor or Weapon");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
       
            Console.WriteLine("1-Buy Weapon");
            Console.WriteLine("2-Buy Armors");
            Console.WriteLine("AnyKey - Main menu");

            Console.Write("Selet the number of menu : ");

            var KeyInput = Console.ReadLine();
            
            if (KeyInput == "1")
            {               
                BuyWeapon();
            }
            else if (KeyInput == "2")
            {
                BuyArmor();
            }               
        }              

        public void BuyWeapon()
        {
            Console.WriteLine("Type the Weapon ID you want to buy :");

            var KeyInput = Hero.GetUserInputNumber();
            var Shopweapon = Weapons.ElementAtOrDefault(0);

            if (KeyInput > Weapons.Count() || KeyInput <= 0)
            {
                Console.WriteLine("Type corrent the Weapon ID !");
                Shopweapon = null;
            }
            else
            {
                Shopweapon = Weapons.ElementAtOrDefault(KeyInput - 1);
            }
   

            if (Shopweapon != null)
            {
                if ((Hero.GoldCoin - Shopweapon.Price) >= 0)
                {
                    //Check  Hero's ArmorsBag whether he has this armor
        
                    var heroArmorBagCheckQuery = (from heroWeapon in Hero.WeaponsBag
                                                  where heroWeapon.Name == Shopweapon.Name
                                                  select heroWeapon).ToList();
                    if (heroArmorBagCheckQuery.Any())
                    {
                        Console.WriteLine("Sorry, You have this weapon already!");
                    }
                    else
                    {   //Hero buy armor and put Hero's ArmorsBag
                        Hero.WeaponsBag.Add(Shopweapon);
                        Hero.GoldCoin = Hero.GoldCoin - Shopweapon.Price;
                        Console.WriteLine("Buying is Completed!");
                    }
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
        }

        public void BuyArmor()
        {
            Console.WriteLine("Type the Armor ID you want to buy :");
            var KeyInput = Hero.GetUserInputNumber();

            var ShopArmor = Armors.ElementAtOrDefault(0);

            if (KeyInput > Armors.Count() || KeyInput <= 0)
            {
                Console.WriteLine("Type corrent the Armor ID !");
                ShopArmor = null;
            }
            else
            {
                ShopArmor = Armors.ElementAtOrDefault(KeyInput - 1);
            }

            if (ShopArmor != null)
            {
                if ((Hero.GoldCoin - ShopArmor.Price) >= 0)
                {
                    //Check  Hero's ArmorsBag whether he has this armor
                    var heroArmorBagCheckQuery = (from heroArmor in Hero.ArmorsBag
                                                  where heroArmor.Name == ShopArmor.Name
                                                  select heroArmor).ToList();
                    if (heroArmorBagCheckQuery.Any())
                    {
                        Console.WriteLine("Sorry, You have this armor already!");
                    }
                    else
                    {   //Hero buy armor and put Hero's ArmorsBag
                        Hero.ArmorsBag.Add(ShopArmor);
                        Hero.GoldCoin = Hero.GoldCoin - ShopArmor.Price;
                        Console.WriteLine("Buying is Completed!");
                    }
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
        }
    }  
}
