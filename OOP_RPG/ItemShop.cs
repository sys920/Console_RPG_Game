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
            Armors.Add(new Armor("11", "Wooden Armor", 10, 8));
            Armors.Add(new Armor("12", "Metal2 Armor", 12, 14));
            Armors.Add(new Armor("13", "Golden Armor", 15, 18));
        }

        private void GenerateWeapen()
        {
            Weapons.Add(new Weapon("21", "Sword2 weapon", 3, 10));
            Weapons.Add(new Weapon("22", "BigAxe weapon", 4, 12));
            Weapons.Add(new Weapon("23", "Xsword weapon", 7, 15));
        }

        public void Start()
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("                                     Item Shop                                                ");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

         
            Console.WriteLine("Armors");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("ID   Name         Feature      price");
            foreach (var armor in Armors)
            {
                Console.WriteLine($"{armor.Id}. {armor.Name} - Defense:{armor.Defense} - {armor.Price} Gold");
               
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Weapon");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("ID   Name         Feature      price");
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"{weapon.Id}. {weapon.Name} - Strength{weapon.Strength} - {weapon.Price} Gold");
               
            }
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"You have {Hero.GoldCoin} Gold now! Buy Armor or Weapon");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("1-Buy Armors");
            Console.WriteLine("2-Buy Weapon");
            Console.WriteLine("AnyKey - Main menu");

            Console.WriteLine("Type the menu");

            var KeyInput = Console.ReadLine();
            
            if (KeyInput == "1")
            {
                BuyArmor();
            }
            else if (KeyInput == "2")
            {
                BuyWeapon();
            }
               
        }

        public void BuyArmor()
        {
            Console.WriteLine("Type the Armor ID you want to buy :");
            var keyInput = Console.ReadLine();
            var armorPrice = 0;
            var armorId = string.Empty;
            var shopQuery = (from armor in Armors
                               where armor.Id == keyInput
                               select armor).ToList();
            if (shopQuery.Any())
            {                
                foreach (var ele in shopQuery)
                {
                    Console.WriteLine($"{ele.Name} - {ele.Price}");
                    armorPrice = ele.Price;
                    armorId = ele.Id;
                }
            
                if ((Hero.GoldCoin - armorPrice) >= 0 )
                {
                    //Check  Hero's ArmorsBag whether he has this armor
                    var heroArmorBagQuery = (from armor in Hero.ArmorsBag
                                             where armor.Id == keyInput
                                             select armor).ToList();
                    if (heroArmorBagQuery.Any())
                    {
                        Console.WriteLine("Already You have this armor");
                    }
                    else
                    {   //Hero buy armor and put Hero's ArmorsBag
                        Hero.ArmorsBag.Add(shopQuery[0]);
                        Hero.GoldCoin = Hero.GoldCoin - armorPrice;
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

        public void BuyWeapon()
        {
            Console.WriteLine("Type the Weapon ID you want to buy :");
            var keyInput = Console.ReadLine();
            var weaponPrice = 0;
            var weaponId = string.Empty;
            var shopQuery = (from weapon in Weapons
                             where weapon.Id == keyInput
                             select weapon).ToList();
            if (shopQuery.Any())
            {
                foreach (var ele in shopQuery)
                {
                    Console.WriteLine($"{ele.Name} - {ele.Price}");
                    weaponPrice = ele.Price;
                    weaponId = ele.Id;
                }

                if ((Hero.GoldCoin - weaponPrice) >= 0)
                {
                    //Check  Hero's ArmorsBag whether he has this armor
                    var heroWeaponBagQuery = (from weapon in Hero.WeaponsBag
                                             where weapon.Id == keyInput
                                             select weapon).ToList();
                    if (heroWeaponBagQuery.Any())
                    {
                        Console.WriteLine("Already You have this weapon");
                    }
                    else
                    {   //Hero buy armor and put Hero's ArmorsBag
                        Hero.WeaponsBag.Add(shopQuery[0]);
                        Hero.GoldCoin = Hero.GoldCoin - weaponPrice;
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
