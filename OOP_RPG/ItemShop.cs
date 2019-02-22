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
            GenerateArmor();
            Weapons = new List<Weapon>();
            GenerateWeapen();
            Hero = hero;
        }

        private void GenerateArmor()
        {
            Armors.Add(new Armor("Wooden Armor", 10, 8));
            Armors.Add(new Armor("Metal2 Armor", 12, 14));
            Armors.Add(new Armor("Golden Armor", 15, 18));
        }

        private void GenerateWeapen()
        {
            Weapons.Add(new Weapon("Sword2 weapon", 3, 10));
            Weapons.Add(new Weapon("BigAxe weapon", 4, 12));
            Weapons.Add(new Weapon("Xsword weapon", 7, 15));
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
            Console.WriteLine("ID   Name         Feature      price");
            var weaponNumber = 1;
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"{weaponNumber}. {weapon.Name} - Strength{weapon.Strength} - {weapon.Price} Gold");
                weaponNumber = weaponNumber + 1;

            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");
            
            //Display weapon list
            Console.WriteLine("# Armors");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("ID   Name         Feature      price");
            var armorNumber = 1;
            foreach (var armor in Armors)
            {
                Console.WriteLine($"{armorNumber}. {armor.Name} - Defense:{armor.Defense} - {armor.Price} Gold");
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
