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
        private List<Potion> Potions { get; set; }
        private Hero Hero { get; }

        public ItemShop(Hero hero)
        {
            Armors = new List<Armor>();
            Weapons = new List<Weapon>();
            Potions = new List<Potion>();
            GenerateItems();
            Hero = hero;
        }

        private void GenerateItems()
        {
            Armors.Add(new Armor("Leather", 4, 8));
            Armors.Add(new Armor("BreastPlate", 8, 18));
            Armors.Add(new Armor("Augmented Chain", 15, 25));
            Armors.Add(new Armor("CorosPlate", 20, 40));

            Weapons.Add(new Weapon("Recurve bow", 3, 10));
            Weapons.Add(new Weapon("BigAxe", 6, 20));
            Weapons.Add(new Weapon("XV sword", 15, 30));
            Weapons.Add(new Weapon("Arming sword", 25, 50));

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

            Console.WriteLine("# What would you buy ?");
            Console.WriteLine("1-Buy Weapon");
            Console.WriteLine("2-Buy Armor");
            Console.WriteLine("3-Buy Potion");
            Console.WriteLine("4-Sell Wapon");
            Console.WriteLine("5-Sell Armor");
            Console.WriteLine("AnyKey - Main menu");

            var KeyInput = Console.ReadLine();

            if (KeyInput == "1")
            {
                BuyWeapon();
            }
            else if (KeyInput == "2")
            {
                BuyArmor();
            }
            else if (KeyInput == "3")
            {
                BuyPotion();
            }
            else if (KeyInput == "4")
            {
                SellWeapon();
            }
            else if (KeyInput == "5")
            {
                SellArmor();
            }
        }              

        public void BuyWeapon()
        {
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
            Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Type the Weapon ID you want to buy :");

            var KeyInput = Hero.GetUserInputNumber();
            var shopWeapon = Weapons.ElementAtOrDefault(0);

            if (KeyInput > Weapons.Count() || KeyInput <= 0)
            {
                Console.WriteLine("Type corrent the Weapon ID !");
                shopWeapon = null;
            }
            else
            {
                shopWeapon = Weapons.ElementAtOrDefault(KeyInput - 1);
            }
   

            if (shopWeapon != null)
            {
                if ((Hero.GoldCoin - shopWeapon.Price) >= 0)
                {
                    //Check  Hero's ArmorsBag whether he has this armor
        
                    var heroArmorBagCheckQuery = (from heroWeapon in Hero.WeaponsBag
                                                  where heroWeapon.Name == shopWeapon.Name && heroWeapon.Price == shopWeapon.Price
                                                  select heroWeapon).ToList();
                    if (heroArmorBagCheckQuery.Any())
                    {
                        Console.WriteLine("Sorry, You have this weapon already!");
                    }
                    else
                    {   //Hero buy armor and put Hero's ArmorsBag
                        Hero.WeaponsBag.Add(shopWeapon);
                        Hero.GoldCoin = Hero.GoldCoin - shopWeapon.Price;
                        Console.WriteLine($"Buying '{shopWeapon.Name}' is Completed!");
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
            Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("Type the Armor ID you want to buy :");
            var KeyInput = Hero.GetUserInputNumber();

            var shopArmor = Armors.ElementAtOrDefault(0);

            if (KeyInput > Armors.Count() || KeyInput <= 0)
            {
                Console.WriteLine("Type corrent the Armor ID !");
                shopArmor = null;
            }
            else
            {
                shopArmor = Armors.ElementAtOrDefault(KeyInput - 1);
            }

            if (shopArmor != null)
            {
                if ((Hero.GoldCoin - shopArmor.Price) >= 0)
                {
                    //Check  Hero's ArmorsBag whether he has this armor
                    var heroArmorBagCheckQuery = (from heroArmor in Hero.ArmorsBag
                                                  where heroArmor.Name == shopArmor.Name && heroArmor.Price == shopArmor.Price
                                                  select heroArmor).ToList();
                    if (heroArmorBagCheckQuery.Any())
                    {
                        Console.WriteLine("Sorry, You have this armor already!");
                    }
                    else
                    {   //Hero buy armor and put Hero's ArmorsBag
                        Hero.ArmorsBag.Add(shopArmor);
                        Hero.GoldCoin = Hero.GoldCoin - shopArmor.Price;
                        Console.WriteLine($"Buying '{shopArmor.Name}' is Completed!");
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

        public void BuyPotion()
        {
            //Display weapon list
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
            Console.WriteLine("Type the Potion ID you want to buy :");
            var KeyInput = Hero.GetUserInputNumber();

            var shopPotion = Potions.ElementAtOrDefault(0);

            if (KeyInput > Potions.Count() || KeyInput <= 0)
            {
                Console.WriteLine("Type corrent the Potion ID !");
                shopPotion = null;
            }
            else
            {
                shopPotion = Potions.ElementAtOrDefault(KeyInput - 1);
            }

            if (shopPotion != null)
            {
                if ((Hero.GoldCoin - shopPotion.Price) >= 0)                {
                    
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
        }

        public void SellWeapon()
        {
            var weaponSaleDiscount = 0.5;
            Console.WriteLine("# Sell Weapon");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,10} | {3,10} |", "ID", "Name", "Strenth", "Sell Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            if (Hero.WeaponsBag.Count() != 0 )
            {
                for (var i = 0; i < Hero.WeaponsBag.Count(); i++)
                {
                    Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,10} | {3,10} |", i + 1, Hero.WeaponsBag[i].Name, Hero.WeaponsBag[i].Strength, Convert.ToInt32(Hero.WeaponsBag[i].Price * weaponSaleDiscount)));

                }
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("Type the Weapon ID you want to Sell in the bag :");

                var KeyInput = Hero.GetUserInputNumber();


                if (KeyInput > Weapons.Count() || KeyInput <= 0)
                {
                    Console.WriteLine("Type corrent the Weapon ID !");

                }
                else
                {
                    Hero.GoldCoin = Hero.GoldCoin + (Convert.ToInt32(Hero.WeaponsBag[KeyInput - 1].Price * weaponSaleDiscount));

                    if (Hero.EquippedWeapon != null)
                    {
                        if (Hero.WeaponsBag[KeyInput - 1].Name == Hero.EquippedWeapon.Name)
                        {
                            Hero.EquippedWeapon = null;
                        }
                    }
                        
                    Hero.WeaponsBag.Remove(Hero.WeaponsBag[KeyInput - 1]);
                }
               
            } 
            else
            {
                Console.WriteLine("Nothing to sell");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }                 
        }

        public void SellArmor()
        {
            var armorSaleDiscount = 0.5;

            Console.WriteLine("# Sell Armors");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,10} | {3,10} |", "ID", "Name", "Defense", "Sell Price"));
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            if (Hero.ArmorsBag.Count() != 0)
            {
                for (var i = 0; i < Hero.ArmorsBag.Count(); i++)
                {
                    Console.WriteLine(String.Format("{0,3} | {1,-15} | {2,10} | {3,10} |", i + 1, Hero.ArmorsBag[i].Name, Hero.ArmorsBag[i].Defense, Convert.ToInt32(Hero.ArmorsBag[i].Price * armorSaleDiscount)));
                }

                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine($"# You have {Hero.GoldCoin} Gold now!");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("Type the Armor ID you want to Sell :");

                var KeyInput = Hero.GetUserInputNumber();

                if (KeyInput > Weapons.Count() || KeyInput <= 0)
                {
                    Console.WriteLine("Type corrent the Armor ID !");

                }
                else
                {
                    Hero.GoldCoin = Hero.GoldCoin + (Convert.ToInt32(Hero.ArmorsBag[KeyInput - 1].Price * armorSaleDiscount));

                    if (Hero.EquippedArmor != null)
                    {
                        if (Hero.ArmorsBag[KeyInput - 1].Name == Hero.EquippedArmor.Name)
                        {
                            Hero.EquippedArmor = null;
                        }
                    }
                        
                    Hero.ArmorsBag.Remove(Hero.ArmorsBag[KeyInput - 1]);
                }
            } 
            else
            {
                Console.WriteLine("Nothing to sell in the bag");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
        }
    }  
}
