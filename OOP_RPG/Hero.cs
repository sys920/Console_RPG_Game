using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; }
        public int Defense { get; }
        public int OriginalHP { get; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public List<Armor> ArmorsBag { get; set; }
        public List<Weapon> WeaponsBag { get; set; }
        public List<Potion> PotionsBag { get; set; }
        public int GoldCoin { get; set; }

        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero()
        {
            ArmorsBag = new List<Armor>();
            WeaponsBag = new List<Weapon>();
            PotionsBag = new List<Potion>();
            Strength = 2;
            Defense = 3;
            OriginalHP = 30;
            CurrentHP = 30;
            GoldCoin = 100;
        }

        //These are the Methods of our Class.
        public void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"***** HERO { this.Name}'s STATS *****");
            Console.WriteLine("----------------------------------------------------------------------------------------------");

            Console.WriteLine($"# Strength: {this.Strength} {(this.EquippedWeapon == null ? "" : "(+" + this.EquippedWeapon.Strength + ")")}");

            

            Console.WriteLine($"# Defense: {this.Defense} {(this.EquippedArmor == null ? "" : "(+" + this.EquippedArmor.Defense +")")}");

            
            Console.WriteLine("# Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);

            Console.WriteLine("# Potion(s): ");

            DisplayPotion();

            Console.WriteLine("# Gold coins: " + this.GoldCoin);
            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine($"*****  HERO { this.Name}'s INVENTORY ******");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("# Weapon Bag:");

            if(this.WeaponsBag.Count() != 0)
            {
                var weaponNumber = 1;
                foreach (var weapon in this.WeaponsBag)
                {
                    Console.WriteLine($"{weaponNumber}. {weapon.Name} : {weapon.Strength} Strength");
                    weaponNumber += 1;
                }
            }
            else
            {
                Console.WriteLine(" [ No Weapon in this bag ] ");
            }

            
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("# Armor Bag:");
            if(this.ArmorsBag.Count() != 0 )
            {
                var armorNumber = 1;
                foreach (var armor in this.ArmorsBag)
                {
                    Console.WriteLine($"{armorNumber}. {armor.Name} : {armor.Defense} Defense");
                    armorNumber += 1;
                }
            }
            else
            {
                Console.WriteLine(" [ No Armor in this bag ] ");
            }
            
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("# Current Equipped Item(s):");
            if(EquippedWeapon != null || EquippedArmor != null)
            {
                if (EquippedWeapon != null)
                {
                    Console.WriteLine($" [ Weapon] {EquippedWeapon.Name} - {EquippedWeapon.Strength} Strenth");
                }
                if (EquippedArmor != null)
                {
                    Console.WriteLine($" [ Armor ] {EquippedArmor.Name} - {EquippedArmor.Defense} Defense");
                }
            }
            else 
            {
                Console.WriteLine(" [ Nothing was equipped ] ");
            }
        
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("1-Equip Weapon");
            Console.WriteLine("2-UnEquip Weapon");
            Console.WriteLine("3-Equip Armors");
            Console.WriteLine("4-UnEquip Armors");
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.Write("Selct the menu : ");

            var KeyInput = Console.ReadLine();

            if (KeyInput == "1")
            {               
                EquipWeapon();
            }
            else if (KeyInput == "2")
            {
                UnEquipWeapon();
            }
            else if (KeyInput == "3")
            {
                EquipArmor();
            }
            else if (KeyInput == "4")
            {
                UnEquipArmor();
            }
        }

        public void EquipWeapon()
        {
            if (WeaponsBag.Any())
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.Write("Type the Weapon ID to equip : ");

                var KeyInput = GetUserInputNumber();
                
                if (KeyInput > WeaponsBag.Count() || KeyInput <= 0 )
                {
                    Console.WriteLine("Type corrent the Weapon ID !");
                }
                else
                {
                    this.EquippedWeapon = this.WeaponsBag[KeyInput - 1];
                    Console.WriteLine($"{WeaponsBag[KeyInput - 1].Name} is equipped ");
                }
          
                Console.WriteLine("----------------------------------------------------------------------------------------------");
        
            }
            else
            {
                Console.WriteLine("You don't have any weapon, buy a weapon first at the item shop");
                Console.ReadKey();
            }
        }

        public void UnEquipWeapon()
        {
            if (this.EquippedWeapon != null)
            {                             
                Console.WriteLine($"{this.EquippedWeapon.Name} is now unequipped ");
                this.EquippedWeapon = null;
            }
            else
            {
                Console.WriteLine("You don't have any weapon equiped");
                Console.ReadKey();
            }
        }

        public void EquipArmor()
        {
            if (ArmorsBag.Any())
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.WriteLine("Type the armor ID you want to equip : ");
                var KeyInput = GetUserInputNumber();

                if (KeyInput > ArmorsBag.Count() || KeyInput <=0 )
                {
                    Console.WriteLine("Type corrent the Armor ID !");
                }
                else
                {
                    this.EquippedArmor = this.ArmorsBag[KeyInput - 1];
                    Console.WriteLine($"{ArmorsBag[KeyInput - 1].Name} is equipped ");
                }
                
                Console.WriteLine("----------------------------------------------------------------------------------------------");
               
            }
            else
            {
                Console.WriteLine("You don't have any armor, buy a weapon first at the item shop");
                Console.ReadKey();
            }
        }

        public void UnEquipArmor()
        {
            if (this.EquippedArmor != null)
            {
                Console.WriteLine($"{this.EquippedArmor.Name} is now unequipped ");
                this.EquippedArmor = null;
            }
            else
            {
                Console.WriteLine("You don't have any armor equiped");
                Console.ReadKey();
            }
        }

        public int GetUserInputNumber()
        {
            //Checking validation the date pickup
            bool inputnumberValid = false;
            int keyInputResult = 0;
            
            while (inputnumberValid != true)
            {
               
                if (int.TryParse(Console.ReadLine(), out keyInputResult))
                {
                    inputnumberValid = true;
                }
                else
                {
                    Console.Write("Type the number only !:");
                   
                }
            }
            return keyInputResult;
        }

        public void DisplayPotion()
        {
            var potionQuery = (from potion in PotionsBag
                               group potion by potion.Name into newGroup
                               select new
                               {
                                   Name = newGroup.Key,
                                   Quantyty = newGroup.Count()
                               }).ToList();
            if (potionQuery.Count() != 0)
            {
                for (var i = 0; i < potionQuery.Count(); i++)
                {
                    Console.WriteLine($" {i + 1}. {potionQuery[i].Name} ({potionQuery[i].Quantyty})");
                }
            }
            else
            {
                Console.WriteLine($" [No potion yet]");
            }
            
        }

        public void UsingPotion()
        {
            var potionQuery = (from potion in PotionsBag
                               group potion by potion.Name into newGroup
                               select new
                               {
                                   Name = newGroup.Key,
                                   Quantity = newGroup.Count()
                               }).ToList();

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            if (potionQuery.Count() != 0)
            {
                    for (var i = 0; i < potionQuery.Count(); i++)
                    {
                    Console.WriteLine($" {i + 1}. {potionQuery[i].Name} ({potionQuery[i].Quantity})");
                    }

                Console.WriteLine("----------------------------------------------------------------------------------------------");
                Console.Write("Selet the potion to use: ");
                var KeyInput = GetUserInputNumber();

                //var pppotion = PotionsBag.ElementAtOrDefault(0);

                if (KeyInput > potionQuery.Count() || KeyInput <= 0)
                {
                    Console.WriteLine("Type corrent the potion ID !");

                }
                else
                {
                    var usingPotionQuery = (from potion in PotionsBag
                                            where potion.Name == potionQuery[KeyInput - 1].Name
                                            select potion).FirstOrDefault();


                    this.CurrentHP = this.CurrentHP + usingPotionQuery.HealthRestored;

                    if (this.CurrentHP > this.OriginalHP)
                    {
                        Console.WriteLine($"You don't need to drink potion at this point, You wasted ({this.CurrentHP - this.OriginalHP})! ");
                        this.CurrentHP = this.OriginalHP;                        
                    }

                    PotionsBag.Remove(usingPotionQuery);

                    Console.WriteLine($"Drink '{potionQuery[KeyInput - 1].Name}' successfully!");
                }
            }
            else
            {
                Console.WriteLine($" You don't have any potion");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
            }
        }
    }
}