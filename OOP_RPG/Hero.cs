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
    
        public InterfaceOfWeapon EquippedWeapon { get; set; }
        public InterfaceOfArmor EquippedArmor { get; set; }
        public InterfaceOfShield EquippedShield { get; set; }
        public List<InterfaceOfItemShop> HeroBag { get; private set; }
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

            HeroBag = new List<InterfaceOfItemShop>();
            PotionsBag = new List<Potion>();
            Strength = 30;
            Defense = 30;
            OriginalHP = 40;
            CurrentHP = 40;
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
            Console.WriteLine($"# Defense armor: {this.Defense} {(this.EquippedArmor == null ? "" : "(+" + this.EquippedArmor.Defense +")")}");
            Console.WriteLine($"# Defense shield:{(this.EquippedShield == null ? "0": "(+" + this.EquippedShield.Defense + ")")}");
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

            //Display Weapon Items 
            Console.WriteLine("# Weapon(s):");

            if(this.GetWeapons().Count() != 0)
            {
                var weaponNumber = 1;
                foreach (var weapon in GetWeapons())
                {
                    Console.WriteLine($"{weaponNumber}. {weapon.Name} : {weapon.Strength} Strength");
                    weaponNumber += 1;
                }
            }
            else
            {
                Console.WriteLine(" [ No Weapon in this bag ] ");
            }

            //Display Armor Items
            Console.WriteLine("----------------------------------------------------------------------------------------------");
            Console.WriteLine("# Armor:");
            if(GetArmors().Count() != 0 )
            {
                var armorNumber = 1;
                foreach (var armor in GetArmors())
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

            //Display Shield Items
            Console.WriteLine("# Shield:");
            if (GetShield().Count() != 0)
            {
                var shieldNumber = 1;
                foreach (var shield in GetShield())
                {
                    Console.WriteLine($"{shieldNumber}. {shield.Name} : {shield.Defense} Defense");
                    shieldNumber += 1;
                }
            }
            else
            {
                Console.WriteLine(" [ No Shield in this bag ] ");
            }

            Console.WriteLine("----------------------------------------------------------------------------------------------");

            //Current Equipped Items
            Console.WriteLine("# Current Equipped Item(s):");
            if(EquippedWeapon != null || EquippedArmor != null || EquippedShield != null)
            {
                if (EquippedWeapon != null)
                {
                    Console.WriteLine($" [ Weapon] {EquippedWeapon.Name} - {EquippedWeapon.Strength} Strenth");
                }
                if (EquippedArmor != null)
                {
                    Console.WriteLine($" [ Armor ] {EquippedArmor.Name} - {EquippedArmor.Defense} Defense");
                }
                if (EquippedShield != null)
                {
                    Console.WriteLine($" [ Shield ] {EquippedShield.Name} - {EquippedShield.Defense} Defense");
                }

            }
            else 
            {
                Console.WriteLine(" [ Nothing was equipped ] ");
            }        
           
        }

        public void EquipWeapon(int index)
        {
            if (GetWeapons().Count() != 0)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------"); 

                if (index > GetWeapons().Count() || index < 0 )
                {
                    Console.WriteLine("Type corrent the weapon Id !");
                }
                else
                {
                    var weapon = GetWeapons()[index];
                    this.EquippedWeapon = weapon;
                    Console.WriteLine($"'{GetWeapons()[index].Name}' is equipped ");
                }
          
                Console.WriteLine("----------------------------------------------------------------------------------------------");
        
            }
            else
            {
                Console.WriteLine("You don't have any weapon, or Type corrent weapon Id");
                Console.ReadKey();
            }
        }

        public void UnEquipWeapon()
        {
            if (this.EquippedWeapon != null)
            {                             
                Console.WriteLine($"'{this.EquippedWeapon.Name}' is now unequipped ");
                this.EquippedWeapon = null;
            }
            else
            {
                Console.WriteLine("You don't have any weapon equipped");
                Console.ReadKey();
            }
        }

        public void EquipArmor(int index)
        {
            if (GetArmors().Count() != 0)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");   
                
                if (index > GetArmors().Count() || index < 0 )
                {
                    Console.WriteLine("Type corrent the armor Id !");
                }
                else
                {
                    var armor = GetArmors()[index];
                    this.EquippedArmor = armor;
                    Console.WriteLine($"'{GetArmors()[index].Name}' is equipped ");
                   
                }
                
                Console.WriteLine("----------------------------------------------------------------------------------------------");
               
            }
            else
            {
                Console.WriteLine("You don't have any armor, or Type corrent armor Id");
                Console.ReadKey();
            }
        }

        public void UnEquipArmor()
        {
            if (this.EquippedArmor != null)
            {
                Console.WriteLine($"'{this.EquippedArmor.Name}' is now unequipped ");
                this.EquippedArmor = null;
            }
            else
            {
                Console.WriteLine("You don't have any armor equipped");
                Console.ReadKey();
            }
        }

        public void EquipShield(int index)
        {
            if (GetShield().Count() != 0)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------------");

                if (index > GetShield().Count() || index < 0)
                {
                    Console.WriteLine("Type corrent the shield Id !");
                }
                else
                {
                    var shield = GetShield()[index];
                    this.EquippedShield = shield;
                    Console.WriteLine($"'{GetShield()[index].Name}' is equipped ");

                }

                Console.WriteLine("----------------------------------------------------------------------------------------------");

            }
            else
            {
                Console.WriteLine("You don't have any shield, or Type corrent shield Id ");
                Console.ReadKey();
            }
        }

        public void UnEquipShield()
        {
            if (this.EquippedShield != null)
            {
                Console.WriteLine($"'{this.EquippedShield.Name}' is now unequipped ");
                this.EquippedShield = null;
            }
            else
            {
                Console.WriteLine("You don't have any shield equipped");
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


        public IReadOnlyList<InterfaceOfWeapon> GetWeapons()
        {
            return HeroBag.Where(p => p is InterfaceOfWeapon).Cast<InterfaceOfWeapon>().ToList();
        }

        public IReadOnlyList<InterfaceOfArmor> GetArmors()
        {
            return HeroBag.Where(p => p is InterfaceOfArmor).Cast<InterfaceOfArmor>().ToList();
        }

        public IReadOnlyList<InterfaceOfShield> GetShield()
        {
            return HeroBag.Where(p => p is InterfaceOfShield).Cast<InterfaceOfShield>().ToList();
        }
    }
}